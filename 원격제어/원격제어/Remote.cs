using System.Drawing;
using System.Windows.Automation;

namespace 원격제어
{
    //원격 제어 호스트 개체도 프로그램에 유일해야 하므로 단일체 패턴을 적용할게요.먼저 클래스 내에 정적 멤버 필드로 단일 개체를 선언하세요.
    /// <summary>
    /// 원격 제어 호스트 클래스
    /// </summary>
    public class Remote
    {
        static Remote singleton; //단일개체

        /// <summary>
        /// 단일 개체 - 가져오기
        /// </summary>
        public static Remote Singleton { get { return singleton; } }

        static Remote()
        {
            singleton = new Remote(); //단일개체 생성
        }

        //폼에서는 원격 제어 요청이 왔을 때 요청자의 정보를 화면에 표시해 주어야 합니다. 이를 위해 원격 제어 요청 메시지 수신 이벤트를 선언하세요.
        public event RecvRCInfoEventHandler RecvedRCInfo = null; //원격제어 요청 메시지 수신 이벤트

        //폼이나 다른 클래스에서 원격 제어 컨트롤로에서 보낸 키보드와 마우스 이벤트를 수신하였을 때의 이벤트 정보를 구독할 수 있게 이벤트를 선언하세요.
        public event RecvKMEEventHandler RecvedKMEvent = null; //키보드, 마우스 메시지 수신 이벤트

        //원격 제어 호스트에는 컨트롤러에서 보내는 키보드와 마우스 메시지를 수신할 서버가 필요합니다.
        RecvEventServer res = null; //키보드, 마우스 메시지 수신 서버

        //원격 제어 호스트는 주기적으로 데스크톱 화면 영역을 캡쳐하여 이미지를 전송해야 합니다.여기에서는 데스크톱 화면 영역을 가져오기 할 수 있게 속성을 제공합시다.
        /// <summary>
        /// 데스크톱 사각 영역 - 가져오기
        /// </summary>
        public Rectangle Rect { get; private set; }

        //생성자의 가시성을 private으로 접근 지정하여 단일 개체외에 다른 개체를 생성할 수 없게 하세요.
        private Remote()
        {
            //UI 자동화 기술에서는 최상위 자동화 요소를 구하는 정적 속성을 제공하고 있습니다. 
            //다른 방법도 있지만 여기에서는 이를 이용하여 데스크 톱의 사각 영역을 구하기로 할게요. 
            //이 방법은 일반적인 방법은 아닙니다. 
            //제가 소프트웨어 접근성에 관심을 갖고 있어서 이를 사용한 것일 뿐입니다.

            //UI 자동화 기술을 사용하기 위해서는 [그림 9]처럼 UI 자동화 기술에 관한 .NET 어셈블리를 참조 추가해야 합니다. 
            //UIAutomationClient.dll, UIAutomationClientSideProviders.dll, UIAutomationTypes.dll을 참조 추가하세요. 
            //그리고 Rect 형식은 WindowsBase.dll을 참조 추가해야 사용할 수 있습니다.

            AutomationElement ae = AutomationElement.RootElement; //최상위 자동화 요소 구하기
            System.Windows.Rect rt = ae.Current.BoundingRectangle; //사각형 영역 구하기
            Rect = new Rectangle((int)rt.Left, (int)rt.Top, (int)rt.Width, (int)rt.Height); //Rectangle형식으로 변환

            SetupServer.RecvedRCInfo += new RecvRCInfoEventHandler(SetupServer_RecvedRCInfo); //원격제어 요청 수신 이벤트 메시지 핸들러 등록
            SetupServer.Start(MyIP, NetworkInfo.SetupPort); //원격제어 요청 서버 가동
        }
        
        void SetupServer_RecvedRCInfo(object sender, RecvRCInfoEventArgs e)
        {
            if (RecvedRCInfo != null) //원격제어 요청 수신 구독자가 있을때
            {
                RecvedRCInfo(this, e); //원격제어 요청 수신 이벤트 발생(By Pass)
            }
        }

        public string MyIP { get { return NetworkInfo.DefaultIP; } }

        public void RecvEventStart()
        {
            res = new 원격제어.RecvEventServer(MyIP, NetworkInfo.EventPort); //메세지 수신 서버 가동
            res.RecvedKMEvent += new RecvKMEEventHandler(res_RecvKMEEventHandler);
        }

        void res_RecvKMEEventHandler(object sender, RecvKMEEventArgs e)
        {
            if (RecvedKMEvent != null) //메시지 수신 이벤트 핸들러가 있을 때
            {
                RecvedKMEvent(this, e); //이벤트 발생(By Pass)
            }

            //수신한 이벤트에 따라 프로그램 방식으로 이벤트 발생
            switch (e.MT)
            {
                case MsgType.MT_KDOWN:
                    WrapNative.KeyDown(e.Key);
                    break;
                case MsgType.MT_KEYUP:
                    WrapNative.KeyUp(e.Key);
                    break;
                case MsgType.MT_M_LEFTDOWN:
                    WrapNative.LeftDown();
                    break;
                case MsgType.MT_M_LEFTUP:
                    WrapNative.LeftUp();
                    break;
                case MsgType.MT_M_MOVE:
                    WrapNative.Move(e.Now);
                    break;
            }
        }

        public void Stop()
        {
            SetupServer.Close(); //Setup 서버 닫기
            if(res != null)
            {
                res.Close(); //메시지 수신 서버 닫기
                res = null;
            }
        }
    }
}
