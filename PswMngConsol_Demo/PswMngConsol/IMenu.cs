using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal interface IMenu
    {
        public static void MainProgram()
        {
            Console.Clear();
            Console.WriteLine($"Velkommen : {Environment.UserName.ToUpper()}\n");
            Console.WriteLine("Hvad vil du foretage dig?");
            Console.WriteLine($"1       : Ændr admin kode.");
            Console.WriteLine($"2       : Ændr admin hint.");
            Console.WriteLine($"3       : Tilføj ny service.");
            Console.WriteLine($"4       : Tilføj ny bruger til service.");
            Console.WriteLine($"5       : Udskriv services og brugere.");
            Console.WriteLine($"6      : Sammenkæde kode for flere brugere.");
            Console.WriteLine($"7      : Ændr service kode.");
            Console.WriteLine($"8      : Ændr service brugernavn.");
            Console.WriteLine($"9      : Ændr servicenavn.");
            Console.WriteLine($"10       : Slet bruger fra service.");
            Console.WriteLine($"11       : Slet service.");
            Console.WriteLine($"12       : Genstart programmet.");
            Console.WriteLine($"13       : Luk ned.");
            

            string? input = Console.ReadLine();
            if (input == "1") { Option1_ChangeAdmPsw(); }
            else if (input == "2") { Option2_ChangeTipForAdmPsw(); }
            else if (input == "3") { Option3_AddNewService(); }
            else if (input == "4") { Option4_AddUserToService(); }
            else if (input == "5") { Option5_PrintingOutServices(); }
            else if (input == "6") { Option6_LinkPswTogether(); }
            else if (input == "7") { Option7_ChangeServicePsw(); }
            else if (input == "8") { Option8_ChangeServiceUsr(); }
            else if (input == "9") { Option9_ChangeServiceName(); }
            else if (input == "10") { Option10_DeleteUserFromService(); }
            else if (input == "11") { Option11_DeleteService(); }
            else if (input == "12") { Option12_RestartProgram(); }
            else if (input == "13") { Option13_ShuttingDown(); }
            
        }

        public static void Option1_ChangeAdmPsw() { CAdmin.CreateOrChangePsw(); }
        public static void Option2_ChangeTipForAdmPsw() { CAdmin.CreateOrChangeDateTimeAndTip(CAdmin.pswHash, CAdmin.pswTip); }
        public static void Option3_AddNewService() { CService.AddServiceAndUser(); }
        public static void Option4_AddUserToService() { CService.AddAnotherUser(); }
        public static void Option5_PrintingOutServices() { CService.PrintingOut(); }
        public static void Option6_LinkPswTogether() { CService.LinkPswTogether(); }
        public static void Option7_ChangeServicePsw() { CService.ChangePsw(); }
        public static void Option8_ChangeServiceUsr() { CService.ChangeUsr(); }
        public static void Option9_ChangeServiceName() { CService.ChangeName(); }
        public static void Option10_DeleteUserFromService() { CService.DeleteUser(); }
        public static void Option11_DeleteService() { CService.DeleteService(); }
        public static void Option12_RestartProgram() { ILogin.RestartProgram(); }
        public static void Option13_ShuttingDown() { ILogin.ShuttingDown(); }
        

    }
}

