namespace PswMngConsol
{
    internal interface IMenu
    {
        public static void MainProgram()
        {
            //Kan multithreading anvendes til noget brugbar her?
            //ThreadStart starter = myLongRunningTask;
            //starter += () => {
            //    // Do what you want in the callback
            //};
            //Thread thread = new Thread(starter) { IsBackground = true };
            //thread.Start();

            //MANGLER send keystrokes funktionen !!!!!!!!

            byte
                counterLine = 1,
                counterInput = 1;

            Console.Clear();
            Console.WriteLine($"Velkommen {Environment.UserName.ToUpper()}\n");

            
            Console.WriteLine(
                $"{counterLine++}\t: Ændr admin kode.\n" +  /*counterLine++ = 1 fordi værdien bliver føst ændret efter koden er kørt og ikke samtidig.*/
                $"{counterLine++}\t: Ændr admin hint.\n" +
                $"{counterLine++}\t: Tilføj ny service og ny bruger\n" +
                $"{counterLine++}\t: Tilføj ny bruger til service.\n" +
                $"{counterLine++}\t: Autoudfyld brugernavn og kode.\n" +
                $"{counterLine++}\t: Udskriv services og brugere.\n" +
                $"{counterLine++}\t: Sammenkæde service kode til andre brugere.\n" +
                $"{counterLine++}\t: Ophæv sammnkædning af kode for bestemte brugere.\n" +
                $"{counterLine++}\t: Nulstil sammnkædning af kode for alle brugerne.\n" +
                $"{counterLine++}\t: Ændr service kode.\n" +
                $"{counterLine++}\t: Ændr service brugernavn.\n" +
                $"{counterLine++}\t: Ændr servicenavn.\n" +
                $"{counterLine++}\t: Slet bruger fra service.\n" +
                $"{counterLine++}\t: Slet service.\n" +
                $"{counterLine++}\t: Genstart programmet.\n" +
                $"{counterLine++}\t: Luk ned.");            /*counterLine = 15*/

        Console.Write("\nHvad vil du foretage dig?\t: ");
            string input = Console.ReadLine();
            if (input == counterInput++.ToString()) { CAdmin.CreateOrChangePsw(); }
            else if (input == counterInput++.ToString()) { CAdmin.CreateOrChangeDateTimeAndTip(CAdmin.pswHash, CAdmin.pswTip); }
            else if (input == counterInput++.ToString()) { CService.AddServiceNameAndUrsnameAndPsw(); }
            else if (input == counterInput++.ToString()) { CService.AddUrsnameAndPswToServiceName(); }
            else if (input == counterInput++.ToString()) { CService.AutofillUsrnameAndPsw(); }
            else if (input == counterInput++.ToString()) { CService.PrintingOutServiceNameAndUrsnameAndPsw(); }
            else if (input == counterInput++.ToString()) { CService.LinkingPswTogether(); }
            else if (input == counterInput++.ToString()) { CService.RemovingLinkingPsw(); }
            else if (input == counterInput++.ToString()) { CService.RemovingLinkingPswAllUsr(); }
            else if (input == counterInput++.ToString()) { CService.ChangeServicePsw(); } 
            else if (input == counterInput++.ToString()) { CService.ChangeServiceUrsname(); }
            else if (input == counterInput++.ToString()) { CService.ChangeServiceName(); }
            else if (input == counterInput++.ToString()) { CService.DeleteServiceUrsAndPsw(); }
            else if (input == counterInput++.ToString()) { CService.DeleteServiceNameAndUrsAndPsw(); }
            else if (input == counterInput++.ToString()) { ILogin.RestartProgram(); }
            else if (input == counterInput++.ToString()) { ILogin.ShuttingDown(); } 
        }

    }
}

