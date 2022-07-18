using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class Validation
    {
        public static string StringMinLength(int x)
        {
            string? value = null;
            string error = Message.userinputMinLength(x);
            do
            {
                string? answer = Console.ReadLine();
                Console.WriteLine(answer.GetType() );
                if (answer.Length < x && StringEmpty(answer))
                {
                    Console.WriteLine(error);
                }
                else value = answer;
            } while (value == null);
            return value;
        }

        public static string StringMinUppercase(int x)
        {
            string? value = null;
            string error = "Skal indeholde mindst 1 stort bogstav";
            char[] answerChar;
            do
            {
                string? answer = Console.ReadLine();
                if (StringUppercase(answer)) //Return true if the answer contains Uppercase
                    value = answer;
                else
                    Console.WriteLine(error);
            } while (value == null);
            return value;
        }

        public static bool StringUppercase(string a)
        {
            bool bol = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsUpper(a, i))
                {
                    bol = true;
                    break;
                }
            }
            return bol;
        }

        public static bool StringEmpty(string a)
        {
            bool bol = false;
            if (IsEmpty(a) || a == "" || a == a.Trim())
            {
                bol = true;
            }
            return bol;
        }


        public static string StringMinLowercase(int x)
        {
            string? value = null;
            string error = "Skal indeholde mindst 1 lille bogstav";
            char[] answerChar;
            do
            {
                string? answer = Console.ReadLine();
                if (StringLowercase(answer)) //Return true if the answer contains Lowercase
                    value = answer;
                else
                    Console.WriteLine(error);
            } while (value == null);
            return value;
        }

        public static bool StringLowercase(string a)
        {
            bool bol = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsLower(a, i))
                {
                    bol = true;
                    break;
                }
            }
            return bol;
        }


    }
}
