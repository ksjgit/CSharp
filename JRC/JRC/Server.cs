using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JRC
{
    public class Server
    {
        public string IP { get; set; }
        public int Port { get; set; }
        
        UdpClient svr;

        public Server(string ip, int port)
        {
            IP = ip;
            Port = port;

            IPAddress ipaddr = IPAddress.Parse(IP);
            IPEndPoint ep = new IPEndPoint(ipaddr, Port);
            svr = new UdpClient(ep);

            Start();
        }

        public delegate void MyEventHandler(string str);
        public event MyEventHandler FireMsg;

        public void DoMsg(string str)
        {
            if (FireMsg != null)
            {
                FireMsg(str);
            }
        }

        public void Start()
        {
            //DoMsg("서버대기중");
            svr.BeginReceive(udpReceiveCallback, svr);

            //ThreadPool.QueueUserWorkItem((WaitCallback)pingCallback);
        }

        void udpReceiveCallback(IAsyncResult ar)
        {
            try
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
                    //DoMsg("A" + ex.ToString());
                }

                if (receiveBytes != null)
                {
                    string clientID = Encoding.UTF8.GetString(receiveBytes);

                    DoMsg(clientID);

                    //DoMsg("CLCON / " + clientID + " / " + remoteEndPoint.Address.ToString() + " / " + remoteEndPoint.Port);

                    //if (_ipList.ContainsKey(clientID) == false)
                    //{
                    //    _ipList.Add(clientID, remoteEndPoint);
                    //}
                    //else
                    //{
                    //    _ipList[clientID] = remoteEndPoint;
                    //}

                    //bool sent = false;
                    
                    //if (sent == false)
                    //{
                    //    byte[] sentBytes = Encoding.UTF8.GetBytes("ACK/");
                    //    udpServer.BeginSend(sentBytes, sentBytes.Length, remoteEndPoint, udpSendCallback, udpServer);
                    //}

                    //OutputIPList();
                }

                udpServer.BeginReceive(udpReceiveCallback, udpServer);
            }
            catch (Exception ex)
            {
                DoMsg("1" + ex.ToString());
            }
        }
    }
}
