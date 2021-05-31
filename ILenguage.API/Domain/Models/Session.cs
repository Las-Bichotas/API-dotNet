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

       /*  public int DayId { get; set; }
        public Day Day { get; set;} */

        /*
        public int UserId { get; set; }
        public User User { get; set; }
        */

        public IList<SessionDetail> SessionsDetails { get; set; } = new List<SessionDetail>();
        public SessionDetail SessionDetail { get;set; }
    }
}
