namespace PswMngConsol
{
    internal interface IMessage
    {
        public static string

            anyMoreServiceNameToBeChanged = "Er der flere servicenavn du gerne vil?",
            anyMorePswToBeChanged = "Er der flere kode du gerne vil ændre?",
            anyMoreUsrnameToBeChanged = "Er der flere brugernavn du gerne vil ændre?",
            anyMoreUsrToBeDeleted = "Er der flere brugere du gerne vil slette?",
            anyMoreServiceToBeDeleted = "Er der flere service du gerne vil slette?",
            anyMoreUsrnameToBeAdded = "Tilføj endnu en bruger?",
            anyMoreUsrToBeLinkedTogether = "Vil du sammenkæde flere brugere til reference?",
            anyMorePrintOut = "Vil printe andet ud?",
            anyMoreServiceAndUrsToBeAdded = "Vil du tilføje flere service?",
            addUrsname = "Tilføj brugernavn                  \t: ",
            addPsw = "Tilføj kode                        \t: ",


            changeAdminCode = "Ændr kode til din Admin konto.\n" +
                                    "Angiv venligst en ny kode          \t: ",

            createNewAdminCode = "Opret kode til din Admin konto.\n" +
                                    "Opret venligst en kode             \t: ",

            createPswTip = "Opret en hint til koden.           \t: ",
            criteriaFail = "Din kode opfylder ikke følgende kriterier:",

            deleteUsrWhere = "Hvor vil du slette en bruger?",

            empty = "",
            enterServiceNum = "Indtast service nr.                \t:",
            enterServiceNumRef = "Indtast reference service nr.      \t: ",
            enterUsrNumRef = "Indtast reference bruger nr. : ",
            enterUsrNum = "Indtast bruger nr.                 \t: ",
            enterAdmPsw = "Indtast admin koden for at logge på\t: ",
            enterNewPsw = "Indtast den nye kode               \t: ",
            enterNewServiceName = "Indtast det nye servicenavn        \t: ",
            enterNewUsrname = "Indtast det nye brugernavn : ",

            globalUsrIDNum = "GlobalUsrID nr.",

            localUsrIDNum = "LocalUsrID nr.",

            noService = "Der er ikke oprettet nogen service.\nTryk på en vilkårlig tast for at vende tilbage.",
            na = "NA",

            option1Yes = "1              \t: Ja\n" +
                                    "Alt andet      \t: Nej",

            optionNameCount = "Indtast service nr. for at udskrive en specifik service.\n" +
                               "Alt andet:     \t\t: Udskriver samtlige services.",

            overviewAllServices = "Oversigt over alle oprettede services:",

            pswNoMatch = $"Forkert kode.\nPrøv igen.",
            pswNum = "Kode nr.",
            pswTip = "Hint til din kode er               \t:",
            pswDateTime = "Koden blev oprettet                \t: d.",

            repeatCode = "Gentag venligst din kode           \t: ",
            remainingAttempt = "Antal login forsøg tilbage         \t: ",

            serviceNum = "Service nr.",
            thisServiceExists = "Følgende service eksisterer allerede\t: ",
            service = "Service",
            shutDown = "Programmet lukker ned.\nHAV EN GOD DAG!",

            tryAgain = "Prøv igen.",

            usrNum = "Bruger nr.",

            whatToLinkTogether = "Hvor skal der sammenkædes?",
            whereToAddNewUsr = "Hvor vil tilføje en bruger?",
            whichServiceIsInvolved = "På hvilket service vil du foretage handlingen?",
            whereToRemoveLinkingPsw = "Hvor vil du fjerne sammenkædning?",
            whereToAutofill = "Hvad skal autoudfyldes?",
            whereToChangePsw = "Hvor vil du ændre kode?",

            addUsr_EnterServiceNum = "Hvor vil du tilføje en bruger?\n" + $"{enterServiceNum}",
            deleteService_EnterServiceNum = "Hvilken Service vil du slette?\n" + $"{enterServiceNum}",
            ChangeServiceName_EnterServiceNum = "Hvilken Service vil du ændre navn på?\n" + $"{enterServiceNum}",
            ChangeUrsname_EnterServiceNum = "Hvor vil du ændre brugernavn?\n" + $"{enterServiceNum}",
            ChangePsw_EnterServiceNum = $"{whereToChangePsw}\n{enterServiceNum}",
            ChangePsw_EnterUsrNum = $"{whereToChangePsw}\n{enterUsrNum}",
            printService_EnterServiceNum = "\n\n0\t\t\t: Udskriver en specifik service.\n" +
                                "Alt andet \t: Udskriver samtlige services.\n" + $"{enterServiceNum}",
            linkPswTogether_EnterServiceNumRef = $"{whatToLinkTogether}\n{enterServiceNumRef}",
            linkPswTogether_EnterUrsNumRef = $"{whatToLinkTogether}\n{enterUsrNumRef}",
            linkPswTogether_EnterServiceNum = $"{whatToLinkTogether}\n{enterServiceNum}",
            linkPswTogether_EnterUrsNum = $"{whatToLinkTogether}\n{enterUsrNum}",
            removeLinkPsw_EnterServiceNumRef = $"{whereToRemoveLinkingPsw}\n{enterServiceNumRef}",
            removeLinkPsw_EnterUrsNumRef =  $"{whereToRemoveLinkingPsw}\n{enterUsrNumRef}",
            removeLinkPsw_EnterServiceNum = $"{whereToRemoveLinkingPsw}\n{enterServiceNum}",
            removeLinkPsw_EnterUrsNum = $"{whereToRemoveLinkingPsw}\n{enterUsrNum}",
            allLinkPswBeenRemoved = "Alle sammenkædning af koder er blevet nulstillet.",
            autofill_EnterServiceNum = $"{whereToAutofill}\n{enterServiceNum}",
            autofill_EnterUsrNum = $"{whereToAutofill}\n{enterUsrNum}",
            deleteUsr_EnterServiceNum = $"{whereToRemoveLinkingPsw}\n{enterServiceNum}";

              

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
