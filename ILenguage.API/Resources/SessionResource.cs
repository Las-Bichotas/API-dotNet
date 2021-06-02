using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SessionResource
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Link { get; set; }
        public string State { get; set; }
        public string Topic { get; set; }
        public string Information { get; set; }

        public ScheduleResource Schedule { get; set; }

    }
}
