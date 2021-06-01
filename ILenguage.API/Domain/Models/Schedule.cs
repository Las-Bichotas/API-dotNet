using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        
    
        public ICollection<Sday> Sdays {get; set;}
        public List<UserSchedule> UserSchedules { get; set; }
    }
}
