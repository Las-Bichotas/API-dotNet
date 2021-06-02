using System.ComponentModel.DataAnnotations;
using System;
namespace ILenguage.API.Resources
{
    public class SaveScheduleResource
    {

      [Required]
       public DateTime Day { get; set; }
    }
}
