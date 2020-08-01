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
            this.clmNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smtReset = new System.Windows.Forms.ToolStripMenuItem();
            this.smtExit = new System.Windows.Forms.ToolStripMenuItem();
            this.smtSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen30 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen60 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen120 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen180 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen240 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtGreen300 = new System.Windows.Forms.ToolStripMenuItem();
            this.smtBeep = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRIffmpeg = new System.Windows.Forms.ToolStripMenuItem();
            this.smtRIGreensleeves = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.smtChkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.svfDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.smtClearCache = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.smtAddSilence = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "聆聽材料清單：";
            // 
            // listPending
            // 
            this.listPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPending.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNum,
            this.clmFileName,
            this.clmIn,
            this.clmOut,
            this.clmLength});
            this.listPending.FullRowSelect = true;
            this.listPending.GridLines = true;
            this.listPending.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listPending.HideSelection = false;
            this.listPending.Location = new System.Drawing.Point(12, 60);
            this.listPending.MultiSelect = false;
            this.listPending.Name = "listPending";
            this.listPending.Size = new System.Drawing.Size(956, 418);
            this.listPending.TabIndex = 0;
            this.listPending.UseCompatibleStateImageBehavior = false;
            this.listPending.View = System.Windows.Forms.View.Details;
            this.listPending.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listPending_ColumnWidthChanging);
            this.listPending.SelectedIndexChanged += new System.EventHandler(this.listPending_SelectedIndexChanged);
            // 
            // clmNum
            // 
            this.clmNum.Text = "編號";
            // 
            // clmFileName
            // 
            this.clmFileName.Text = "檔案名稱";
            this.clmFileName.Width = 468;
            // 
            // clmIn
            // 
            this.clmIn.Text = "開始時間";
            this.clmIn.Width = 130;
            // 
            // clmOut
            // 
            this.clmOut.Text = "結束時間";
            this.clmOut.Width = 130;
            // 
            // clmLength
            // 
            this.clmLength.Text = "長度";
            this.clmLength.Width = 130;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.smtSequence,
            this.tsmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExport,
            this.toolStripSeparator1,
            this.smtReset,
            this.smtExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(45, 20);
            this.menuFile.Text = "檔案";
            // 
            // tsmExport
            // 
            this.tsmExport.Enabled = false;
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(180, 22);
            this.tsmExport.Text = "匯出檔案";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // smtReset
            // 
            this.smtReset.Name = "smtReset";
            this.smtReset.Size = new System.Drawing.Size(180, 22);
            this.smtReset.Text = "重設所有內容";
            this.smtReset.Click += new System.EventHandler(this.smtReset_Click);
            // 
            // smtExit
            // 
            this.smtExit.Name = "smtExit";
            this.smtExit.Size = new System.Drawing.Size(180, 22);
            this.smtExit.Text = "結束";
            this.smtExit.Click += new System.EventHandler(this.smtExit_Click);
            // 
            // smtSequence
            // 
            this.smtSequence.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmRepair});
            this.smtSequence.Name = "smtSequence";
            this.smtSequence.Size = new System.Drawing.Size(71, 20);
            this.smtSequence.Text = "實用工具";
            // 
            // tsmAdd
            // 
            this.tsmAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smtGreen,
            this.smtBeep,
            this.toolStripSeparator4,
            this.smtAddSilence});
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(191, 22);
            this.tsmAdd.Text = "加入內建音效";
            // 
            // smtGreen
            // 
            this.smtGreen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smtGreen30,
            this.smtGreen60,
            this.smtGreen120,
            this.smtGreen180,
            this.smtGreen240,
            this.smtGreen300});
            this.smtGreen.Name = "smtGreen";
            this.smtGreen.Size = new System.Drawing.Size(180, 22);
            this.smtGreen.Text = "綠袖子音樂";
            // 
            // smtGreen30
            // 
            this.smtGreen30.Name = "smtGreen30";
            this.smtGreen30.Size = new System.Drawing.Size(106, 22);
            this.smtGreen30.Text = "30秒";
            this.smtGreen30.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtGreen60
            // 
            this.smtGreen60.Name = "smtGreen60";
            this.smtGreen60.Size = new System.Drawing.Size(106, 22);
            this.smtGreen60.Text = "1分鐘";
            this.smtGreen60.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtGreen120
            // 
            this.smtGreen120.Name = "smtGreen120";
            this.smtGreen120.Size = new System.Drawing.Size(106, 22);
            this.smtGreen120.Text = "2分鐘";
            this.smtGreen120.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtGreen180
            // 
            this.smtGreen180.Name = "smtGreen180";
            this.smtGreen180.Size = new System.Drawing.Size(106, 22);
            this.smtGreen180.Text = "3分鐘";
            this.smtGreen180.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtGreen240
            // 
            this.smtGreen240.Name = "smtGreen240";
            this.smtGreen240.Size = new System.Drawing.Size(106, 22);
            this.smtGreen240.Text = "4分鐘";
            this.smtGreen240.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtGreen300
            // 
            this.smtGreen300.Name = "smtGreen300";
            this.smtGreen300.Size = new System.Drawing.Size(106, 22);
            this.smtGreen300.Text = "5分鐘";
            this.smtGreen300.Click += new System.EventHandler(this.smtGreensleeves);
            // 
            // smtBeep
            // 
            this.smtBeep.Name = "smtBeep";
            this.smtBeep.Size = new System.Drawing.Size(180, 22);
            this.smtBeep.Text = "Beep音效";
            this.smtBeep.Click += new System.EventHandler(this.smtBeep_Click);
            // 
            // tsmRepair
            // 
            this.tsmRepair.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRIffmpeg,
            this.smtRIGreensleeves,
            this.toolStripSeparator3,
            this.smtClearCache});
            this.tsmRepair.Name = "tsmRepair";
            this.tsmRepair.Size = new System.Drawing.Size(191, 22);
            this.tsmRepair.Text = "錯誤修正及提升效能";
            // 
            // tsmRIffmpeg
            // 
            this.tsmRIffmpeg.Name = "tsmRIffmpeg";
            this.tsmRIffmpeg.Size = new System.Drawing.Size(191, 22);
            this.tsmRIffmpeg.Text = "重新安裝ffmpeg套件";
            this.tsmRIffmpeg.Click += new System.EventHandler(this.tsmRIffmpeg_Click);
            // 
            // smtRIGreensleeves
            // 
            this.smtRIGreensleeves.Name = "smtRIGreensleeves";
            this.smtRIGreensleeves.Size = new System.Drawing.Size(191, 22);
            this.smtRIGreensleeves.Text = "重置內建聲音檔";
            this.smtRIGreensleeves.Click += new System.EventHandler(this.smtRIGreensleeves_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.smtChkUpdate,
            this.toolStripSeparator2,
            this.tsmTutorial});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(45, 20);
            this.tsmHelp.Text = "幫助";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmAbout.Text = "關於";
            // 
            // smtChkUpdate
            // 
            this.smtChkUpdate.Name = "smtChkUpdate";
            this.smtChkUpdate.Size = new System.Drawing.Size(180, 22);
            this.smtChkUpdate.Text = "檢查更新";
            this.smtChkUpdate.Click += new System.EventHandler(this.smtChkUpdate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmTutorial
            // 
            this.tsmTutorial.Name = "tsmTutorial";
            this.tsmTutorial.Size = new System.Drawing.Size(180, 22);
            this.tsmTutorial.Text = "使用教學";
            this.tsmTutorial.Click += new System.EventHandler(this.tsmTutorial_Click);
            // 
            // btnAppend
            // 
            this.btnAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppend.Location = new System.Drawing.Point(12, 484);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(242, 28);
            this.btnAppend.TabIndex = 3;
            this.btnAppend.Text = "新增音訊到清單中";
            this.btnAppend.UseVisualStyleBackColor = true;
            this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(260, 484);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(242, 28);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "從清單移除所選音訊";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Enabled = false;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(974, 141);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 35);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Enabled = false;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(974, 367);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(35, 35);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTime.Location = new System.Drawing.Point(780, 481);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(188, 31);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "總時長：00:00:00.000";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // svfDialog
            // 
            this.svfDialog.DefaultExt = "mp3";
            this.svfDialog.FileName = "Export";
            this.svfDialog.Filter = "MP3|*.mp3";
            this.svfDialog.Title = "龨出檔案至...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // smtClearCache
            // 
            this.smtClearCache.Name = "smtClearCache";
            this.smtClearCache.Size = new System.Drawing.Size(191, 22);
            this.smtClearCache.Text = "清除暫存檔案";
            this.smtClearCache.Click += new System.EventHandler(this.smtClearCache_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // smtAddSilence
            // 
            this.smtAddSilence.Name = "smtAddSilence";
            this.smtAddSilence.Size = new System.Drawing.Size(180, 22);
            this.smtAddSilence.Text = "無聲片段";
            this.smtAddSilence.Click += new System.EventHandler(this.smtAddSilence_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 525);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAppend);
            this.Controls.Add(this.listPending);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(766, 416);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聆聽材料實用工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listPending;

        #endregion

        private ColumnHeader clmFileName;
        private ColumnHeader clmIn;
        private ColumnHeader clmOut;
        private ColumnHeader clmLength;
        private ColumnHeader clmNum;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem tsmExport;
        private ToolStripMenuItem smtReset;
        private ToolStripMenuItem smtExit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem smtSequence;
        private ToolStripMenuItem tsmAdd;
        private ToolStripMenuItem smtGreen;
        private ToolStripMenuItem smtGreen30;
        private ToolStripMenuItem smtGreen60;
        private ToolStripMenuItem smtGreen120;
        private ToolStripMenuItem smtGreen180;
        private ToolStripMenuItem smtGreen240;
        private ToolStripMenuItem smtGreen300;
        private ToolStripMenuItem smtBeep;
        private ToolStripMenuItem tsmHelp;
        private ToolStripMenuItem smtChkUpdate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmTutorial;
        private Button btnAppend;
        private Button btnRemove;
        private Button btnUp;
        private Button btnDown;
        private ToolStripMenuItem tsmAbout;
        private Label lblTotalTime;
        private ToolStripMenuItem tsmRepair;
        private ToolStripMenuItem tsmRIffmpeg;
        private ToolStripMenuItem smtRIGreensleeves;
        private SaveFileDialog svfDialog;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem smtClearCache;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem smtAddSilence;
    }
}