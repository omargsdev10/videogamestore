namespace VGS.Shared.Response
{
    using VGS.Shared.Entities;

    public class VideoGameResponse : BaseResponse
    {
        public VideoGameModel VideoGame { get; set; }
    }
}
