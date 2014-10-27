﻿using System;
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
        Form1 _f;
        DatalogForm _df;
        int clientCnt = 0;

        public PositionListener(Form1 f, DatalogForm df)
        {
            _f = f;
            _df = df;
        }

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

        public void updateClients(string data)
        {
            MethodInvoker action = () => _f.labelData.Text = data;
            _f.BeginInvoke(action);
        }

        public void updateLog(string data)
        {
            MethodInvoker action = () => _df.richTextBoxLog.Text += '\n' + data;
            _df.BeginInvoke(action);
        }

        public void Start(int port = 8000)
        {
            positionDict = new Dictionary<string, List<DataPoint>>();

            serverSocket = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);

            serverSocket.Start();
            System.Diagnostics.Debug.Write(">> " + "server started @ " + DateTime.Now.ToString() + " on port " + port);
            updateLog(">> " + "server started @ " + DateTime.Now.ToString() + " on port " + port);
            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                clientCnt++;
                updateClients(clientCnt.ToString());
                string clientIP = ClientToIP(clientSocket);
                positionDict.Add(clientIP, new List<DataPoint>());
                System.Diagnostics.Debug.Write(">> " + "new client " + clientIP);

                PositionListenerHandler client = new PositionListenerHandler(_df);
                client.startClient(clientSocket);
            }
        }

        public static string ClientToIP(TcpClient client)
        {
            return ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
        }
    }
}
