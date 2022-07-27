using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class Account
    {
        public static List<string> PswTip = new();
        public static List<DateTime> PswCreatedDateTime = new();
    }

    internal class Admin : Account
    {
        public static List<string> PswHashWithSalt = new();
        public static List<string> Salt = new();
    }

    internal class Service : Account
    {
        public string Name { get; set; }
        public static List<string> Psw = new();
        public static List<string> Usr = new();
    }

}
