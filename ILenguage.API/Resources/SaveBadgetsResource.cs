using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveBadgetsResource
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImgSrc { get; set; }
    }
}