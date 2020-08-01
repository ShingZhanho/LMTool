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
using System.Windows.Forms.VisualStyles;
using WMPLib;

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

        // for playing alert
        WindowsMediaPlayer myplayer = new WindowsMediaPlayer();

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
            Thread thread = new Thread(ExportAudio);
            thread.Start();
        }

        private void ExportAudio() {
            foreach (ListViewItem item in ProcessList) {
                _currentStep = ProcessList.IndexOf(item) + 1;
                pgbProgress.Value = _currentStep;
                lblProgress.Text = $"正在進行第{_currentStep}步，共{_totalSteps}步";
                Log($"正在裁剪第{_currentStep}段音訊（編號{item.Text}）");

                // start ffmpeg
                StartFfmpeg($"-i {item.SubItems[5].Text.Replace("\\","/")} " +
                                $"-ss {item.SubItems[2].Text} -to {item.SubItems[3].Text} " + 
                                $"-acodec libmp3lame {_outputPath}/{_currentStep}.mp3");
                while (!File.Exists($"{_outputPath}/{_currentStep}.mp3")) { int a = 0; }
            }

            // generate audio_join.txt
            Log("正在準備合併清單");
            List<string> join_txt = new List<string>();
            int i = 1;
            while (File.Exists($"{_outputPath}/{i}.mp3")) {
                join_txt.Add($"file ./{i}.mp3");
                i++;
            }
            File.WriteAllLines($"{_outputPath}/audio_join.txt", join_txt.ToArray());

            // start to join files
            Log("開始合併檔案");
            Debug.Print("ARGS: " +
                $"-safe 0 -f concat -i \"{_outputPath}/audio_join.txt\" " +
                $"-c copy \"{_outputPath}/Output.mp3\"");
            StartFfmpeg($"-safe 0 -f concat -i \"{_outputPath}/audio_join.txt\" " +
                        $"-c copy \"{_outputPath}/Output.mp3\"");
            while (!File.Exists($"{_outputPath}/Output.mp3")) { int a = 0; }

            // Copy file to destination
            File.Copy($"{_outputPath}/Output.mp3", SavePath);
            Log("正在儲存檔案");

            // Wait
            Thread.Sleep(5000);

            // Done
            Log("合併完成。請試聽匯出的檔案，如果發現內容有誤，請關閉匯出視窗，然後重試。");
            pgbProgress.Value = pgbProgress.Maximum;
            lblStatus.Text = "目前狀態：全部完成。";
            lblProgress.Text = "完成";

            myplayer.URL = "./res/chord.mp3";
            myplayer.controls.play();
            MessageBox.Show("所有作業完成！", "完成", MessageBoxButtons.OK);

            if (chbOpenDir.Checked)
                Process.Start(new ProcessStartInfo("explorer.exe", 
                    $"{Path.GetDirectoryName(SavePath)}"));

            if (chbClose.Checked) Close();

            ControlBox = true;
        }

        private void StartFfmpeg(string args) {
            Debug.Print(args);
            var proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Path.GetFullPath("./ffmpeg-4.3.1-win32-static/bin/ffmpeg.exe"),
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
            proc.Start();
            //Log($"Start ffmpeg with arguments {args}");  // Uncomment this line for debug purposes
            proc.WaitForExit();
            Debug.Print("FFMPEG DONE");
        }

        private void Log(string text) {
            rtbLog.Text += text + "\n";
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e) {
            myplayer.close();
        }
    }
}
