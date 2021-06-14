using System.ComponentModel.DataAnnotations;
using System;
namespace ILenguage.API.Resources
{
    public class SaveScheduleResource
    {


      [Required]
      [MaxLength(30)]
      public string NameEventSchedule { get; set; }
      /*[Required]
      
      /*
      public DateTime Day { get; set; }
      [Required]
      
      public DateTime StartHour { get; set; }
      [Required]
    
      public DateTime EndHour { get; set; }#1#*/
    }
}
