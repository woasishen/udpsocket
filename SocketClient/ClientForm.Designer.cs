namespace SocketClient
{
    partial class ClientForm
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
            this.logListBox = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendMsgRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // logListBox
            // 
            this.logListBox.BackColor = System.Drawing.Color.Black;
            this.logListBox.ForeColor = System.Drawing.Color.White;
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 12;
            this.logListBox.Location = new System.Drawing.Point(12, 12);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(534, 256);
            this.logListBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendButton.Location = new System.Drawing.Point(429, 285);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(117, 157);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendMsgRichTextBox
            // 
            this.sendMsgRichTextBox.Location = new System.Drawing.Point(12, 285);
            this.sendMsgRichTextBox.Name = "sendMsgRichTextBox";
            this.sendMsgRichTextBox.Size = new System.Drawing.Size(411, 157);
            this.sendMsgRichTextBox.TabIndex = 5;
            this.sendMsgRichTextBox.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 454);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendMsgRichTextBox);
            this.Controls.Add(this.logListBox);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox sendMsgRichTextBox;
    }
}

