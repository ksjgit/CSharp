using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Drawing;
using System.IO;

namespace 원격제어
{
    /// <summary>
    /// 이미지 수신 서버
    /// </summary>
    public class ImageServer
    {
        Socket lis_sock; //Listen 소켓
        Thread accept_thread = null;

        /// <summary>
        /// 이미지 수신 이벤트
        /// </summary>
        public event RecvImageEventHandler RecvedImage = null;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ip">로컬 IP</param>
        /// <param name="port">포트</param>
        public ImageServer(string ip, int port)
        {
            //EndPoint와 소켓 결합
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //소켓생성
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);

            lis_sock.Listen(5); //back로그 큐 크기 설정

            
        }

        void AcceptLoop() //연결 요청을 대기하고 수락하는 AcceptLoop 메서드를 구현합시다
        {
            try
            {
                while (lis_sock != null) //클라이언트 연결 요청을 대기하고 수락하는 부분은 무한 반복합니다.
                {
                    Socket do_sock = lis_sock.Accept();
                    Receive(do_sock); //do_sock로 이미지 수신
                }
            }
            catch
            {
                Close();
            }
        }

        void Receive(Socket dosock) //작업 소켓에서 이미지를 수신하는 Receive 메서드를 구현합시다
        {
            byte[] lbuf = new byte[4]; //이미지 길이를 수신할 버퍼
            dosock.Receive(lbuf); //이미지 길이 수신

            int len = BitConverter.ToInt32(lbuf, 0); //수신한 버퍼의 내용을 정수로 변환
            byte[] buffer = new byte[len]; //이미지 길이만큼 버퍼 생성

            int trans = 0;
            while (trans < len)
            {
                trans += dosock.Receive(buffer, trans, len - trans, SocketFlags.None); //이미지 수신
            }

            //이미지 수신 이벤트에 등록 개체가 있으면 이미지 수신 이벤트를 발생합니다.
            if (RecvedImage != null) //이미지 수신 이벤트가 존재하면
            {
                IPEndPoint iep = dosock.RemoteEndPoint as IPEndPoint;
                RecvImageEventArgs e = new 원격제어.RecvImageEventArgs(iep, ConvertBitmap(buffer));
                RecvedImage(this, e);
            }
            dosock.Close();
        }

        //수신한 이미지 버퍼를 이미지로 변환하는 ConvertBitmap 메서드를 구현합시다.
        /// <summary>
        /// 수신한 버퍼를 비트맵 이미지로 변환 메서드
        /// </summary>
        /// <param name="data">수신한 버퍼</param>
        /// <returns>비트맵 이미지</returns>
        public Bitmap ConvertBitmap(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, (int)data.Length); //메모리 스트림에 버퍼를 기록
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }

        public void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
