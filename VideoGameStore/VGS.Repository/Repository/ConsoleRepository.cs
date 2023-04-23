namespace VGS.Repository.Repository
{
    using Newtonsoft.Json;
    using VGS.Repository.Interfaces;
    using VGS.Shared.Entities;
    using VGS.Shared.Enum;
    using VGS.Shared.Response;

    public class ConsoleRepository : IConsoleRepository
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Get consoles list
        /// </summary>
        /// <returns></returns>
        public async Task<ConsoleListResponse> GetAll()
        {
            var response = new ConsoleListResponse
            {
                ConsoleList = new List<ConsoleModel>(),
                OperationResult = new Shared.Shared.OperationResult { Result = OperationResultEnum.Success }
            };
            try
            {
                HttpResponseMessage responseMessage =
                    await client.GetAsync("https://localhost:7142/Console");
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ConsoleListResponse>(responseBody);

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
