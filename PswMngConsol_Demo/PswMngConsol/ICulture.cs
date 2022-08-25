using System.Globalization;

namespace PswMngConsol
{
    interface ICulture
    {
        public static void DaDk()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-Dk");
        }
        public static void EnGb()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Gb");
        }
        public static void EnUs()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
        }

    }
}
