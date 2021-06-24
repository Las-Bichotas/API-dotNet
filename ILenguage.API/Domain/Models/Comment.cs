using System;

namespace ILenguage.API.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int TutorId { get; set; }
        public User tutor { get; set; }
        public DateTime date { get; set; }
    }
}