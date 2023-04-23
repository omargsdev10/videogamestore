﻿namespace API.Repository.Interfaces
{
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    public interface IVideoGameRepository
    {
        /// <summary>
        /// Get all active video games
        /// </summary>
        /// <returns></returns>
        Task<VideoGameListResponse> GetAllVideoGames();

        /// <summary>
        /// Get video game by Id
        /// </summary>
        /// <returns></returns>
        Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request);

        /// <summary>
        /// Insert a new video game in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> PostVideoGame(VideoGameRequest request);

        /// <summary>
        /// Save edit of video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> EditVideoGame(VideoGameRequest request);

        /// <summary>
        /// Disabled video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request);
    }
}
