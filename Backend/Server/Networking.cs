using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Networking
    {
        public static void SendData(string data, string ip, int port = 8080)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.SendTimeout = 1000;
                client.Connect(ip, port);
                NetworkStream stream_out = client.GetStream();

                // send data
                stream_out.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);

                // flush to make sure data has been sent
                stream_out.Flush();

                // clean up
                stream_out.Close();
                System.Windows.Forms.MessageBox.Show("Sent message.");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ooooops.. Something went wrong.");
            }
        }
    }
}
