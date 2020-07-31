﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using ListeningMaterialTool.Properties;
using WMPLib;

namespace ListeningMaterialTool {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private bool isExported = false; // Indicates if all the changes are exported to a file

        private void frmMain_Load(object sender, EventArgs e) {
            

            // Creates dirs
            if (!Directory.Exists("./res/")) Directory.CreateDirectory("./res/");
        }

        private void listPending_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            // Prevent columns width to be changed
            e.Cancel = true;
            e.NewWidth = listPending.Columns[e.ColumnIndex].Width;
        }

        private void btnAppend_Click(object sender, EventArgs e) {
            frmNewAudio newAudio = new frmNewAudio();
            if (newAudio.ShowDialog() == DialogResult.OK) { // Clicks on OK, add item
                ListViewItem lstItem = new ListViewItem();
                lstItem.Name = listPending.Items.Count.ToString(); // Number
                lstItem.SubItems.Add(Path.GetFileName(newAudio.FilePath)); // Filename
                TimeSpan ts = TimeSpan.FromSeconds(newAudio.SecIn);
                lstItem.SubItems.Add(string.Format("{0:D2}:{1:D2}:{2:D2}",
                    ts.Hours, ts.Minutes, ts.Seconds));       // In time
                ts = TimeSpan.FromSeconds(newAudio.SecOut);
                lstItem.SubItems.Add(string.Format("{0:D2}:{1:D2}:{2:D2}",
                    ts.Hours, ts.Minutes, ts.Seconds));       // Out time
                ts = TimeSpan.FromSeconds(newAudio.SecOut - newAudio.SecIn);
                lstItem.SubItems.Add(string.Format("{0:D2}:{1:D2}:{2:D2}",
                    ts.Hours, ts.Minutes, ts.Seconds));       // Duration
            }
        }

        private void smtReset_Click(object sender, EventArgs e) {
            // Plays alert sound and show message
            if (!File.Exists("./res/chord.mp3"))
                File.WriteAllBytes("./res/chord.mp3", Resources.chord);
            WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
            myplayer.URL = "./res/chord.mp3";
            myplayer.controls.play();
            DialogResult dialogResult =
                MessageBox.Show("你確定要重設所有內容？任何未匯出的更改都會丟失。",
                    "警告", MessageBoxButtons.YesNo);
            myplayer.close();
            if (dialogResult == DialogResult.Yes) {
                Application.Restart();
            }
        }

        private void smtExit_Click(object sender, EventArgs e) {
            // Closes if changes not saved
            if (!isExported) { // Changes not saved
                WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
                myplayer.URL = "./res/chord.mp3";
                myplayer.controls.play();
                DialogResult dialogResult =
                    MessageBox.Show("你確定要退出嗎？你有尚未匯出的內容。",
                        "警告", MessageBoxButtons.YesNo);
                myplayer.close();
                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
                else 
                    return;
            }
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Closes if changes not saved
            if (!isExported && e.CloseReason != CloseReason.ApplicationExitCall) { // Changes not saved
                WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
                myplayer.URL = "./res/chord.mp3";
                myplayer.controls.play();
                DialogResult dialogResult =
                    MessageBox.Show("你確定要退出嗎？你有尚未匯出的內容。",
                        "警告", MessageBoxButtons.YesNo);
                myplayer.close();
                if (dialogResult == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }
            Application.Exit();
        }
    }
}