using System;
using System.Drawing;
using System.Windows.Forms;

namespace 원격제어
{
    //이번에는 원격 제어할 때 대상 호스트의 화면을 표시하는 RemoteCleintForm 폼을 추가하세요.
    //자식 컨트롤로 PictureBox 컨트롤을 추가하고 이름을 pbox_remote으로 정합시다.
    //PictureBox 컨트롤의 Dock 속성을 Fill로 설정하고 SizeMode 속성르 StretchImage로 설정하세요.

    /// <summary>
    /// 원격 클라이언트 폼
    /// </summary>
    public partial class RemoteClientForm : Form
    {
        bool check; //이미지 수신 여부
        Size csize; //클라이언트 폼 크기

        //원격 호스트를 제어하기 위한 키보드와 마우스 이벤트를 전송에 사용할 클라이언트를 속성으로 제공합시다.
        SendEventClient EventSC { get { return Controller.Singleton.SendEventClient; } }

        public RemoteClientForm()
        {
            InitializeComponent();
        }
        
        private void RemoteClientForm_Load(object sender, EventArgs e)
        {
            //컨트롤로의 단일체에 이미지 수신 이벤트 핸드러를 등록하세요.
            Controller.Singleton.RecvedImage += new 원격제어.RecvImageEventHandler(Singleton_RecvImageEventHandler);
        }

        void Singleton_RecvImageEventHandler(object sender, RecvImageEventArgs e)
        {
            //만약 한 번도 이미지를 수신하지 않았다면 이벤트 클라이언트를 가동하세요.
            if (check == false)
            {
                Controller.Singleton.StartEventClient();
                check = true;
                csize = e.Image.Size; //이벤트 인자로 받은 부분은 원격 제어 호스트의 데스크 톱 화면의 크기입니다.
            }

            pbox_remote.Image = e.Image; //수신한 이미지로 pbox_remote의 Image 속성을 설정하면 수신한 이미지를 PictureBox에 표시합니다.
        }

        private void RemoteClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (check == true)
            {
                EventSC.SendKeyDown(e.KeyValue);
            }
        }

        private void RemoteClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (check == true)
            {
                EventSC.SendKeyUp(e.KeyValue);
            }
        }

        private void pbox_remote_MouseMove(object sender, MouseEventArgs e)
        {
            if (check == true)
            {
                Point pt = ConvertPoint(e.X, e.Y); //좌표를 변환하여 전송 (PictureBox 좌표 --> RemotePC 좌표)
                EventSC.SendMouseMove(pt.X, pt.Y);
            }
        }

        private Point ConvertPoint(int x, int y)
        {
            int nx = x * csize.Width / pbox_remote.Width; //x좌표는 원격 호스트의 너비를 곱한 값을 pbox_remote의 너비로 나눈 값으로 변환합니다.
            int ny = y * csize.Height / pbox_remote.Height; //y좌표는 원격 호스트의 높이를 곱한 값을 pbox_remote의 높이로 나눈 값으로 변환합니다.

            return new Point(nx, ny);
        }

        private void pbox_remote_MouseDown(object sender, MouseEventArgs e)
        {
            if(check == true)
            {
                Text = e.Location.ToString();
                EventSC.SendMouseDown(e.Button);
            }
        }

        private void pbox_remote_MouseUp(object sender, MouseEventArgs e)
        {
            if (check == true)
            {
                EventSC.SendMouseUp(e.Button);
            }
        }
    }
}
