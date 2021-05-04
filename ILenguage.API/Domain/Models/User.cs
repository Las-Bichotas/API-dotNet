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
        //public int roleId { get; set; }
        //public Role role { get; set; }

        //TODO: PayMethos falta implementar
        // public List<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

        //TODO: Add session class
        //public List<Session> relatedSessions { get; set; } = new List<Session>();

        public List<RelatedUser> RelatedUsers { get; set; }
        public List<EInterestBank> RelatedInterest { get; set; } = new List<EInterestBank>();
        public List<ELenguageBank> RelatedLenguageInterest { get; set; } = new List<ELenguageBank>();

        public int SuscriptionId { get; set; }
        public Suscription Suscription { get; set; }

        public List<Schedule> Schedules { get; set; }

    }
}