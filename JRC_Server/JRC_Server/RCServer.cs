﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.IO;

namespace JRC_Server
{
    public class RCServer
    {
        public string IP { get; set; }
        public int Port { get; set; }

        UdpClient _svr;

        string cip; //요청한 클라이언트 IP

        public RCServer(string ip, int port)
        {
            IP = ip;
            Port = port;

            IPAddress ipaddr = IPAddress.Parse(IP);
            IPEndPoint ep = new IPEndPoint(ipaddr, Port);
            _svr = new UdpClient(ep);
            
            _svr.BeginReceive(udpReceiveCallback, _svr); //서버대기
        }
        
        public void SendMsg(string msg)
        {
            IPAddress ipaddr = IPAddress.Parse(cip);
            IPEndPoint svr = new IPEndPoint(ipaddr, RCInfo.ListenPort);
            
            byte[] uidBytes = Encoding.UTF8.GetBytes(msg);

            _svr.Send(uidBytes, uidBytes.Length, svr);
        }


        void udpReceiveCallback(IAsyncResult ar)
        {
            UdpClient udpSocket = ar.AsyncState as UdpClient;
            IPEndPoint remoteEndPoint = null;

            byte[] receiveBytes = null;

            try
            {
                receiveBytes = udpSocket.EndReceive(ar, ref remoteEndPoint);
                cip = remoteEndPoint.Address.ToString();
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
                        ReceiveImage(receiveBytes, remoteEndPoint);
                        break;

                    case RCInfo.EventPort:
                        break;

                }
            }

            udpSocket.BeginReceive(udpReceiveCallback, udpSocket);
        }

        //RCInfo.ListenPort 를 통해서 들어온거
        void ReceiveMsg(byte[] receiveBytes, IPEndPoint ep)
        {
            string msg = Encoding.UTF8.GetString(receiveBytes);

            switch (msg)
            {
                case "CONNECT_REQ":
                    DoConnectRequest(ep.Address.ToString()); //클라이언트 IP 던져줌.
                    break;

                default:
                    DoConnectRequest(msg); //클라이언트 IP 던져줌.
                    break;
            }
        }

        void ReceiveImage(byte[] receiveBytes, IPEndPoint ep)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(receiveBytes, 0, (int)receiveBytes.Length); //메모리 스트림에 버퍼를 기록
            Bitmap bitmap = new Bitmap(ms);
            
            DoRecvedImage(bitmap); //클라이언트 IP 던져줌.
        }

        public delegate void MyEventHandler(object s, object e);
        public event MyEventHandler FireMsg;
        public event MyEventHandler ConnectRequest; //클라이언트가 연결 요청시 발생
        public event MyEventHandler RecvedImage; //클라이언트 이미지 받았을때..

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

        public void DoRecvedImage(Bitmap img)
        {
            if (RecvedImage != null)
            {
                RecvedImage(null, img);
            }
        }

    }
}
