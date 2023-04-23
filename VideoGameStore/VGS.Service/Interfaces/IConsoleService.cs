namespace VGS.Service.Interfaces
{
    using VGS.Shared.Response;

    public interface IConsoleService
    {
        /// <summary>
        /// Obtiene la lista de consolas
        /// </summary>
        /// <returns></returns>
        Task<ConsoleListResponse> GetAll();
    }
}
