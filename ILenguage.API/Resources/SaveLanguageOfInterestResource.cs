using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveLanguageOfInterestResource
    {
        [Required]
        public string Name { get; set; }
    }
}