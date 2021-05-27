using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class LanguageOfInterestResponse : BaseResponse<LanguageOfInterest>
    {
        public LanguageOfInterestResponse(LanguageOfInterest resource) : base(resource)
        {
        }

        public LanguageOfInterestResponse(string message) : base(message)
        {
        }
    }
}