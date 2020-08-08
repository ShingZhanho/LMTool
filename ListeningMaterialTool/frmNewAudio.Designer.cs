namespace ListeningMaterialTool {
    partial class frmNewAudio {
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
            this.lblFileName = new System.Windows.Forms.Label();
            this.audioProgress = new System.Windows.Forms.TrackBar();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTrimIn = new System.Windows.Forms.Button();
            this.btnTenBackward = new System.Windows.Forms.Button();
            this.btnTrimOut = new System.Windows.Forms.Button();
            this.btnTenForward = new System.Windows.Forms.Button();
            this.btnTogglePlay = new System.Windows.Forms.Button();
            this.opfDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize) (this.audioProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(116, 17);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 18);
            this.lblFileName.TabIndex = 1;
            // 
            // audioProgress
            // 
            this.audioProgress.Enabled = false;
            this.audioProgress.Location = new System.Drawing.Point(12, 38);
            this.audioProgress.Maximum = 1;
            this.audioProgress.Name = "audioProgress";
            this.audioProgress.Size = new System.Drawing.Size(666, 45);
            this.audioProgress.TabIndex = 2;
            this.audioProgress.TickFrequency = 10000;
            this.audioProgress.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(12, 17);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(92, 18);
            this.lblCurrentTime.TabIndex = 8;
            this.lblCurrentTime.Text = "00:00:00.000";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(586, 17);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(92, 18);
            this.lblTotalTime.TabIndex = 9;
            this.lblTotalTime.Text = "00:00:00.000";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(12, 163);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(83, 90);
            this.lblSummary.TabIndex = 10;
            this.lblSummary.Text = "裁剪撮要：\r\n檔案：\r\n從：\r\n至：\r\n長度：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(548, 267);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 27);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "確定新增到清單";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTrimIn
            // 
            this.btnTrimIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrimIn.Enabled = false;
            this.btnTrimIn.Location = new System.Drawing.Point(132, 94);
            this.btnTrimIn.Name = "btnTrimIn";
            this.btnTrimIn.Size = new System.Drawing.Size(40, 40);
            this.btnTrimIn.TabIndex = 7;
            this.btnTrimIn.UseVisualStyleBackColor = true;
            // 
            // btnTenBackward
            // 
            this.btnTenBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTenBackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenBackward.Enabled = false;
            this.btnTenBackward.Location = new System.Drawing.Point(225, 94);
            this.btnTenBackward.Name = "btnTenBackward";
            this.btnTenBackward.Size = new System.Drawing.Size(40, 40);
            this.btnTenBackward.TabIndex = 6;
            this.btnTenBackward.UseVisualStyleBackColor = true;
            // 
            // btnTrimOut
            // 
            this.btnTrimOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrimOut.Enabled = false;
            this.btnTrimOut.Location = new System.Drawing.Point(514, 94);
            this.btnTrimOut.Name = "btnTrimOut";
            this.btnTrimOut.Size = new System.Drawing.Size(40, 40);
            this.btnTrimOut.TabIndex = 5;
            this.btnTrimOut.UseVisualStyleBackColor = true;
            // 
            // btnTenForward
            // 
            this.btnTenForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTenForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenForward.Enabled = false;
            this.btnTenForward.Location = new System.Drawing.Point(421, 94);
            this.btnTenForward.Name = "btnTenForward";
            this.btnTenForward.Size = new System.Drawing.Size(40, 40);
            this.btnTenForward.TabIndex = 4;
            this.btnTenForward.UseVisualStyleBackColor = true;
            // 
            // btnTogglePlay
            // 
            this.btnTogglePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePlay.Enabled = false;
            this.btnTogglePlay.Location = new System.Drawing.Point(318, 89);
            this.btnTogglePlay.Name = "btnTogglePlay";
            this.btnTogglePlay.Size = new System.Drawing.Size(50, 50);
            this.btnTogglePlay.TabIndex = 3;
            this.btnTogglePlay.UseVisualStyleBackColor = true;
            // 
            // opfDialog
            // 
            this.opfDialog.Filter = "常見音訊檔類型|*.m4a;*.flac;*.mp3;*.wav;*.wma;*.aac";
            this.opfDialog.Title = "選取音訊檔";
            // 
            // frmNewAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 321);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnTrimIn);
            this.Controls.Add(this.btnTenBackward);
            this.Controls.Add(this.btnTrimOut);
            this.Controls.Add(this.btnTenForward);
            this.Controls.Add(this.btnTogglePlay);
            this.Controls.Add(this.audioProgress);
            this.Controls.Add(this.lblFileName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(706, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(706, 360);
            this.Name = "frmNewAudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增音訊";
            ((System.ComponentModel.ISupportInitialize) (this.audioProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TrackBar audioProgress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnTenBackward;
        private System.Windows.Forms.Button btnTenForward;
        private System.Windows.Forms.Button btnTogglePlay;
        private System.Windows.Forms.Button btnTrimIn;
        private System.Windows.Forms.Button btnTrimOut;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.OpenFileDialog opfDialog;

        #endregion
    }
}