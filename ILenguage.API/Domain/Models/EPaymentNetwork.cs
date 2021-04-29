using System.ComponentModel;

namespace ILenguage.API.Domain.Models
{
    public enum EPaymentNetwork : byte
    {
        [Description("Visa")]
        Visa = 1,
        [Description("Mastercard")]
        Mastercard = 2, 
        [Description("American Express")]
        AmericanExpress = 3,
        [Description("Diners club")]
        DinersClub=4

    }
}