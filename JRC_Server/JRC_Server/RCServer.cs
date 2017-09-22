using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JRC_Server
{
    public class RCServer
    {
        public string IP { get; set; }
        public int Port { get; set; }

        UdpClient _svr;

        public RCServer(string ip, int port)
        {
            IP = ip;
            Port = port;

            IPAddress ipaddr = IPAddress.Parse(IP);
            IPEndPoint ep = new IPEndPoint(ipaddr, Port);
            _svr = new UdpClient(ep);
            
            _svr.BeginReceive(udpReceiveCallback, _svr); //서버대기
        }
        

        void udpReceiveCallback(IAsyncResult ar)
        {
            UdpClient udpServer = ar.AsyncState as UdpClient;
            IPEndPoint remoteEndPoint = null;

            byte[] receiveBytes = null;

            try
            {
                receiveBytes = udpServer.EndReceive(ar, ref remoteEndPoint);
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
                        DoConnectRequest(remoteEndPoint.Address.ToString()); //클라이언트 IP 던져줌.
                        break;

                    case RCInfo.ImgPort:
                        break;

                    case RCInfo.EventPort:
                        break;

                }
            }
        }


        public delegate void MyEventHandler(object s, object e);
        public event MyEventHandler FireMsg;
        public event MyEventHandler ConnectRequest; //클라이언트가 연결 요청시 발생

        public void DoMsg(string str)
        {
            if (FireMsg != null)
            {
                FireMsg(null, str);
            }
        }

        public void DoConnectRequest(string remoteIP)
        {
            if (ConnectRequest != null)
            {
                ConnectRequest(null, remoteIP);
            }
        }

    }
}
