using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Models
{
    public class SessionDetails
    {
        public int Id { get; set; }

        public string State { get; set; }

        public int SessionId { get; set; }
        public Session Session { set; get; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
