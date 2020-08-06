using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;

namespace ListeningMaterialTool {
    public partial class frmStart : Form {
        public frmStart() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private bool _appClosingForm;
        private bool _flag_DownloadDone, _flag_ExtractDone;

        private void frmStart_Load(object sender, System.EventArgs e) {
            // Display version
            lblVersion.Text = $"版本：{Settings.Default.App_VersionName}";
            lblVersion.Text += Settings.Default.App_VersionName.Contains("b") ? "（測試版本）" : "";

            // Skip this form
            if (CheckFiles()) {
                new frmMain().Show();
                _appClosingForm = true;
                Close();
            }

            // Check network
            btnStart.Enabled = IsConnected();
            btnStart.Text = btnStart.Enabled ? "開始" : "請連接到網際網路";
        }

        private bool CheckFiles() {
            var listToCheck = new [] {
                "./built_in_sound/Beep.mp3",
                "./built_in_sound/G_30.mp3",
                "./built_in_sound/G_60.mp3",
                "./built_in_sound/G_120.mp3",
                "./built_in_sound/G_180.mp3",
                "./built_in_sound/G_240.mp3",
                "./built_in_sound/G_300.mp3",
                "./ffmpeg/ffmpeg.exe"
            };
            var allExist = true;
            foreach (var file in listToCheck) {
                allExist = allExist && File.Exists(file);
            }
            return allExist;
        }

        private bool IsConnected() {
            try {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            } catch {
                return false;
            }
        }

        private void frmStart_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing && !_appClosingForm)
                Application.Exit();
        }

        private void btnStart_Click(object sender, System.EventArgs e) {
            btnStart.Text = "待作業完成後會自動開啟LMTool";
            btnStart.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // Download
            MyDownloadAsync(Settings.Default.URL_DownloadFfmpeg);

            // Extract
            ExtractFile();

            // Wait for all work done
            new Thread(() => {
                var loop = true;
                while (loop) {
                    Thread.Sleep(1000);
                    if (!_flag_DownloadDone || !_flag_ExtractDone) continue;
                    loop = false;
                    Application.Restart();
                }
            }).Start();
        }

        private async void MyDownloadAsync(string url) {
            if (!Directory.Exists("./ffmpeg")) Directory.CreateDirectory("./ffmpeg");
            if (File.Exists("./ffmpeg/ffmpeg.exe")) File.Delete("./ffmpeg/ffmpeg.exe");
            using (var client = new WebClient()) {
                client.DownloadFileCompleted += (sender, e) => {
                    lblFfmpeg.ForeColor = Color.ForestGreen;
                    lblFfmpeg.Text += "（完成）";
                    _flag_DownloadDone = true;
                };
                await client.DownloadFileTaskAsync(url,
                    "./ffmpeg/ffmpeg.exe");
            }
        }

        private async void ExtractFile() {
            var tempPath = $"{Path.GetTempPath()}/LMTool";
            var task = Task.Run(() => {
                if (Directory.Exists("./built_in_sound")) Directory.Delete("./built_in_sound", true);
                File.WriteAllBytes($@"{tempPath}/built_in_sound.zip", Resources.built_in_sound);
                ZipFile.ExtractToDirectory($@"{tempPath}/built_in_sound.zip",
                    Application.StartupPath);
                File.Delete($@"{tempPath}/built_in_sound.zip");

                lblSound.ForeColor = Color.ForestGreen;
                lblSound.Text += "（完成）";
                _flag_ExtractDone = true;
            });
            await task;
        }
    }
}