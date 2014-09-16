using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend
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
                    Console.WriteLine(">> " + "data from " + PositionListener.ClientToIP(clientSocket) + ": " + dataFromClient.Replace('\n', ' '));
                    /*
                    rCount = Convert.ToString(requestCount);
                    serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(">> " + ex.ToString());
                }
            }
        }
    }
}
