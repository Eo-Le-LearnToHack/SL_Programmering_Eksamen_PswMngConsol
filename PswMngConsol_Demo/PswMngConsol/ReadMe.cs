/*********************
 * LIST OF REFERENCE *
 *********************
 *
 * Array, remove element:           https://www.delftstack.com/howto/csharp/how-to-remove-element-of-an-array-in-csharp/
 * Array, resize:                   https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
 * 
 * UserInput, Mask:                 https://www.youtube.com/watch?v=MSkFeb7HhiQ
 * 
 * Delegate, Action/Predicate/Func: Bogen om C#
 * 
 * Exception, e.message:            Bogen om C#
 * 
 * List, add item:                  Bogen om C#
 * List, remove item:               https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=net-6.0
 * 
 * Loop, For:                       Bogen om C#
 * Loop, Do:                        Bogen om C#
 * Loop, While:                     Bogen om C#
 * 
 * Class, Inheritance:              SmartLearning
 * Class, Abstract:                 https://www.youtube.com/watch?v=7SksH2hewzU
 * Class, Array:                    SmartLearning
 * 
 * Interface, Fields not allowed:   https://stackoverflow.com/questions/54242436/why-is-the-interface-showing-interfaces-cannot-contain-fields
 * 
 * Hash, compute and compare:       https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-6.0
 * Hash, simple encrypt/decrypt     https://stackoverflow.com/questions/9031537/really-simple-encryption-with-c-sharp-and-symmetricalgorithm
 * 
 * Memory, value vs reference:      Bogen om C#
 * Mouseclick:                      https://www.medo64.com/2013/05/console-mouse-input-in-c/
 * Mouseclick, solution example:    https://www.medo64.com/content/consolemouse.zip
 * 
 * Overload:                        SmartLearning
 * 
 * Password complexity:             https://docs.microsoft.com/en-us/dotnet/api/system.char?view=net-6.0
 * 
 * ref, apply changes to source :   linkedin.EssentialTraining
 * Record, vs Class :               https://josipmisko.com/posts/c-sharp-class-vs-record
 * 
 * Substring, simplify:             https://stackoverflow.com/questions/65256292/ide0057-substring-can-be-simplified
 * Substring, range operator:       https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges
 * System.Windows.Forms:            https://stackoverflow.com/questions/19707885/c-sharp-copy-to-clipboard
 * Unload, reload project:          https://stackoverflow.com/questions/38460253/how-to-use-system-windows-forms-in-net-core-class-library
 * Sendkeys, commands:              https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?redirectedfrom=MSDN&view=windowsdesktop-6.0
 * 
 * String, interpolated:            Bogen om C#
 *
 * \t, \n:                          Bogen om C#
 * 
 * Weakreference, IsAlive:          https://stackoverflow.com/questions/39351935/in-c-sharp-how-to-know-if-a-weak-referenced-object-is-going-to-be-garbage-collec
 * 
 * 
 * 
 * 
 * 
 * 
 * Developers words:
 * The project is divided into 
 * 3 classes - naming the prefix with capital C,
 * 8 interfaces - naming the prefix with capital I.
 * The classes CAccount and CAdmin are abstract class because it is not suppose to be instantiated.
 * The classes CAdmin and CService are inherited from the abstract class CAccount.
 * The class CService can be instantiated.
 * The two specialised classes both have their own fields and methods
 * All members in the interfaces are public static in order to call to them directly.
 * This is not best practice how to use interfaces but since this is a small personal program it makes the code easier for the developer to manage.
 * Delegates er blevet anvendt flittigt i CService for at reducere på antal metoder, idet der var mange metoder som havde mange fælles trin.
 * Ved brug af delegates kunne der oprette en master metode "DeleteOrChangeOrAddAnything" som anvender delegates som argumenter, dvs. master metoden tager andre metoder som argumenter.
 * Idet delegates er anvendt som argument er der ikke behov for at sætte delegates til null efter hver brug.
 * Delagtes reducerede ca. 200 linjer koder.
 * Ved efter tanke, efterhånden som flere og flere metoder bliver kaldt fra den samme master metode kan det virke uoverskueligt ved første øjekast, da master metoden tager mange argumenter.
 * IMessage samler alle skrivning til Console, derved reducerer på skrivefejl ved gentagelser eller rettelse flere steder i koden.
 * Idet tekstbeskederne er gemt centralt i IMessage gør det nemmere at finde og rette tekster ved behov.
 * The user data are not stored in a record type because I want it to immutable/unchangeable after creation.
 * The main master method has 5 overloads.
 * 
 * 
 * 
 * 
 * The master method which can contains all CService methods:
 *    //public static void MasterMethod(
        //    Func<string?> SetServiceName,

        //    Action<string> AddOrDisplayRefServiceName,
        //    Func<string?, string?, string?> ReturningServiceRefIndexOrPrintOutUrsnamesAndPsw, string msgWhereToDoWhatServiceRef, string msgEnterServiceNumRef,
        //    Action<string> DisplayOrNotDisplayRefUrsnameAndPsw,     
        //    Func<string?, string?, string?> ReturningUsrRefIndexOrPrintOutUrsnamesAndPsw, string msgWhereToDoWhatUsrRef, string msgEnterUsrNumRef,

        //    Predicate<string> BoolIfTrue, Action<string> ActionIfTrue,
           
        //    Action<string> AddOrDisplayServiceName,
        //    Func<string?, string?, string?> ReturningServiceIndexOrPrintOutUrsnamesAndPsw, string msgWhereToDoWhat, string msgEnterServiceNum,
        //    Action<string> DisplayOrNotDisplayUrsnameAndPsw,
        //    Func<string?, string?, string?> ReturningUsrIndexOrPrintOutUrsnamesAndPsw, string msgWhereToDoWhatUsr, string msgEnterUsrNum,

        //    Action<string, string, string, string> ActionToPerform,              
        //    Predicate<string> BoolOption, string msgElseYouWantToChange,
        //    Action<string> IncrementalServiceOrNot)
        //{
        //    try
        //    {
        //        string? serviceName = SetServiceName();                                          

        //        AddOrDisplayRefServiceName(serviceName);
        //        string? serviceRefIndex = ReturningServiceRefIndexOrPrintOutUrsnamesAndPsw(msgWhereToDoWhatServiceRef, msgEnterServiceNumRef);        //Returning serviceRefIndex
        //        DisplayOrNotDisplayRefUrsnameAndPsw(serviceRefIndex);                               //Displaying RefUsrnameAndPsw
        //        string? usrRefIndex = ReturningUsrRefIndexOrPrintOutUrsnamesAndPsw(msgWhereToDoWhatUsrRef, msgEnterUsrNumRef);                //returning usrRefIndex
        //        Console.WriteLine();

        //        if (BoolIfTrue(serviceName)) { ActionIfTrue(serviceName); }                         //delegate Predicate and delegate Action
        //        else
        //        {
        //            bool bol;
        //            do
        //            {
        //                bol = false;
        //                AddOrDisplayServiceName(serviceName);                                       //Do Nothing
        //                string? serviceIndex = ReturningServiceIndexOrPrintOutUrsnamesAndPsw(msgWhereToDoWhat, msgEnterServiceNum);      //Returning serviceIndex
        //                DisplayOrNotDisplayUrsnameAndPsw(serviceIndex);                             //Displaying UsrnameAndPsw
        //                string? usrIndex = ReturningUsrIndexOrPrintOutUrsnamesAndPsw(msgWhereToDoWhatUsr, msgEnterUsrNum);              //returning usrIndex

        //                ActionToPerform(serviceRefIndex, usrRefIndex,serviceIndex, usrIndex);                             //ACTION to perform
        //                bol = BoolOption(msgElseYouWantToChange);                                   //Loop or not...user choice
        //                IncrementalServiceOrNot(serviceName);                                       //Counter incremental or not
        //            } while (bol);
        //        }
        //    }
        //    catch (Exception e) { IMessage.ExceptionMessage(e); }
        //}
 * 
 * 
 * BUT this creates alot of repetation in the methods calling the master method. 
 * The master method was then dividing into overloads to remove the repetation, 
 * however the overloads contains some "overload" repetetion, which is much more prefer.
 * 
 * 
 *Youtuber brackeys C#
    //copy/paste: https://stackoverflow.com/questions/10140500/c-sharp-clipboard-direct-copy-paste
 *
 *
 * copy/paste: https://stackoverflow.com/questions/10140500/c-sharp-clipboard-direct-copy-paste
 * STAThreadAttribute: https://stackoverflow.com/questions/17762037/current-thread-must-be-set-to-single-thread-apartment-sta-error-in-copy-stri
 * 
 * 
 * 
 * Future work: //https://stackoverflow.com/questions/18291448/how-do-i-detect-keypress-while-not-focused
 */
