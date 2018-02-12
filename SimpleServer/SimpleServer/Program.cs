using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ServerControl server = new ServerControl();
            server.Start();
            server.Accept();
        }
    }
}
