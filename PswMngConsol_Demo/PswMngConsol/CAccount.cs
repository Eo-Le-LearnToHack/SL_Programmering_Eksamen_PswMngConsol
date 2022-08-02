using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    public abstract class CAccount //Abstract means the class can't be instantiated
    {
        public static List<string> pswTip = new();
        public static List<DateTime> pswDateTime = new();
    }
}
