namespace VGS.Service.Services
{
    using VGS.Repository.Interfaces;
    using VGS.Service.Interfaces;
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    public class VideoGameService : IVideoGameService
    {
        #region attributes
        public IVideoGameRepository _videoGameRepository;
        #endregion

        /// <summary>
        /// Constructor of service
        /// </summary>
        /// <param name="videoGameRepository"></param>
        public VideoGameService(IVideoGameRepository videoGameRepository) => _videoGameRepository = videoGameRepository;

        #region methods
        /// <summary>
        /// Get all videogames active in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameListResponse> GetAll() => await _videoGameRepository.GetAll();

        /// <summary>
        /// Save or update a Videogame in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> PostVideoGame(VideoGameRequest request) => await _videoGameRepository.PostVideoGame(request);

        /// <summary>
        /// Get videogame by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request) => await _videoGameRepository.GetVideoGameById(request);

        /// <summary>
        /// Disable video game in database
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request) => await _videoGameRepository.DisabledVideoGame(request);

        #endregion
    }
}