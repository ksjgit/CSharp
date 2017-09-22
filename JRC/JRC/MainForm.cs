using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace JRC
{
    public partial class MainForm : Form
    {
        string sip; //제어당하는 PC IP
        //int sport; //제어당하는 PC 포트

        string cip; //제어하는 PC IP

        Socket sock_reql; //제어 요청대기 소켓
        Socket sock_reqc; //제어 요청 소켓

        Server recvSvr; //수신 서버(UUP)
        UdpClient sendCl; //보내는 클라이언트

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txt_msg.Text += NetworkInfo.DefaultIP + System.Environment.NewLine;
            recvSvr = new Server(NetworkInfo.DefaultIP, NetworkInfo.SetupPort);
            recvSvr.FireMsg += RecvSvr_FireMsg;
            //Listen();
        }

        delegate void MyDele(string str);
        private void RecvSvr_FireMsg(string str)
        {
            if (this.InvokeRequired)
            {
                object[] objs = new object[1] { str };
                this.Invoke(new MyDele(RecvSvr_FireMsg), objs);
            }
            else
            {
                txt_msg.Text += str + System.Environment.NewLine;
            }

        }

        //제어 하는 쪽
        private void btn_setting_Click(object sender, EventArgs e) //제어할려고 요청
        {
            sip = txt_sip.Text;

            IPAddress ipaddr = IPAddress.Parse(sip);
            IPEndPoint ep = new IPEndPoint(ipaddr, NetworkInfo.SetupPort);
            sock_reqc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock_reqc.Connect(ep);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //제어 당하는 쪽..
        //제어요청 패킷 대기 (제어 당할려고 대기)
        public void Listen()
        {
            IPAddress ipaddr = IPAddress.Parse(NetworkInfo.DefaultIP);
            IPEndPoint ep = new IPEndPoint(ipaddr, NetworkInfo.SetupPort);
            sock_reql = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock_reql.Bind(ep);
            sock_reql.Listen(5); //back로그 큐 크기 설정
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            cip = txt_cip.Text;
            IPAddress ipaddr = IPAddress.Parse(cip);
            IPEndPoint svr = new IPEndPoint(ipaddr, NetworkInfo.SetupPort);

            string uid = "가나다라";
            byte[] uidBytes = Encoding.UTF8.GetBytes(uid);

            sendCl = new UdpClient();
            int s = sendCl.Send(uidBytes, uidBytes.Length, svr);
            sendCl.BeginReceive(udpReceiveCallback, sendCl);
        }

        void udpReceiveCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient udpSocket = ar.AsyncState as UdpClient;
                IPEndPoint remoteEndPoint = null;

                byte[] receiveBytes = udpSocket.EndReceive(ar, ref remoteEndPoint);

                string receiveData = Encoding.UTF8.GetString(receiveBytes);

                txt_msg.Text += receiveData + System.Environment.NewLine;

                //if (command.Length != 0)
                //{
                //switch (command[0].Trim())
                //{
                //    case "ACK":
                //        this.BeginInvoke(
                //            new MethodInvoker(delegate ()
                //            {
                //                this.listBox1.Items.Add("연결성공 : " + remoteEndPoint.Address.ToString() + " / " + remoteEndPoint.Port.ToString());
                //                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                //            }));
                //        break;

                //    case "CLLST": //클라이언트 목록
                //        this.BeginInvoke(new MethodInvoker(delegate () { listBox2.Items.Clear(); }));

                //        for (int i = 1; i < command.Length; i++)
                //        {
                //            string[] txt = command[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                //            //if (txt[0] == txt_id.Text.Trim()) continue;
                //            string tmp_str = txt[0] + " / " + txt[1] + "  / " + txt[2];
                //            this.BeginInvoke(new MethodInvoker(delegate () { listBox2.Items.Add(tmp_str); }));
                //        }
                //        break;

                //    case "DATA": //데이타
                //        string tmp_msg = command[1] + " / " + command[2] + "  / " + command[3];

                //        this.BeginInvoke(new MethodInvoker(delegate () { DisplayChat(0, tmp_msg); }));

                //        this.BeginInvoke(
                //            new MethodInvoker(delegate ()
                //            {
                //                this.listBox3.Items.Add(command[2] + " / " + remoteEndPoint.Address.ToString() + " / " + remoteEndPoint.Port.ToString());
                //                this.listBox3.SelectedIndex = this.listBox3.Items.Count - 1;
                //            }));
                //        break;

                //}
                //}

                udpSocket.BeginReceive(udpReceiveCallback, udpSocket);
            }
            catch { }
        }
    }
}
