namespace ListeningMaterialTool {
    partial class frmExport {
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbTerminal = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.chbOpenDir = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(44, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(143, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "目前狀態：正在匯出";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(47, 83);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(532, 305);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "程式日誌：";
            // 
            // rtbTerminal
            // 
            this.rtbTerminal.BackColor = System.Drawing.Color.Black;
            this.rtbTerminal.ForeColor = System.Drawing.Color.White;
            this.rtbTerminal.Location = new System.Drawing.Point(585, 83);
            this.rtbTerminal.Name = "rtbTerminal";
            this.rtbTerminal.ReadOnly = true;
            this.rtbTerminal.Size = new System.Drawing.Size(532, 305);
            this.rtbTerminal.TabIndex = 3;
            this.rtbTerminal.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "ffmpeg日誌：";
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(585, 29);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(532, 23);
            this.pgbProgress.TabIndex = 5;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(420, 29);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(159, 18);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "正在進行第1步，共2步";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbOpenDir
            // 
            this.chbOpenDir.AutoSize = true;
            this.chbOpenDir.Checked = true;
            this.chbOpenDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOpenDir.Location = new System.Drawing.Point(47, 427);
            this.chbOpenDir.Name = "chbOpenDir";
            this.chbOpenDir.Size = new System.Drawing.Size(132, 22);
            this.chbOpenDir.TabIndex = 7;
            this.chbOpenDir.Text = "自動開啟資料夾";
            this.chbOpenDir.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "完成後：";
            // 
            // chbClose
            // 
            this.chbClose.AutoSize = true;
            this.chbClose.Checked = true;
            this.chbClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbClose.Location = new System.Drawing.Point(197, 427);
            this.chbClose.Name = "chbClose";
            this.chbClose.Size = new System.Drawing.Size(117, 22);
            this.chbClose.TabIndex = 9;
            this.chbClose.Text = "關閉這個視窗";
            this.chbClose.UseVisualStyleBackColor = true;
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 469);
            this.ControlBox = false;
            this.Controls.Add(this.chbClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbOpenDir);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbTerminal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "匯出檔案";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbTerminal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox chbOpenDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbClose;
    }
}