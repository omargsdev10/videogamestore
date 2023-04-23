namespace VideoGameStoreAPI.Controllers
{
    using API.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using VGS.Shared.Response;

    [ApiController]
    [Route("[controller]")]
    public class ConsoleController : ControllerBase
    {
        private IConsoleService _consoleService;
        public ConsoleController(IConsoleService consoleService) 
        {
            _consoleService = consoleService;   
        }

        /// <summary>
        /// Get consoles list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ConsoleListResponse GetConsoleList()
        {
            return _consoleService.GetAllConsoles().Result;
        }
    }
}
