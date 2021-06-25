using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class CommentResponse : BaseResponse<Comment>
    {
        public CommentResponse(Comment resource) : base(resource)
        {
        }

        public CommentResponse(string message) : base(message)
        {
        }
    }
}