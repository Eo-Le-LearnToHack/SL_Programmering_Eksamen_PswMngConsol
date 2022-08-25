using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class CPerson
    {
        public CPerson(string hashString, string salt, string pswTip, string creationDateTime)
        {
            HashString = hashString;
            Salt = salt;
            PswTip = pswTip;
            CreationDateTime = creationDateTime;
        }

        public string HashString { get; set; }
        public string Salt { get; set; }
        public string PswTip { get; set; }
        public string CreationDateTime { get; set; }

        //public Person(string firstName, string lastName, string url)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Url = url;
        //}

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Url { get; set; }
    }
}
