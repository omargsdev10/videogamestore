namespace VGS.Repository.Repository
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VGS.Repository.Interfaces;
    using VGS.Shared.Entities;
    using VGS.Shared.Enum;
    using VGS.Shared.Response;

    public class GenderRepository : IGenderRepository
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Get videogames gender list
        /// </summary>
        /// <returns></returns>
        public async Task<GenderListResponse> GetAll()
        {
            var response = new GenderListResponse
            {
                GenderList = new List<GenderModel>(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success }
            };
            try
            {
                HttpResponseMessage responseMessage =
                    await client.GetAsync("https://localhost:7142/Gender");
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<GenderListResponse>(responseBody);

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
