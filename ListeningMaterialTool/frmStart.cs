using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;

namespace ListeningMaterialTool {
    public partial class frmStart : Form {
        public frmStart() {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, System.EventArgs e) {
            // Display version
            lblVersion.Text = $"版本：{Settings.Default.App_VersionName}";
            lblVersion.Text += Settings.Default.App_VersionName.Contains("b") ? "（測試版本）" : "";

            // Skip this form
            if (CheckFiles()) {
                new frmMain().Show();
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
    }
}