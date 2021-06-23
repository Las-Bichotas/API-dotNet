using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        //TODO: falta como representar la foto de perfil
        // public byte profilePhoto {get; set;}

        //TODO: Esperando a modelo Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        //TODO: PayMethos falta implementar
        // public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

        //TODO: Add session class
        //public List<Session> relatedSessions { get; set; } = new List<Session>();

        public List<RelatedUser> RelatedUsers { get; set; }
        public List<UserTopics> UserTopic { get; set; }
        public List<UserLanguages> UserLanguage { get; set; }

        //public int SuscriptionId { get; set; }
        //public Suscription Suscription { get; set; }

        public List<UserSchedule> UserSchedules { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }

        // Relationship with session 06/22/2021
        public int SessionId { get; set; }
        public Session Session { get; set; }

    }
}