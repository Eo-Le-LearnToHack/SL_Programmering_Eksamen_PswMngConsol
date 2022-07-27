using PswMngConsol;
using System;
using System.Text;
using System.Security.Cryptography;

List<bool> listOfComplianceResult = new();
List<string> listOfComplianceErrTxt = new();
List<int> listOfComplexityIndexNonCompliance = new();

string userInput = null;
int minLen = 10, byteArrLen = 8, loginAttempt = 10;
string errorPswNoMatch = "Kodeord stemmer ikke over ens. Prøv igen.";
string msgCorrectPsw = "Kodeord er korrekt.";
string msgShutDown = "Programmet lukker ned.";


//Opretter admin kode hvis denne ikke er blevet oprettet.
while (Admin.PswHashWithSalt.Count < 1) 
{
    CreateOrChangeAdmPsw();
}

void CreateOrChangeAdmPsw()
{
    ResetAll();
    if (Admin.PswHashWithSalt.Count < 1)
    {
        Console.Write($"Opret kode til din Admin konto.\nOpret venligst en kode\t\t\t\t\t:");
        userInput = MaskUserInput();
        CreateListOfComplianceResult(listOfComplianceResult, userInput, minLen);
        CreateListOfComplianceErrTxt(listOfComplianceErrTxt, userInput, minLen);
        CreatelistOfComplexityIndexNonCompliance(listOfComplexityIndexNonCompliance, userInput, minLen);
        CheckIfPswComplexityIsFulfilled(listOfComplexityIndexNonCompliance, listOfComplianceErrTxt);
        string userInputRepeat = MaskUserInput();
        CreatePswIfCriteriaAreFulfilled(listOfComplexityIndexNonCompliance, byteArrLen, userInput, userInputRepeat, errorPswNoMatch);
        CreateOrChangeTipForAdmPsw(Admin.PswHashWithSalt, Admin.PswTip);
        Admin.PswCreatedDateTime.Add(LogCurrentDateTime());
        Console.Clear();
    }
    else if (Admin.PswHashWithSalt.Count > 0)
    {
        Console.Write($"Ændr kode til din Admin konto.\nAngiv venligst en ny kode\t\t\t\t\t:");
        userInput = MaskUserInput();
        CreateListOfComplianceResult(listOfComplianceResult, userInput, minLen);
        CreateListOfComplianceErrTxt(listOfComplianceErrTxt, userInput, minLen);
        CreatelistOfComplexityIndexNonCompliance(listOfComplexityIndexNonCompliance, userInput, minLen);
        CheckIfPswComplexityIsFulfilled(listOfComplexityIndexNonCompliance, listOfComplianceErrTxt);
        string userInputRepeat = MaskUserInput();
        CreatePswIfCriteriaAreFulfilled(listOfComplexityIndexNonCompliance, byteArrLen, userInput, userInputRepeat, errorPswNoMatch);
        CreateOrChangeTipForAdmPsw(Admin.PswHashWithSalt, Admin.PswTip);
        Admin.PswCreatedDateTime.Add(LogCurrentDateTime());
        Console.Clear();
    }
    
}



//Hvis Admin kodeord er blevet oprettet må brugeren tilgå while loopen.
bool loopLogin = true;
bool loopLoginOK = false;
while (loopLogin && Admin.PswHashWithSalt.Count > 0 )
{
    Console.Clear();
    if (LoginWithAdminAccount(loginAttempt, Admin.Salt[0], Admin.PswHashWithSalt[0], Admin.PswTip[0], Admin.PswCreatedDateTime[0], errorPswNoMatch))
    { loopLoginOK = true; }
    loopLogin = false;
}

while (loopLoginOK)
{
    Console.Clear();
    Console.WriteLine("Velkommen :" + Environment.UserName.ToUpper());
    Console.WriteLine("Hvad vil du foretage dig?");
    Console.WriteLine($"1       : Ændre admin kode.");
    Console.WriteLine($"2       : Ændre admin hint.");
    Console.WriteLine($"3       : Se eksisterende service");
    Console.WriteLine($"4       : Udskriv alle services og tilhørende login credential");
    Console.WriteLine($"5       : Tilføj en ny service");
    Console.WriteLine($"6       : Luk ned");
    
    userInput = Console.ReadLine();
    if (userInput == "1")
    {
        string oldPsw = Admin.PswHashWithSalt[0];
        CreateOrChangeAdmPsw();
        Console.WriteLine($"Din kode før ændring \t\t\t\t\t:" + oldPsw);
        Console.WriteLine($"Din kode efter ændring\t\t\t\t\t:" + Admin.PswHashWithSalt[0]);
        Console.ReadLine();
    }
    else if (userInput == "2")
    {
        string oldTip = Admin.PswTip[0];
        CreateOrChangeTipForAdmPsw(Admin.PswHashWithSalt, Admin.PswTip);
        Console.WriteLine("Din hint før ændring\t\t\t\t\t:" + oldTip);
        Console.WriteLine("Din hint efter ændring\t\t\t\t\t:" + Admin.PswTip[0]);
        Console.ReadLine();
    }
    else if (userInput == "6") { loopLoginOK = false; }
}

