namespace ILenguage.API.Domain.Models
{
    public class UserTopics
    {
        public int TopicId;
        public TopicsOfInterest Topic;
        public int UserId;
        public User User;
    }
}