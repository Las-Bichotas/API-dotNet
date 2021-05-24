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
        public string StartAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string EndAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link { get; set; }
    }
}
