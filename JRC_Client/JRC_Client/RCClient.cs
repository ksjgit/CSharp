using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace JRC_Client
{
    public class RCClient
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string ServerIP { get; set; }

        UdpClient _cl; //텍스트 & 이벤트 전송 용
        
        public RCClient(string ip, int port, string svrip)
        {
            IP = ip;
            Port = port;
            ServerIP = svrip;

            IPAddress ipaddr = IPAddress.Parse(IP);
            IPEndPoint ep = new IPEndPoint(ipaddr, Port);
            _cl = new UdpClient(ep);

            _cl.BeginReceive(udpReceiveCallback, _cl); //서버대기
        }

        public void SendMsg(string msg)
        {
            IPAddress ipaddr = IPAddress.Parse(ServerIP);
            IPEndPoint svr = new IPEndPoint(ipaddr, RCInfo.ListenPort);

            byte[] uidBytes = Encoding.UTF8.GetBytes(msg);

            _cl.Send(uidBytes, uidBytes.Length, svr);
        }


        public void SendImage(Image img)
        {
            IPAddress ipaddr = IPAddress.Parse(ServerIP);
            IPEndPoint ep = new IPEndPoint(ipaddr, RCInfo.ImgPort); //이미지 포트 사용

            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            
            byte[] data = ms.GetBuffer();
            
            //int packet_size = data.Length / 65535;

            try
            {
                //for (int i = 0; i <= packet_size; i++)
                //{
                //    _cl.Send(data, data.Length, ep);
                //}
                _cl.Send(data, data.Length, ep);
            }
            catch (SocketException ex)
            {
                DoMsg(ex.SocketErrorCode.ToString() + " /// " + ex.ToString());
            }
            
        }

        void udpReceiveCallback(IAsyncResult ar)
        {
            UdpClient udpSocket = ar.AsyncState as UdpClient;
            IPEndPoint remoteEndPoint = null;

            byte[] receiveBytes = null;

            try
            {
                receiveBytes = udpSocket.EndReceive(ar, ref remoteEndPoint);
            }
            catch (SocketException ex)
            {
                DoMsg(ex.ToString());
            }

            if (receiveBytes != null)
            {
                switch (Port)
                {
                    case RCInfo.ListenPort:
                        ReceiveMsg(receiveBytes, remoteEndPoint);
                        break;

                    case RCInfo.ImgPort:
                        break;

                    case RCInfo.EventPort:
                        break;

                }
            }

            udpSocket.BeginReceive(udpReceiveCallback, udpSocket);
        }

        void ReceiveMsg(byte[] receiveBytes, IPEndPoint ep)
        {
            string msg = Encoding.UTF8.GetString(receiveBytes);

            switch (msg)
            {
                case "CONNECT_ACCEPT":
                    DoMsg("CONNECT_ACCEPT"); //클라이언트 IP 던져줌.
                    break;
            }


        }

        public delegate void MyEventHandler(object s, object e);
        public event MyEventHandler FireMsg;

        public void DoMsg(string str)
        {
            if (FireMsg != null)
            {
                FireMsg(null, str);
            }
        }
    }
}
