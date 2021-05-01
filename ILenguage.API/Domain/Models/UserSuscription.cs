namespace ILenguage.API.Domain.Models
{
    public class UserSuscription
    {
        public int SuscriptionId { get; set; }
        public Suscription Suscription { get; set; }
        
        public int UserId { get; set; }
       //! public User User { get; set; }
       
       public ulong CardNumber { get; set; }
       public PaymentMethod PaymentMethod { get; set; }
        
    }
}