namespace VGS.Shared.Response
{
    using VGS.Shared.Entities;

    public class ConsoleListResponse : BaseResponse
    {
        public List<ConsoleModel> ConsoleList { get; set; }
    }
}
