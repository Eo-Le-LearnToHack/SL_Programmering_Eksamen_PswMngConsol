using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace PswMngConsol
{
    
    internal class Program
    {
        [STAThread] //Attribute, COM threading model = Single Threading Apartment (STA).
        static void Main(string[] args)
        {
            ICulture.DaDk(); //Global setting the culture to Danish
            IFile.CreateListFile(); //antal Adminfil = 1, antal Servicefil = 1000
            IFile.CreateFullPathList(); //Oprette referencen til den fulde sti til C:Dev/fil.txt. Selve filerne bliver IKKE oprettet.

            do
            {
                IReset.ILoginLoop();
                CAdmin.IfAdminFileExistsReadValuesFromFileToCAdmin(); //Hvis filens indhold er i korrekt format indlæses værdierne ellers lukker programmet ned.
                while (CAdmin.pswHash.Count == 0) { CAdmin.CreateOrChangePsw(); } //Oprette admin kode hvis denne ikke er blevet oprettet eller ændre eksiterende kode
                while (ILogin.loopLoginCheck && CAdmin.pswHash.Count > 0) { CAdmin.LoginToMainMenu(); }   //Hvis Admin kodeord er blevet oprettet må brugeren tilgå MainProgram ellers lukker programmet.
                while (ILogin.loopLoginSuccessful) { IMenu.MainProgram(); }        //Dette er hovedmenuen
            } while (ILogin.loopProgram);
            IMessage.ProgramShuttingDown();
        }
    
    } //class
} //namespace

//TEST upload to github