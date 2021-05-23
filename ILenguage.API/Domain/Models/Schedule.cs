using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int HourDuration { get; set; }
        public string Name { get; set; }
        
        public List<UserSchedule> UserSchedules { get; set; }
    }
}
