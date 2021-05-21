using ILenguage.API.Domain.Models;

namespace ILenguage.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public UserSubscription UserSubscription { get; set; }
        //TODO:RoleResoure add
        //public RoleResource Role {get; set;}
    }
}