using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SaveSessionDetailResource
    {
        [Required]
        [MaxLength(30)]
        public string State { get; set; }
    }
}
