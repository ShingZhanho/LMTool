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
        public frmNewAudio() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Return values:
        public string FilePath { get; set; } // Audio file location
        public long SecIn { get; set; } // In position in milliseconds
        public long SecOut { get; set; } // Out position in milliseconds
        public long AudioDuration { get; set; } // Duration of audio

        // Needed values when start up:
        public string TempDir { get; set; } // Identifies where to store the audio file
        public int seq { get; set; } // sequence of the current file

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            //RealPath = $@"{TempDir}\{seq.ToString()}{Path.GetExtension(FilePath)}";
            //File.Copy(FilePath, RealPath);
            Close();
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


        private void frmNewAudio_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }

        
        private void frmNewAudio_FormClosing(object sender, FormClosingEventArgs e) {
            // Dispose and stop playback
            
        }
    }
}
