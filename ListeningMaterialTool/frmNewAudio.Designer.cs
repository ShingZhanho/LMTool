using System;
using System.Drawing;

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
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.opfDialog = new System.Windows.Forms.OpenFileDialog();
            this.trbIn = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trbOut = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTrimInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.trbIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.trbOut)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.Location = new System.Drawing.Point(12, 9);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(666, 46);
            this.lblFileInfo.TabIndex = 1;
            this.lblFileInfo.Text = "檔案位置：\r\n總長度：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(548, 195);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 27);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "確定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // opfDialog
            // 
            this.opfDialog.Filter = "常見音訊檔類型|*.m4a;*.mp3;*.wav;*.wma;*.aac";
            this.opfDialog.Title = "選取音訊檔";
            // 
            // trbIn
            // 
            this.trbIn.Location = new System.Drawing.Point(95, 86);
            this.trbIn.Name = "trbIn";
            this.trbIn.Size = new System.Drawing.Size(583, 45);
            this.trbIn.TabIndex = 13;
            this.trbIn.TickFrequency = 1000;
            this.trbIn.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbIn.ValueChanged += new System.EventHandler(this.OnTrackBarValueChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "選取要分割的範圍：";
            // 
            // trbOut
            // 
            this.trbOut.Location = new System.Drawing.Point(95, 107);
            this.trbOut.Name = "trbOut";
            this.trbOut.Size = new System.Drawing.Size(583, 45);
            this.trbOut.TabIndex = 15;
            this.trbOut.TickFrequency = 1000;
            this.trbOut.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trbOut.Value = 10;
            this.trbOut.ValueChanged += new System.EventHandler(this.OnTrackBarValueChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "開始時間：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "結束時間：";
            // 
            // lblTrimInfo
            // 
            this.lblTrimInfo.AutoSize = true;
            this.lblTrimInfo.Location = new System.Drawing.Point(12, 155);
            this.lblTrimInfo.Name = "lblTrimInfo";
            this.lblTrimInfo.Size = new System.Drawing.Size(464, 18);
            this.lblTrimInfo.TabIndex = 18;
            this.lblTrimInfo.Text = "由 00:00:00.000 開始至 00:00:00.000 結束，中間時長 00:00:00.000 。";
            // 
            // frmNewAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 238);
            this.ControlBox = false;
            this.Controls.Add(this.lblTrimInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trbOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbIn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblFileInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(706, 360);
            this.MinimizeBox = false;
            this.Name = "frmNewAudio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增音訊";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize) (this.trbIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.trbOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Label lblTrimInfo;
        private System.Windows.Forms.OpenFileDialog opfDialog;
        private System.Windows.Forms.TrackBar trbIn;
        private System.Windows.Forms.TrackBar trbOut;

        #endregion
    }
}