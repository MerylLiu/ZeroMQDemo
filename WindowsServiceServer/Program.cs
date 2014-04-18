using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceServer
{
    using ZeroMQ;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun = new ServiceBase[1];

            using (ZmqContext context = ZmqContext.Create())
            {
                using (ZmqSocket socket = context.CreateSocket(SocketType.PUB))
                {
                    socket.Bind("tcp://*:8585");
                    servicesToRun[0] = new Service1(socket);
                    ServiceBase.Run(servicesToRun);
                }
            }
        }
    }
}
