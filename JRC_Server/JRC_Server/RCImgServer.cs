using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading;

namespace JRC_Server
{
    public class RCImgServer
    {
        public string IP { get; set; }
        public int Port { get; set; }
        
        Socket _svr; //Listener 
        Socket _acc; //클라이언트와 연결된 소켓

        public RCImgServer(string svrip, int port)
        {
            IP = svrip;
            Port = port;
        }

        public void StartListening()
        {
            IPAddress ipaddr = IPAddress.Parse(IP);
            IPEndPoint ep = new IPEndPoint(ipaddr, Port);
            _svr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _svr.Bind(ep);
                _svr.Listen(10);

                while (true)
                {
                    _svr.BeginAccept(new AsyncCallback(AcceptCallback), _svr);
                }

            }
            catch
            {

            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            //_acc = (ar.AsyncState as Socket).EndAccept(ar);
            //_acc.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

            _acc = (ar.AsyncState as Socket).EndAccept(ar);
            _acc.BeginAccept(imgReceiveCallback, _acc);
        }

        void imgReceiveCallback(IAsyncResult ar)
        {

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] sizeBuf = new byte[4];

                        _acc.Receive(sizeBuf, 0, sizeBuf.Length, 0);

                        int size = BitConverter.ToInt32(sizeBuf, 0);
                        MemoryStream ms = new MemoryStream();

                        while (size > 0)
                        {
                            byte[] buffer;
                            if (size < _acc.ReceiveBufferSize)
                                buffer = new byte[size];
                            else
                                buffer = new byte[_acc.ReceiveBufferSize];

                            int rec = _acc.Receive(buffer, 0, buffer.Length, 0);

                            size -= rec;

                            ms.Write(buffer, 0, buffer.Length);
                        }

                        ms.Close();

                        byte[] data = ms.ToArray();

                        ms.Dispose();
                    }
                    catch
                    {
                        break;
                    }
                }
            }).Start();
           
        }
    }
}
