using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class TopicsOfInterest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserTopics> UserTopic { get; set; }

    }
}