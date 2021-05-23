using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveScheduleResource
    {



        [Required (ErrorMessage = "Name is required")]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Name must have more than 3 digits")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "HourDuration is required")]
        [Range(1,2,ErrorMessage = "The duration must be between 1-2")]
        public int HourDuration { get; set; }
        
        [Required (ErrorMessage = "Day is required")]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Day must have more than 3 digits")]
        [DataType(DataType.Text)]
        public string Day { get; set; }




    }
}
