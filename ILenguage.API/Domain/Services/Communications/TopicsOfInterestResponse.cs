using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class TopicsOfInterestResponse : BaseResponse<TopicsOfInterest>
    {
        public TopicsOfInterestResponse(TopicsOfInterest resource) : base(resource)
        {
        }

        public TopicsOfInterestResponse(string message) : base(message)
        {
        }
    }
}