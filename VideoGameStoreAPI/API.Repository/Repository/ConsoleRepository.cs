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

    public class ConsoleRepository : IConsoleRepository
    {
        private readonly IConfiguration _configuration;
        public ConsoleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get all consoles
        /// </summary>
        /// <returns></returns>
        public async Task<ConsoleListResponse> GetAllConsoles()
        {
            var response = new ConsoleListResponse
            {
                ConsoleList = new List<VGS.Shared.Entities.ConsoleModel>(),
                OperationResult = new VGS.Shared.Shared.OperationResult { Result = VGS.Shared.Enum.OperationResultEnum.Success }
            };
            try 
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_GetAllConsole";
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        response.ConsoleList.Add(
                            new VGS.Shared.Entities.ConsoleModel { 
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
