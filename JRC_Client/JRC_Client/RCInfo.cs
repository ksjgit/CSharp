using System.Net;
using System.Net.Sockets;

namespace JRC_Client
{
    public static class RCInfo
    {
        public const int ListenPort = 20002; //제어 요청 대기 포트
        public const int ImgPort = 20004; //이미지 대기 포트
        public const int EventPort = 20006;  //이벤트 대기 포트

        public static string MyIP
        {
            get
            {
                string host_name = Dns.GetHostName(); //호스트 이름 구하기
                IPHostEntry host_entry = Dns.GetHostEntry(host_name); //호스트 엔트리 구하기
                foreach (IPAddress ipaddr in host_entry.AddressList)
                {
                    if (ipaddr.AddressFamily == AddressFamily.InterNetwork && ipaddr.ToString() != "192.168.56.1")
                    {
                        return ipaddr.ToString(); //IP주소 문자열 반환
                    }
                }
                return string.Empty;
            }
        }
    }
}
