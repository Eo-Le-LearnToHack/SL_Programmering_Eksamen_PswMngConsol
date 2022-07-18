using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class Account
    {
        public string Name { get; private set; }
        private string[] PswTip { get; set; }
        private string[] PswCreatedDateTime { get; set; }

        public string NameCreate()
        {
            //Name must be at least 10 character long
            Console.WriteLine("Opret ny adminKonto. " + Message.min10Length);
            Name = Validation.StringMinLength(10);

            //Name must contain at least 1 Uppercase and 1 lowercase character
            Console.WriteLine("Opret ny adminKonto. " + Message.min1Uppercase);
            Name = Validation.StringMinUppercase(1);

            //Name must contain at least 1 lowercase character
            Console.WriteLine("Opret ny adminKonto. " + Message.min1Lowercase);
            Name = Validation.StringMinLowercase(1);


            return Name;
        }


    }

    internal class Admin : Account
    {
        private string[] PswHashedWithSalt { get; set; }
        private string[] PswSalt { get; set; }
    }

    internal class Usr : Account
    {
        private string[] Psw { get; set; }
        public string[] Service { get; set; }
    }


}
