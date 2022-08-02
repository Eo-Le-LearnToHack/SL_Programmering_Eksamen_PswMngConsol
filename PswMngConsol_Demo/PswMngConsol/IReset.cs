using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IReset
    {
        public static void ListAndUserInputValues()
        {
            if (IPswComplexity.listOfComplianceResult.Count > 0) { IPswComplexity.listOfComplianceResult.Clear(); }
            if (IPswComplexity.listOfNonComplianceIndex.Count > 0) { IPswComplexity.listOfNonComplianceIndex.Clear(); }
            IUserInput.first = null;
            IUserInput.repeat = "Default";
            Console.Clear();
        }

        public static void ListValues()
        {
            if (IPswComplexity.listOfComplianceResult.Count > 0) { IPswComplexity.listOfComplianceResult.Clear(); }
            if (IPswComplexity.listOfNonComplianceIndex.Count > 0) { IPswComplexity.listOfNonComplianceIndex.Clear(); }
            Console.Clear();
        }

        public static void ILoginLoop()
        {
            ILogin.loopLoginCheck = true;
            ILogin.loopLoginSuccessful = false;
            ILogin.loopProgram = false;
        }


    }
}
