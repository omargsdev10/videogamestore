namespace VGS.Repository.Repository
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using VGS.Repository.Interfaces;
    using VGS.Shared.Entities;
    using VGS.Shared.Enum;
    using VGS.Shared.Request;
    using VGS.Shared.Response;

    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Obtiene la lista de videojuegos disponibles
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameListResponse> GetAll()
        {
            var response = new VideoGameListResponse
            {
                VideoGameList = new List<VideoGameModel>(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success } 
            };
            try {
                
                HttpResponseMessage responseMessage =
                    await client.GetAsync("https://localhost:7142/VideoGameStore/GetAllVideoGames");
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<VideoGameListResponse>(responseBody);

            }
            catch (Exception ex)
            {
                response.OperationResult.Result = OperationResultEnum.Fail;
                response.OperationResult.Message = ex.Message;
            }            
            return response;
        }

        /// <summary>
        /// Get videogame by Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = new VideoGameModel(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success }
            };

            try
            {
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var responseMessage = await client.PostAsync("https://localhost:7142/VideoGameStore/GetVideoGameById", data);
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<VideoGameResponse>(responseBody);
            }
            catch (Exception ex)
            {
                response.OperationResult.Result = OperationResultEnum.Fail;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Save or update a Videogame in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> PostVideoGame(VideoGameRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = new VideoGameModel(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success }
            };

            try
            {
                var responseMessage = await new HttpClient().PostAsync("https://localhost:7142/VideoGameStore/PostVideoGame", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<VideoGameResponse>(responseBody);
            }
            catch (Exception ex)
            {
                response.OperationResult.Result = OperationResultEnum.Fail;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Disable video game in database
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = new VideoGameModel(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success }
            };

            try
            {
                var responseMessage = await new HttpClient().PostAsync("https://localhost:7142/VideoGameStore/DisabledVideoGame", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<VideoGameResponse>(responseBody);
            }
            catch (Exception ex)
            {
                response.OperationResult.Result = OperationResultEnum.Fail;
                response.OperationResult.Message = ex.Message;
            }
            return response;
        }
    }
}
