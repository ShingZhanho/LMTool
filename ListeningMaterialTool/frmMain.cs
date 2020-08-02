﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;
using WMPLib;
// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private const string VersionCode = "v0.2-b";

        private long totalMs = 0;
        private bool isExported = true; // Indicates if all the changes are exported to a file
        private string tempPath;
        private int sequence = 0;

        private void frmMain_Load(object sender, EventArgs e) {
            // Shows version code if this is a beta version
            if (VersionCode.Contains("b")) Text = $"{Text} {VersionCode}";
            // Creates dirs
            if (!Directory.Exists("./res/")) Directory.CreateDirectory("./res/");
            if (!Directory.Exists($@"{Path.GetTempPath()}\LMTool"))
                Directory.CreateDirectory($@"{Path.GetTempPath()}LMTool");
            tempPath = $@"{Path.GetTempPath()}LMTool\{DateTime.Now.ToString()
                .Replace("/", "").Replace(":","").Replace(" ","")}";
            Directory.CreateDirectory(tempPath);

            // finds the ffmpeg
            if (!Directory.Exists($"./ffmpeg-4.3.1-win32-static"))
                UnzipFfmpeg();

            // finds built in sounds
            if (!Directory.Exists($"./built_in_sounds"))
                UnzipSounds();

            // finds sound file
            if (!File.Exists("./res/chord.mp3"))
                File.WriteAllBytes("./res/chord.mp3", Resources.chord);
        }

        private void UnzipFfmpeg() {
            if (Directory.Exists("./ffmpeg-4.3.1-win32-static"))
                Directory.Delete("./ffmpeg-4.3.1-win32-static", true);
            // unzip ffmpeg dependency
            File.WriteAllBytes($@"{tempPath}/ffmpeg.zip", Resources.ffmpeg_utilities);
            ZipFile.ExtractToDirectory($@"{tempPath}/ffmpeg.zip",
                Application.StartupPath);
            File.Delete($@"{tempPath}/ffmpeg.zip");
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
            tsmExport.Enabled = listPending.Items.Count != 0;

            // Scroll to bottom
            if (listPending.Items.Count != 0)
                listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void AppendGreensleeves(int sec) {
            ListViewItem lstItem = new ListViewItem();
            sequence++;
            lstItem.Text = sequence.ToString();
            lstItem.SubItems.Add("綠袖子音樂");
            lstItem.SubItems.Add(MsToTime(0));
            lstItem.SubItems.Add(MsToTime(sec * 1000));
            lstItem.SubItems.Add(MsToTime(sec * 1000));
            File.Copy(Path.GetFullPath($"./built_in_sound/G_" +
                                       $"{(sec == 30 ? 30 : sec / 60)}.mp3"), 
                $"{tempPath}/{lstItem.Text}.mp3");
            lstItem.SubItems.Add($"{tempPath}/{lstItem.Text}.mp3");
            listPending.Items.Add(lstItem);
            totalMs += sec * 1000;
            lblTotalTime.Text = $"總時長：{MsToTime(totalMs)}";
            isExported = false;
            tsmExport.Enabled = true;
            listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void smtGreensleeves(object sender, EventArgs e) {
            ToolStripMenuItem smItem = (ToolStripMenuItem) sender;
            if (smItem == smtGreen30) AppendGreensleeves(30);
            if (smItem == smtGreen60) AppendGreensleeves(60);
            if (smItem == smtGreen120) AppendGreensleeves(120);
            if (smItem == smtGreen180) AppendGreensleeves(180);
            if (smItem == smtGreen240) AppendGreensleeves(240);
            if (smItem == smtGreen300) AppendGreensleeves(300);
        }

        

        private string MsToTime(long ms) {
            TimeSpan ts = TimeSpan.FromMilliseconds(ms);
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void smtReset_Click(object sender, EventArgs e) {
            // Plays alert sound and show message
            Alert();
            DialogResult dialogResult =
                MessageBox.Show("你確定要重設所有內容？任何未匯出的更改都會丟失。",
                    "警告", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                Application.Restart();
            }
        }

        private void smtExit_Click(object sender, EventArgs e) {
            // Closes if changes not saved
            if (!isExported) { // Changes not saved
                Alert();
                DialogResult dialogResult =
                    MessageBox.Show("你確定要退出嗎？你有尚未匯出的內容。",
                        "警告", MessageBoxButtons.YesNo);
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
                Alert();
                DialogResult dialogResult =
                    MessageBox.Show("你確定要退出嗎？你有尚未匯出的內容。",
                        "警告", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }

            // Clear cache
            if (Settings.Default.CacheClear_OnClose) {
                foreach (var dir in Directory.GetDirectories(Path.GetDirectoryName(tempPath))) {
                    Directory.Delete(dir, true);
                }
            }
            if (!Settings.Default.CacheClear_Auto) {
                Settings.Default.CacheClear_ClearNow = false;
                Settings.Default.CacheClear_OnClose = false;
            }
            Settings.Default.Save();
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
            File.Delete(listPending.SelectedItems[0].SubItems[5].Text);
            totalMs -= TimeToMs(listPending.SelectedItems[0].SubItems[4].Text);
            lblTotalTime.Text = $"總時長：{MsToTime(totalMs)}";
            listPending.Items.Remove(listPending.SelectedItems[0]);
            tsmExport.Enabled = listPending.Items.Count != 0;
            isExported = false;
        }

        private void btnUp_Click(object sender, EventArgs e) {
            ListViewItem lstItem = listPending.SelectedItems[0];
            int index = listPending.Items.IndexOf(listPending.SelectedItems[0]);
            listPending.Items.Remove(listPending.SelectedItems[0]);
            listPending.Items.Insert(index - 1, lstItem);
            isExported = false;
        }

        private void btnDown_Click(object sender, EventArgs e) {
            ListViewItem lstItem = listPending.SelectedItems[0];
            int index = listPending.Items.IndexOf(listPending.SelectedItems[0]);
            listPending.Items.Remove(listPending.SelectedItems[0]);
            listPending.Items.Insert(index + 1, lstItem);
            isExported = false;
        }

        private void smtChkUpdate_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/ShingZhanho/LMTool/releases");
        }

        private void tsmTutorial_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/ShingZhanho/LMTool#readme");
        }

        private void tsmRIffmpeg_Click(object sender, EventArgs e) {
            Alert();
            MessageBox.Show(
                "此工具部分功能依賴ffmpeg運行。" +
                "如果你在使用應用程式的過程中遇到錯誤，重新安裝有關套件可能有助" +
                "解決有關問題。", "即將進行修復", MessageBoxButtons.OK);
            UnzipFfmpeg();
            Alert();
            MessageBox.Show(
                "已經重新安裝ffmpeg，現在請再次嘗試", "修復完成", MessageBoxButtons.OK);
        }

        private void UnzipSounds() {
            if (Directory.Exists("./built_in_sound"))
                Directory.Delete("./built_in_sound", true);
            // unzip ffmpeg dependency
            File.WriteAllBytes($@"{tempPath}/greensleeves.zip", Resources.built_in_sound);
            ZipFile.ExtractToDirectory($@"{tempPath}/greensleeves.zip",
                Application.StartupPath);
            File.Delete($@"{tempPath}/greensleeves.zip");
        }

        private void smtRIGreensleeves_Click(object sender, EventArgs e) {
            Alert();
            MessageBox.Show(
                "此工具內置Greensleeves音樂及Beep聲效。" +
                "如果你在使用應用程式的過程中遇到錯誤，重置有關檔案可能有助" +
                "解決問題。", "即將進行修復", MessageBoxButtons.OK);
            UnzipSounds();
            Alert();
            MessageBox.Show(
                "已經重置音效檔，現在請再次嘗試", "修復完成", MessageBoxButtons.OK);
        }

        private void Alert() {
            WindowsMediaPlayer myplayer = new WindowsMediaPlayer();
            myplayer.URL = "./res/chord.mp3";
            myplayer.controls.play();
        }

        private void smtBeep_Click(object sender, EventArgs e) {
            // append beep sound
            ListViewItem lstItem = new ListViewItem();
            sequence++;
            lstItem.Text = sequence.ToString();
            lstItem.SubItems.Add("Beep音效");
            lstItem.SubItems.Add(MsToTime(0));
            lstItem.SubItems.Add(MsToTime(839));
            lstItem.SubItems.Add(MsToTime(839));
            File.Copy(Path.GetFullPath($"./built_in_sound/Beep.mp3"),
                $"{tempPath}/{lstItem.Text}.mp3");
            lstItem.SubItems.Add($"{tempPath}/{lstItem.Text}.mp3");
            listPending.Items.Add(lstItem);
            totalMs += 839;
            lblTotalTime.Text = $"總時長：{MsToTime(totalMs)}";
            isExported = false;
            tsmExport.Enabled = true;
            listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void tsmExport_Click(object sender, EventArgs e) {
            if (svfDialog.ShowDialog() == DialogResult.Cancel) return;
            frmExport exportForm = new frmExport();
            exportForm.TempPath = tempPath;
            exportForm.ProcessList = listPending.Items;
            exportForm.SavePath = svfDialog.FileName;
            exportForm.ShowDialog();
            isExported = true;
        }

        private void smtClearCache_Click(object sender, EventArgs e) {
            frmClearCache formClearCache = new frmClearCache();
            formClearCache.TempPath = Path.GetDirectoryName(tempPath);
            formClearCache.ShowDialog();
            if (Settings.Default.CacheClear_ClearNow) Application.Restart();
        }

        private void smtAddSilence_Click(object sender, EventArgs e) {
            frmAddSilence formSilence = new frmAddSilence();
            sequence++;
            formSilence.Sequence = sequence;
            formSilence.TempPath = tempPath;
            formSilence.ShowDialog();
            if (formSilence.DialogResult == DialogResult.OK) {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = formSilence.Sequence.ToString();
                lstItem.SubItems.Add("無聲片段");
                lstItem.SubItems.Add(MsToTime(0));
                lstItem.SubItems.Add(MsToTime(formSilence.AudioLength));
                lstItem.SubItems.Add(MsToTime(formSilence.AudioLength));
                lstItem.SubItems.Add(formSilence.FilePath);
                listPending.Items.Add(lstItem);
                totalMs += formSilence.AudioLength;
                lblTotalTime.Text = $"總時長：{MsToTime(totalMs)}";
                isExported = false;
                tsmExport.Enabled = true;
                listPending.Items[listPending.Items.Count - 1].EnsureVisible();
            }
        }

        // Converts hh:mm:ss.fff to milliseconds
        private long TimeToMs(string time) {
            TimeSpan ts = new TimeSpan (0, 
                int.Parse(time.Split(':')[0]),
                int.Parse(time.Split(':')[1]),
                int.Parse(time.Split(':')[2].Split('.')[1]),
                int.Parse(time.Split('.')[1]));
            return (long) ts.TotalMilliseconds;
        }
    }
}