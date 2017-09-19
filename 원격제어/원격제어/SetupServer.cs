using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace 원격제어
{
    //원격제어 요청을 수신
    //서버 측은 연결 요청을 수신하기 위한 Listening 소켓을 생성하는 부분과 연결 요청을 대기하고 수용하는 부분으로 나눌 수 있습니다. 
    //특히 연결 요청을 대기하고 수용하는 부분은 무한 반복할 것으로 블로킹을 막기 위해 여기에서는 스레드를 사용할게요.

    /// <summary>
    /// 연결 요청 수신 서버 클래스 - 정적 클래스
    /// </summary>
    public static class SetupServer
    {
        static Socket lis_sock; //연결요청 수신 Listen 소켓
        static Thread accept_thread = null; //연결요청 허용 스레드

        /// <summary>
        /// 연결 요청 수신 이벤트 핸들러
        /// </summary>
        static public event RecvRCInfoEventHandler RecvedRCInfo = null; //연결요청 수신 이벤트 핸들러
        
        /// <summary>
        /// 연결 요청 수신 서버 시작 메서드
        /// </summary>
        /// <param name="ip">서버의 IP주소</param>
        /// <param name="port">포트</param>
        static public void Start(string ip, int port)
        {
            //로컬호스트의 IPEndPoint 개체생성
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            lis_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //연결요청 수신 Listen 소켓생성

            lis_sock.Bind(ep); //소켓과 IPEndPoint 결합
            lis_sock.Listen(1); //Back로그 큐 크기 설정 

            ThreadStart ts = new ThreadStart(AcceptLoop); //연결요청 허용 스레드 진입점 개체 생성
            accept_thread = new Thread(ts); //연결요청 허용 스레드 생성
            accept_thread.Start(); //스래드 시작
        }

        static void AcceptLoop() //연결 요청을 대기하는 메서드를 작성합시다
        {
            try
            {
                while(true)
                {
                    Socket do_sock = lis_sock.Accept();
                    if(RecvedRCInfo != null) //연결요청 수신 이벤트 핸들러가 있을때
                    {
                        //연결 요청을 수신하는 이벤트 핸들러가 있다면 이벤트 인자를 생성하여 이벤트를 발생합니다.
                        RecvRCInfoEventArgs e = new RecvRCInfoEventArgs(do_sock.RemoteEndPoint);
                        RecvedRCInfo(null, e); //이벤트 발생
                    }
                    do_sock.Close(); //연결 요청을 수신하였는지 알 수 있게 이벤트를 발생했으니 do_sock은 닫습니다.
                }
            }
            catch
            {
                Close();
            }
        }

        /// <summary>
        /// 연결 요청 수신 서버 닫기
        /// </summary>
        public static void Close()
        {
            if(lis_sock != null)
            {
                lis_sock.Close();
                lis_sock = null;
            }
        }
    }
}
