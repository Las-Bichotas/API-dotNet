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
        public int roleId { get; set; }
        //TODO: Esperando a modelo Role
        public Role role { get; set; }
        //TODO: PayMethos falta implementar
        public List<PayMethods> payMethods { get; set; } = new List<PayMethods>();

        public List<User> relatedUsers { get; set; } = new List<User>();
        public List<EInterestBank> relatedInterest { get; set; } = new List<EInterestBank>();
        public List<ELenguageBank> relatedLenguageInterest { get; set; } = new List<ELenguageBank>();

    }
}