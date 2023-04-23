namespace VGS.Shared.Response
{
    using VGS.Shared.Entities;

    public class VideoGameListResponse : BaseResponse
    {
        public List<VideoGameModel> VideoGameList { get; set; }
    }
}
