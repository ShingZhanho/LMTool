namespace ListeningMaterialTool {
    partial class frmClearCache {
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCacheSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbAutoClear = new System.Windows.Forms.CheckBox();
            this.radAutoClear = new System.Windows.Forms.RadioButton();
            this.radManually = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.chbClearNow = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "目前的暫存檔案已經佔用：";
            // 
            // lblCacheSize
            // 
            this.lblCacheSize.AutoSize = true;
            this.lblCacheSize.Location = new System.Drawing.Point(54, 55);
            this.lblCacheSize.Name = "lblCacheSize";
            this.lblCacheSize.Size = new System.Drawing.Size(43, 18);
            this.lblCacheSize.TabIndex = 1;
            this.lblCacheSize.Text = "0 MB";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 149);
            this.label2.TabIndex = 2;
            this.label2.Text = "        暫存檔案是程式在匯出檔案前會用到的檔案，使用暫存檔案可以避免原來的檔案受到破壞。\r\n        匯出檔案後，程式便不會再使用這些檔案。你可以安" +
    "全地刪除這些檔案，亦可以設定程式在關閉前自動清理。";
            // 
            // chbAutoClear
            // 
            this.chbAutoClear.AutoSize = true;
            this.chbAutoClear.Location = new System.Drawing.Point(309, 127);
            this.chbAutoClear.Name = "chbAutoClear";
            this.chbAutoClear.Size = new System.Drawing.Size(222, 22);
            this.chbAutoClear.TabIndex = 3;
            this.chbAutoClear.Text = "關閉程式前清理一次（推薦）";
            this.chbAutoClear.UseVisualStyleBackColor = true;
            this.chbAutoClear.CheckedChanged += new System.EventHandler(this.chbAutoClear_CheckedChanged);
            // 
            // radAutoClear
            // 
            this.radAutoClear.AutoSize = true;
            this.radAutoClear.Location = new System.Drawing.Point(276, 55);
            this.radAutoClear.Name = "radAutoClear";
            this.radAutoClear.Size = new System.Drawing.Size(206, 22);
            this.radAutoClear.TabIndex = 4;
            this.radAutoClear.TabStop = true;
            this.radAutoClear.Text = "每次關閉程式前，自動清理";
            this.radAutoClear.UseVisualStyleBackColor = true;
            // 
            // radManually
            // 
            this.radManually.AutoSize = true;
            this.radManually.Checked = true;
            this.radManually.Location = new System.Drawing.Point(276, 99);
            this.radManually.Name = "radManually";
            this.radManually.Size = new System.Drawing.Size(86, 22);
            this.radManually.TabIndex = 5;
            this.radManually.TabStop = true;
            this.radManually.Text = "手動清理";
            this.radManually.UseVisualStyleBackColor = true;
            this.radManually.CheckedChanged += new System.EventHandler(this.radManually_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "目前的暫存檔案清理設定：";
            // 
            // chbClearNow
            // 
            this.chbClearNow.AutoSize = true;
            this.chbClearNow.Location = new System.Drawing.Point(309, 155);
            this.chbClearNow.Name = "chbClearNow";
            this.chbClearNow.Size = new System.Drawing.Size(87, 22);
            this.chbClearNow.TabIndex = 7;
            this.chbClearNow.Text = "立即清理";
            this.chbClearNow.UseVisualStyleBackColor = true;
            this.chbClearNow.CheckedChanged += new System.EventHandler(this.chbClearNow_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(591, 224);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(94, 29);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "套用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWarning.Location = new System.Drawing.Point(273, 210);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(302, 43);
            this.lblWarning.TabIndex = 9;
            this.lblWarning.Text = "警告：立即清理將會重新啟動程式，未匯出的變更將會丟失。";
            this.lblWarning.Visible = false;
            // 
            // frmClearCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 265);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.chbClearNow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radManually);
            this.Controls.Add(this.radAutoClear);
            this.Controls.Add(this.chbAutoClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCacheSize);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(713, 304);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(713, 304);
            this.Name = "frmClearCache";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "暫存檔案清理";
            this.Load += new System.EventHandler(this.frmClearCache_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCacheSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbAutoClear;
        private System.Windows.Forms.RadioButton radAutoClear;
        private System.Windows.Forms.RadioButton radManually;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbClearNow;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblWarning;
    }
}