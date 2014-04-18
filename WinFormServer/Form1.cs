using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZeroMQ;

namespace WinFormServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, a) =>
            {
                using (ZmqContext context = ZmqContext.Create())
                using (ZmqSocket socket = context.CreateSocket(SocketType.SUB))
                {
                    socket.Connect("tcp://127.0.0.1:8585");
                    socket.Subscribe(Encoding.Default.GetBytes("test"));

                    while (true)
                    {
                        string rep = socket.Receive(Encoding.UTF8);
                        Console.WriteLine("this is :{0}",rep);
                    }
                }
            };
            timer.Start();
        }

    }
}
