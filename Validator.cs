using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

namespace GlowMate
{
    internal class Validator
    {
        /// <summary>
        /// Validates if the input string is in a valid email format.
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Basic email pattern
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Checks if the input string consists only of numeric digits.
        /// </summary>
        public static bool IsNumeric(string input)
        {
            return long.TryParse(input, out _);
        }
    }
}
