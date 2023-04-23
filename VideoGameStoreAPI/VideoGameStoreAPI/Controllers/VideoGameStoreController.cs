namespace VideoGameStoreAPI.Controllers
{
    using API.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    [ApiController]
    [Route("[controller]")]
    public class VideoGameStoreController : ControllerBase
    {
        private IVideoGameService _videoGameService;
        public VideoGameStoreController(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        /// <summary>
        /// Get all active video games 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVideoGames")]
        public VideoGameListResponse GetAllVideoGames()
        {
            return _videoGameService.GetAllVideoGames().Result;
        }

        /// <summary>
        /// Get video game by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetVideoGameById")]
        public VideoGameResponse GetVideoGameById([FromBody]VideoGameByIdRequest request)
        {
            return _videoGameService.GetVideoGameById(request).Result;
        }

        /// <summary>
        /// Create or edit video game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("PostVideoGame")]
        public VideoGameResponse PostVideoGame(VideoGameRequest request)
        {
            return _videoGameService.PostVideoGame(request).Result;
        }

        /// <summary>
        /// Disabled video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DisabledVideoGame")]
        public VideoGameResponse DisabledVideoGame(VideoGameByIdRequest request)
        {
            return _videoGameService.DisabledVideoGame(request).Result;
        }
    }
}
