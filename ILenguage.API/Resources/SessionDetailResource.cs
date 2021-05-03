using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SessionDetailResource
    {
        public int Id { get; set; }

        public string State { get; set; }

        public SessionResource Session { get; set; }

        public UserResource User { get; set; }
    }
}
