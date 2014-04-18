using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeroMQ;

namespace WinFormServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (ZmqContext context = ZmqContext.Create())
            {
                using (ZmqSocket socket = context.CreateSocket(SocketType.PUB))
                {
                    socket.Bind("tcp://*:8585");

                        var msg = "642|the zeromq"+new Random().Next();
                        socket.Send(msg, Encoding.UTF8);

                        Console.WriteLine("Send message:{0}", msg);

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1(socket));
                }
            }
        }
    }
}
