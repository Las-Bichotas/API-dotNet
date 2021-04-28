using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        //TODO: falta como representar la foto de perfil
        // public byte profilePhoto {get; set;}
        //TODO: Esperando a modelo Role
        public int roleId { get; set; }
        public Role role { get; set; }
        //TODO: PayMethos falta implementar
        public List<PayMethod> PayMethods { get; set; } = new List<PayMethod>();
        public List<Session> relatedSessions { get; set; } = new List<Session>();
        public List<RelatedUser> relatedUsers { get; set; }
        public List<EInterestBank> relatedInterest { get; set; } = new List<EInterestBank>();
        public List<ELenguageBank> relatedLenguageInterest { get; set; } = new List<ELenguageBank>();

    }
}