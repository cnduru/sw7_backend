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

        public void Start()
        {
            int port = 4444;
            serverSocket = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);

            serverSocket.Start();
            Console.WriteLine(">> " + "server started @ " + DateTime.Now.ToString() + " on port " + port); 

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(">> " + "new client " + ClientToIP(clientSocket));

                PositionListenerHandler client = new PositionListenerHandler();
                client.startClient(clientSocket);
            }
        }

        private string ClientToIP(TcpClient client)
        {
            return ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
        }
    }
}
