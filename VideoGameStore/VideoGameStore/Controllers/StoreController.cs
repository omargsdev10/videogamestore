namespace VideoGameStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Drawing;
    using System.Drawing.Imaging;
    using VGS.Service.Interfaces;
    using VGS.Shared.Entities;
    using VGS.Shared.Request;
    using VGS.Shared.Response;
    using VideoGameStore.ViewModels;

    public class StoreController : Controller
    {
        private IVideoGameService _videoGameService;
        private IConsoleService _consoleService;
        private IGenderService _genderService;
        public StoreController(
            IVideoGameService videoGameService,
            IConsoleService consoleService,
            IGenderService genderService)
        {
            _videoGameService = videoGameService;
            _consoleService = consoleService;
            _genderService = genderService;
        }
        public IActionResult Index(bool isTableView = false)
        {
            var model = new VideoGameViewModel
            {
                ConsoleList = _getConsoleList(),
                GenderList = _getGenderList(),
                IsTableView = isTableView
            };
            VideoGameListResponse videoGameList = _videoGameService.GetAll().Result;
            ViewBag.VideoGameList = videoGameList;
            return View(model);
        }

        /// <summary>
        /// Insert or update videogame in database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _PostVideoGame(VideoGameViewModel viewModel)
        {
            string base64 = string.Empty;
            if (!ModelState.IsValid)
            {
                ViewBag.VideoGameList = _videoGameService.GetAll().Result;
                viewModel.ConsoleList = _getConsoleList();
                viewModel.GenderList = _getGenderList();
                viewModel.OpenModal = true;
                return View("Index", viewModel);
            }

            if (viewModel.ImageFile != null)
            {
                base64 = GenerateThumbNail(viewModel.ImageFile);
            }
            else
            {
                base64 = viewModel.Base64ImageFile;
            }
            var request = new VideoGameRequest {
                VideoGame = new VideoGameModel {
                    Id = viewModel.Id ?? 0,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Anho = viewModel.Anho,
                    Gender = new GenderModel {
                        Id = viewModel.GenderId,
                    },
                    Console = new ConsoleModel
                    {
                        Id = viewModel.ConsoleId,
                    },
                    Ranking = viewModel.Ranking,
                    Base64Image = base64
                }
            };
            _ = _videoGameService.PostVideoGame(request).Result;

            return RedirectToAction("Index", new { isTableView = viewModel.IsTableView });
        }

        /// <summary>
        /// Get video game data from database to form edit
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult EditVideoGame(int Id) {
            var _videoGame = _videoGameService.GetVideoGameById(new VideoGameByIdRequest { Id = Id }).Result;
            var model = new VideoGameViewModel();
            model.Id = _videoGame.VideoGame.Id;
            model.Title = _videoGame.VideoGame.Title;
            model.Description = _videoGame.VideoGame.Description;
            model.Anho = _videoGame.VideoGame.Anho;
            model.Ranking = _videoGame.VideoGame.Ranking;
            model.ConsoleId = _videoGame.VideoGame.Console.Id;
            model.GenderId = _videoGame.VideoGame.Gender.Id;
            model.ConsoleList = _getConsoleList();
            model.GenderList = _getGenderList();
            model.Base64ImageFile = _videoGame.VideoGame.Base64Image;
            model.OpenModal = true;
            return Json(model);
        }

        /// <summary>
        /// Disable video game in database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DisableVideoGame(int Id, bool IsTableView)
        {
            _ = _videoGameService.DisabledVideoGame(new VideoGameByIdRequest { Id = Id }).Result;
            return RedirectToAction("Index", new { isTableView = IsTableView });
        }

        /// <summary>
        /// Generate thumbNail from image
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        private String GenerateThumbNail(IFormFile imageFile)
        {
            String base64 = string.Empty;
            try
            {
                using var fileStream = imageFile.OpenReadStream();
                byte[] bytes = new byte[imageFile.Length];
                fileStream.Read(bytes, 0, (int)imageFile.Length);
                System.Drawing.Image image = Image.FromStream(fileStream);
                System.Drawing.Image thumb = image.GetThumbnailImage(250, 250, () => false, IntPtr.Zero);

                using (MemoryStream m = new MemoryStream())
                {
                    thumb.Save(m, ImageFormat.Png);
                    byte[] imageBytes = m.ToArray();

                    base64 = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                }
            }
            catch
            {
            }
            return base64;
        }

        /// <summary>
        /// Get Console list
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> _getConsoleList()
        {
            return _consoleService.GetAll().Result.ConsoleList
                        .Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        /// <summary>
        /// Get Gender list
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> _getGenderList()
        {
            return _genderService.GetAll().Result.GenderList
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    }
                );
        }

        /// <summary>
        /// Get list of years
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetDropDownListForYears()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            for (int i = 1950; i <= DateTime.Now.Year; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls.OrderByDescending(x => x.Value).ToList();
        }

        /// <summary>
        /// Get list for ranking
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetDropDownListRanking()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            for (int i = 1; i <= 10; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }
    }
}
