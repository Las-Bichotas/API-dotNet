using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class Suscription
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        
        //TODO: 
        //! public List<UserSuscription> UserSuscriptions { get; set; }
    }
}