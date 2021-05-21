using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int MonthDuration { get; set; }
        public string Name { get; set; }
        
       
    }
}