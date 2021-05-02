using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Domain.Models
{
    public class Suscription
    {
        public int Id { get; set; }
        public float Price { get; set; }
        //Data Anotations
        [Range(1,12,ErrorMessage = "The duration must be between 1-12")]
        public int MonthDuration { get; set; }
        public string Name { get; set; }
        
        //TODO: 
         public List<UserSuscription> UserSuscriptions { get; set; }
    }
}