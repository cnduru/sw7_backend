using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    class PositionListener
    {
        TcpListener serverSocket;
        TcpClient clientSocket;
        List<TcpClient> clientList;
        List<TcpListener> serverList;


        ~PositionListener()
        {
            // destructor
            Console.WriteLine(" >> " + "Closing sockets..");

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

                Console.WriteLine(">> Done.");
                Console.Read();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(">> something went wrong.");
                Console.Read();
            }
        }

        public static Dictionary<string, List<DataPoint>> positionDict;

        public void Start()
        {
            positionDict = new Dictionary<string, List<DataPoint>>();
            int port = 4444;

            serverSocket = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);

            serverSocket.Start();
            Console.WriteLine(">> " + "server started @ " + DateTime.Now.ToString() + " on port " + port); 

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                string clientIP = ClientToIP(clientSocket);
                positionDict.Add(clientIP, new List<DataPoint>());
                Console.WriteLine(">> " + "new client " + clientIP);

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
