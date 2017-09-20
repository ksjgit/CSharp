using System.Net;
using System.Net.Sockets;

namespace 원격제어
{
    /// <summary>
    /// 네트워크 정보 클래스 - 정적 클래스
    /// </summary>
    public static class NetworkInfo
    {
        public static short ImgPort { get { return 20004; } } //이미지 서버 포트 - 하드코딩 
        public static short SetupPort { get { return 20002; } } //원격제어 요청 포트
        public static short EventPort { get { return 20010; } } //이벤트 서버 포트

        public static string DefaultIP
        {
            get
            {
                string host_name = Dns.GetHostName(); //호스트 이름 구하기
                IPHostEntry host_entry = Dns.GetHostEntry(host_name); //호스트 엔트리 구하기
                foreach (IPAddress ipaddr in host_entry.AddressList)
                {
                    if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ipaddr.ToString(); //IP주소 문자열 반환
                    }
                }
                return string.Empty;
            }
        }
    }

    //이번에는 원격 제어하는 컨트롤러를 만들어 봅시다.
    public class Controller
    {
        //원격 제어 컨트롤러는 단일체 패턴으로 정의할 것입니다. 이를 위해 정적 개체를 위한 정적 멤버 필드를 선언하세요.
        static Controller singleton; //단일체

        public static Controller Singleton { get { return singleton; } } //단일체 접근자

        //단일체는 정적 생성자에서 생성하세요. 
        //정적 생성자는 접근 지정자를 표시할 수 없습니다. 
        //그리고 정적 생성자는 해당 형식을 사용하는 것보다 먼저 수행하는 것을 보장하며 개발자가 직접 호출하는 대상이 아닙니다.

        static Controller()
        {
            singleton = new Controller();
        }

        //단일체 외에 다른 개체를 생성할 수 없게 생성자의 접근 가시성을 private으로 지정합니다.
        private Controller() //접근 가시성이 private인 기본 생성자
        {
        }

        ImageServer img_sever = null; //이미지 수신 서버
        SendEventClient sce = null; //키보드, 마우스 제어 이벤트 전송 클라이언트
        public event RecvImageEventHandler RecvedImage = null; //이미지 수신 이벤트

        string host_ip; //원격제어 호스트 IP 문자열

        public SendEventClient SendEventClient { get { return sce; } } //이벤트 전송 클라이언트 접근자
        public string MyIP { get { return NetworkInfo.DefaultIP; } } //로컬 IP문자열 접근자

        public void Start(string host_ip)
        {
            this.host_ip = host_ip;
            img_sever = new ImageServer(MyIP, NetworkInfo.ImgPort); //이미지 서버 가동
            img_sever.RecvedImage += new RecvImageEventHandler(img_sever_RecvedImage);
            SetupClient.Setup(host_ip, NetworkInfo.SetupPort);
        }

        void img_sever_RecvedImage(object sender, RecvImageEventArgs e)
        {
            if (RecvedImage != null) //이미지 수진 이벤트 구독자가 있을 때
            {
                RecvedImage(this, e); //이미지 수신 이벤트 게시(By Pass)
            }
        }

        //이벤트 클라이언트를 시작하는 메서드를 정의합시다.
        public void StartEventClient()
        {
            sce = new 원격제어.SendEventClient(host_ip, NetworkInfo.EventPort); //이벤트 송신 클라이언트 개체 생성
        }

        public void Stop() //원격 컨트롤러 멈춤
        {
            if (img_sever != null)
            {
                img_sever.Close();//이미지 서버 닫기
                img_sever = null;
            }
        }
    }
}
