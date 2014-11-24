using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static class Dispatcher
    {
        /// <summary>
        /// Method dispatching XML instruction to the right component and returns a status XML string
        /// </summary>
        public static string Dispatch(string xml)
        {
            if (xml.Contains("<Login>"))
            {
                // todo: this string should be sent back to the android client
                string authStatus = XMLhandler.AuthenticateLogin(xml);
                return authStatus;
            }
            else
            {
                // no tag matched a known dispatch instruction
                return @"<Error>Message not understood</Error>";
            }
        }
    }
}
