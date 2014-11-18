using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    static class Program {
        [STAThread]

        static void Main() {
			AsynchronousSocketListener.StartListening ();
			Thread socketListener = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
			socketListener.IsBackground = true;
			socketListener.Start();
        }
    }
}
