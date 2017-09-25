using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JRC_Server
{
    public partial class JRC_Server : Form
    {
        string sip;
        string cip;

        RCServer ListenSvr; //요청 및 메세지 주고받는 서버
        RCServer ImageSvr;  //이미지 받는 서버

        UdpClient connCL; //클라이언트 와 메세지 주고 받을 놈..

        public JRC_Server()
        {
            InitializeComponent();
        }

        private void JRC_Server_Load(object sender, EventArgs e)
        {
            sip = RCInfo.MyIP;
            txt_sip.Text = sip;
        }
        
        private void btn_listen_Click(object sender, EventArgs e)
        {
            ListenSvr = new RCServer(sip, RCInfo.ListenPort);
            ListenSvr.ConnectRequest += ListenSvr_ConnectRequest;

            txt_msg.Text += "서버 Start" + System.Environment.NewLine;

            ImageSvr = new RCServer(sip, RCInfo.ImgPort);
            ImageSvr.RecvedImage += ImageSvr_RecvedImage;
        }
        

        private void btn_reqaccept_Click(object sender, EventArgs e)
        {

            //ListenSvr.SendMsg("CONNECT_ACCEPT");

            cip = txt_cip.Text;

            IPAddress ipaddr = IPAddress.Parse(cip);
            IPEndPoint svr = new IPEndPoint(ipaddr, RCInfo.ListenPort);

            string uid = "CONNECT_ACCEPT";
            byte[] uidBytes = Encoding.UTF8.GetBytes(uid);

            connCL = new UdpClient();
            int s = connCL.Send(uidBytes, uidBytes.Length, svr);
            //connCL.BeginReceive(udpReceiveCallback, connCL);
        }

        delegate void MyEventDele(object s, object e);
        private void ListenSvr_ConnectRequest(object s, object e)
        {
            if(this.InvokeRequired)
            {
                object[] objs = new object[2] {s,e};
                this.Invoke(new MyEventDele(ListenSvr_ConnectRequest), objs);
            }
            else
            {
                txt_cip.Text = (string)e;
                txt_msg.Text += (string)e + System.Environment.NewLine;
            }
            
        }
        
        private void ImageSvr_RecvedImage(object s, object e)
        {
            if (this.InvokeRequired)
            {
                object[] objs = new object[2] { s, e };
                this.Invoke(new MyEventDele(ImageSvr_RecvedImage), objs);
            }
            else
            {
                pic1.Image = (Bitmap)e;
                //txt_cip.Text = (string)e;
                //txt_msg.Text += (string)e + System.Environment.NewLine;
            }
        }

    }
}
