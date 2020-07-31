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
using ListeningMaterialTool.Properties;
using WMPLib;

namespace ListeningMaterialTool {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private long totalMs = 0;
        private bool isExported = true; // Indicates if all the changes are exported to a file
        private string tempPath;
        private int sequence = 0;

        private void frmMain_Load(object sender, EventArgs e) {
            // Creates dirs
            if (!Directory.Exists("./res/")) Directory.CreateDirectory("./res/");
            if (!Directory.Exists($@"{Path.GetTempPath()}\LMTool"))
                Directory.CreateDirectory($@"{Path.GetTempPath()}LMTool");
            tempPath = $@"{Path.GetTempPath()}LMTool\{DateTime.Now.ToString()
                .Replace("/", "").Replace(":","")}";
            Directory.CreateDirectory(tempPath);
        }

        private void listPending_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            // Prevent columns width from being changed
            e.Cancel = true;
            e.NewWidth = listPending.Columns[e.ColumnIndex].Width;
        }

        private void btnAppend_Click(object sender, EventArgs e) {
            frmNewAudio newAudio = new frmNewAudio();
            newAudio.TempDir = tempPath;
            sequence++;
            newAudio.seq = sequence;
            if (newAudio.ShowDialog() == DialogResult.OK) { // Clicks on OK, add item
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = newAudio.seq.ToString();                 // Number
                lstItem.SubItems.Add(Path.GetFileName(newAudio.FilePath));           // Filename
                lstItem.SubItems.Add(string.Format(MsToTime(newAudio.SecIn)));       // In time
                lstItem.SubItems.Add(MsToTime(newAudio.SecOut));                     // Out time
                lstItem.SubItems.Add(MsToTime(newAudio.SecOut - newAudio.SecIn));    // Duration
                lstItem.SubItems.Add(newAudio.RealPath);
                totalMs += newAudio.SecOut - newAudio.SecIn;
                listPending.Items.Add(lstItem);
                isExported = false;
                lblTotalTime.Text = $"總時長：{MsToTime(totalMs)}";
            }
        }

        private string MsToTime(long ms) {
            TimeSpan ts = TimeSpan.FromMilliseconds(ms);
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
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

        private void listPending_SelectedIndexChanged(object sender, EventArgs e) {
            if (listPending.SelectedItems.Count == 0) {
                btnRemove.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            } else {
                btnRemove.Enabled = true;
                btnUp.Enabled = listPending.SelectedItems[0] != listPending.Items[0];
                btnDown.Enabled = 
                    listPending.SelectedItems[0] != listPending.Items[listPending.Items.Count - 1];
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            listPending.Items.Remove(listPending.SelectedItems[0]);
        }

        private void btnUp_Click(object sender, EventArgs e) {
            ListViewItem lstItem = listPending.SelectedItems[0];
            int index = listPending.Items.IndexOf(listPending.SelectedItems[0]);
            listPending.Items.Remove(listPending.SelectedItems[0]);
            listPending.Items.Insert(index - 1, lstItem);
        }

        private void btnDown_Click(object sender, EventArgs e) {
            ListViewItem lstItem = listPending.SelectedItems[0];
            int index = listPending.Items.IndexOf(listPending.SelectedItems[0]);
            listPending.Items.Remove(listPending.SelectedItems[0]);
            listPending.Items.Insert(index + 1, lstItem);
        }
    }
}