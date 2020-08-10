using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;

// ReSharper disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmNewAudio : Form {
        public frmNewAudio(AudioTaskItemsCollection audioList, string filename) {
            InitializeComponent();
            _audioList = audioList;
            _filename = filename;
            CheckForIllegalCrossThreadCalls = false;
            _audioFile = new AudioFile(filename);
        }

        private AudioTaskItemsCollection _audioList;
        private readonly string _filename;
        private readonly AudioFile _audioFile;

        #region Buttons events handler

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            
            // Add new item to list
            _audioList.Append(_filename, trbIn.Value, trbOut.Value);
            
            Close();
        }

        #endregion
        
        // TrackBar values change
        private void OnTrackBarValueChange(object sender, EventArgs e) {
            if (trbIn.Value >= trbOut.Value) { // In time is later than Out time
                btnConfirm.Enabled = false;
                lblTrimInfo.Text = "開始時間不應比結束時間遲，或與結束時間相同。";
            }
            else {
                btnConfirm.Enabled = true;
                lblTrimInfo.Text = $"由 {MsToTime(trbIn.Value)} 開始" +
                                   $"至 {MsToTime(trbOut.Value)} 結束，" +
                                   $"中間時長 {MsToTime(trbOut.Value - trbIn.Value)} 。";
            }
        }

        private void OnFormLoad(object sender, EventArgs e) {
            // Set track bars
            trbIn.Maximum = Convert.ToInt32(_audioFile.Duration);
            trbOut.Maximum = Convert.ToInt32(_audioFile.Duration);
            trbOut.Value = trbOut.Maximum;
            
            // Set labels
            lblFileInfo.Text = $"檔案名稱：{_filename}\n長度：{MsToTime(_audioFile.Duration)}";
            lblTrimInfo.Text = $"由 {MsToTime(trbIn.Value)} 開始" +
                               $"至 {MsToTime(trbOut.Value)} 結束，" +
                               $"中間時長 {MsToTime(trbOut.Value - trbIn.Value)} 。";
        }
        
        private string MsToTime(long ms) {
            TimeSpan ts = TimeSpan.FromMilliseconds(ms);
            return $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
        }

        //private void UpdateSummary() {
        //    lblSummary.Text = $"裁剪撮要：\n" +
        //                      $"檔案：{Path.GetFileName(FilePath)}\n" +
        //                      $"從：{MsToTime(SecIn)}\n" +
        //                      $"至：{MsToTime(SecOut)}\n" +
        //                      $"長度：{MsToTime(SecOut - SecIn)}";
        //}
    }
}