namespace GetRemoteProcess
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_RemoteAddr = new System.Windows.Forms.TextBox();
            this.Textbox_RemotePort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.TextBox_Info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // TextBox_RemoteAddr
            // 
            this.TextBox_RemoteAddr.Location = new System.Drawing.Point(87, 30);
            this.TextBox_RemoteAddr.Name = "TextBox_RemoteAddr";
            this.TextBox_RemoteAddr.Size = new System.Drawing.Size(166, 25);
            this.TextBox_RemoteAddr.TabIndex = 1;
            // 
            // Textbox_RemotePort
            // 
            this.Textbox_RemotePort.Location = new System.Drawing.Point(317, 30);
            this.Textbox_RemotePort.Name = "Textbox_RemotePort";
            this.Textbox_RemotePort.Size = new System.Drawing.Size(122, 25);
            this.Textbox_RemotePort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Location = new System.Drawing.Point(494, 23);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(100, 34);
            this.Btn_Connect.TabIndex = 4;
            this.Btn_Connect.Text = "连接";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // TextBox_Info
            // 
            this.TextBox_Info.Location = new System.Drawing.Point(15, 73);
            this.TextBox_Info.Multiline = true;
            this.TextBox_Info.Name = "TextBox_Info";
            this.TextBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Info.Size = new System.Drawing.Size(589, 331);
            this.TextBox_Info.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 416);
            this.Controls.Add(this.TextBox_Info);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Textbox_RemotePort);
            this.Controls.Add(this.TextBox_RemoteAddr);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_RemoteAddr;
        private System.Windows.Forms.TextBox Textbox_RemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.TextBox TextBox_Info;
    }
}

