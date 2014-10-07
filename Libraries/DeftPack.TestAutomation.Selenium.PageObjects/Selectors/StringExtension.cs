
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    internal static class StringExtension
    {
        private static readonly char[] RestrictedCharacters =
        {
            '!', '"', '#', '$', '%', '&', '(', ')', '*', '+', ',',
            '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '`', '{', '|', '}', '~'
        };

        internal static string Escape(this string text)
        {
            return RestrictedCharacters.Aggregate(text,
                (current, character) => current.Replace(character.ToString(), string.Format(@"\\{0}", character)));
        }
    }
}
