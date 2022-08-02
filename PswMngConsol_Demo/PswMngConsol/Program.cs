namespace PswMngConsol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                IReset.ILoginLoop();
                while (CAdmin.pswHash.Count == 0)                           { CAdmin.CreateOrChangePsw(); } //Oprette admin kode hvis denne ikke er blevet oprettet eller ændre eksiterende kode
                while (ILogin.loopLoginCheck && CAdmin.pswHash.Count > 0)   { CAdmin.LoginToMainMenu(); }   //Hvis Admin kodeord er blevet oprettet må brugeren tilgå MainProgram ellers lukker programmet.
                while (ILogin.loopLoginSuccessful)                          { IMenu.MainProgram(); }        //Dette er hovedmenuen
            } while (ILogin.loopProgram);
            IMessage.ProgramShuttingDown();
        }

    } //class
} //namespace

