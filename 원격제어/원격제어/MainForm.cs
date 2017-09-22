using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 원격제어
{
    public partial class MainForm : Form
    {
        string sip; //상대 IP
        int sport;  //상대 port
        RemoteClientForm rcf = null; //원격호스트 화면(제어당하는 화면)
        VirtualCursorForm vcf = null; //가상커서

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vcf = new VirtualCursorForm(); //가상커서 생성
            rcf = new RemoteClientForm(); //원격 호스트 화면 폼 생성 (제어당하는)

            txt_msg.Text += NetworkInfo.DefaultIP + System.Environment.NewLine;

            Remote.Singleton.RecvedRCInfo += new RecvRCInfoEventHandler(Remote_RecvedRCInfo);
        }

        //크로스 스레드 문제가 발생할 수 있으니 다음처럼 문제를 해결하세요. 
        //Windows Forms 응용에서는 컨트롤을 소유하고 있는 스레드가 아닌 다른 스레드에서 컨트롤의 상태를 변경하려고 할 때 크로스 스레드 문제가 발생합니다.
        //이를 확인하려면 컨트롤의 InvokeRequired 속성을 확인합니다.
        //만약 InvokeRequired 속성이 true라면 현재 수행하는 스레드는 컨트롤을 소유하지 않은 스레드라는 의미입니다.
        //이 때 컨트롤의 Invoke 메서드를 호출하면 .NET 프레임워크에서는 컨트롤을 소유한 스레드가 대행하게 해 줍니다.
        //다음은 수신한 상대 정보를 컨트롤을 통해 표시하는 부분으로 크로스 스레드 문제를 해결하는 코드로 작성하였습니다.
        delegate void Remote_Dele(object sender, RecvRCInfoEventArgs e);
        void Remote_RecvedRCInfo(object sender, RecvRCInfoEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] objs = new object[2] { sender, e };
                this.Invoke(new Remote_Dele(Remote_RecvedRCInfo), objs);
            }
            else
            {
                txt_controller_ip.Text = e.IPAddressStr;
                sip = e.IPAddressStr;
                sport = e.Port;

                btn_ok.Enabled = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Remote.Singleton.Stop(); //원격호스트 멈춤
            Controller.Singleton.Stop(); //원격 컨트롤러 멈춤

            Application.Exit();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            if(txt_ip.Text == NetworkInfo.DefaultIP) //자신의 IP와 같을때
            {
                MessageBox.Show("같은 호스트 입니다.");
                txt_ip.Text = "";
                return;
            }

            string host_ip = txt_ip.Text;

            Rectangle rect = Remote.Singleton.Rect;

            Controller.Singleton.Start(host_ip); //컨트롤러 가동

            rcf.ClientSize = new Size(rect.Width - 40, rect.Height - 80);
            rcf.Show(); //원격제어 화면 폼 시각화
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //this.Hide();

            Remote.Singleton.RecvEventStart(); //원격제어 이벤트 수신 서버 가동
            timer_send_img.Start(); //이미지 전송 타이머 가동

            vcf.Show(); //가상화 커서 시각화
        }

        private void noti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void timer_send_img_Tick(object sender, EventArgs e)
        {
            Rectangle rect = Remote.Singleton.Rect;
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics gp = Graphics.FromImage(bitmap);

            Size size2 = new Size(rect.Width, rect.Height);

            gp.CopyFromScreen(new Point(0, 0), new Point(0, 0), size2); //화면 복사
            gp.Dispose();
            try
            {
                txt_msg.Text += sip + "/" + NetworkInfo.ImgPort.ToString() + System.Environment.NewLine;
                txt_msg.Refresh();

                ImageClient ic = new ImageClient(sip, NetworkInfo.ImgPort);
                txt_msg.Text += sip + "/" + NetworkInfo.ImgPort.ToString() + System.Environment.NewLine;
                txt_msg.Refresh();
                
                ic.SendImageAsync(bitmap, null); //이미지를 비동기로 전송
            }
            catch
            {
                timer_send_img.Stop();
                MessageBox.Show(sip.ToString() + " 서버 연결 실패");
                this.Close();
            }
        }
    }
}
