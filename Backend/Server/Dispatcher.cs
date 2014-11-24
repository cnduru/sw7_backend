using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Dispatcher
    {
        public void Dispatch(string xml)
        {
            if (xml.Contains("<Login>"))
            {
                // todo: this string should be sent back to the android client
                string authStatus = XMLhandler.AuthenticateLogin(xml);
            }
        }
    }
}
