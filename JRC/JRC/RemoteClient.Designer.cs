namespace JRC
{
    partial class RemoteClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic_remotescr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_remotescr)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_remotescr
            // 
            this.pic_remotescr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_remotescr.Location = new System.Drawing.Point(0, 0);
            this.pic_remotescr.Name = "pic_remotescr";
            this.pic_remotescr.Size = new System.Drawing.Size(798, 518);
            this.pic_remotescr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_remotescr.TabIndex = 0;
            this.pic_remotescr.TabStop = false;
            // 
            // RemoteClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 518);
            this.Controls.Add(this.pic_remotescr);
            this.Name = "RemoteClient";
            this.Text = "RemoteClient";
            ((System.ComponentModel.ISupportInitialize)(this.pic_remotescr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_remotescr;
    }
}