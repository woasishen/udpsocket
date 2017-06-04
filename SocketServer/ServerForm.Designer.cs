namespace SocketServer
{
    partial class ServerForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.connectedClientPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.sendMsgRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectedClientPanel
            // 
            this.connectedClientPanel.AutoScroll = true;
            this.connectedClientPanel.Location = new System.Drawing.Point(12, 26);
            this.connectedClientPanel.Name = "connectedClientPanel";
            this.connectedClientPanel.Size = new System.Drawing.Size(144, 371);
            this.connectedClientPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "已连接的客户端：";
            // 
            // logListBox
            // 
            this.logListBox.BackColor = System.Drawing.Color.Black;
            this.logListBox.ForeColor = System.Drawing.Color.White;
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 12;
            this.logListBox.Location = new System.Drawing.Point(162, 26);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(364, 208);
            this.logListBox.TabIndex = 2;
            // 
            // sendMsgRichTextBox
            // 
            this.sendMsgRichTextBox.Location = new System.Drawing.Point(162, 240);
            this.sendMsgRichTextBox.Name = "sendMsgRichTextBox";
            this.sendMsgRichTextBox.Size = new System.Drawing.Size(241, 157);
            this.sendMsgRichTextBox.TabIndex = 3;
            this.sendMsgRichTextBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendButton.Location = new System.Drawing.Point(409, 240);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(117, 157);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(538, 409);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendMsgRichTextBox);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectedClientPanel);
            this.Name = "ServerForm";
            this.Text = "服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel connectedClientPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.RichTextBox sendMsgRichTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}

