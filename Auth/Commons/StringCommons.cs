using System.Text.RegularExpressions;

namespace Auth.Commons
{
    public static class StringCommons
    {

        public static bool IsValidSequence (this string input)
        {
            var matches = Regex.Matches(input, @"(.)\1+");
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Length > 1)
                return false;
                //...
            }
        return true;

        }

        public static bool HasValidSpecialChar (this string input)
        {
            var matches = Regex.Matches(input, @"[@#_-e]");
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Length > 1)
                return true;
                //...
            }
        return false;

        }
        
    }
}