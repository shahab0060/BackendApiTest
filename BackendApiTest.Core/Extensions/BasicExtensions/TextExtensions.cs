using BackendApiTest.Core.Security;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BackendApiTest.Core.Extensions.BasicExtensions
{
    public static class TextExtensions
    {
        public static string? ToTitle(this string? title) => title.CapitalizeFirstCharacterOfEachWord().SanitizeText();

        public static string? ToText(this string? text) => text.SanitizeText();
        public static string Join(this List<string> list, string separator = " & ") =>
        string.Join(separator, list);

        public static string Truncate(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
        }
        public static string? CapitalizeFirstCharacterOfEachWord(this string? text)
        {
            if (text is null) return null;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(text);
        }

        public static bool IsValidUrl(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            // Regular expression pattern for matching a URL
            string pattern = @"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w.-]*)*/?$";

            return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
        }

        public static string ConvertImageNameToWebP(this string imageName) =>
           Path.GetFileNameWithoutExtension(imageName) + ".webp";
    }
}
