namespace VGS.Service.Interfaces
{
    using VGS.Shared.Response;

    public interface IGenderService
    {
        /// <summary>
        /// Get gender list
        /// </summary>
        /// <returns></returns>
        Task<GenderListResponse> GetAll();
    }
}
