namespace JRC_Client
{
    partial class JRC_Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sip = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.btn_sendimg = new System.Windows.Forms.Button();
            this.txt_chat = new System.Windows.Forms.TextBox();
            this.bnt_sendmsg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "서버 IP";
            // 
            // txt_sip
            // 
            this.txt_sip.Location = new System.Drawing.Point(61, 12);
            this.txt_sip.Name = "txt_sip";
            this.txt_sip.Size = new System.Drawing.Size(120, 21);
            this.txt_sip.TabIndex = 6;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(187, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 5;
            this.btn_connect.Text = "연결 요청";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_msg.Location = new System.Drawing.Point(12, 41);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(782, 455);
            this.txt_msg.TabIndex = 8;
            // 
            // btn_sendimg
            // 
            this.btn_sendimg.Location = new System.Drawing.Point(385, 12);
            this.btn_sendimg.Name = "btn_sendimg";
            this.btn_sendimg.Size = new System.Drawing.Size(98, 23);
            this.btn_sendimg.TabIndex = 9;
            this.btn_sendimg.Text = "이미지 전송";
            this.btn_sendimg.UseVisualStyleBackColor = true;
            this.btn_sendimg.Click += new System.EventHandler(this.btn_sendimg_Click);
            // 
            // txt_chat
            // 
            this.txt_chat.Location = new System.Drawing.Point(535, 12);
            this.txt_chat.Name = "txt_chat";
            this.txt_chat.Size = new System.Drawing.Size(178, 21);
            this.txt_chat.TabIndex = 11;
            // 
            // bnt_sendmsg
            // 
            this.bnt_sendmsg.Location = new System.Drawing.Point(719, 12);
            this.bnt_sendmsg.Name = "bnt_sendmsg";
            this.bnt_sendmsg.Size = new System.Drawing.Size(75, 23);
            this.bnt_sendmsg.TabIndex = 10;
            this.bnt_sendmsg.Text = "문자 전송";
            this.bnt_sendmsg.UseVisualStyleBackColor = true;
            this.bnt_sendmsg.Click += new System.EventHandler(this.bnt_sendmsg_Click);
            // 
            // JRC_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 508);
            this.Controls.Add(this.txt_chat);
            this.Controls.Add(this.bnt_sendmsg);
            this.Controls.Add(this.btn_sendimg);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sip);
            this.Controls.Add(this.btn_connect);
            this.Name = "JRC_Client";
            this.Text = "RC 클라이언트";
            this.Load += new System.EventHandler(this.JRC_Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sip;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button btn_sendimg;
        private System.Windows.Forms.TextBox txt_chat;
        private System.Windows.Forms.Button bnt_sendmsg;
    }
}

