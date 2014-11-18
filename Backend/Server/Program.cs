using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main() {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Server setup form
            //var form1 = new Form1();
            //form1.Show();
			AsynchronousSocketListener.StartListening ();
			/*Thread t = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
			t.IsBackground = true;
			t.Start();
			Console.WriteLine ("listening started...");*/


			//Application.Run();
        }
    }
}
