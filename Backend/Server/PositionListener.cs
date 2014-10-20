using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class PositionListener
    {
        TcpListener serverSocket;
        TcpClient clientSocket;
        List<TcpClient> clientList;
        List<TcpListener> serverList;


        ~PositionListener()
        {
            // destructor. Cleans up
            try
            {
                foreach (TcpClient item in clientList)
                {
                    clientSocket.Close();
                }

                foreach (TcpListener item in serverList)
                {
                    serverSocket.Stop();
                }
            }
            catch (SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static Dictionary<string, List<DataPoint>> positionDict;

        public void Start(int port = 8000)
        {
            positionDict = new Dictionary<string, List<DataPoint>>();

            serverSocket = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);

            serverSocket.Start();
            System.Diagnostics.Debug.Write(">> " + "server started @ " + DateTime.Now.ToString() + " on port " + port); 

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                string clientIP = ClientToIP(clientSocket);
                positionDict.Add(clientIP, new List<DataPoint>());
                System.Diagnostics.Debug.Write(">> " + "new client " + clientIP);

                PositionListenerHandler client = new PositionListenerHandler();
                client.startClient(clientSocket);
            }
        }

        public static string ClientToIP(TcpClient client)
        {
            return ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
        }
    }
}
