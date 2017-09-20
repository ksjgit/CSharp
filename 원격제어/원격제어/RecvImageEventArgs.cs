using System;
using System.Net;
using System.Drawing;

namespace 원격제어
{
    //이미지 수신 서버를 구현합시다. 이미지 수신 서버에서는 이미지를 수신할 때마다 폼에 이를 알려주어야 합니다. 이 부분을 위해 이벤트 처리를 할 것입니다. 
    //먼저 이미지를 수신하였을 때 이벤트를 처리하기 위해 대리자와 이벤트 인자 클래스를 정의합시다. 

    /// <summary>
    /// 이미지 수신 이벤트 인자 클래스
    /// </summary>
    public class RecvImageEventArgs : EventArgs 
    {
        /// <summary>
        /// IP 단말 - 가져오기
        /// </summary>
        public IPEndPoint IPEndPoint { get; private set; }
        public IPAddress IPAddress { get { return IPEndPoint.Address; } }
        public string IPAddressStr { get { return IPAddress.ToString(); } }
        public int Port { get { return IPEndPoint.Port; } }

        public Image Image { get; private set; }
        public Size Size { get { return Image.Size; } }
        public int Width { get { return Image.Width; } }
        public int Height { get { return Image.Height; } }

        internal RecvImageEventArgs(IPEndPoint remote_ip, Image image)
        {
            IPEndPoint = remote_ip;
            Image = image;
        }

        /// <summary>
        /// ToString 메서드
        /// </summary>
        /// <returns>IP주소 및 이미지 크기를 문자열로 반환</returns>
        public override string ToString()
        {
            return string.Format("IP:{0} width:{1} height:{2}", IPAddressStr, Width, Height);
        }
    }

    /// <summary>
    /// 이미지 수신 처리를 위한 대리자
    /// </summary>
    /// <param name="sender">이벤트 통보 개체(게시자)</param>
    /// <param name="e">이벤트 처리 인자</param>
    public delegate void RecvImageEventHandler(object sender, RecvImageEventArgs e);
}
