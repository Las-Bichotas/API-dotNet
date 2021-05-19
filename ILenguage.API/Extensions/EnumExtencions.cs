using System.ComponentModel;
using System.Reflection;

namespace ILenguage.API.Extensions
{
    public static class EnumExtencions
    {
        public static string ToDescriptionsString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? @enum.ToString();

        }

    }
}