namespace ILenguage.API.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string startedAt { get; set; }
        public string finishedAt { get; set; }
        public bool state { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
