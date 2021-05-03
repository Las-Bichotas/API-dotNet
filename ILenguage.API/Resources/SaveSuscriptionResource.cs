using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveSuscriptionResource
    {
        [Required (ErrorMessage = "Name is required")]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Name must have more than 3 digits")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "MonthDuration is required")]
        [Range(1,12,ErrorMessage = "The duration must be between 1-12")]
        public int MonthDuration { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "The price must have only 2 decimals")] //This is to be sure price has 2 digits max
        public float Price { get; set; }
    }
}