namespace PswMngConsol
{
    internal class CService : CAccount
    {
        public static List<string> name = new();
        public static List<int> ID = new(); //SKAL DENNE ANVENDES TIL NOGET?

        public static int
            counterServiceAccIndex = 0,
            counterServiceAccLength = 1;

        public static CService[] serviceAcc = new CService[counterServiceAccLength];
        public List<string> psw = new();
        public List<string> usr = new();


        public static void ChangeName()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        Console.Clear();
                        Console.WriteLine($"Hvor vil du ændre servicenavn?\n");
                        for (int i = 0; i < serviceAcc.Length; i++)
                        { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                        Console.Write($"\n{IMessage.enterServiceNum}");
                        string serviceIndex = Console.ReadLine();

                        Console.Write("Indtast det nye servicenavn : ");
                        name[Convert.ToInt32(serviceIndex)] = Console.ReadLine();

                        Console.WriteLine($"Er der andre service du gerne vil ændre navn på?\n{IMessage.option1Yes}");
                        if ("1" == Console.ReadLine()) { bol = true; } else { bol = false; }
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


        public static void ChangeUsr()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        Console.Clear();
                        Console.WriteLine($"Hvor vil du ændre brugernavn?\n");
                        for (int i = 0; i < serviceAcc.Length; i++)
                        { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                        Console.Write($"\n{IMessage.enterServiceNum}");
                        string serviceIndex = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceIndex)].ToUpper()}\n");
                        for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceIndex)].usr.Count; j++)
                        {
                            Console.WriteLine($"{IMessage.usrNum} {j}\t : {serviceAcc[Convert.ToInt32(serviceIndex)].usr[j]}");
                            Console.WriteLine($"Kode nr. {j}\t\t\t : {serviceAcc[Convert.ToInt32(serviceIndex)].psw[j]}");
                            Console.WriteLine();
                        }

                        Console.Write($"\n{IMessage.enterUsrNum}");
                        string usrIndex = Console.ReadLine();

                        Console.Write("Indtast det nye brugernavn : ");
                        serviceAcc[Convert.ToInt32(serviceIndex)].usr[Convert.ToInt32(usrIndex)] = Console.ReadLine();

                        Console.WriteLine($"Er der andre brugernavn du gerne vil ændre?\n{IMessage.option1Yes}");
                        if ("1" == Console.ReadLine()) { bol = true; } else { bol = false; }
                    } while (bol);

                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


        public static void ChangePsw()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        Console.Clear();
                        Console.WriteLine($"Hvor vil du ændre kode?\n");
                        for (int i = 0; i < serviceAcc.Length; i++)
                        { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                        Console.Write($"\n{IMessage.enterServiceNum}");
                        string serviceIndex = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceIndex)].ToUpper()}\n");
                        for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceIndex)].usr.Count; j++)
                        { 
                            Console.WriteLine($"{IMessage.usrNum} {j}\t : {serviceAcc[Convert.ToInt32(serviceIndex)].usr[j]}");
                            Console.WriteLine($"Kode nr. {j}\t\t\t : {serviceAcc[Convert.ToInt32(serviceIndex)].psw[j]}");
                            Console.WriteLine();
                        }

                        Console.Write($"\n{IMessage.enterUsrNum}");
                        string usrIndex = Console.ReadLine();

                        Console.Write("Indtast den nye kode : ");
                        serviceAcc[Convert.ToInt32(serviceIndex)].psw[Convert.ToInt32(usrIndex)] = Console.ReadLine();

                        Console.WriteLine($"Er der andre bruger du gerne vil ændre kode på?\n{IMessage.option1Yes}");
                        if ("1" == Console.ReadLine()) { bol = true; } else { bol = false; }
                    } while (bol);
                    
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void LinkPswTogether()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Hvor skal der sammenkædes?\n");
                    for (int i = 0; i < serviceAcc.Length; i++)
                    { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                    Console.Write($"\nIndtast reference service nr. :");
                    string serviceRefIndex = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceRefIndex)].ToUpper()}\n");
                    for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceRefIndex)].usr.Count; j++)
                    { Console.WriteLine($"{IMessage.usrNum} {j}\t : {serviceAcc[Convert.ToInt32(serviceRefIndex)].usr[j]}"); }

                    Console.Write($"\nIndtast reference bruger nr. : ");
                    string usrRefIndex = Console.ReadLine();

                    //.............
                    bool bol;
                    do
                    {
                        bol = false;
                        Console.Clear();
                        Console.WriteLine($"Hvor skal der sammenkædes?\n");
                        for (int i = 0; i < serviceAcc.Length; i++)
                        { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                        Console.Write($"\nIndtast det næste service nr. :");
                        string serviceNextIndex = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceNextIndex)].ToUpper()}\n");
                        for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceNextIndex)].usr.Count; j++)
                        { Console.WriteLine($"{IMessage.usrNum} {j}\t : {serviceAcc[Convert.ToInt32(serviceNextIndex)].usr[j]}"); }

                        Console.Write($"\nIndtast det næste bruger nr. : ");
                        string usrNextIndex = Console.ReadLine();

                        serviceAcc[Convert.ToInt32(serviceNextIndex)].psw[Convert.ToInt32(usrNextIndex)] = serviceAcc[Convert.ToInt32(serviceRefIndex)].psw[Convert.ToInt32(usrRefIndex)];

                        Console.WriteLine($"\nVil du sammenkæde flere brugere til reference?\n{IMessage.option1Yes}");
                        if ("1" == Console.ReadLine()) { bol = true; } else { bol = false; }

                    } while (bol);
                    
                  
                }

            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


        public static void DeleteUser()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"{IMessage.deleteUsrWhere}\n");
                    for (int i = 0; i < serviceAcc.Length; i++)
                    { Console.WriteLine($"{IMessage.serviceNum} {i}\t: {name[i].ToUpper()}"); }

                    Console.Write($"\n{IMessage.enterServiceNum}");
                    string serviceIndex = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceIndex)].ToUpper()}\n");
                    for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceIndex)].usr.Count; j++)
                    { Console.WriteLine($"{IMessage.usrNum} {j}\t : {serviceAcc[Convert.ToInt32(serviceIndex)].usr[j]}"); }

                    Console.Write($"\n{IMessage.enterUsrNum}");
                    string usrIndex = Console.ReadLine();

                    serviceAcc[Convert.ToInt32(serviceIndex)].usr.RemoveAt(Convert.ToInt32(usrIndex));
                    serviceAcc[Convert.ToInt32(serviceIndex)].psw.RemoveAt(Convert.ToInt32(usrIndex));
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


        public static void PrintingOut()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0) { Console.WriteLine(IMessage.noService); }
                else if (name.Count > 0)
                {
                    Console.WriteLine("Hvad vil du udskrive?");
                    for (int i = 0; i < name.Count; i++) { Console.WriteLine($"{i}\t: {name[i]}"); }
                    Console.WriteLine($"\n0-{name.Count - 1}: Indtast service nr. for at udskrive en specifik service.\nAlt andet: Udskriver samtlige services.");
                    IUserInput.first = Console.ReadLine();
                    int userOutput;
                    bool bol = Int32.TryParse(IUserInput.first, out userOutput);
                    Console.Clear();
                    if (!bol)
                    {
                        for (int i = 0; i < serviceAcc.Length; i++)
                        {
                            Console.WriteLine($"Service: {name[i].ToUpper()}\n");
                            for (int j = 0; j < serviceAcc[i].usr.Count; j++)
                            {
                                Console.WriteLine($"Brugernavn\t: {serviceAcc[i].usr[j]}");
                                Console.WriteLine($"Kode      \t: {serviceAcc[i].psw[j]}");
                                Console.WriteLine();
                            }
                            Console.WriteLine("---------------------------------------------------------------");
                            Console.WriteLine();
                        }
                    }
                    else if (Convert.ToInt32(IUserInput.first) >= 0 && Convert.ToInt32(IUserInput.first) < name.Count)
                    {
                        Console.WriteLine($"Service: {name[Convert.ToInt32(IUserInput.first)].ToUpper()}\n");
                        for (int j = 0; j < serviceAcc[Convert.ToInt32(IUserInput.first)].usr.Count; j++)
                        {
                            Console.WriteLine($"Brugernavn\t: {serviceAcc[Convert.ToInt32(IUserInput.first)].usr[j]}");
                            Console.WriteLine($"Kode      \t: {serviceAcc[Convert.ToInt32(IUserInput.first)].psw[j]}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("---------------------------------------------------------------");
                    }

                }
                Console.ReadLine();
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void AddAnotherUser()
        {
            try
            {
                Console.Clear();
                if (name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Hvor vil du tilføje ny bruger:\n");
                    for (int i = 0; i < name.Count; i++) { Console.WriteLine($"{i}: {name[i]}"); }
                    Console.Write("\nIndtast service nr.: ");
                    AddUser(Console.ReadLine());
                }

            }
            catch (Exception e)
            { IMessage.ExceptionMessage(e); }
        }

        public static void AddUser(string serviceIndex)
        {
            try
            {
                bool bol = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Service {name[Convert.ToInt32(serviceIndex)].ToUpper()}");
                    Console.WriteLine();
                    Console.Write(IMessage.addName);
                    CService.serviceAcc[Convert.ToInt32(serviceIndex)].usr.Add(Console.ReadLine());
                    Console.Write(IMessage.addCode);
                    CService.serviceAcc[Convert.ToInt32(serviceIndex)].psw.Add(Console.ReadLine());
                    Console.WriteLine($"\n{IMessage.addAnotherUser}\n{IMessage.option1Yes}");
                    if ("1" == Console.ReadLine()) { bol = true; } else { bol = false; }
                } while (bol);
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


        public static void AddServiceAndUser()
        {
            try
            {
                Console.Clear();
                Console.Write($"Angiv navn på din nye service\t\t: ");
                string serviceName = Console.ReadLine().ToLower();
                
                Console.WriteLine();
                if (CService.name.Contains(serviceName))
                {
                    Console.WriteLine($"{IMessage.thisServiceExists}{serviceName}");
                    Console.ReadLine();
                }
                else if (!CService.name.Contains(serviceName))
                {
                    CService.ID.Add(CService.name.Count);
                    CService.name.Add(serviceName);
                    if (CService.counterServiceAccIndex == 0)
                    {
                        CService.serviceAcc[CService.counterServiceAccIndex] = new CService();
                        Console.Write(IMessage.addName);
                        CService.serviceAcc[CService.counterServiceAccIndex].usr.Add(Console.ReadLine());
                        Console.Write(IMessage.addCode);
                        CService.serviceAcc[CService.counterServiceAccIndex].psw.Add(Console.ReadLine());
                    }
                    else if (CService.counterServiceAccIndex > 0)
                    {
                        Array.Resize(ref CService.serviceAcc, CService.counterServiceAccLength);
                        CService.serviceAcc[CService.counterServiceAccIndex] = new CService();
                        Console.Write(IMessage.addName);
                        CService.serviceAcc[CService.counterServiceAccIndex].usr.Add(Console.ReadLine());
                        Console.Write(IMessage.addCode);
                        CService.serviceAcc[CService.counterServiceAccIndex].psw.Add(Console.ReadLine());
                    }

                    Console.WriteLine($"\n{IMessage.addAnotherUser}\n{IMessage.option1Yes}");
                    if ("1" == Console.ReadLine()) { CService.AddUser(CService.counterServiceAccIndex.ToString()); }
                    CService.counterServiceAccLength++;
                    CService.counterServiceAccIndex++;
                    Console.ReadLine();
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }



        public static void DeleteService()
        {
            try
            {
                Console.Clear();
                if (CService.name.Count == 0)
                {
                    Console.WriteLine(IMessage.noService);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Hvilken service vil du slette?\n");
                    for (int i = 0; i < CService.serviceAcc.Length; i++)
                    { Console.WriteLine($"Service nr. {i}\t: {CService.name[i]}"); }

                    Console.Write($"\n{IMessage.enterServiceNum}");
                    string serviceIndex = Console.ReadLine();

                    CService.name.RemoveAt(Convert.ToInt32(serviceIndex));
                    int indexToRemove = Convert.ToInt32(serviceIndex); //https://www.delftstack.com/howto/csharp/how-to-remove-element-of-an-array-in-csharp/
                    CService.serviceAcc = CService.serviceAcc.Where((source, index) => index != indexToRemove).ToArray();
                    CService.counterServiceAccLength--;
                    CService.counterServiceAccIndex--;
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }


    }

}
