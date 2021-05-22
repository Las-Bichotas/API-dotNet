using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveTopicOfInterestResource
    {
        [Required]
        public string Name { get; set; }
    }
}