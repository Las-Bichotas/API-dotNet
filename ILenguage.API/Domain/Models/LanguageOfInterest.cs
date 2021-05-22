using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class LanguageOfInterest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserLanguages> UserLanguage;
    }
}