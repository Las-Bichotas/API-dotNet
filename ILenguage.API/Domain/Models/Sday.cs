using System;
using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class Sday
    {
        public int Id { get; set; }
        public int CurrentScheduleId {get; set;}
        public Schedule CurrentSchedule { get;set;}
        public DateTime InicialDay {get;set;}

    
  /*       public IList<Session> Sessions { get; set; }  */
      
    }
}
 