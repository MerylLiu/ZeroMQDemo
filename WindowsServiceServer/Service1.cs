using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsServiceServer
{
    using System.Timers;
    using ZeroMQ;

    public partial class Service1 : ServiceBase
    {
        readonly Timer _timer = new Timer();
        ZmqSocket _socket;

        public Service1(ZmqSocket socket)
        {
            _timer.Interval = 3000;
            _socket = socket;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
            _timer.Elapsed += (s, a) => 
                _socket.Send("642|测试消息" + new Random().Next(), Encoding.GetEncoding("gb2312"));
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
