using System.Text.RegularExpressions;

namespace Auth.Commons
{
    public static class StringCommons
    {

        public static bool IsValidSequence (this string input)
        {
            var result = true;
            var matches = Regex.Matches(input, @"(.)\1+");

                if (matches.Count > 1)
                {
                result = false;
                }

                //...

        return result;
        }

        public static bool HasValidSpecialChar (this string input)
        {
            var result = false;
            var matches = Regex.Matches(input, @"[@#_-e]");
           
                if (matches.Count > 1)
                {
                result = true;
                }
        return result;
        }
        
    }
}