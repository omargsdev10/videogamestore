namespace API.Service.Interfaces
{
    using VGS.Shared.Response;

    public interface IConsoleService
    {
        /// <summary>
        /// Get all consoles
        /// </summary>
        /// <returns></returns>
        Task<ConsoleListResponse> GetAllConsoles();
    }
}
