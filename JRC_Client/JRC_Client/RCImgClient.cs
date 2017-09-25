using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace JRC_Client
{
    public class RCImgClient
    {
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }

        Socket _cl;
        
        public RCImgClient(string svrip, int port)
        {
            ServerIP = svrip;
            ServerPort = port;

            IPAddress ipaddr = IPAddress.Parse(ServerIP);
            IPEndPoint ep = new IPEndPoint(ipaddr, ServerPort);
            _cl =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _cl.Connect(ep);
        }

        public void SendImg(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);

            byte[] data = ms.GetBuffer();

            _cl.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
            _cl.Send(data);
        }
    }
}
