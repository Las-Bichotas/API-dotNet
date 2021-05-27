using System;

namespace ILenguage.API.Domain.Models
{
    public class UserSubscription
    {
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        
       

    }
}