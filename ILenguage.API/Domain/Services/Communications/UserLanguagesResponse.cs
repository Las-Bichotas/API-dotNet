using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserLanguagesResponse : BaseResponse<UserLanguages>
    {
        public UserLanguagesResponse(UserLanguages resource) : base(resource)
        {
        }

        public UserLanguagesResponse(string message) : base(message)
        {
        }
    }
}