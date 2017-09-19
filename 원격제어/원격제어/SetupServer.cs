using System;
using System.Net;

namespace 원격제어
{
    //원격 제어 요청을 수신하여 수락 혹은 거절하는 SetupServer에서는 상대측에서 원격 제어 요청이 온 시점을 알아야 합니다. 
    //이를 위해 이벤트 처리를 할 수 있게 대리자와 이벤트 인자 형식을 정의합시다.
    //이벤트 처리에 사용할 인자는 EventArgs 클래스를 기반으로 파생 클래스로 정의하는 것을 권해요.
    class SetupServer
    {
    }
}
