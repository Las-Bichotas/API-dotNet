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

        public int roleId { get; set; }
        //TODO: Esperando a modelo Role
        public Role role { get; set; }

        public List<User> relatedUsers { get; set; } = new List<User>();

        //TODO: Lista de intereses
        public List<ELenguageBank> relatedInterest { get; set; } = new List<ELenguageBank>();

    }
}