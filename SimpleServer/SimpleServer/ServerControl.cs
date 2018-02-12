using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleServer
{
    class ServerControl
    {
        private Socket serverSocket;
        public ServerControl()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        }

        public void Start()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any,12321));
            serverSocket.Listen(10);
            Console.WriteLine("服务器启动成功");
            Thread threadAccept = new Thread(Accept);
            threadAccept.IsBackground = true;
        }

        public void Accept()
        {
            Socket client = serverSocket.Accept();
            IPEndPoint point = client.RemoteEndPoint as IPEndPoint;
            Console.WriteLine(point.Address + "【" + point.Port + "】连接成功");
            Thread threadreceive = new Thread(Receive);
            threadreceive.IsBackground = true;
            threadreceive.Start(client);
            Accept();
        }

        private void Receive(object obj)
        {
            Socket client = obj as Socket;
            IPEndPoint point = client.RemoteEndPoint as IPEndPoint;
            try
            {
                byte[] msg = new byte[1024];
                int msgLen = client.Receive(msg);
                Console.WriteLine(point.Address + "【" + point.Port + "】" + Encoding.UTF8.GetString(msg, 0, msgLen));
                client.Send(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(msg,0,msgLen)+"楼上说得对"));
                Receive(client);
            }
            catch
            {
                Console.WriteLine(point.Address + "【" + point.Port + "】断开");
            }
        }
    }
}
