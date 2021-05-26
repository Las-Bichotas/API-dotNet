using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserTopicsResponse : BaseResponse<UserTopics>
    {
        public UserTopicsResponse(UserTopics resource) : base(resource)
        {
        }

        public UserTopicsResponse(string message) : base(message)
        {
        }
    }
}