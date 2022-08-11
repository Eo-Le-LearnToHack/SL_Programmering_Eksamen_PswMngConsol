using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IUserInput
    {

        public static string
            first = null,
            repeat = "";

        public static string Mask()
        {
            string output = "";
            while (true) //Jumps out of loop if the return is null
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true); //true sørger for at outputtet vises direkte på konsollen.
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
                            output = output[..^1]; //Reducerer userInput i længden med -1. Original kode output.Substring(0, output.Length - 1) .. Den nye kode anvender range operator;
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
