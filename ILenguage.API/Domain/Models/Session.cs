using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Link { get; set; }
        

        public string State { get; set; }
        public string Topic { get; set; }
        public string Information { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        /* To Delete */
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }


        public SessionDetail SessionDetail { get;set; }

        /* ! To Delete*/
    }
}
