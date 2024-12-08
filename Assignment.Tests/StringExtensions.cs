using IntelliTect.TestTools;
using System.Text.RegularExpressions;

namespace Assignment.Tests
{
    /// <summary>
    /// Useful string extensions for performing assertions.
    /// </summary>

    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the string matches the given pattern (case-insensitive).
        /// </summary>
        /// <param name="s">The string to match</param>
        /// <param name="pattern">The pattern to match it against.</param>
        /// <returns></returns>
        public static bool IsLikeRegex(this string s, string pattern)
        {
            return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(s);
        }

        /// <summary>
        /// Implement's VB's Like operator logic.
        /// </summary>
        // Provided in addition to IsLike that takes an escape character 
        // even though a default escapeCharacter is provided as it
        // is hopefully simpler to use this one because no thinking 
        // about escapeCharacter is required.  
        public static bool IsLike(this string text, string pattern)
        {
            return new WildcardPattern(pattern).IsMatch(text);
        }

        /// <summary>
        /// Implement's VB's Like operator logic.
        /// </summary>
        public static bool IsLike(this string text, string pattern, char escapeCharacter)
        {
            return new WildcardPattern(pattern, escapeCharacter).IsMatch(text);
        }
    }
}