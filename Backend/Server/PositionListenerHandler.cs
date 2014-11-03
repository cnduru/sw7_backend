using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class PositionListenerHandler
    {
        TcpClient clientSocket;
        string clNo;
        DatalogForm _dform;
        Form2 _f2;

        public PositionListenerHandler(DatalogForm dform, Form2 f2)
        {
            _dform = dform;
            _f2 = f2;
        }

        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(HandleData);
            ctThread.Start();
        }


        private void HandleData()
        {
            int datasize = 100;
            byte[] bytesFrom = new byte[datasize];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;

            while ((true))
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, datasize);//(int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf('\0'));
                    System.Diagnostics.Debug.Write(">> " + "data from " + PositionListener.ClientToIP(clientSocket) + ": " + dataFromClient.Replace('\n', ' '));
                    updateLog(">> " + "data from " + PositionListener.ClientToIP(clientSocket) + ": " + dataFromClient.Replace('\n', ' '));

                    //Store received data in list. Data from start of list is: Lat, Lng, IMEI, Signal
                    List<string> clientData = new List<string>();
                    clientData = dataFromClient.Split(';').ToList();
                    Connection connection = new Connection(Convert.ToInt64(clientData[0]), Convert.ToInt32(clientData[1]));
                    _f2.AddToDataGrid(connection);

                    /* code for sending stuff.. currently not needed
                    rCount = Convert.ToString(requestCount);
                    serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);*/
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(">> " + ex.ToString());
                }
            }
        }


        public void updateLog(string data)
        {
            MethodInvoker action = () => _dform.richTextBoxLog.Text += '\n' + data;
            _dform.BeginInvoke(action);
        }
    }
}
