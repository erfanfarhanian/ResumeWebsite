using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace Resume.Bussines.Extentions
{
    public static class EnumExtentions
    {
        public static string GetEnumName(this Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType()
                .GetMember(myEnum.ToString())
                .FirstOrDefault();

            if (enumDisplayName != null)
                return enumDisplayName.GetCustomAttribute<DisplayAttribute>().GetName();

            return "";
        }
    }
}