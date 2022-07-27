using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class Validation
    {
        public static bool StrMinLen(string input, int minLen)
        { if (input.Length >= minLen) { return true; } else { return false; } }

        public static bool StrContainsUppercase(string input)
        { if (input.Any(Char.IsUpper)) { return true; } else { return false; } }

        public static bool StrContainsLowercase(string input)
        { if (input.Any(Char.IsLower)) { return true; } else { return false; } }

        public static bool StringContainsNumber(string input)
        { if (input.Any(Char.IsNumber)) { return true; } else { return false; } }

        public static bool StrNoSeparator(string input)
        { if (input.Any(Char.IsSeparator)) { return false; } else { return true; } }

        public static bool StrContainsSpecialChar(string input)
        { if (input.Any(Char.IsSymbol) || input.Any(Char.IsPunctuation)) { return true; } else { return false; } }


    }
}


/* TEST
 * 
 * 
 *  public static bool StrNotEmpty(string input)
        { if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) { return false; } else { return true; } }

 * public static Predicate<string> dPredicateStr;
        public static Func<string, int, bool> dFuncStrIntBool;
        public static Func<bool, bool> dFunc2xBool;
        public static int counter = 0;

        public static void DelToInvoke (Predicate<string> dMethod, string userInput, int dMethodIndex)
            {
            if (dMethod != null)
            {
                int listLength = dMethod.GetInvocationList().Length;
                var tempDel = dMethod.GetInvocationList()[dMethodIndex]; //Creating a reference to the Predicate method reference at index counter.
                object bol = tempDel.DynamicInvoke(userInput); //Running the method at index once and creating an object from the it. The object is either true or false.
                if ((bool)bol) 
                {
                    Console.WriteLine("true true");
                }

                tempDel = null;
                Validation.counter++;
            }
        }

 * 
 * */