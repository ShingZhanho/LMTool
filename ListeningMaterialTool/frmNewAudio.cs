using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LibVLCSharp.Shared;
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
        public int SecIn { get; set; } // In position in seconds
        public int SecOut { get; set; } // Out position in seconds
        public int AudioDuration { get; set; } // Duration of audio

        // Needed values when start up:
        public string TempDir { get; set; } // Identifies where to store the audio file

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private LibVLC libVlc;
        private MediaPlayer mediaPlayer;

        private void btnSelectFile_Click(object sender, EventArgs e) {
            LibVLCSharp.Shared.Core.Initialize();
            // Open file
            if (opfDialog.ShowDialog() != DialogResult.OK) return;
            FilePath = opfDialog.FileName;
            lblFileName.Text = FilePath;

            // Initial VLC objects
            libVlc = null;
            libVlc = new LibVLC();
            mediaPlayer = null;
            mediaPlayer = new MediaPlayer(libVlc);
            audioPlayer.MediaPlayer = mediaPlayer;
            //mediaPlayer.TimeChanged += mediaPlayer_TimeChanged;
            mediaPlayer.Media = new Media(libVlc, new Uri(FilePath.Replace("\\", "\\\\")));
            ParseMedia(); // ParseMedia and continue work
        }

        private void mediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e) {

        }

        private async void ParseMedia() {
            await mediaPlayer.Media.Parse(MediaParseOptions.FetchLocal,0);
            AudioDuration = Convert.ToInt32(mediaPlayer.Media.Duration) / 1000;

            // Set controls
            lblTotalTime.Text = SecToTime(AudioDuration);
            btnTogglePlay.Enabled = true;
            btnTrimIn.Enabled = true;
            btnTrimOut.Enabled = true;
            btnTenForward.Enabled = true;
            btnTenBackward.Enabled = true;
            audioProgress.Enabled = true;
            audioProgress.Maximum = AudioDuration;
            btnConfirm.Enabled = true;

            // Set default in and out
            SecIn = 0;
            SecOut = AudioDuration;
            UpdateSummary();
        }

        private string SecToTime(int sec) {
            TimeSpan ts = TimeSpan.FromSeconds(sec);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                ts.Hours, ts.Minutes, ts.Seconds);
        }

        private void UpdateSummary() {
            lblSummary.Text = $"裁剪撮要：\n" +
                              $"檔案：{Path.GetFileName(FilePath)}\n" +
                              $"從：{SecToTime(SecIn)}\n" +
                              $"至：{SecToTime(SecOut)}\n" +
                              $"長度：{SecToTime(SecOut - SecIn)}";
        }

        private void btnTogglePlay_Click(object sender, EventArgs e) {
            if (mediaPlayer.IsPlaying) {
                mediaPlayer.Pause();
                btnTogglePlay.BackgroundImage = null;
                btnTogglePlay.BackgroundImage = Resources.play;
            } else {
                mediaPlayer.Play();
                btnTogglePlay.BackgroundImage = null;
                btnTogglePlay.BackgroundImage = Resources.pause;
            }
        }

        private void frmNewAudio_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
