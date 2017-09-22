using System.Net;
using System.Net.Sockets;

namespace JRC
{
    public static class NetworkInfo
    {
        public static int SetupPort { get { return 20002; } } //제어 요청 대기 포트
        public static int ImgPort { get { return 20004; } } //이미지 서버 대기 포트
        public static int EventPort { get { return 20010; } } //이벤트 서버 대기 포트

        public static string DefaultIP
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
