namespace PswMngConsol
{
    internal abstract class CAdmin : CAccount //Abstract means the class can't be instantiated
    {
        public static List<string> pswHash = new();
        public static List<string> salt = new();

        public static void CreatePswIfCriteriaFulfilled(string input, string inputRepeat)
        {
            if (input == inputRepeat) { AddSaltAndPsw(IHash.byteArrLen); }
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
        }

        public static void CreateOrChangeDateTimeAndTip(List<string> pswHash, List<string> pswTip)
        {
            if (IUserInput.first == IUserInput.repeat || IPswComplexity.listOfNonComplianceIndex.Count == 0 && pswTip.Count > 0)
            {
                Console.Clear();

                Console.Write(IMessage.createPswTip);
                pswTip.Clear();
                pswTip.Add(Console.ReadLine());

                DateTime localDateTime = DateTime.Now;
                pswDateTime.Clear();
                pswDateTime.Add(localDateTime);
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
                else if (pswHash.Count > 0) { Console.Write(IMessage.changeAdminCode); }
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
