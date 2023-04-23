namespace VGS.Shared.Response
{
    using VGS.Shared.Entities;

    public class GenderListResponse : BaseResponse
    {
        public List<GenderModel> GenderList { get; set; }
    }
}
