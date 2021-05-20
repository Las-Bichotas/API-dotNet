using System.ComponentModel;

namespace ILenguage.API.Domain.Models
{
    public enum EInterestBank
    {
        [Description("Scien")]
        Science,
        [Description("Hist")]
        History,
        [Description("Sport")]
        Sports,
        [Description("Music")]
        Music,
        [Description("Business")]
        Business,
        [Description("Weath")]
        Weather,
        [Description("New")]
        News

    }
}