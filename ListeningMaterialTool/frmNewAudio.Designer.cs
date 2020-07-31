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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.audioProgress = new System.Windows.Forms.TrackBar();
            this.btnTogglePlay = new System.Windows.Forms.Button();
            this.btnTenForward = new System.Windows.Forms.Button();
            this.btnTrimOut = new System.Windows.Forms.Button();
            this.btnTenBackward = new System.Windows.Forms.Button();
            this.btnTrimIn = new System.Windows.Forms.Button();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.audioProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(98, 28);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "選取檔案";
            this.btnSelectFile.UseVisualStyleBackColor = true;
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
            this.audioProgress.Location = new System.Drawing.Point(12, 81);
            this.audioProgress.Maximum = 1;
            this.audioProgress.Name = "audioProgress";
            this.audioProgress.Size = new System.Drawing.Size(666, 45);
            this.audioProgress.TabIndex = 2;
            this.audioProgress.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // btnTogglePlay
            // 
            this.btnTogglePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePlay.Enabled = false;
            this.btnTogglePlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTogglePlay.Image = global::ListeningMaterialTool.Properties.Resources.play;
            this.btnTogglePlay.Location = new System.Drawing.Point(319, 132);
            this.btnTogglePlay.Name = "btnTogglePlay";
            this.btnTogglePlay.Size = new System.Drawing.Size(50, 50);
            this.btnTogglePlay.TabIndex = 3;
            this.btnTogglePlay.UseVisualStyleBackColor = true;
            // 
            // btnTenForward
            // 
            this.btnTenForward.BackgroundImage = global::ListeningMaterialTool.Properties.Resources.fast_forward_10;
            this.btnTenForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTenForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenForward.Enabled = false;
            this.btnTenForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTenForward.Location = new System.Drawing.Point(422, 137);
            this.btnTenForward.Name = "btnTenForward";
            this.btnTenForward.Size = new System.Drawing.Size(40, 40);
            this.btnTenForward.TabIndex = 4;
            this.btnTenForward.UseVisualStyleBackColor = true;
            // 
            // btnTrimOut
            // 
            this.btnTrimOut.BackgroundImage = global::ListeningMaterialTool.Properties.Resources.trim_out;
            this.btnTrimOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrimOut.Enabled = false;
            this.btnTrimOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrimOut.Location = new System.Drawing.Point(515, 137);
            this.btnTrimOut.Name = "btnTrimOut";
            this.btnTrimOut.Size = new System.Drawing.Size(40, 40);
            this.btnTrimOut.TabIndex = 5;
            this.btnTrimOut.UseVisualStyleBackColor = true;
            // 
            // btnTenBackward
            // 
            this.btnTenBackward.BackgroundImage = global::ListeningMaterialTool.Properties.Resources.rewind_10;
            this.btnTenBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTenBackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenBackward.Enabled = false;
            this.btnTenBackward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTenBackward.Location = new System.Drawing.Point(226, 137);
            this.btnTenBackward.Name = "btnTenBackward";
            this.btnTenBackward.Size = new System.Drawing.Size(40, 40);
            this.btnTenBackward.TabIndex = 6;
            this.btnTenBackward.UseVisualStyleBackColor = true;
            // 
            // btnTrimIn
            // 
            this.btnTrimIn.BackgroundImage = global::ListeningMaterialTool.Properties.Resources.trim_in;
            this.btnTrimIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrimIn.Enabled = false;
            this.btnTrimIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrimIn.Location = new System.Drawing.Point(133, 137);
            this.btnTrimIn.Name = "btnTrimIn";
            this.btnTrimIn.Size = new System.Drawing.Size(40, 40);
            this.btnTrimIn.TabIndex = 7;
            this.btnTrimIn.UseVisualStyleBackColor = true;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(12, 60);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(64, 18);
            this.lblCurrentTime.TabIndex = 8;
            this.lblCurrentTime.Text = "00:00:00";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(614, 60);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(64, 18);
            this.lblTotalTime.TabIndex = 9;
            this.lblTotalTime.Text = "00:00:00";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 90);
            this.label1.TabIndex = 10;
            this.label1.Text = "裁剪撮要：\r\n檔案：\r\n從：\r\n至：\r\n長度：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(548, 282);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 27);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "確定新增到清單";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(548, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNewAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 321);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnTrimIn);
            this.Controls.Add(this.btnTenBackward);
            this.Controls.Add(this.btnTrimOut);
            this.Controls.Add(this.btnTenForward);
            this.Controls.Add(this.btnTogglePlay);
            this.Controls.Add(this.audioProgress);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnSelectFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewAudio";
            this.Text = "新增音訊";
            ((System.ComponentModel.ISupportInitialize)(this.audioProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TrackBar audioProgress;
        private System.Windows.Forms.Button btnTogglePlay;
        private System.Windows.Forms.Button btnTenForward;
        private System.Windows.Forms.Button btnTrimOut;
        private System.Windows.Forms.Button btnTenBackward;
        private System.Windows.Forms.Button btnTrimIn;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}