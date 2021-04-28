using System.Linq;
using System.Xml.Schema;

namespace ILenguage.API.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(
                str.Select((x, i) => i > 0 && char.IsUpper(x)
                    ? "_" + x.ToString()
                    : x.ToString())).ToLower();
        }
    }
}