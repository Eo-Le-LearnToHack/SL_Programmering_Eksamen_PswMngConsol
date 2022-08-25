using System.Globalization;

namespace PswMngConsol
{
    internal abstract class CAdmin : CAccount //Abstract means the class can't be instantiated
    {
        public static List<string> pswHash = new(); //SKAL laves om til almindelig string på et senere tidspunkt.
        public static List<string> salt = new();    //SKAL laves om til almindelig string på et senere tidspunkt.
        public static List<string> pswTip = new();  //SKAL laves om til almindelig string på et senere tidspunkt.


        public static void IfAdminFileExistsReadValuesFromFileToCAdmin()
        {
            try
            {
                if (IFile.FileExists(IFile.fileAdminTxt[0]))
                {
                    IFile.listStringArray.Clear();
                    IFile.ReadAllToListStringArrayFromTxtFile(IFile.fullPathAdmin[0]);
                    if (IFile.listStringArray.Count == 1 && IFile.listStringArray[0].Length == 4)
                    {
                        CAdmin.pswHash.Clear(); //SKAL ÆNDRE DISSE til alm. string, så behøves clear ikke anvendes.
                        CAdmin.salt.Clear();
                        CAdmin.pswTip.Clear();
                        CAdmin.pswDateTime.Clear();

                        CAdmin.pswHash.Add(IFile.listStringArray[0][0]);
                        CAdmin.salt.Add(IFile.listStringArray[0][1]);
                        CAdmin.pswTip.Add(IFile.listStringArray[0][2]);
                        CAdmin.pswDateTime.Add(DateTime.Parse((IFile.listStringArray[0][3]), CultureInfo.DefaultThreadCurrentCulture));
                    }
                    else
                    {
                        Console.WriteLine("Filens indehold i Admin0.txt er forkert. Programmet lukker ned");
                        System.Environment.Exit(1); //Exitcode = 0, means the program ends succesfully.
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Filens indehold i Admin0.txt er forkert. Programmet lukker ned");
                System.Environment.Exit(1); //Exitcode = 0, means the program ends succesfully.
            }
            
        }

        public static void CreatePswIfCriteriaFulfilled(string input, string inputRepeat)
        {
            if (input == inputRepeat) 
            { 
                AddSaltAndPsw(IHash.byteArrLen); 
            }
            else { Console.WriteLine(IMessage.pswNoMatch); }
        }

        public static void AddSaltAndPsw(byte byteArrLen)
        {
            string salt = IHash.GenerateSalt(byteArrLen);
            CAdmin.salt.Clear();
            CAdmin.salt.Add(salt);

            string pswHash = IHash.GenerateHash(IUserInput.first, salt);
            CAdmin.pswHash.Clear();
            CAdmin.pswHash.Add(pswHash);

            //LogSaltAndPsw
            IFile.ReadAndAddStrToFileTxt(IFile.path + IFile.fileAdminTxt[0], pswHash + ",");
            IFile.ReadAndAddStrToFileTxt(IFile.path + IFile.fileAdminTxt[0], salt + ",");
        }

        public static void CreateOrChangeDateTimeAndTip(List<string> pswHash, List<string> pswTip)
        {
            if (IUserInput.first == IUserInput.repeat || IPswComplexity.listOfNonComplianceIndex.Count == 0 && pswTip.Count > 0)
            {
                Console.Clear();
                Console.Write(IMessage.createPswTip);
                string pswTipNew = Console.ReadLine();
                int elementsInTxtFile = IFile.ReturnElementsInSingleLineFileTxt(IFile.fullPathAdmin[0]); //bør være 4 elementer (pswHash,salt,pswTip,creationTime)
                if (pswTip.Count > 0 && elementsInTxtFile == 4) //svarer til adminkoden er blevet oprettet
                {
                    IFile.OverWritePswTipInTxtFile(IFile.fullPathAdmin[0], pswTipNew); //LogTip
                }
                else
                {
                    pswTip.Clear();
                    pswTip.Add(pswTipNew);
                    DateTime DateTime = DateTime.Now;
                    pswDateTime.Clear();
                    pswDateTime.Add(DateTime);
                    //LogTipAndDateTime
                    IFile.ReadAndAddStrToFileTxt(IFile.path + IFile.fileAdminTxt[0], pswTipNew + ",");
                    IFile.ReadAndAddStrToFileTxt(IFile.path + IFile.fileAdminTxt[0], DateTime.ToString("dd-MM-yyyy HH:mm:ss"));
                } 
            }
            else
            {
                Console.Clear();
                Console.WriteLine(IMessage.pswNoMatch);
            }
        }

        public static void CreateOrChangePsw()
        {
            do
            {
                IReset.ListAndUserInputValues();
                if (pswHash.Count == 0) { Console.Write(IMessage.createNewAdminCode); }
                else if (pswHash.Count > 0) 
                { 
                    Console.Write(IMessage.changeAdminCode);
                    IFile.ClearAllStrInFileTxt(IFile.fullPathAdmin[0]);
                }
                IUserInput.first = IUserInput.Mask();
                IPswComplexity.CheckIfComplexityFulfilled(IUserInput.first);
            } while (IPswComplexity.listOfNonComplianceIndex.Count > 0);

            do
            {
                IReset.ListValues();
                Console.Write(IMessage.repeatCode);
                IUserInput.repeat = IUserInput.Mask();
                IPswComplexity.CheckIfComplexityFulfilled(IUserInput.repeat);
                CreatePswIfCriteriaFulfilled(IUserInput.first, IUserInput.repeat);
            } while (IPswComplexity.listOfNonComplianceIndex.Count > 0 || IUserInput.first != IUserInput.repeat);

            CAdmin.CreateOrChangeDateTimeAndTip(pswHash, pswTip);
            Console.Clear();
        }

        public static bool Login(int attempt, string Salt, string PswHash)
        {
            bool bol = false;
            for (int i = attempt; i > 0; i--)
            {
                Console.Clear();
                Console.Write($"{IMessage.remainingAttempt}{i}\n{IMessage.enterAdmPsw}");
                IUserInput.first = IUserInput.Mask();
                if (IHash.CompareHash(IUserInput.first, Salt, PswHash)) { bol = true; break; }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{IMessage.pswNoMatch}\n{IMessage.pswTip} {pswTip[0]}\n{IMessage.pswDateTime} {pswDateTime[0]}");
                    Console.ReadLine();
                }
            }
            return bol;
        }

        public static void LoginToMainMenu()
        {
            Console.Clear();
            if (Login(ILogin.attempt, salt[0], pswHash[0])) 
            { ILogin.loopLoginSuccessful = true; }
            ILogin.loopLoginCheck = false;
        }

        

    }

}
