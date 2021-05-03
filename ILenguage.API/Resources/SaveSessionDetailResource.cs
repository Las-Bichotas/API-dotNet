using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SaveSessionDetailResource
    {
        public string State { get; set; }

        public int UserId { get; set; }

        public int SessionId { get; set; }
    }
}
