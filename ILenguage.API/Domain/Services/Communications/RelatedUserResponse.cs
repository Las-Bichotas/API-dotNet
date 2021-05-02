using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class RelatedUserResponse : BaseResponse<RelatedUser>
    {
        public RelatedUserResponse(RelatedUser resource) : base(resource)
        {
        }

        public RelatedUserResponse(string message) : base(message)
        {
        }
    }
}