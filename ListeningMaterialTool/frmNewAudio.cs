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
        public long SecIn { get; set; } // In position in milliseconds
        public long SecOut { get; set; } // Out position in milliseconds
        public long AudioDuration { get; set; } // Duration of audio

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

            LoadAudio();
        }

        private void LoadAudio() {
            // Initial VLC objects
            libVlc = null;
            libVlc = new LibVLC();
            mediaPlayer = null;
            mediaPlayer = new MediaPlayer(libVlc);
            audioPlayer.MediaPlayer = mediaPlayer;
            mediaPlayer.TimeChanged += mediaPlayer_TimeChanged;
            mediaPlayer.EndReached += mediaPlayer_EndReached;
            mediaPlayer.Stop();
            mediaPlayer.Media = new Media(libVlc, new Uri(FilePath.Replace("\\", "\\\\")));
            ParseMedia(); // ParseMedia and continue work
        }

        private void mediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e) {
            if(e.Time <= audioProgress.Maximum) UpdateControls(e.Time);
        }

        private async void ParseMedia() {
            await mediaPlayer.Media.Parse(MediaParseOptions.FetchLocal,0);
            AudioDuration = mediaPlayer.Media.Duration;

            // Set controls
            lblTotalTime.Text = MsToTime(AudioDuration);
            btnTogglePlay.Enabled = true;
            btnTrimIn.Enabled = true;
            btnTrimOut.Enabled = true;
            btnTenForward.Enabled = true;
            audioProgress.Enabled = true;
            audioProgress.Maximum = Convert.ToInt32(AudioDuration);
            btnConfirm.Enabled = true;

            mediaPlayer.Play();

            // Set default in and out
            SecIn = 0;
            SecOut = Convert.ToInt32(AudioDuration);
            UpdateSummary();
        }

        private void mediaPlayer_EndReached(object sender, EventArgs e) {
            UpdateControls(AudioDuration);
        }

        private void UpdateControls(long time) {
            // Progress bar
            if (!sliderIsPressed)
                audioProgress.Value = Convert.ToInt32(time);

            // Trim in button
            btnTrimIn.Enabled = audioProgress.Value < SecOut;

            // Trim out button
            btnTrimOut.Enabled = audioProgress.Value > SecIn;

            // 10 forward button
            btnTenForward.Enabled = audioProgress.Value + 10000 <= AudioDuration;

            // 10 backward button
            btnTenBackward.Enabled = audioProgress.Value - 10000 >= 0;

            // Update label
            lblCurrentTime.Text = MsToTime(audioProgress.Value);
        }

        private string MsToTime(long ms) {
            TimeSpan ts = TimeSpan.FromMilliseconds(ms);
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void UpdateSummary() {
            lblSummary.Text = $"裁剪撮要：\n" +
                              $"檔案：{Path.GetFileName(FilePath)}\n" +
                              $"從：{MsToTime(SecIn)}\n" +
                              $"至：{MsToTime(SecOut)}\n" +
                              $"長度：{MsToTime(SecOut - SecIn)}";
        }

        private void btnTogglePlay_Click(object sender, EventArgs e) {
            if (mediaPlayer.Media == null) {
                LoadAudio();
            }
            if (mediaPlayer.IsPlaying) {
                mediaPlayer.Pause();
                btnTogglePlay.Image = null;
                btnTogglePlay.Image = Resources.play;
            } else {
                mediaPlayer.Play();
                btnTogglePlay.Image = null;
                btnTogglePlay.Image = Resources.pause;
            }
        }

        private void frmNewAudio_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }

        private bool sliderIsPressed;

        // Hold slider
        private void audioProgress_MouseDown(object sender, MouseEventArgs e) {
            sliderIsPressed = true;
        }

        private void audioProgress_MouseUp(object sender, MouseEventArgs e) {
            sliderIsPressed = false;
            mediaPlayer.Time = audioProgress.Value;
        }

        private void btnTrimIn_Click(object sender, EventArgs e) {
            SecIn = mediaPlayer.Time;
            UpdateSummary();
        }

        private void btnTrimOut_Click(object sender, EventArgs e) {
            SecOut = mediaPlayer.Time;
            UpdateSummary();
        }

        private void btnTenBackward_Click(object sender, EventArgs e) {
            mediaPlayer.Time -= 10000;
        }

        private void btnTenForward_Click(object sender, EventArgs e) {
            mediaPlayer.Time += 10000;
        }

        private void frmNewAudio_FormClosing(object sender, FormClosingEventArgs e) {
            // Dispose and stop playback
            mediaPlayer.Stop();
            mediaPlayer.Dispose();
            libVlc.Dispose();
        }
    }
}
