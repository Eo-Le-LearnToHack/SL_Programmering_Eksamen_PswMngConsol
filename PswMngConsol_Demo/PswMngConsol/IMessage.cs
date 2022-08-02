using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IMessage
    {
        public static string
            addName = "Tilføj brugernavn                \t: ",
            addCode = "Tilføj kode                      \t: ",
            addAnotherUser = "Tilføj endnu en bruger?",
            option1Yes = "1         \t: Ja\nAlt andet    \t: Nej",

            changeAdminCode = "Ændr kode til din Admin konto.\nAngiv venligst en ny kode            \t: ",
            createNewAdminCode = "Opret kode til din Admin konto.\nOpret venligst en kode             \t: ",
            createPswTip = "Opret en hint til koden.        \t: ",
            criteriaFail = "Din kode opfylder ikke følgende kriterier:",

            deleteUsrWhere = "Hvor vil du slette en bruger?",

            enterServiceNum = "Indtast service nr.  \t:",
            enterUsrNum = "Indtast bruger nr.   \t: ",
            enterAdmPsw = "Indtast admin koden for at logge på    \t: ",

            noService = "Der er ikke oprettet nogen service.",

            pswNoMatch = $"Forkert kode.\nPrøv igen.",
            pswTip = "Hint til din kode er    \t:",
            pswDateTime = "Koden blev oprettet     \t: d.",

            repeatCode = "Gentag venligst din kode          \t: ",
            remainingAttempt = "Antal login forsøg tilbage             \t: ",

            serviceNum = "Service nr.",
            thisServiceExists = "Følgende service eksisterer allerede \t: ",
            service = "Service",
            shutDown = "Programmet lukker ned.\nHAV EN GOD DAG!",

            tryAgain = "Prøv igen.",

            usrNum = "Bruger nr.";


            
            



        public static void ProgramShuttingDown()
        {
            Console.Clear();
            Console.WriteLine(shutDown);
            Console.ReadLine();
        }

        public static void ExceptionMessage(Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
