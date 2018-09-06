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
using System.Threading;

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
            MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + logString);
        }
        #endregion

        //服务器端监听器
        TcpListener tcpListener = null;
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        int port = 19023;
        //一个客户端
        TcpClient remoteClient;
        /// <summary>
        /// 启动服务器端
        /// </summary>
        private void StartServer()
        {
            tcpListener = new TcpListener(ip, port);
            tcpListener.Start();
            WriteLog("服务已经启动……");
        }
        /// <summary>
        /// 等待一个客户端连接
        /// </summary>
        private void WaitConnection()
        {
            //一直等待一个连接
            remoteClient = tcpListener.AcceptTcpClient();
            WriteLog(string.Format("来自{0}的客户端已连接。",remoteClient.Client.LocalEndPoint));
        }
        int BufferSize = 2048;
        private void SendData()
        {
            //建立和已连接的客户端之间的数据流
            using (NetworkStream streamToClient = remoteClient.GetStream())
            {
                //缓存数组
                Byte[] buffer = new byte[BufferSize];
                int readBytes = 0;
                try
                {
                    //锁定数据流，不允许同时操作
                    lock(streamToClient)
                    {
                        readBytes = streamToClient.Read(buffer, 0, BufferSize);
                    }
                    //向连接的客户端发送数据
                    lock(streamToClient)
                    {
                        streamToClient.Write(buffer, 0, buffer.Length);
                    }
                }
                catch(Exception ex)
                {
                    WriteLog(ex.Message);
                }

                //释放数据流和连接
                //streamToClient.Dispose();
                //remoteClient.Close();
            }
        }

        public void Process()
        {
            StartServer();
            WaitConnection();
        }

        private string GetByteString(byte[] buffer)
        {
            string str = Encoding.UTF8.GetString(buffer);
            return str;
        }

        private void Btn_StartServer_Click(object sender, EventArgs e)
        {
            //启动线程
            Thread thread = new Thread(new ThreadStart(Process));
            thread.Start();
            Btn_StartServer.Text = "运行中";
            Btn_StartServer.Enabled = false;
        }
    }
}
//https://www.cnblogs.com/jamesping/articles/2071932.html
//https://blog.csdn.net/jiangxinyu/article/details/7595512