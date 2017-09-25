using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace JRC_Client
{
    public partial class JRC_Client : Form
    {
        string sip; //서버IP
        string cip; //자기IP

        RCClient ListenCL; //서버와 메시지 주고 받을 클라이언트
        RCImgClient imgCL; //이미지 전송 클라이언트

        public JRC_Client()
        {
            InitializeComponent();
        }

        private void JRC_Client_Load(object sender, EventArgs e)
        {
            cip = RCInfo.MyIP;
            this.Text += " / " + cip;
        }

        private void btn_connect_Click(object sender, EventArgs e) //연결요청
        {
            sip = txt_sip.Text;

            ListenCL = new RCClient(cip, RCInfo.ListenPort, sip);
            ListenCL.FireMsg += ListenCL_FireMsg;

            ListenCL.SendMsg("CONNECT_REQ");
        }

        delegate void MyEventDele(object s, object e);
        private void ListenCL_FireMsg(object s, object e)
        {
            if (this.InvokeRequired)
            {
                object[] objs = new object[2] { s, e };
                this.Invoke(new MyEventDele(ListenCL_FireMsg), objs);
            }
            else
            {
                txt_msg.Text += (string)e + System.Environment.NewLine;
            }
        }

        private void btn_sendimg_Click(object sender, EventArgs e)
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            //Rectangle rect = new Rectangle(0,0,Screen.PrimaryScreen.Bounds.Width/4, Screen.PrimaryScreen.Bounds.Height/4);

            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                //gr.DrawRectangle(new Pen(Color.Yellow), 10, 10, 100, 100);
                gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            }

            ListenCL.SendImage(bmp);
        }

        private void bnt_sendmsg_Click(object sender, EventArgs e)
        {
            ListenCL.SendMsg(txt_chat.Text);
        }
    }
}
