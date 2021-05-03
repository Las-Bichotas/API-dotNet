using System;

namespace ILenguage.API.Domain.Models
{
    public class UserSuscription
    {
        public int SuscriptionId { get; set; }
        public Suscription Suscription { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
       
       public int PeymentMethodId { get; set; }
       //public PaymentMethod PaymentMethod { get; set; }
       
       //
       public int UserSuscriptionId { get; set; }
       public DateTime InitialDate { get; set; }
       public DateTime FinalDate { get; set; }
        
    }
}