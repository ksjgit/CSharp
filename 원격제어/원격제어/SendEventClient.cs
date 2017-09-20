using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace 원격제어
{
    //이 프로그램에서는 키보드와 마우스 이벤트가 발생할 때마다 원격 제어 호스트의 이벤트 수신 서버에 연결하여 전송하고 닫는 것을 반복할 거예요.

    //전송하고 수신할 메시지 종류를 열거형으로 정의합시다.
    /// <summary>
    /// 원격 제어 이벤트 종류 열거형
    /// </summary>
    public enum MsgType //원격제어 이벤트 종류
    {
        MT_KDOWN = 1, MT_KEYUP, MT_M_LEFTDOWN, MT_M_LEFTUP, MT_M_RIGHTDOWN, MT_M_RIGHTUP, MT_M_MIDDLEDOWN, MT_M_MIDDLEUP, MT_M_MOVE
    }

    //이벤트를 전송하는 SendEventClient를 작성합시다.
    /// <summary>
    /// 원격 제어 이벤트 전송 클라이언트 클래스
    /// </summary>
    public class SendEventClient
    {
        IPEndPoint ep;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ip">원격지 호스트 IP</param>
        /// <param name="port">포트</param>
        public SendEventClient(string ip, int port)
        {
            ep = new IPEndPoint(IPAddress.Parse(ip), port);
        }

        //이 프로그램에서 키보드와 마우스 이벤트 정보 중에 제일 큰 크기는 마우스 이동 이벤트입니다. 이벤트 종류 1바이트, x좌표 4바이트, y좌표 4바이트로 총 9바이트가 필요합니다.
        /// <summary>
        /// 키 누름 이벤트 전송 메서드
        /// </summary>
        /// <param name="key">누른 키</param>
        public void SendKeyDown(int key)
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_KDOWN;

            Array.Copy(BitConverter.GetBytes(key), 0, data, 1, 4); //누른 키를 버퍼에 복사
            SendData(data); //버퍼전송
        }

        /// <summary>
        /// 키 뗌 이벤트 전송 메서드
        /// </summary>
        /// <param name="key">뗀 키</param>
        public void SendKeyUp(int key)
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_KEYUP;

            Array.Copy(BitConverter.GetBytes(key), 0, data, 1, 4); //누른 키를 버퍼에 복사
            SendData(data); //버퍼전송
        }

        /// <summary>
        /// 마우스 누름 이벤트 전송 메서드
        /// </summary>
        /// <param name="mouseButtons">누른 마우스 버튼</param>
        public void SendMouseDown(MouseButtons mouseButtons)
        {
            byte[] data = new byte[9];

            switch (mouseButtons)
            {
                case MouseButtons.Left:
                    data[0] = (byte)MsgType.MT_M_LEFTDOWN;
                    break;
                case MouseButtons.Right:
                    data[0] = (byte)MsgType.MT_M_RIGHTDOWN;
                    break;
                case MouseButtons.Middle:
                    data[0] = (byte)MsgType.MT_M_MIDDLEDOWN;
                    break;
            }

            SendData(data); //마우스누름 이벤트 전송
        }

        /// <summary>
        /// 마우스 뗌 이벤트 전송 메서드
        /// </summary>
        /// <param name="mouseButtons">뗀 마우스 버튼</param>
        public void SendMouseUp(MouseButtons mouseButtons)
        {
            byte[] data = new byte[9];

            switch (mouseButtons)
            {
                case MouseButtons.Left:
                    data[0] = (byte)MsgType.MT_M_LEFTUP;
                    break;
                case MouseButtons.Right:
                    data[0] = (byte)MsgType.MT_M_RIGHTUP;
                    break;
                case MouseButtons.Middle:
                    data[0] = (byte)MsgType.MT_M_MIDDLEUP;
                    break;
            }

            SendData(data); //마우스 뗌 이벤트 전송
        }

        /// <summary>
        /// 마우스 이동 메서드
        /// </summary>
        /// <param name="x">마우스 x좌표</param>
        /// <param name="y">마우스 y좌표</param>
        public void SendMouseMove(int x, int y)
        {
            byte[] data = new byte[9];
            data[0] = (byte)MsgType.MT_M_MOVE; //마우스 이동 이벤트 설정

            Array.Copy(BitConverter.GetBytes(x), 0, data, 1, 4); //x좌표 복사
            Array.Copy(BitConverter.GetBytes(y), 0, data, 5, 4); //y좌표 복사

            SendData(data); //마우스 이동 이벤트 전송
        }

        private void SendData(byte[] data)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ep); //원격제어 호스트에 연결
            sock.Send(data); //이벤트 전송
            sock.Close();
        }

    }
}
