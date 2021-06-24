using System;

namespace ILenguage.API.Resources
{
    public class CommentResource
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int TutorId { get; set; }
        public DateTime date { get; set; }
    }
}