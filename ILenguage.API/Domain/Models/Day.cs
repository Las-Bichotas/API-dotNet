using System;
using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class Day
    {
        public int Id { get; set; }
        
        public DateTime Days {get;set;} 
    
        public IList<Session> Sessions { get; set; } 
      
    }
}
