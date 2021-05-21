using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SavePaymentResource
    {
        [Required(ErrorMessage = "Card number is required")]
        [StringLength(16, ErrorMessage = "Card number must contain 16 digits")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }
        
        [Required(ErrorMessage = "Expired month is required")]
        [Range(1,12, ErrorMessage = "Month entered is invalid")]
        public int Month { get; set; }
        
        [Required(ErrorMessage = "Expired year is required")]
        public int Year { get; set; }
        
        [Required(ErrorMessage = "cvc code is requiered")]
        [Range(100,999, ErrorMessage = "Invalid cvc code")]
        [DataType(DataType.Password)]
        public string Cvc { get; set; }
        
        [Required(ErrorMessage = "Value is required")]
        //[RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "The price must have only 2 decimals")] //This is to be sure price has 2 digits max
        public long? Value { get; set; }
    }
}