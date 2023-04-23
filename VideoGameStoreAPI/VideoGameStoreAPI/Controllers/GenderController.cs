namespace VideoGameStoreAPI.Controllers
{
    using API.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using VGS.Shared.Response;

    [ApiController]
    [Route("[controller]")]
    public class GenderController : ControllerBase
    {
        private IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        /// <summary>
        /// Get genders list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public GenderListResponse GetGenderList()
        {
            return _genderService.GetAllGenders().Result;
        }
    }
}
