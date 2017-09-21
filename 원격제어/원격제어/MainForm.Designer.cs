namespace 원격제어
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_controller_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.timer_send_img = new System.Windows.Forms.Timer(this.components);
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "원격 호스트 주소";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(127, 29);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(258, 21);
            this.txt_ip.TabIndex = 1;
            // 
            // txt_controller_ip
            // 
            this.txt_controller_ip.Location = new System.Drawing.Point(127, 72);
            this.txt_controller_ip.Name = "txt_controller_ip";
            this.txt_controller_ip.ReadOnly = true;
            this.txt_controller_ip.Size = new System.Drawing.Size(258, 21);
            this.txt_controller_ip.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "원격 컨트롤러 주소";
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(406, 27);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(120, 23);
            this.btn_setting.TabIndex = 4;
            this.btn_setting.Text = "설정하기";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Enabled = false;
            this.btn_ok.Location = new System.Drawing.Point(406, 70);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(120, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "원격 제어 허용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // timer_send_img
            // 
            this.timer_send_img.Tick += new System.EventHandler(this.timer_send_img_Tick);
            // 
            // noti
            // 
            this.noti.Text = "notifyIcon1";
            this.noti.Visible = true;
            this.noti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.noti_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 118);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.txt_controller_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_controller_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Timer timer_send_img;
        private System.Windows.Forms.NotifyIcon noti;
    }
}

