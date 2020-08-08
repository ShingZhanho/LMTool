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
        }

        private AudioTaskItemsCollection _audioList;
        private string _filename;

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnTextBoxesTextChange(object sender, EventArgs e) {
            var textBox = (TextBox) sender;
            if (new []{2,5,8}.Contains(textBox.Text.Length)) textBox.AppendText(textBox.Text.Length == 8 ? "." : ":");
        }

        private void OnTextBoxesClicked(object sender, EventArgs e) {
            var textBox = (TextBox) sender;
            textBox.SelectAll();
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
