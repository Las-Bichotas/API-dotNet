using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IList<SessionDetails> SessionsDetails { get; set; } = new List<SessionDetails>();
    }
}
