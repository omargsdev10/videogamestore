using VGS.Repository.Interfaces;
using VGS.Service.Interfaces;
using VGS.Shared.Response;

namespace VGS.Service.Services
{
    public class ConsoleService : IConsoleService
    {
        #region attributes
        public IConsoleRepository _consoleRepository;
        #endregion

        /// <summary>
        /// Constructor of service
        /// </summary>
        /// <param name="consoleRepository"></param>
        public ConsoleService(IConsoleRepository consoleRepository) => _consoleRepository = consoleRepository;

        /// <summary>
        /// Obtiene la lista de consolas
        /// </summary>
        /// <returns></returns>
        public async Task<ConsoleListResponse> GetAll()
        {
            return await _consoleRepository.GetAll();
        }
    }
}
