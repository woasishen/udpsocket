using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class ServerForm : Form
    {
        private readonly UdpClient _udpClient = new UdpClient(8888);
        private readonly IPAddress _remoteIp;
        private readonly List<IPEndPoint> _ports = new List<IPEndPoint>(); 

        public ServerForm()
        {
            InitializeComponent();
            //获取本机可用IP地址
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ipa in ips)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    _remoteIp = ipa;
                    break;
                }
            }
            Text += $"  当前Ip:{_remoteIp}  数字ip：{_remoteIp.Address}";

            var myThread = new Thread(ReceiveData) {IsBackground = true};
            myThread.Start();
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveData()
        {
            var remote = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    //关闭udpClient 时此句会产生异常
                    byte[] receiveBytes = _udpClient.Receive(ref remote);
                    string receiveMessage = Encoding.Unicode.GetString(
                        receiveBytes, 0, receiveBytes.Length);
                    AddItem(logListBox, $"来自{remote}:{receiveMessage}");
                    if (_ports.Contains(remote))
                    {
                        continue;
                    }
                    _ports.Add(remote);
                    HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                        this,
                        tempPort =>
                        {
                            var tempRadioButton = new RadioButton
                            {
                                Text = tempPort.ToString(),
                                Tag = tempPort,
                                Dock = DockStyle.Top
                            };
                            connectedClientPanel.Controls.Add(tempRadioButton);
                            tempRadioButton.BringToFront();
                        },
                        remote);
    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            var message = (string)obj;
            byte[] bytes = Encoding.Unicode.GetBytes(message);
            var remoteIp = (IPEndPoint) connectedClientPanel.Controls.OfType<RadioButton>().First(s => s.Checked).Tag;
            try
            {
                _udpClient.Send(bytes, bytes.Length, remoteIp);
                AddItem(logListBox, $"向{remoteIp}发送：{message}");
                ClearText(sendMsgRichTextBox);
            }
            catch (Exception ex)
            {
                AddItem(logListBox, "发送出错：" + ex.Message);
            }
        }

        private void AddItem(ListBox listBox, string txt)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    listBox.Items.Add(txt);
                });
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var myThread = new Thread(SendMessage) {IsBackground = true};
            myThread.Start(sendMsgRichTextBox.Text);
        }

        private void ClearText(RichTextBox textBox)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    textBox.Text = string.Empty;
                });
        }
    }
}
