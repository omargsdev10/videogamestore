namespace VGS.Service.Services
{
    using VGS.Repository.Interfaces;
    using VGS.Service.Interfaces;
    using VGS.Shared.Response;

    public class GenderService : IGenderService
    {
        #region attributes
        public IGenderRepository _genderRepository;
        #endregion

        /// <summary>
        /// Constructor of service
        /// </summary>
        /// <param name="consoleRepository"></param>
        public GenderService(IGenderRepository genderRepository) => _genderRepository = genderRepository;

        /// <summary>
        /// Get gender list
        /// </summary>
        /// <returns></returns>
        public async Task<GenderListResponse> GetAll()
        {
            return await _genderRepository.GetAll();
        }
    }
}
