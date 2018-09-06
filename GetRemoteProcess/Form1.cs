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

namespace GetRemoteProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        IPAddress remoteIp = null;
        int remotePort = 0;
        Thread t1;
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if(TextBox_RemoteAddr.Text == "")
            {
                TextBox_RemoteAddr.Text = "127.0.0.1";
            }
            if(Textbox_RemotePort.Text == "")
            {
                return;
            }

            remoteIp = IPAddress.Parse(TextBox_RemoteAddr.Text);
            remotePort = int.Parse(Textbox_RemotePort.Text);

            //启动线程
            t1 = new Thread(new ThreadStart(Connect));
            t1.Start();
        }

        /// <summary>
        /// 连接
        /// </summary>
        private void Connect()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(remoteIp, remotePort);
                if(client.Connected)
                {
                    MessageBox.Show("连接上服务器！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
