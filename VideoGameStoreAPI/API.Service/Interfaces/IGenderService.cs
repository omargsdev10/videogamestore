namespace API.Service.Interfaces
{
    using System.Threading.Tasks;
    using VGS.Shared.Response;

    public interface IGenderService
    {
        /// <summary>
        /// Get all genders
        /// </summary>
        /// <returns></returns>
        Task<GenderListResponse> GetAllGenders();
    }
}
