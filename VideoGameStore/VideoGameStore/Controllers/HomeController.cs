using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameStore.Models;
using VGS.Service;
using VGS.Service.Interfaces;

namespace VideoGameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVideoGameService _videoGameService;

        public HomeController(
            ILogger<HomeController> logger,
            IVideoGameService videoGameService
            )
        {
            _logger = logger;
            _videoGameService = videoGameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}