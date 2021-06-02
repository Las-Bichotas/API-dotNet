using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace ILenguage.API.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Day { get; set;}
        public string NameDay;
        public List<UserSchedule> UserSchedules { get; set; }
    }
}
