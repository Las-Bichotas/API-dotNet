using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveCommentResource
    {

        [Required]
        public string Content { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}