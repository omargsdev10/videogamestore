namespace API.Repository.Repository
{
    using API.Repository.Interfaces;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using VGS.Shared.Enum;
    using VGS.Shared.Response;

    public class GenderRepository : IGenderRepository
    {
        private readonly IConfiguration _configuration;
        public GenderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get all genders
        /// </summary>
        /// <returns></returns>
        public async Task<GenderListResponse> GetAllGenders()
        {
            var response = new GenderListResponse
            {
                GenderList = new List<VGS.Shared.Entities.GenderModel>(),
                OperationResult = new VGS.Shared.Shared.OperationResult { Result = VGS.Shared.Enum.OperationResultEnum.Success }
            };
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_GetAllGender";
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        response.GenderList.Add(
                            new VGS.Shared.Entities.GenderModel
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                            });
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.OperationResult = new VGS.Shared.Shared.OperationResult
                {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                };
            }
            return response;
        }
    }
}
