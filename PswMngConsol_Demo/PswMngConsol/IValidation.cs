using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IValidation
    {
        public static bool StrMinLen(string input, int minLen)
        { if (input.Length >= minLen) { return true; } else { return false; } }

        public static bool StrContainsUppercase(string input)
        { if (input.Any(Char.IsUpper)) { return true; } else { return false; } }

        public static bool StrContainsLowercase(string input)
        { if (input.Any(Char.IsLower)) { return true; } else { return false; } }

        public static bool StrContainsNumber(string input)
        { if (input.Any(Char.IsNumber)) { return true; } else { return false; } }

        public static bool StrNoSeparator(string input)
        { if (input.Any(Char.IsSeparator)) { return false; } else { return true; } }

        public static bool StrContainsSpecialChar(string input)
        { if (input.Any(Char.IsSymbol) || input.Any(Char.IsPunctuation)) { return true; } else { return false; } }


    }
}