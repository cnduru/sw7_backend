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
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            
            PositionListener listener = new PositionListener();

            if (textBoxPort.Text == "")
            {
                Thread myNewThread = new Thread(() => listener.Start(8000));
                myNewThread.Start();
            }
            else
            {
                Thread myNewThread = new Thread(() => listener.Start(Convert.ToInt32(textBoxPort.Text)));
                myNewThread.Start();
            }

            labelServerStatus.Text = "Running on port " + (textBoxPort.Text == "" ? "8000" : "Running on port " + textBoxPort.Text);
        }
    }
}
