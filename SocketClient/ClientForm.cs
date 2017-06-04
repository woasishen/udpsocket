using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SocketServer;

namespace SocketClient
{
    public partial class ClientForm : Form
    {
        private readonly UdpClient _udpClient;
        private readonly IPAddress _remoteIp;

        public ClientForm()
        {
            InitializeComponent();
            var random = new Random();
            var port = random.Next(1001, 9999);
            
            _udpClient = new UdpClient(port);
            //获取本机可用IP地址
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipa in ips)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    _remoteIp = ipa;
                    break;
                }
            }
            Text = _remoteIp + @":" + port;
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
                }
                catch
                {
                    break;
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
            var iep = new IPEndPoint(_remoteIp, 8888);
            try
            {
                _udpClient.Send(bytes, bytes.Length, iep);
                AddItem(logListBox, $"向{iep}发送：{message}");
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

        private void ClearText(RichTextBox textBox)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    textBox.Text = string.Empty;
                });
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var myThread = new Thread(SendMessage) {IsBackground = true};
            myThread.Start(sendMsgRichTextBox.Text);
        }
    }
}
