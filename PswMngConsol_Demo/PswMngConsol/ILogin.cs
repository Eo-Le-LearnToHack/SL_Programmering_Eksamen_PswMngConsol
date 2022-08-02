using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface ILogin
    {
        public static int
            attempt = 10;

        public static bool 
            loopLoginCheck = true, 
            loopLoginSuccessful = false,
            loopProgram = false;

        public static void RestartProgram() 
        { 
            loopProgram = true; 
            loopLoginSuccessful = false; 
        }
        public static void ShuttingDown() 
        { 
            loopProgram = false; 
            loopLoginSuccessful = false; 
        }
    }
}
