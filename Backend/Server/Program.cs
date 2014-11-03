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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Server setup form
            var form1 = new Form1();
            form1.Show();
            //form2.InitializeTestData(MakeTestData());

            //Run live test data
            //Thread thread = new Thread(form2.RunTestData);
            //thread.Start();
            Application.Run();
        }

        //Creates test data
        private static List<Connection> MakeTestData() {
            List<Connection> testConnections = new List<Connection>();

            testConnections.Add(new Connection(1234, 12));
            testConnections.Add(new Connection(9876, 30));
            testConnections.Add(new Connection(2468, 2));
            testConnections.Add(new Connection(1357, 7));

            return testConnections;
        }
    }
}
