namespace PswMngConsol
{
    //ID.Add(name.Count); //Starter med Nul, ved hver user added?
    internal class CService : CAccount
    {
        public static List<string> name = new();     

        public static int
            counterServiceAccIndex = 0,
            counterServiceAccLength = 1,
            counterGlobalUsrID = 0; //OBS! på et tidspunkt vil programmet crashes hvis global ID ikke bliver nulstillet!!


        public static CService[] serviceAcc = new CService[counterServiceAccLength];
        public List<string> psw = new();
        public List<string> usr = new();
        public List<int> globalUsrID = new();
        public List<int> localUsrID = new();





        public static void MasterMethod(
            Action<string> AddOrDisplayServiceName,
            Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,
            Action<string> DisplayOrNotDisplayUrsnameAndPsw,
            Action<string> ActionToPerform,
            Predicate<string> BoolOption, string msgElseYouWantToChange)
        {
            try
            {
                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }                     
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        AddOrDisplayServiceName(IMessage.na);              
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);     
                        DisplayOrNotDisplayUrsnameAndPsw(serviceIndex);
                        ActionToPerform(serviceIndex);                             
                        bol = BoolOption(msgElseYouWantToChange);                                   
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void MasterMethod(
            Action<string> AddOrDisplayServiceName,
            Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,
            Action<string> ActionToPerform,
            Predicate<string> BoolOption, string msgElseYouWantToChange)
        {
            try
            {
                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        AddOrDisplayServiceName(IMessage.na);
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);  
                        ActionToPerform(serviceIndex);                             
                        bol = BoolOption(msgElseYouWantToChange);                                   
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void MasterMethod(
           Action<string> AddOrDisplayServiceName,
           Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,
           Action<string> ActionToPerform)
        {
            try
            {
                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }
                else
                {
                    bool bol = false;
                    do
                    {
                        AddOrDisplayServiceName(IMessage.na);
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);         
                        ActionToPerform(serviceIndex);                                         
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void MasterMethod(
            Action<string> AddOrDisplayRefServiceName,
            Func<string, string> ReturningServiceRefIndex, string msgWhereToDoWhatServiceRef,
            Action<string> DisplayOrNotDisplayRefUrsnameAndPsw,
            Func<string, string> ReturningUsrRefIndex, string msgWhereToDoWhatUsrRef,

            Action<string> AddOrDisplayServiceName,
            Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,
            Action<string> DisplayOrNotDisplayUrsnameAndPsw,
            Func<string, string> ReturningUsrIndex, string msgWhereToDoWhatUsr,

            Action<string, string, string, string> ActionToPerform,
            Predicate<string> BoolOption, string msgElseYouWantToChange)
        {
            try
            {
                AddOrDisplayRefServiceName(IMessage.na);
                string serviceRefIndex = ReturningServiceRefIndex(msgWhereToDoWhatServiceRef); //Returning serviceRefIndex
                DisplayOrNotDisplayRefUrsnameAndPsw(serviceRefIndex);                           //Displaying RefUsrnameAndPsw
                string usrRefIndex = ReturningUsrRefIndex(msgWhereToDoWhatUsrRef);             //Returning usrRefIndex
                Console.WriteLine();

                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }         
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        AddOrDisplayServiceName(IMessage.na);                                      
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);         //Returning serviceIndex
                        DisplayOrNotDisplayUrsnameAndPsw(serviceIndex);                         //Displaying UsrnameAndPsw
                        string usrIndex = ReturningUsrIndex(msgWhereToDoWhatUsr);              //Returning usrIndex

                        ActionToPerform(serviceRefIndex, usrRefIndex, serviceIndex, usrIndex);        
                        bol = BoolOption(msgElseYouWantToChange);                                                                  
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void MasterMethod(
            Func<string> SetServiceName,

            Action<string> AddServiceName,
            Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,

            Action<string> ActionToPerform,
            Action<string> IncrementalService)
        {
            try
            {
                string serviceName = SetServiceName();

                Console.WriteLine();

                if (TemplateBoolServiceNameExists(serviceName)) { TemplateMsgThisServiceExists(serviceName); }                         //delegate Predicate and delegate Action
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        AddServiceName(serviceName);
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);

                        ActionToPerform(serviceIndex);
                        IncrementalService(serviceName);
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void MasterMethod(
            Action<string> AddOrDisplayServiceName,
            Func<string, string> ReturningServiceIndex, string msgWhereToDoWhat,
            Action<string> DisplayOrNotDisplayUrsnameAndPsw,
            Func<string, string> ReturningUsrIndex, string msgWhereToDoWhatUsr,

            Action<string, string> ActionToPerform,
            Predicate<string> BoolOption, string msgElseYouWantToChange)
        {
            try
            {

                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }
                else
                {
                    bool bol;
                    do
                    {
                        bol = false;
                        AddOrDisplayServiceName(IMessage.na);
                        string serviceIndex = ReturningServiceIndex(msgWhereToDoWhat);         //Returning serviceIndex
                        DisplayOrNotDisplayUrsnameAndPsw(serviceIndex);                         //Displaying UsrnameAndPsw
                        string usrIndex = ReturningUsrIndex(msgWhereToDoWhatUsr);              //Returning usrIndex

                        ActionToPerform(serviceIndex, usrIndex);
                        bol = BoolOption(msgElseYouWantToChange);
                    } while (bol);
                }
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void AddUrsnameAndPswToServiceName()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.addUsr_EnterServiceNum,
                TemplateAddUsr);
        }


        public static void DeleteServiceNameAndUrsAndPsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.deleteService_EnterServiceNum,
                TemplateDeleteService,
                TemplateBoolOption1, IMessage.anyMoreServiceToBeDeleted);
        }

        public static void ChangeServiceName()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.ChangeServiceName_EnterServiceNum,
                TemplateChangeServiceName,
                TemplateBoolOption1, IMessage.anyMoreServiceNameToBeChanged);
        }

