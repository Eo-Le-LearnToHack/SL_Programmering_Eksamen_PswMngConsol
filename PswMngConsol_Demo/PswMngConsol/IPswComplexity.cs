using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IPswComplexity
    {
        public static int
            minLen = 10;

        public static List<bool> listOfComplianceResult = new();                    //Loggin all compliance check. True = OK, false = Fail.
        public static List<int> listOfNonComplianceIndex = new();         //Loggin only noncompliance.
        public static List<string> listOfNonComplianceTxt = new List<string>        //A full list of text to display if any criterium fails.
        {
            $"1. Koden skal indeholde mindst               \t: {minLen} karakterer.",
            "2. Koden skal indeholde mindst                \t: 1 lille bogstav.",
            "3. Koden skal indeholde mindst                \t: 1 stort bogstav.",
            "4. Koden skal indeholde mindst                \t: 1 tal.",
            "5. Koden skal indeholde mindst                \t: 1 specialtegn.",
            "6. Koden må ikke indeholde                    \t: mellemrum",
        };

        public static void CreateListOfComplianceResult(List<bool> boolList, string input, int minLen)
        {
            if (IValidation.StrMinLen(input, minLen)) { boolList.Add(true); } else { boolList.Add(false); }
            if (IValidation.StrContainsLowercase(input)) { boolList.Add(true); } else { boolList.Add(false); }
            if (IValidation.StrContainsUppercase(input)) { boolList.Add(true); } else { boolList.Add(false); }
            if (IValidation.StrContainsNumber(input)) { boolList.Add(true); } else { boolList.Add(false); }
            if (IValidation.StrContainsSpecialChar(input)) { boolList.Add(true); } else { boolList.Add(false); }
            if (IValidation.StrNoSeparator(input)) { boolList.Add(true); } else { boolList.Add(false); }
        }

        

        public static void CreatelistOfComplexityIndexNonCompliance(List<int> nonComplianceIndexList)
        {
            for (int i = 0; i < listOfComplianceResult.Count; i++)
            { if (!listOfComplianceResult[i]) { nonComplianceIndexList.Add(i); } }
        }

        public static void PrintingOutNonComplianceCriteria(List<int> nonComplianceIndexList, List<string> nonComplianceTxtList)
        {
            Console.Clear();
            if (nonComplianceIndexList.Count > 0)
            {
                Console.WriteLine(IMessage.criteriaFail);
                for (int i = 0; i < nonComplianceIndexList.Count; i++)
                { Console.WriteLine(nonComplianceTxtList[nonComplianceIndexList[i]]); }
                Console.WriteLine($"\n{IMessage.tryAgain}");
                Console.ReadLine();
            }
            else { Console.Write(IMessage.repeatCode); }
        }

        public static void CheckIfComplexityFulfilled(string input)
        {
            CreateListOfComplianceResult(listOfComplianceResult, input, minLen);                            //If criterium OK save as true or else save as false.
            CreatelistOfComplexityIndexNonCompliance(listOfNonComplianceIndex);                   //If criterium fails saving the index number to the list.
            PrintingOutNonComplianceCriteria(listOfNonComplianceIndex, listOfNonComplianceTxt);   //If CreatelistOfComplexityIndexNonCompliance is not empty then at least one criterium is not OK
        }



    }
}
