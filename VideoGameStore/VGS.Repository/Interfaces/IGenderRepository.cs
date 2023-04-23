namespace VGS.Repository.Interfaces
{
    using VGS.Shared.Response;

    public interface IGenderRepository
    {
        /// <summary>
        /// Get videogames gender list
        /// </summary>
        /// <returns></returns>
        Task<GenderListResponse> GetAll();
    }
}
