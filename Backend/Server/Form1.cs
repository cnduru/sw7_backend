using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelServerStatus.Text = "Stopped.";
            labelData.Text = "0";
        }

        public void testmethod()
        {
            _df.ShowDialog();
        }
        DatalogForm _df;

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            DatalogForm df = new DatalogForm();
            _df = df;
            Thread thread = new Thread(new ThreadStart(testmethod));
            thread.IsBackground = true;
            thread.Start();
         
            PositionListener listener = new PositionListener(this, df);

            if (textBoxPort.Text == "")
            {
                Thread myNewThread = new Thread(() => listener.Start(8000));
                myNewThread.IsBackground = true;
                myNewThread.Start();
            }
            else
            {
                Thread myNewThread = new Thread(() => listener.Start(Convert.ToInt32(textBoxPort.Text)));
                myNewThread.IsBackground = true;
                myNewThread.Start();
            }

            labelServerStatus.Text = "Running on port " + (textBoxPort.Text == "" ? "8000" : "Running on port " + textBoxPort.Text);
        }

        private void buttonSendTestData_Click(object sender, EventArgs e)
        {
            Networking.SendData("Årh! Sig nu hvad i hedder, sig i elsker Mager!", "192.168.43.1");
        }
    }
}