        public static void PrintingOutServiceNameAndUrsnameAndPsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateDisplayUsrnamesAndPswOrAll, IMessage.printService_EnterServiceNum,
                TemplateDisplayNothing,
                TemplateBoolOption1, IMessage.anyMorePrintOut);
        }


        public static void AddServiceNameAndUrsnameAndPsw()
        {
            MasterMethod(
                TemplateReturnServiceName,
                TemplateAddServiceName,
                TemplateReturnServiceIndex, IMessage.addUsr_EnterServiceNum,
                TemplateAddUsr,
                TemplateIncrementalService);
        }

        public static void ChangeServicePsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.ChangePsw_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateReturnUrsIndex, IMessage.ChangePsw_EnterServiceNum,
                TemplateChangePsw,
                TemplateBoolOption1, IMessage.anyMorePswToBeChanged);
        }

       

        

        public static void ChangeServiceUrsname()
        {
            MasterMethod(                
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.ChangeUrsname_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateChangeUrsname,
                TemplateBoolOption1, IMessage.anyMoreUsrnameToBeChanged);
        }

       
        public static void DeleteServiceUrsAndPsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.deleteService_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateDeleteUsr,
                TemplateBoolOption1, IMessage.anyMoreUsrToBeDeleted);
        }



        public static string TemplateDisplayUsrnamesAndPswOrAll(string msgWhereToDoWhat)
        {
            if (name.Count > 1) { Console.Write($"\n\n0-{CService.name.Count - 1}\t\t\t: {IMessage.optionNameCount}\n{IMessage.enterServiceNum}"); }
            else { Console.Write($"{msgWhereToDoWhat}"); }
            string serviceIndex = Console.ReadLine();
            try
            {
                if (Convert.ToInt32(serviceIndex) >= 0 && Convert.ToInt32(serviceIndex) <= name.Count - 1) { TemplateDisplayingUsrnamesAndPsw(serviceIndex); }
            }
            catch (Exception e) { TemplateDisplayingAllUsrnamesAndPsw(e.Message); }
            Console.ReadLine();
            return serviceIndex;
        }



        public static void LinkingPswTogether()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.linkPswTogether_EnterServiceNumRef,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateReturnUrsIndex, IMessage.linkPswTogether_EnterUrsNumRef,

                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.linkPswTogether_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateReturnUrsIndex, IMessage.linkPswTogether_EnterUrsNum,

                TemplateLinkingPswTogether,
                TemplateBoolOption1, IMessage.anyMoreUsrToBeLinkedTogether
                );
        }



        public static void AutofillUsrnameAndPsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.autofill_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateReturnUrsIndex, IMessage.autofill_EnterUsrNum,

                TemplateAutofill,
                TemplateBoolOption1, IMessage.anyMorePswToBeChanged);
        }

        private static void TemplateAutofill(string serviceIndex, string usrIndex)
        {
            ConsoleKeyInfo cki = new();
            Console.WriteLine("Tryk på\nF9 for at starte autoudfyld af brugernavn.\nF10 for at starte autoudfyld af kode.\nEnter for at afslutte autoudfyld.");
            do
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.F9)
                {
                    MessageBox.Show("Placer musemarkøren i det felt som brugernavn skal udfyldes i.\nKlik OK og autoudfyld går i gang.");
                    Thread.Sleep(500);
                    ISendkeys.MyCopyPaste($"{serviceAcc[Convert.ToInt32(serviceIndex)].usr[Convert.ToInt32(usrIndex)]}");
                }
                else if (cki.Key == ConsoleKey.F10)
                {
                    MessageBox.Show("Placer musemarkøren i det felt som brugernavn skal udfyldes i.\nKlik OK og autoudfyld går i gang.");
                    Thread.Sleep(500);
                    ISendkeys.MySendKeys($"{serviceAcc[Convert.ToInt32(serviceIndex)].psw[Convert.ToInt32(usrIndex)]}");
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    int a = 2;
                    Console.WriteLine("Enter trykket");
                    a.Equals(1);
                }
            } while (true);
                
            
        }

        public static void RemovingLinkingPsw()
        {
            MasterMethod(
                TemplateDisplayingServiceNames,
                TemplateReturnServiceIndex, IMessage.removeLinkPsw_EnterServiceNum,
                TemplateDisplayingUsrnamesAndPsw,
                TemplateReturnUrsIndex, IMessage.removeLinkPsw_EnterUrsNum,

                TemplateRemoveLinkingPsw,
                TemplateBoolOption1, IMessage.anyMoreUsrToBeLinkedTogether
                );
        }

        public static void MasterMethod(
           Action<string> ActionToPerform)
        {
            try
            {
                if (TemplateBoolServiceNameNotExists()) { TemplateMsgNoServiceExists(); }
                else { ActionToPerform(IMessage.na); }
            } catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void RemovingLinkingPswAllUsr()
        {
            MasterMethod(
                TemplateRemoveLinkingPswAllUsr
                );
        }

        public static void TemplateRemoveLinkingPswAllUsr(string _0)
        {
            try
            {
                Console.Clear();
                for (int i = 0; i < serviceAcc.Length; i++)
                {
                    for (int j = 0; j < serviceAcc[i].usr.Count; j++)
                    {
                        serviceAcc[i].globalUsrID[j] = serviceAcc[i].localUsrID[j];
                    }
                }
                Console.WriteLine(IMessage.allLinkPswBeenRemoved);
                Console.ReadLine();
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void TemplateRemoveLinkingPsw(string serviceIndex, string usrIndex)
        {
            try
            {
                Console.Clear();
                serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID[Convert.ToInt32(usrIndex)]= serviceAcc[Convert.ToInt32(serviceIndex)].localUsrID[Convert.ToInt32(usrIndex)];
            } catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void TemplateLinkingPswTogether(string serviceRefIndex, string usrRefIndex, string serviceIndex, string usrIndex)
        {
            serviceAcc[Convert.ToInt32(serviceIndex)].psw[Convert.ToInt32(usrIndex)] = serviceAcc[Convert.ToInt32(serviceRefIndex)].psw[Convert.ToInt32(usrRefIndex)];
            serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID[Convert.ToInt32(usrIndex)] = serviceAcc[Convert.ToInt32(serviceRefIndex)].globalUsrID[Convert.ToInt32(usrRefIndex)];
        }


        public static bool TemplateBoolServiceNameNotExists()
        {
            if (name.Count == 0) { return true; } else { return false; }
        }



        public static void TemplateIncrementalService(string _)
        {
            CService.counterServiceAccLength++;
            CService.counterServiceAccIndex++;
        }


        public static string TemplateReturnServiceName()
        {
            Console.Clear();
            Console.Write($"{IMessage.enterNewServiceName}");
            return Console.ReadLine().ToLower();
        }

        public static bool TemplateBoolServiceNameExists(string serviceName)
        { 
            if (name.Contains(serviceName)) { return true; } else { return false; } 
        }

        public static void TemplateMsgThisServiceExists(string serviceName)
        {
            Console.WriteLine($"{IMessage.thisServiceExists}{serviceName}");
            Console.ReadLine();
        }

        public static void TemplateAddServiceName(string serviceName)
        {
            if (counterServiceAccIndex > 0) { Array.Resize(ref serviceAcc, counterServiceAccLength); } //Forøg arrayetslængde med +1 //ref gør at ændringen tilføjes til originale kilde/array
            serviceAcc[counterServiceAccIndex] = new CService();
            name.Add(serviceName);
            TemplateDisplayingServiceNames(serviceName);
        }
        
       

        public static void TemplateMsgNoServiceExists()
        {
            Console.Clear();
            Console.WriteLine(IMessage.noService);
            Console.ReadLine();
        }

        

        public static void TemplateDisplayingServiceNames(string serviceName)
        {

            WeakReference serviceName_wr = new WeakReference(serviceName);
            Console.Clear();
            Console.WriteLine($"{IMessage.overviewAllServices.ToUpper()}\n");
            if (name.Count > 0)
            {
                for (int i = 0; i < serviceAcc.Length; i++)
                { Console.WriteLine($"{IMessage.serviceNum} {i}\t\t: {name[i].ToUpper()}"); }
            }
            else if (serviceName_wr.IsAlive)
            {
                Console.WriteLine($"{IMessage.serviceNum} 0\t\t: {serviceName.ToUpper()}");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{IMessage.noService}");
            }
        }

      
        public static string TemplateReturnServiceIndex(string msgWhereToDoWhat)
        {
            Console.Write($"\n{msgWhereToDoWhat}");
            return Console.ReadLine();
        }


        public static void TemplateDisplayNothing(string _) { }
       
        public static string TemplateReturnUrsIndex(string msgWhereToDoWhat) {
            Console.WriteLine($"{msgWhereToDoWhat}");
            return Console.ReadLine(); 
        }
        
        public static bool TemplateBoolOption1(string msgMoreElementToChange)
        {
                Console.WriteLine($"\n{msgMoreElementToChange}\n{IMessage.option1Yes}");
                if ("1" == Console.ReadLine()) { return true; } else { return false; }
        }


        public static void TemplateDeleteUsr(string serviceIndex)
        {
            Console.Write($"\n{IMessage.enterUsrNum}");
            string usrIndex = Console.ReadLine();

            serviceAcc[Convert.ToInt32(serviceIndex)].usr.RemoveAt(Convert.ToInt32(usrIndex));
            serviceAcc[Convert.ToInt32(serviceIndex)].psw.RemoveAt(Convert.ToInt32(usrIndex));
            serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID.RemoveAt(Convert.ToInt32(usrIndex)); //På et tidspunkt vil globalID nå bufferoverflow og programmet vil crashe, fordi globalID ikke bliver nulstillet eller resused ved sletning af en bruger
        }


        public static void TemplateChangeServiceName(string serviceIndex)
        {
            Console.Write($"{IMessage.enterNewServiceName}");
            name[Convert.ToInt32(serviceIndex)] = Console.ReadLine();
        }

        

        public static void TemplateAddUsr(string serviceIndex)
        {
            try
            {
                bool bol;
                do
                {
                    bol = false;
                    Console.Clear();
                    Console.Write($"Service {name[Convert.ToInt32(serviceIndex)].ToUpper()}\n{IMessage.addUrsname}");
                    serviceAcc[Convert.ToInt32(serviceIndex)].usr.Add(Console.ReadLine());
                    Console.Write($"{IMessage.addPsw}");
                    serviceAcc[Convert.ToInt32(serviceIndex)].psw.Add(Console.ReadLine());
                    serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID.Add(counterGlobalUsrID);
                    serviceAcc[Convert.ToInt32(serviceIndex)].localUsrID.Add(counterGlobalUsrID);
                    counterGlobalUsrID++;
                    bol = TemplateBoolOption1(IMessage.anyMoreUsrnameToBeAdded);
                } while (bol);
            }
            catch (Exception e) { IMessage.ExceptionMessage(e); }
        }

        public static void TemplateChangeUrsname(string serviceIndex)
        {
            Console.Write($"\n{IMessage.enterUsrNum}");
            string usrIndex = Console.ReadLine();
            Console.Write($"\n{IMessage.enterNewUsrname}");
            serviceAcc[Convert.ToInt32(serviceIndex)].usr[Convert.ToInt32(usrIndex)] = Console.ReadLine();
        }

       
        public static void TemplateChangePsw(string serviceIndex, string usrIndex)
        {
            

            Console.Write(IMessage.enterNewPsw);
            serviceAcc[Convert.ToInt32(serviceIndex)].psw[Convert.ToInt32(usrIndex)] = Console.ReadLine();


            for (int i = 0; i < serviceAcc.Length; i++)
            {
                for (int j = 0; j < serviceAcc[i].usr.Count; j++)
                {
                    if (serviceAcc[i].globalUsrID[j] == serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID[Convert.ToInt32(usrIndex)])
                    {
                        serviceAcc[i].psw[j] = serviceAcc[Convert.ToInt32(serviceIndex)].psw[Convert.ToInt32(usrIndex)];
                        Console.WriteLine($"Flere servicebrugere er sammekædet \t: Kode for service {CService.name[i].ToUpper()}, bruger {serviceAcc[i].usr[j].ToUpper()} er blevet ændret.");
                    }
                }
            }
        }

        public static void TemplateDisplayingUsrnamesAndPsw(string serviceIndex)
        {
            Console.Clear();
            Console.WriteLine($"{IMessage.service}\t: {name[Convert.ToInt32(serviceIndex)].ToUpper()}\n");
            for (int j = 0; j < serviceAcc[Convert.ToInt32(serviceIndex)].usr.Count; j++)
            {
                Console.WriteLine(
                    $"{IMessage.globalUsrIDNum} {serviceAcc[Convert.ToInt32(serviceIndex)].globalUsrID[j]}\n" +
                    $"{IMessage.usrNum} {j}\t: {serviceAcc[Convert.ToInt32(serviceIndex)].usr[j]}\n" +
                    $"{IMessage.pswNum} {j}\t: {serviceAcc[Convert.ToInt32(serviceIndex)].psw[j]}\n");
                    
                Console.WriteLine();
            }
        }

            public static void TemplateDisplayingAllUsrnamesAndPsw(string _)
        {
            Console.Clear();
            for (int i = 0; i < serviceAcc.Length; i++)
            {
                Console.WriteLine($"Service: {name[i].ToUpper()}\n");
                for (int j = 0; j < serviceAcc[i].usr.Count; j++)
                {
                    Console.WriteLine(
                        $"{IMessage.globalUsrIDNum} {serviceAcc[i].globalUsrID[j]}\n" +
                        $"{IMessage.usrNum} {j}\t: {serviceAcc[i].usr[j]}\n" +
                        $"{IMessage.pswNum} {j}\t: {serviceAcc[i].psw[j]}\n");
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine();
            }
        }

        public static void TemplateDeleteService(string serviceIndex)
        {
            CService.name.RemoveAt(Convert.ToInt32(serviceIndex));
            int indexToRemove = Convert.ToInt32(serviceIndex); //https://www.delftstack.com/howto/csharp/how-to-remove-element-of-an-array-in-csharp/
            CService.serviceAcc = CService.serviceAcc.Where((source, index) => index != indexToRemove).ToArray();
            CService.counterServiceAccLength--;
            CService.counterServiceAccIndex--;
        }

    }
}
