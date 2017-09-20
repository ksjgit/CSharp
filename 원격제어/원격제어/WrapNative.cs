using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace 원격제어
{
    //원격 제어 호스트에서는 수신한 키보드와 마우스 이벤트를 프로그램 방식으로 발생해 주어야 합니다. 
    //이를 위해 Windows API에서 제공하는 기능을 래핑하여 클래스로 구현합시다.

    //키보드 이벤트나 마우스 이벤트를 강제로 발생하기 위해서는 Windows API에서 제공하는 시스템 함수를 호출해야 합니다.
    //다음은 프로그램 방식으로 키보드 이벤트를 발생시키는 keybd_event 함수의 원형입니다.
    //WINUSERAPI VOID WINAPI keybd_event(__in BYTE bVk, __in BYTE bScan,__in DWORD dwFlags,__in ULONG_PTR dwExtraInfo);

    //C#에서 Native 에서 제공하는 것을 사용하려면 System.Runtime.InteropServices 네임스페이스의 DllImport 특성을 이용합니다.
    //DllImport 특성을 이용할 때 사용할 함수가 있는 dll 파일의 정보를 지정해야 하는데 WINUSERAPI 매크로 상수가 함수 원형 앞에 명시되어 있으면 User32.dll 파일을 지정하세요.
    //Native dll에 있는 함수를 Import할 때는 extern 키워드를 포함하여 함수를 선언합니다. 
    //그리고 입력 인자 형식이 포인터일 때는 ref 혹은 out으로 바꾸시고 리턴 형식이 포인터일 때는 IntPtr로 하면 적당합니다. 
    //자세한 내용은 MSDN의 상호 운용성 부분을 살펴보시기 바랍니다. (하이퍼링크에 문제가 있다면 MSDN에서 직접 검색하시기 바랍니다.)
    //https://msdn.microsoft.com/ko-kr/library/ms172270(v=vs.110).aspx

    //먼저 발생할 키보드 이벤트의 종류를 열거형으로 정의합시다. 
    //이는 WinUser.h에 키보드 관련 이벤트의 매크로 상수 값에 맞게 정의해야 합니다. 
    //발생할 키보드 이벤트 종류는 키 누름, 확장 키, 키 뗌이 있고 이들의 조합을 허용하기 위해 Flags 특성을 지정합니다.
    /// <summary>
    /// 키보드 이벤트 열거형
    /// </summary>
    [Flags]
    public enum KeyFlag
    {
        KE_DOWN = 0, KE_EXTENDEDKEY = 1, KE_UP = 2
    }

    //마우스 이벤트의 종류도 열거형으로 정의하세요. 
    //마찬가지로 WinUser.h 파일에 매크로 상수를 참고하세요. 
    //마우스 이벤트는 이동과 누름과 뗌, 휠에 관한 이벤트 종류가 있습니다.
    [Flags]
    public enum MouseFlag
    {
        ME_MOVE = 1, ME_LEFTDOWN = 2, ME_LEFTUP = 4, ME_RIGHTDOWN = 8,
        ME_RIGHTUP = 0x10, ME_MIDDLEDOWN = 0x20, ME_MIDDLEUP = 0x40, ME_WHEEL = 0x800,
        ME_ABSOULUTE = 8000
    }

    /// <summary>
    /// Native(Win32 API) 기술 래핑 클래스(정적 클래스)
    /// </summary>
    public class WrapNative
    {
        //DllImport 특성을 명시한 후에 mouse_event를 선언하세요. 여기에서 래핑하는 함수는 모두 Windows API에 있는 기능입니다.
        [DllImport("user32.dll")]
        static extern void mouse_event(int flag, int dx, int dy, int buttons, int extra);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point point); //현재 마우스 좌표를 얻어오는 기능도 선언하세요.

        [DllImport("user32.dll")]
        static extern int SetCursorPos(int x, int y); //마우스 좌표를 설정하는 기능도 선언하세요.

        [DllImport("user32.dll")]
        static extern void keybd_event(byte vk, byte scan, int flags, int extra); //키보드 이벤트를 발생하는 keybd_event를 선언하세요.

        /// <summary>
        /// 키 누름(DOWN) 이벤트를 발생시키는 메서드
        /// </summary>
        /// <param name="keycode">키</param>
        public static void KeyDown(int keycode) //이제 키 누름 이벤트를 발생하는 메서드를 제공합시다. 단순히 래핑하는 역할만 할 거예요.
        {
            keybd_event((byte)keycode, 0, (int)KeyFlag.KE_DOWN, 0);
        }

        /// <summary>
        /// 키 뗌(UP) 이벤트를 발생시키는 메서드
        /// </summary>
        /// <param name="keycode">키</param>
        public static void KeyUp(int keycode) //키 뗌 이벤트를 발생하는 메서드도 래핑하여 제공하세요.
        {
            keybd_event((byte)keycode, 0, (int)KeyFlag.KE_UP, 0);
        }

        /// <summary>
        /// 마우스 좌표를 바꾸는 메서드
        /// </summary>
        /// <param name="x">바꿀 X 좌표</param>
        /// <param name="y">바꿀 Y 좌표</param>
        public static void Move(int x, int y) //마우스 좌표를 변경하는 메서드도 래핑하여 제공하세요.
        {
            SetCursorPos(x, y);
        }

        /// <summary>
        /// 마우스 좌표를 바꾸는 메서드
        /// </summary>
        /// <param name="pt">바꿀 포인트</param>
        public static void Move(Point pt)
        {
            Move(pt.X, pt.Y);
        }

        /// <summary>
        /// 프로그램 방식으로 마우스 왼쪽 버튼 누름 이벤트 발생시키는 메서드
        /// </summary>
        public static void LeftDown() //마우스 왼쪽 버튼을 누르는 이벤트를 발생하는 메서드도 래핑하여 제공하세요.
        {
            mouse_event((int)MouseFlag.ME_LEFTDOWN, 0, 0, 0, 0);
        }

        /// <summary>
        /// 프로그램 방식으로 마우스 왼쪽 버튼 뗌 이벤트 발생시키는 메서드
        /// </summary>
        public static void LeftUp() //마우스 왼쪽 버튼을 떼는 이벤트를 발생하는 메서드도 래핑하여 제공하세요.
        {
            mouse_event((int)MouseFlag.ME_LEFTUP, 0, 0, 0, 0);
        }
    }
}
