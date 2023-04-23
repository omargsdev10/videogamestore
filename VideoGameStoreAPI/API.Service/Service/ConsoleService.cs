namespace API.Service.Service
{
    using API.Repository.Interfaces;
    using API.Service.Interfaces;
    using VGS.Shared.Response;

    public class ConsoleService : IConsoleService
    {
        private readonly IConsoleRepository _consoleRepository;
        public ConsoleService(IConsoleRepository consoleRepository)
        {
            _consoleRepository = consoleRepository;
        }
        /// <summary>
        /// Get all consoles
        /// </summary>
        /// <returns></returns>
        public async Task<ConsoleListResponse> GetAllConsoles()
        {
            return await _consoleRepository.GetAllConsoles();
        }
    }
}
