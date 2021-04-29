using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveSuscriptionResource
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [Range(1,12,ErrorMessage = "The duration must be between 1-12")]
        public int MonthDuration { get; set; }
        
        [Required]
        public float Price { get; set; }
    }
}