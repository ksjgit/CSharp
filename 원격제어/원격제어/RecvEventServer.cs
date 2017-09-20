using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace 원격제어
{
    /// <summary>
    /// 원격 제어 이벤트 수신 서버
    /// </summary>
    public class RecvEventServer
    {
        Socket lis_sock;

        /// <summary>
        /// 원격 제어 이벤트 수신하였음을 알리는 이벤트
        /// </summary>
        public event RecvKMEEventHandler RecvedKMEvent = null;
        Thread th;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ip">로컬 IP</param>
        /// <param name="port">포트</param>
        public RecvEventServer(string ip, int port)
        {
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock.Bind(ep);
            lis_sock.Listen(5);

            ThreadStart ts = new ThreadStart(AcceptLoop);
            th = new Thread(ts);
            th.Start();
        }

        /// <summary>
        /// 비동기로 수신하기 위한 대리자
        /// </summary>
        /// <param name="dosock"></param>
        public delegate void ReceiveDele(Socket dosock);

        void AcceptLoop()
        {
            Socket do_sock;

            ReceiveDele rld = new ReceiveDele(Receive); //수신 대리자 개체 생성
            try
            {
                while (true)
                {
                    do_sock = lis_sock.Accept();
                    //수신 대리자 개체의 BeginInvoke 호출로 메시지 수신을 비동기로 처리하세요.
                    rld.BeginInvoke(do_sock, null, null); //비동기로 수신
                }
            }
            catch
            {
                //예외가 발생하면 닫습니다. 
                //상품화 수준으로 작성하시려면 스레드로 작성하는 부분을 비동기 방식으로 변경하고 다양한 테스트 조건에서 발생하는 버그들을 수정하셔야 합니다.
                Close();
            }
        }

        void Receive(Socket dosock)
        {
            //먼저 크기가 9인 버퍼를 생성하여 메시지를 수신합니다. 
            //클라이언트 측에서는 전송할 메시지 종류에 관계없이 고정길이 버퍼에 데이터를 설정하여 보내게 구현하였습니다.
            byte[] buffer = new byte[9]; //수신할 버퍼 생성

            int n = dosock.Receive(buffer); //메세지수신

            //수신 이벤트를 구독 요청한 개체가 있다면 이벤트 인자를 생성하여 수신 이벤트를 게시하세요.
            if (RecvedKMEvent != null) //수신이벤트 구독자가 있을때
            {
                RecvKMEEventArgs e = new 원격제어.RecvKMEEventArgs(new 원격제어.Meta(buffer));
                RecvedKMEvent(this, e);
            }
            dosock.Close();
        }

        void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
