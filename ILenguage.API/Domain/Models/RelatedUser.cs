namespace ILenguage.API.Domain.Models
{
    public class RelatedUser
    {
        public int UserIdOne { get; set; }
        public User UserOne { get; set; }

        public int UserIdTwo { get; set; }
        public User UserTwo { get; set; }
    }
}