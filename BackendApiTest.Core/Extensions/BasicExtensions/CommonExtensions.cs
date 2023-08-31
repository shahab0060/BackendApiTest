using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BackendApiTest.Core.Extensions.BasicExtensions
{
    public static class CommonExtensions
    {
        #region url

        static string FixUrlSpacesWithDash(this string url)
        => url.ToLower().Trim().Replace(" ", "-").Replace("%", "-").Replace("&", "")
           .Replace("--", "-");

        public static string ToUrl(this string url)
            => url.ToLower().Trim().FixUrlSpacesWithDash();

        #endregion

        #region enums

        public static string? GetEnumName(this System.Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType().GetMember(myEnum.ToString()).FirstOrDefault();
            if (enumDisplayName is not null)
                return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();
            return null;
        }

        #endregion

        #region Convert Bool To Icon

        public static string ConvertBoolToIcon(this bool value)
        => value ? "check_circle" : "highlight_off";

        public static string? ConvertBoolToIcon(this bool? value)
        => (value is not null) ? ConvertBoolToIcon((bool)value) : null;

        #endregion

        #region Convert Bool To Text Color

        public static string ConvertBoolToTextColor(this bool value)
        => value ? "text-success" : "text-danger";
        public static string? ConvertBoolToTextColor(this bool? value)
        => (value is not null) ? ConvertBoolToTextColor((bool?)value) : null;


        #endregion

        public static bool IsEuqal(this List<long> firstList, List<long> secondList) =>
            firstList.Distinct().OrderBy(e => e)
            .SequenceEqual(secondList.Distinct().OrderBy(e => e));
    }
}
