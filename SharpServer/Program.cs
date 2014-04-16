using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpServer
{
    using ZeroMQ;

    public class Program
    {
        static void Main(string[] args)
        {
            using (ZmqContext context = ZmqContext.Create())
            {
                using (ZmqSocket socket = context.CreateSocket(SocketType.PUB))
                {
                    socket.Bind("tcp://*:8585");

                    while (true)
                    {
                        var msg = "test|the zeromq";
                        socket.Send(msg, Encoding.UTF8);

                        Console.WriteLine("Send message:{0}", msg);
                    }
                }
            }
        }
    }
}
