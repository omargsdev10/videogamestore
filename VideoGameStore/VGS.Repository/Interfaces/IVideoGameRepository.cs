namespace VGS.Repository.Interfaces
{
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    public interface IVideoGameRepository
    {
        /// <summary>
        /// Get all video games from database
        /// </summary>
        /// <returns></returns>
        Task<VideoGameListResponse> GetAll();

        /// <summary>
        /// Save or update a Videogame in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> PostVideoGame(VideoGameRequest request);

        /// <summary>
        /// Get videogame by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request);

        /// <summary>
        /// Disable video game in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request);
    }
}
