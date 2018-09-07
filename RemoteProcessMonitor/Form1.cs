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
        private bool WaitConnection()
        {
            WriteLog("等待客户端连接……");
            //一直等待一个连接
            remoteClient = tcpListener.AcceptTcpClient();
            WriteLog(string.Format("来自{0}的客户端已连接。",remoteClient.Client.LocalEndPoint));
            return true ;
        }

        /// <summary>
        /// 获取网络流
        /// </summary>
        /// <returns></returns>
        private NetworkStream GetNetworkStream()
        {
            if(remoteClient.Connected)
            {
                return remoteClient.GetStream();
            }
            return null;
        }

        int BufferSize = 8192;
        NetworkStream streamToClient = null;

        private void SendData()
        {
            if(streamToClient == null)
            {
                streamToClient = GetNetworkStream();
            }

            //缓存数组
            Byte[] buffer = new byte[BufferSize];

            try
            {
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

        public void Process()
        {
            StartServer();
            WaitConnection();
        }
        /// <summary>
        /// 将byte数组转换为字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private string GetByteString(byte[] buffer)
        {
            string str = Encoding.UTF8.GetString(buffer);
            return str;
        }

        /// <summary>
        /// 字符串数组转为字节数组
        /// </summary>
        /// <param name="ItemsList"></param>
        /// <returns></returns>
        private byte[] GetByte(string[] ItemsList)
        {
            byte[] b;
            string str = "";
            foreach(string s in ItemsList)
            {
                str += s + "|";
            }
            b = Encoding.UTF8.GetBytes(str);
            return b;
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