using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ILenguage.API.Domain.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public ulong CardNumber { get; set; }
        public string OwnerName { get; set; }
        public uint Year { get; set; }
        [Range(1,12,ErrorMessage = "Month must be between 1 to 12")]
        public uint month { get; set; }
        public uint CvcCode { get; set; }
        public EPaymentNetwork PaymentNetwork { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<UserSuscription> UserSuscriptions { get; set; }
      
    }
}