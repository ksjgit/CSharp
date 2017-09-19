using System.Net;
using System.Net.Sockets;

namespace 원격제어
{
    //SetupClient는 단순히 상대에게 누가 요청하는지 알려주는 역할만 수행할 거예요. 값을 유지할 필요도 없고 개체를 만들 필요도 없는 클래스이므로 정적 클래스로 정의하세요.

    /// <summary>
    /// 원격 제어 요청 클라이언트 - 정적 클래스
    /// </summary>
    public static class SetupClient
    {
        /// <summary>
        /// 원격 제어 요청 메서드
        /// </summary>
        /// <param name="ip">상대 IP 주소</param>
        /// <param name="port">상대 포트 번호</param>
        public static void Setup(string ip, int port)
        {
            IPAddress ipaddr = IPAddress.Parse(ip); //상대IP 주소 개체를 생성
            IPEndPoint ep = new IPEndPoint(ipaddr, port); //IP 단말주소(IP주소+포트번호) 개체생성

            //TCP 소켓생성(네트워크주소 체계, 전송방식, 프로토콜)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //연결한 후에 바로 닫습니다. 원격 제어를 수용할 지 여부를 판단하는 곳에 원격 제어 요청이 있다는 것을 알려주는 목적 뿐이어서 전달할 정보는 없습니다.
            sock.Connect(ep); //연결요청
            sock.Close(); //소켓 닫기
        }
    }
}
