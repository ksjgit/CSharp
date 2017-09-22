using System;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace 원격제어
{
    //원격 제어를 허용한 호스트의 전체 화면을 제어하는 컨트롤러에게 주기적으로 화면을 전송해야 합니다. 
    //이 부분을 담당하는 ImageClient를 작성합시다.


    /// <summary>
    /// 이미지 전송 클라이언트
    /// </summary>
    public class ImageClient
    {
        Socket sock;
        
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ip">컨트롤러의 IP 주소</param>
        /// <param name="port">컨트롤러의 포트</param>
        public ImageClient(string ip, int port)
        {
            IPAddress ipaddr = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(ipaddr, port);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ep);
        }

        /// <summary>
        /// 이미지 전송 메서드
        /// </summary>
        /// <param name="img">전송할 이미지</param>
        /// <returns>전송 성공 여부</returns>
        public bool SendImage(Image img) //이미지를 전송하는 메서드를 정의
        {
            if (sock == null) return false;

            MemoryStream ms = new MemoryStream(); //메모리스트림 개체 생성
            img.Save(ms, ImageFormat.Jpeg);

            //메모리스트림 버퍼 가져오기
            byte[] data = ms.GetBuffer();
            try
            {
                int trans = 0;
                byte[] lbuf = BitConverter.GetBytes(data.Length); //버퍼크기를 바이트배열 변환
                sock.Send(lbuf); //버퍼길이 전송

                while (trans < data.Length) //전송한 크기가 데이터 길이보다 작으면 반복
                {
                    trans += sock.Send(data, trans, data.Length - trans, SocketFlags.None);
                }
                sock.Close();
                sock = null;
                return true;
            }
            catch
            {
                //예외가 발생하면 응용을 끝내기로 할게요. 
                //이 프로그램은 원격 제어 프로그램을 만드는 방법을 다루고 있으면 상품 수준으로 작성한 것은 아닙니다. 
                //상품 수준으로 만들기 위해서는 다양한 조건으로 테스트를 수행하고 비정상적인 버그들을 잡는 과정이 필요합니다.
                Application.Exit();
                return false;
            }
        }

        /// <summary>
        /// 비동기로 이미지를 보내는 메서드의 대리자
        /// </summary>
        /// <param name="img">전송할 이미지</param>
        /// <returns>이미지 전송 성공 여부</returns>
        public delegate bool SendImageDele(Image img);

        /// <summary>
        /// 이미지를 비동기로 전송하는 메서드
        /// </summary>
        /// <param name="img">전송할 이미지</param>
        /// <param name="callback">이미지 전송을 완료할 때 처리할 콜백</param>
        public void SendImageAsync(Image img, AsyncCallback callback)
        {
            SendImageDele dele = new SendImageDele(SendImage); //비동기로 이미지를 보내는 메서드의 대리자
            dele.BeginInvoke(img, callback, this); //비동기로 이미지 전송
        }

        /// <summary>
        /// 이미지 클라이언트 닫기 메서드
        /// </summary>
        public void Close()
        {
            if(sock != null)
            {
                sock.Close();
                sock = null;
            }
        }
    }
}
