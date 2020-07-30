using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LibVLCSharp;

namespace ListeningMaterialTool {
    partial class frmMain {
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
            this.listPending = new System.Windows.Forms.ListView();
            this.audioPlayer = new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)(this.audioPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "聆聽材料列表：";
            // 
            // listPending
            // 
            this.listPending.HideSelection = false;
            this.listPending.Location = new System.Drawing.Point(12, 35);
            this.listPending.Name = "listPending";
            this.listPending.Size = new System.Drawing.Size(416, 270);
            this.listPending.TabIndex = 0;
            this.listPending.UseCompatibleStateImageBehavior = false;
            // 
            // audioPlayer
            // 
            this.audioPlayer.BackColor = System.Drawing.Color.Black;
            this.audioPlayer.Location = new System.Drawing.Point(236, 12);
            this.audioPlayer.MediaPlayer = null;
            this.audioPlayer.Name = "audioPlayer";
            this.audioPlayer.Size = new System.Drawing.Size(98, 55);
            this.audioPlayer.TabIndex = 1;
            this.audioPlayer.Text = "videoView1";
            this.audioPlayer.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 450);
            this.Controls.Add(this.listPending);
            this.Controls.Add(this.audioPlayer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "聆聽材料實用工具";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.audioPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listPending;
        private LibVLCSharp.WinForms.VideoView audioPlayer;

        #endregion
    }
}