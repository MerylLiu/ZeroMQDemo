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

        public ZmqSocket _socket;

        public Form1(ZmqSocket socket)
        {
            _socket = socket;
            InitializeComponent();
        }

        Timer timer = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 3000;
            timer.Tick += (s, a) =>
            {
                var msg = "642|the zeromq" + new Random().Next();
                _socket.Send(msg, Encoding.GetEncoding("gb2312"));
            };
            timer.Start();
        }

    }
}
