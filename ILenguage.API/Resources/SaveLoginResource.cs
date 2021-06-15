using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveLoginResource
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}