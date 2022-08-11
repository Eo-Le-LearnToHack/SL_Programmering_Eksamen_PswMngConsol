using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PswMngConsol
{
    internal class ISendkeys
    {

        public static void MySendKeys(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string myText = text.Substring(i, 1);
                SendKeys.SendWait(myText);
                Thread.Sleep(100);
            }
        }

        public static void MyCopyPaste(string text)
        {
            Clipboard.SetText(text);
            string myText = Clipboard.GetText();
            SendKeys.SendWait("^V"); //ctr+V


        }
    }
}
