namespace VGS.Shared.Request
{
    using VGS.Shared.Entities;

    public class VideoGameRequest : BaseRequest
    {
        public VideoGameModel VideoGame { get; set; }
    }
}
