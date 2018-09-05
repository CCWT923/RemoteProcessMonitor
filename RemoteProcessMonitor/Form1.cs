using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace RemoteProcessMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 记录日志
        private void WriteLog(string logString)
        {
            textBox1.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + logString + "\n";
        }
        #endregion

        //服务器端监听器
        TcpListener tcpListener = null;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        //一个客户端
        TcpClient remoteClient;
        /// <summary>
        /// 启动服务器端
        /// </summary>
        private void StartServer()
        {
            tcpListener = new TcpListener(ip, 19023);
            tcpListener.Start();
            WriteLog("服务已经启动……");
        }
        /// <summary>
        /// 等待一个客户端连接
        /// </summary>
        private async void WaitConnection()
        {
            //一直等待一个连接
            remoteClient = await tcpListener.AcceptTcpClientAsync();
            WriteLog(string.Format("来自{0}的客户端已连接。",remoteClient.Client.LocalEndPoint));
        }

        private void SendData()
        {
            using (NetworkStream networkStream = remoteClient.GetStream())
            {
                //缓存数据
                Byte[] buffer = new byte[2048];
                
            }
        }
    }
}
