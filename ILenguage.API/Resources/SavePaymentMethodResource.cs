using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SavePaymentMethod
    {
        [Required(ErrorMessage = "Card Number is required")]
        [DataType(DataType.CreditCard)]
        public ulong CardNumber { get; set; }
        
        [Required (ErrorMessage = "The owner of the card is required")]
        [MaxLength(30)]
        [MinLength(3, ErrorMessage = "Owner name must have more than 3 digits")]
        [DataType(DataType.Text)]
        public string OwnerName { get; set; }
        
        [Required(ErrorMessage = "Year is required")]
        public uint Year { get; set; }
        
        [Required(ErrorMessage = "Month is requires")]
        [Range(1,12,ErrorMessage = "Month must be between 1 to 12")]
        public uint month { get; set; }
        
        [Required(ErrorMessage = "cvc is required")]
        [DataType(DataType.Password)]
        public uint CvcCode { get; set; }
        
        
    }
}