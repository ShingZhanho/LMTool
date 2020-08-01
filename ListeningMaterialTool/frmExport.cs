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
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmExport : Form {
        public frmExport() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        // values to receive
        public string SavePath { get; set; } // The path of the exported file
        public string TempPath { get; set; } // The temp path
        public ListView.ListViewItemCollection ProcessList { get; set; } // Trimming queue

        // private values
        private string _outputPath;
        private int _totalSteps;
        private int _currentStep = 1;

        private void frmExport_Load(object sender, EventArgs e) {
            TempPath = TempPath.Replace("\\", "/");
            // Create a output dir
            int i = 0;
            while (Directory.Exists($"{TempPath}/out{i}")) {
                i++;
            }
            Directory.CreateDirectory($"{TempPath}/out{i}");
            _outputPath = $"{TempPath}/out{i}";
            _totalSteps = ProcessList.Count + 1;
            pgbProgress.Maximum = _totalSteps;
            Log("開始匯出檔案...");
            Thread thread = new Thread(TrimAudio);
            thread.Start();
        }

        private void TrimAudio() {
            foreach (ListViewItem item in ProcessList) {
                _currentStep = ProcessList.IndexOf(item) + 1;
                pgbProgress.Value = _currentStep;
                lblProgress.Text = $"正在進行第{_currentStep}步，共{_totalSteps}步";
                Log($"正在裁剪第{_currentStep}段音訊（編號{item.Text}）");

                // start ffmpeg
                StartFfmpeg($"-i {item.SubItems[5].Text.Replace("\\","/")} " +
                                $"-ss {item.SubItems[2].Text} -to {item.SubItems[3].Text} " + 
                                $"-c copy {_outputPath}/{_currentStep}.mp3");
                while (!_trimDone) { int a = 0; } // Wait until done
            }
        }

        private bool _trimDone;

        private void StartFfmpeg(string args) {
            _trimDone = false;
            rtbTerminal.Text = "";
            var proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "./ffmpeg-4.3.1-win32-static/bin/ffmpeg.exe",
                    Arguments = args,
                    //CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            proc.Start();
            //Log($"Start ffmpeg with arguments {args}");  // Uncomment this line for debug purposes
            proc.WaitForExit();
            // get command line output
            while (!proc.StandardOutput.EndOfStream) {
                string line = proc.StandardOutput.ReadLine();
                rtbTerminal.Text += line;
                rtbTerminal.SelectionStart = rtbTerminal.Text.Length;
                rtbTerminal.ScrollToCaret();
            }
            _trimDone = true; // allow next step
        }

        private void Log(string text) {
            rtbLog.Text += text + "\n";
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }
    }
}
