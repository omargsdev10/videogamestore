namespace API.Service.Service
{
    using API.Repository.Interfaces;
    using API.Service.Interfaces;
    using System.Threading.Tasks;
    using VGS.Shared.Response;

    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        /// <summary>
        /// Get all genders
        /// </summary>
        /// <returns></returns>
        public async Task<GenderListResponse> GetAllGenders()
        {
            return await _genderRepository.GetAllGenders();
        }
    }
}
