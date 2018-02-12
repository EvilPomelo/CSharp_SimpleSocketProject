using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            ClientControl client = new ClientControl();
            client.Connect("127.0.0.1", 12321);
            //client.Connect("18.219.59.3", 12321);
            Console.WriteLine("请输入要发送的内容，输入quit退出");
            string msg = Console.ReadLine();
            while (msg!="quit")
            {
                client.Send(msg);
                msg = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
