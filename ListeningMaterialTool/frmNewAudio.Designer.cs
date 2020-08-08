using System;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.lblCutInfo = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.Location = new System.Drawing.Point(12, 9);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(666, 46);
            this.lblFileInfo.TabIndex = 1;
            this.lblFileInfo.Text = "檔案位置：\r\n長度：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(548, 282);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 27);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "確定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 282);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "開始時間";
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(205, 106);
            this.txtTimeIn.MaxLength = 12;
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(138, 24);
            this.txtTimeIn.TabIndex = 14;
            this.txtTimeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeIn.TextChanged += new System.EventHandler(this.OnTextBoxesTextChange);
            this.txtTimeIn.Click += new EventHandler(this.OnTextBoxesClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "結束時間";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(376, 106);
            this.txtTimeOut.MaxLength = 12;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(138, 24);
            this.txtTimeOut.TabIndex = 14;
            this.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeOut.TextChanged += new System.EventHandler(this.OnTextBoxesTextChange);
            this.txtTimeOut.Click += new EventHandler(this.OnTextBoxesClicked);
            // 
            // lblCutInfo
            // 
            this.lblCutInfo.Location = new System.Drawing.Point(94, 144);
            this.lblCutInfo.Name = "lblCutInfo";
            this.lblCutInfo.Size = new System.Drawing.Size(584, 46);
            this.lblCutInfo.TabIndex = 1;
            this.lblCutInfo.Text = "中間長度：\r\n完成後按「確定」來新增。";
            // 
            // picIcon
            // 
            this.picIcon.Image = global::ListeningMaterialTool.Properties.Resources.ok_icon;
            this.picIcon.Location = new System.Drawing.Point(53, 147);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(30, 30);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 15;
            this.picIcon.TabStop = false;
            // 
            // frmNewAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 321);
            this.ControlBox = false;
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblCutInfo);
            this.Controls.Add(this.lblFileInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(706, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(706, 360);
            this.Name = "frmNewAudio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增音訊";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog opfDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.Label lblCutInfo;
        private System.Windows.Forms.PictureBox picIcon;
    }
}