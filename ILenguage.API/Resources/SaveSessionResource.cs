using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SaveSessionResource
    {
        [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        [MaxLength(200)]
        public string Link { get; set; }
    }
}
