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
        [MaxLength(100)]
        public DateTime StartAt { get; set; }

        [Required]
        [MaxLength(100)]
        public DateTime EndAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link { get; set; }
    }
}
