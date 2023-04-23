namespace API.Repository.Repository
{
    using API.Repository.Interfaces;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System.Data;
    using VGS.Shared.Entities;
    using VGS.Shared.Enum;
    using VGS.Shared.Request;
    using VGS.Shared.Response;
    using VGS.Shared.Shared;

    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly IConfiguration _configuration;
        public VideoGameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Get all active video games
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameListResponse> GetAllVideoGames() {
            var response = new VideoGameListResponse {
                VideoGameList = new List<VideoGameModel>(),
                OperationResult = new OperationResult { Result = OperationResultEnum.Success }
            };
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_GetAllVideoGames";
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        response.VideoGameList.Add(
                            new VideoGameModel { 
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Description = reader.GetString("Description"),
                                Anho = reader.GetInt16("Anho"),
                                Console = new ConsoleModel { 
                                    Id = reader.GetInt32("IdConsole"),
                                    Name = reader.GetString("Console"),
                                },
                                Gender = new GenderModel
                                {
                                    Id = reader.GetInt32("IdGender"),
                                    Name = reader.GetString("Gender"),
                                },
                                Ranking = reader.GetByte("Ranking"),
                                Base64Image = reader.GetString("ImageFile")
                            }
                        );
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.OperationResult = new VGS.Shared.Shared.OperationResult {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                };
            }
            return response;
        }

        /// <summary>
        /// Get video game by Id
        /// </summary>
        /// <returns></returns>
        public async Task<VideoGameResponse> GetVideoGameById(VideoGameByIdRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = new VideoGameModel(),
                OperationResult = new OperationResult { Result = OperationResultEnum.Success }
            };
            try {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_GetVideoGameById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = request.Id, SqlDbType = SqlDbType.Int });
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.Read())
                    {
                        response.VideoGame = new VideoGameModel
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Description = reader.GetString("Description"),
                                Anho = reader.GetInt16("Anho"),
                                Console = new ConsoleModel
                                {
                                    Id = reader.GetInt32("IdConsole"),
                                    Name = reader.GetString("Console"),
                                },
                                Gender = new GenderModel
                                {
                                    Id = reader.GetInt32("IdGender"),
                                    Name = reader.GetString("Gender"),
                                },
                                Ranking = reader.GetByte("Ranking"),
                                Base64Image = reader.GetString("ImageFile")
                            };
                    }
                    conn.Close();
                }
            }
            catch (Exception ex) {
                response.OperationResult = new VGS.Shared.Shared.OperationResult
                {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                };
            }
            return response;
        }
        /// <summary>
        /// Insert a new video game in database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> PostVideoGame(VideoGameRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = request.VideoGame,
                OperationResult = new OperationResult {
                    Result = OperationResultEnum.Success
                }
            };
            try {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_InsertVideoGame";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Title", Value = request.VideoGame.Title, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Description", Value = request.VideoGame.Description, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Anho", Value = request.VideoGame.Anho, SqlDbType = SqlDbType.SmallInt });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Ranking", Value = request.VideoGame.Ranking, SqlDbType = SqlDbType.SmallInt });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdConsole", Value = request.VideoGame.Console.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdGender", Value = request.VideoGame.Gender.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@ImageFile", Value = request.VideoGame.Base64Image, SqlDbType = SqlDbType.VarChar });
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.Read()) {
                        response.VideoGame.Id = Convert.ToInt32(reader[0].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.OperationResult = new OperationResult
                {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                }; 
            }
            return response;
        }

        /// <summary>
        /// Save edit of video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> EditVideoGame(VideoGameRequest request)
        {
            var response = new VideoGameResponse { 
                VideoGame = request.VideoGame,
                OperationResult = new OperationResult
                {
                    Result = OperationResultEnum.Success
                }
            };
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_UpdateVideoGame";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = request.VideoGame.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Title", Value = request.VideoGame.Title, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Description", Value = request.VideoGame.Description, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Anho", Value = request.VideoGame.Anho, SqlDbType = SqlDbType.SmallInt });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Ranking", Value = request.VideoGame.Ranking, SqlDbType = SqlDbType.SmallInt });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdConsole", Value = request.VideoGame.Console.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdGender", Value = request.VideoGame.Gender.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@ImageFile", Value = request.VideoGame.Base64Image, SqlDbType = SqlDbType.VarChar });
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.OperationResult = new OperationResult
                {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                };
            }
            return response;
        }

        /// <summary>
        /// Disabled video game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<VideoGameResponse> DisabledVideoGame(VideoGameByIdRequest request)
        {
            var response = new VideoGameResponse
            {
                VideoGame = new VideoGameModel { Id = request.Id },
                OperationResult = new OperationResult
                {
                    Result = OperationResultEnum.Success
                }
            };
            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("storeConnectionString")))
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SP_DisableVideoGame";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = request.Id, SqlDbType = SqlDbType.Int });
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                response.OperationResult = new OperationResult
                {
                    Result = OperationResultEnum.Fail,
                    Message = ex.ToString()
                };
            }
            return response;
        }
    }
}