Console.WriteLine(msgShutDown);
Console.ReadLine();





////METODER
///
void ResetAll()
{
    if (listOfComplianceResult.Count > 0)               { listOfComplianceResult.Clear(); }
    if (listOfComplianceErrTxt.Count > 0)               { listOfComplianceErrTxt.Clear(); }
    if (listOfComplexityIndexNonCompliance.Count > 0)   { listOfComplexityIndexNonCompliance.Clear(); }
    Console.Clear();
}

string? MaskUserInput()
{
    string output = "";
    while (true) //Jumps out of loop if the return is null
    {
        ConsoleKeyInfo userInput = Console.ReadKey(true);
        switch (userInput.Key)
        {
            case ConsoleKey.Escape:
                break; //return null;
            case ConsoleKey.Enter:
                Console.WriteLine();
                return output;
            case ConsoleKey.Backspace:
                if (output.Length > 0)
                {
                    output = output.Substring(0, (output.Length - 1)); //Reducerer userInput i længden med -1.
                    Console.Write("\b \b"); //DEn første backspace flytter en position tilbage. Den næste empty+backspace sletter positionen.
                }
                break;
            default:
                output += userInput.KeyChar;
                Console.Write("*");
                break;
        }
    }
}


void CreateListOfComplianceResult(List<bool> boolList, string userInput, int minLen)
{
    if (Validation.StrMinLen(userInput, minLen))        { boolList.Add(true); } else { boolList.Add(false); }
    if (Validation.StrContainsLowercase(userInput))     { boolList.Add(true); } else { boolList.Add(false); }
    if (Validation.StrContainsUppercase(userInput))     { boolList.Add(true); } else { boolList.Add(false); }
    if (Validation.StringContainsNumber(userInput))     { boolList.Add(true); } else { boolList.Add(false); }
    if (Validation.StrContainsSpecialChar(userInput))   { boolList.Add(true); } else { boolList.Add(false); }
    if (Validation.StrNoSeparator(userInput))           { boolList.Add(true); } else { boolList.Add(false); }
}

void CreateListOfComplianceErrTxt(List<string> strList, string userInput, int minLen)
{
    strList.Add($"Koden skal indeholde mindst\t\t\t\t:{minLen} karakterer.");
    strList.Add($"Koden skal indeholde mindst\t\t\t\t:1 lille bogstav.");
    strList.Add($"Koden skal indeholde mindst\t\t\t\t:1 stort bogstav.");
    strList.Add($"Koden skal indeholde mindst\t\t\t\t:1 tal.");
    strList.Add($"Koden skal indeholde mindst\t\t\t\t:1 specialtegn.");
    strList.Add($"Koden må ikke indeholde    \t\t\t\t:mellemrum");
}

void CreatelistOfComplexityIndexNonCompliance(List<int> listOfComplexityIndexNonCompliance, string userInput, int minLen)
{
    for (int i = 0; i < listOfComplianceResult.Count; i++)
    { if (!listOfComplianceResult[i]) { listOfComplexityIndexNonCompliance.Add(i); } }
}

void CheckIfPswComplexityIsFulfilled(List<int> listOfComplexityIndexNonCompliance, List<string> listOfComplexityErrTxt)
{
    if (listOfComplexityIndexNonCompliance.Count > 0)
    {
        Console.WriteLine("Din kode opfylder ikke følgende kriterier:");
        for (int i = 0; i < listOfComplexityIndexNonCompliance.Count; i++)
        { Console.WriteLine(listOfComplexityErrTxt[listOfComplexityIndexNonCompliance[i]]); }
        Console.WriteLine("\nPrøv igen.");
    }
    else { Console.Write("Gentag venligst din kode\t\t\t\t\t:"); }
}

