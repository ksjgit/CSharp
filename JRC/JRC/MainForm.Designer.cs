namespace JRC
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
            this.txt_sip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.txt_cip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_sip
            // 
            this.txt_sip.Location = new System.Drawing.Point(105, 12);
            this.txt_sip.Name = "txt_sip";
            this.txt_sip.Size = new System.Drawing.Size(202, 21);
            this.txt_sip.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "제어당하는 IP";
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(313, 12);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(95, 23);
            this.btn_setting.TabIndex = 5;
            this.btn_setting.Text = "제어요청";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // txt_cip
            // 
            this.txt_cip.Location = new System.Drawing.Point(105, 49);
            this.txt_cip.Name = "txt_cip";
            this.txt_cip.Size = new System.Drawing.Size(202, 21);
            this.txt_cip.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "제어하는 IP";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(313, 49);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(95, 23);
            this.btn_connect.TabIndex = 8;
            this.btn_connect.Text = "제어허용";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(12, 86);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(697, 260);
            this.txt_msg.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 358);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_cip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.txt_sip);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "JRC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_sip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.TextBox txt_cip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_msg;
    }
}

