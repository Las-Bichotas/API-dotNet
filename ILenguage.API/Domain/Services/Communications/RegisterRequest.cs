using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Domain.Services.Communications
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string UserName { get; set; }
     
        [Required]
        public string Password { get; set; }
    }
}