string GenerateSalt(int byteArrLen) //Create a random salt string
{
    RandomNumberGenerator randomNumGen = RandomNumberGenerator.Create();   
    byte[] bytes = new byte[byteArrLen];              // Creates an instance of onedimensional byte array. The highest number in a byte is 256 = 2^8.
    randomNumGen.GetBytes(bytes);               //Fills an array of bytes with a cryptographically strong random sequence of values.
    return Convert.ToBase64String(bytes);       //Converts the byte array to a string
}

string GenerateHashWithSalt(string userInput, string salt)
{
    byte[] bytes = Encoding.UTF8.GetBytes(userInput + salt); //Converting the userInput+salt to a byte array (max value 255). The length of the array is defined by the length of the input+salt
    SHA256 sha256 = SHA256.Create();                 //Creates a SHA256 hashAlgorithm
    byte[] hash = sha256.ComputeHash(bytes);         //Convertes the bytes array to a hash containing a byte array with a length of 32.                                                   
    //return Convert.ToBase64String(bytes);         //Giver en længde på 40

    StringBuilder sb = new();
    for (int i = 0; i < hash.Length; i++)
    { sb.Append(hash[i].ToString("x2")); }            // Loop through each byte of the hashed data and format each one as a short hexadecimal string with a length of 2 and use lower case.
    return sb.ToString();                             // Return the short hexadecimal string. Giver en længde på 64.
}


bool CompareHash(string userInput, string salt, string hash) // VERIFFY if string gives the same hash against the hash string
{
    StringComparer stringComparerCaseSensitive = StringComparer.Ordinal;
    string hashOutput = GenerateHashWithSalt(userInput, salt); //Hash the input.
    return stringComparerCaseSensitive.Compare(hashOutput, hash) == 0; //Return true if perfect match
}



void CreatePswIfCriteriaAreFulfilled(List<int> listOfComplexityIndexNonCompliance, int byteArrLen, string userInput, string userInputRepeat, string errorNoMatchRetry)
{
    if (Admin.PswHashWithSalt.Count < 1)
    {
        if (listOfComplexityIndexNonCompliance.Count < 1)
        {
            string salt = GenerateSalt(byteArrLen);
            string pswHashWithSalt = GenerateHashWithSalt(userInput, salt);
            if (CompareHash(userInputRepeat, salt, pswHashWithSalt))
            {
                Admin.Salt.Add(salt);
                Admin.PswHashWithSalt.Add(pswHashWithSalt);
            }
            else { Console.WriteLine(errorNoMatchRetry); }
        }
    }
    else if (Admin.PswHashWithSalt.Count > 0)
    {
        string salt = GenerateSalt(byteArrLen);
        string pswHashWithSalt = GenerateHashWithSalt(userInput, salt);
        if (CompareHash(userInputRepeat, salt, pswHashWithSalt))
        {
            Admin.Salt[0] = salt;
            Admin.PswHashWithSalt[0] = pswHashWithSalt;
        }
        else { Console.WriteLine(errorNoMatchRetry); }
    }
}



void CreateOrChangeTipForAdmPsw(List<string> AdminPswHashWithSalt, List<string> pswTip)
{
    if (AdminPswHashWithSalt.Count > 0 && pswTip.Count < 1)
    {
        Console.Write("Opret en hint for bedre at huske admin koden.\t\t:");
        pswTip.Add(Console.ReadLine());
    }
    else if (AdminPswHashWithSalt.Count > 0 && pswTip.Count > 0)
    {
        Console.Write("Ændr din hint for bedre at huske admin koden.\t\t:");
        pswTip[0] = Console.ReadLine();
    }
}


DateTime LogCurrentDateTime()
{
    DateTime utcDateDanish = DateTime.UtcNow.AddHours(1); //Dansk tid er UTC+1.
    return utcDateDanish;
}

bool LoginWithAdminAccount(int loginAttempt, string Salt, string PswHashWithSalt, string PswTip, DateTime PswCreatedDateTime, string errorNoMatchRetry)
{
    bool bol = false;
    for (int i = loginAttempt; i > 0; i--)
    {
        Console.Clear();
        Console.WriteLine($"Indtast admin koden for at logge på. Du har {i} forsøg.");
        userInput = MaskUserInput();
        if (CompareHash(userInput, Salt, PswHashWithSalt))
        { bol = true; break; }
        else
        {
            Console.WriteLine(errorNoMatchRetry);
            Console.WriteLine($"Hint til din kode er: {PswTip}");
            Console.WriteLine("Koden blev oprettet d.: " + PswCreatedDateTime);
            Console.ReadLine();
        }
    }
    return bol;
}