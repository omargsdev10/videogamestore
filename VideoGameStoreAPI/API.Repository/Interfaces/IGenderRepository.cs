namespace API.Repository.Interfaces
{
    using VGS.Shared.Response;

    public interface IGenderRepository
    {
        /// <summary>
        /// Get all genders
        /// </summary>
        /// <returns></returns>
        Task<GenderListResponse> GetAllGenders();
    }
}
