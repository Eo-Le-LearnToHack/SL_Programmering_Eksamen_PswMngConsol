using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IUserInput
    {

        public static string?
            first = null,
            repeat = "Default";

        public static string Mask()
        {
            string output = "";
            while (true) //Jumps out of loop if the return is null
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                switch (userInput.Key)
                {
                    case ConsoleKey.Escape:
                        break; //return null;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return output;
                    case ConsoleKey.Backspace:
                        if (output.Length != 0)
                        {
                            output = output.Substring(0, output.Length - 1); //Reducerer userInput i længden med -1.
                            Console.Write("\b \b"); //DEn første backspace flytter en position tilbage. Den næste empty+backspace sletter positionen.
                        }
                        break;
                    default:
                        output += userInput.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }

    }
}
