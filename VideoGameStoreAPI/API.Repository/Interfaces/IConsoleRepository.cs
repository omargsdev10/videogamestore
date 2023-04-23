namespace API.Repository.Interfaces
{
    using VGS.Shared.Response;

    public interface IConsoleRepository
    {
        /// <summary>
        /// Get all consoles
        /// </summary>
        /// <returns></returns>
        Task<ConsoleListResponse> GetAllConsoles();
    }
}
