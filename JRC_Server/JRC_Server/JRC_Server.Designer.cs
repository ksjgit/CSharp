namespace JRC_Server
{
    partial class JRC_Server
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
            this.btn_listen = new System.Windows.Forms.Button();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.txt_sip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cip = new System.Windows.Forms.TextBox();
            this.btn_reqaccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(184, 12);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(75, 23);
            this.btn_listen.TabIndex = 0;
            this.btn_listen.Text = "서버 시작";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic1.BackColor = System.Drawing.Color.Black;
            this.pic1.Location = new System.Drawing.Point(12, 41);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(778, 477);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 1;
            this.pic1.TabStop = false;
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_msg.Location = new System.Drawing.Point(796, 41);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(266, 477);
            this.txt_msg.TabIndex = 2;
            // 
            // txt_sip
            // 
            this.txt_sip.Location = new System.Drawing.Point(58, 12);
            this.txt_sip.Name = "txt_sip";
            this.txt_sip.ReadOnly = true;
            this.txt_sip.Size = new System.Drawing.Size(120, 21);
            this.txt_sip.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "서버 IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "클라이언트 IP";
            // 
            // txt_cip
            // 
            this.txt_cip.Location = new System.Drawing.Point(490, 12);
            this.txt_cip.Name = "txt_cip";
            this.txt_cip.ReadOnly = true;
            this.txt_cip.Size = new System.Drawing.Size(120, 21);
            this.txt_cip.TabIndex = 5;
            // 
            // btn_reqaccept
            // 
            this.btn_reqaccept.Location = new System.Drawing.Point(616, 12);
            this.btn_reqaccept.Name = "btn_reqaccept";
            this.btn_reqaccept.Size = new System.Drawing.Size(75, 23);
            this.btn_reqaccept.TabIndex = 7;
            this.btn_reqaccept.Text = "요청수락";
            this.btn_reqaccept.UseVisualStyleBackColor = true;
            this.btn_reqaccept.Click += new System.EventHandler(this.btn_reqaccept_Click);
            // 
            // JRC_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 530);
            this.Controls.Add(this.btn_reqaccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_cip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sip);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btn_listen);
            this.Name = "JRC_Server";
            this.Text = "RC 서버";
            this.Load += new System.EventHandler(this.JRC_Server_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.TextBox txt_sip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cip;
        private System.Windows.Forms.Button btn_reqaccept;
    }
}

