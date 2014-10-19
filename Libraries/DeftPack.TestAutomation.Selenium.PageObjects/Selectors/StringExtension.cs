
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

        /// <summary>
        /// Escaping the forbidden characters (jQuery selectors)
        /// </summary>
        /// <param name="text">Selector part to be escaped</param>
        /// <returns>Escaped string</returns>
        internal static string Escape(this string text)
        {
            return RestrictedCharacters.Aggregate(text,
                (current, character) => current.Replace(character.ToString(), string.Format(@"\\{0}", character)));
        }
    }
}
