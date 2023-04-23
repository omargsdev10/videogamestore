namespace VGS.Repository.Interfaces
{
    using VGS.Shared.Response;

    public interface IConsoleRepository
    {
        /// <summary>
        /// Obtiene la lista de consolas
        /// </summary>
        /// <returns></returns>
        Task<ConsoleListResponse> GetAll();
    }
}
