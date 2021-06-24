using System.Collections.Generic;

namespace ILenguage.API.Domain.Models
{
    public class Badgets
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }
        public List<UserBadgets> UserBadgets { get; set; }
    }
}