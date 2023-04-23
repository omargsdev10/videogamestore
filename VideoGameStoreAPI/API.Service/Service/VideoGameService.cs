namespace API.Service.Service
{
    using API.Repository.Interfaces;
    using API.Service.Interfaces;
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;
        public VideoGameService(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        /// <summary>
        /// Get all active video games
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameListResponse> GetAllVideoGames()
        {
            return await _videoGameRepository.GetAllVideoGames();
        }

        /// <summary>
        /// Get video game by Id
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request)
        {
            return await _videoGameRepository.GetVideoGameById(request);
        }

        /// <summary>
        /// Insert or edit a video game in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> PostVideoGame(VideoGameRequest request)
        {
            if (request.VideoGame.Id > 0)
            {
                return await _videoGameRepository.EditVideoGame(request);
            }
            else 
            {
                return await _videoGameRepository.PostVideoGame(request);
            }
        }

        /// <summary>
        /// Disabled video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request)
        {
            return await _videoGameRepository.DisabledVideoGame(request);
        }
    }
}
