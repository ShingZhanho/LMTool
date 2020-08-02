namespace ListeningMaterialTool {
    partial class frmAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tapInfo = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.tapInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = global::ListeningMaterialTool.Properties.Resources.LMTool_512;
            this.picLogo.Location = new System.Drawing.Point(13, 13);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(159, 158);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.tapInfo);
            this.tabInfo.Location = new System.Drawing.Point(180, 13);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabInfo.Multiline = true;
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(632, 452);
            this.tabInfo.TabIndex = 1;
            // 
            // tapInfo
            // 
            this.tapInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tapInfo.Controls.Add(this.label5);
            this.tapInfo.Controls.Add(this.label4);
            this.tapInfo.Controls.Add(this.linkLabel1);
            this.tapInfo.Controls.Add(this.label3);
            this.tapInfo.Location = new System.Drawing.Point(4, 27);
            this.tapInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tapInfo.Name = "tapInfo";
            this.tapInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tapInfo.Size = new System.Drawing.Size(624, 421);
            this.tapInfo.TabIndex = 0;
            this.tapInfo.Text = "一般資訊";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "聆聽材料實用工具\r\nLMTool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "VERSION";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(548, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "多謝你使用LMTool！\r\n此應用程式已在GitHub上開放原始碼，歡迎所有人士一同投身到開發工作當中。";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(61, 74);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 18);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub 頁面";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(548, 133);
            this.label4.TabIndex = 2;
            this.label4.Text = "此應用程式亦引入了以下的函式庫 / 工具：\r\n音訊播放：\r\n    VideoLAN/libVLC\r\n    VideoLAN/libVLCSharp\r\n\r\n音訊" +
    "裁剪及合併：\r\n    ffmpeg";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(548, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "應用程式以GNU v3.0協定發行。";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 478);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.picLogo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(841, 517);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(841, 517);
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "關於LMTool";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.tapInfo.ResumeLayout(false);
            this.tapInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TabControl tabInfo;
        private System.Windows.Forms.TabPage tapInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}