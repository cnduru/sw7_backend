using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class PositionListenerHandler
    {
        TcpClient clientSocket;
        string clNo;

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
    }
}
