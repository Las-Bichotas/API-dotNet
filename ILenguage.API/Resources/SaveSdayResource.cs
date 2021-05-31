using System.ComponentModel.DataAnnotations;
using System;
namespace ILenguage.API.Resources
{
    public class SaveSdayResource
    {
        [Required]
        public DateTime InicialDay { get; set; }

        

    }
}
