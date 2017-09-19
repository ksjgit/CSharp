using System;
using System.Net;

namespace 원격제어
{
    //원격 제어 요청을 수신하여 수락 혹은 거절하는 SetupServer에서는 상대측에서 원격 제어 요청이 온 시점을 알아야 합니다.
    //이를 위해 이벤트 처리를 할 수 있게 대리자와 이벤트 인자 형식을 정의합시다.
    //이벤트 처리에 사용할 인자는 EventArgs 클래스를 기반으로 파생 클래스로 정의하는 것을 권해요.

    /// <summary>
    /// 원격 제어 요청 수신 이벤트 인자 클래스
    /// </summary>
    public class RecvRCInfoEventArgs : EventArgs 
    {
        /// <summary>
        /// IP 단말 정보 - 가져오기
        /// </summary>
        public IPEndPoint IPEndPoint { get; private set; }

        /// <summary>
        /// IP 주소 문자열 - 가져오기
        /// </summary>
        public string IPAddressStr { get { return IPEndPoint.Address.ToString(); } }

        /// <summary>
        /// 포트 - 가져오기
        /// </summary>
        public int Port { get { return IPEndPoint.Port; } }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="RemoteEndPoint">상대측 단말 정보</param>
        internal RecvRCInfoEventArgs(EndPoint RemoteEndPoint)
        {
            IPEndPoint = RemoteEndPoint as IPEndPoint; //as 연산은 하향 캐스팅에 사용하는 참조 연산입니다.
        }
    }

    /// <summary>
    /// 원격 제어 요청 수신 이벤트를 정의하기 위한 대리자
    /// </summary>
    /// <param name="sender">이벤트 통보 개체</param>
    /// <param name="e">이벤트 처리 인자</param>
    public delegate void RecvRCInfoEventHandler(object sender, RecvRCInfoEventArgs e);
}
