using System;
using System.Drawing;
using System.Windows.Forms;

namespace 원격제어
{
    //원격 제어 컨트롤러에서는 상대 호스트의 마우스 위치를 화면에 표시해야 합니다. 
    //이 부분을 위해 가상의 커서를 만듭시다. 
    //가상 커서는 도구 스타일의 작은 폼으로 정의합시다. 
    //VirtualCursorForm 이름의 폼을 추가하세요.
    //Form의 AutoSizeMode를 GrowAndShrink로 설정하세요.
    //BackColor는 Red, FormBorderSytle은 None, TopMost를 True로 지정합니다.
    //Size 속성과 MaximumSize, MinimumSize 속성을 10, 10으로 지정하세요.
    /// <summary>
    /// 가상 커서
    /// </summary>
    public partial class VirtualCursorForm : Form
    {
        public VirtualCursorForm()
        {
            InitializeComponent();
        }

        //Load 이벤트 핸들러에서 Remote 단일 개체에 키보드와 마우스 이벤트 수신 이벤트 핸들러를 등록하세요. 
        //Remote 단일 개체는 폼이나 컨트롤이 아니므로 속성 창을 이용할 수 없습니다. 따라서 코드에 직접 이벤트 핸들러를 등록하세요.
        private void VirtualCursorForm_Load(object sender, EventArgs e)
        {
            Remote.Singleton.RecvedKMEvent += new RecvKMEEventHandler(Singleton_RecvedKMEvent);
        }

        void Singleton_RecvedKMEvent(object sender, RecvKMEEventArgs e)
        {
            if (e.MT == MsgType.MT_M_MOVE) //만약 이벤트가 마우스 이동이면 가상 커서를 이동하세요.
            {
                Location = new Point(e.Now.X + 3, e.Now.Y + 3);
            }
        }
    }
}
