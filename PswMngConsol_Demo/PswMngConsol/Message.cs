using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class Message
    {
        public static string inputName = "Du skal angive et navn";
        public static string inputMinLength { get; set; }
        public static string min10Length = "Skal være mindst 10 karakterer lang.";
        public static string  min1Uppercase = "Skal være indeholde mindst 1 stort bogstav.";
        public static string min1Lowercase = "Skal være indeholde mindst 1 lille bogstav.";
        //public static string maxLength = "Du skal angive et navn med";


        public static string userinputMinLength(int x)
        {
            inputMinLength = $"Længden skal være mindst {x} karakterer lang.";
            return inputMinLength;
        }

    }
}
