using System;

namespace ILenguage.API.Domain.Models
{
    public class UserSchedule
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

    }
}