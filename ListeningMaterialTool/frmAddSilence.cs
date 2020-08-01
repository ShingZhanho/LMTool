using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListeningMaterialTool {
    public partial class frmAddSilence : Form {
        public frmAddSilence() {
            InitializeComponent();
        }

        // Values needed on start
        public string TempPath { get; set; } // The temp dir for output
        public int Sequence { get; set; } // For file naming

        // Values to be returned
        public string FilePath { get; set; } // The path of the silence audio file
        public int AudioLength { get; set; } // The length of the file in milliseconds

        private void frmAddSilence_Load(object sender, EventArgs e) {

        }

        private void numMins_ValueChanged(object sender, EventArgs e) {
            btnOK.Enabled =
                numMins.Value + numSecs.Value != 0;
            numMins.Maximum = numMins.Value + 1;
        }

        private void numSecs_ValueChanged(object sender, EventArgs e) {
            btnOK.Enabled =
                numMins.Value + numSecs.Value != 0;
            if (numSecs.Value == 60) {
                numSecs.Value = 0;
                numMins.Value++;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            // Generate audio with ffmpeg
            var proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "./ffmpeg-4.3.1-win32-static/bin/ffmpeg.exe",
                    Arguments = $"-f lavfi -i anullsrc=r=11025:cl=mono -t " +
                                $"{numMins.Value * 60 + numSecs.Value} " +
                                $" {TempPath}/{Sequence}.m4a",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            proc.Start();
            proc.WaitForExit();

            // Set value
            FilePath = $"{TempPath}/{Sequence}.m4a";
            AudioLength = Convert.ToInt32(numMins.Value * 60 + numSecs.Value) * 1000;

            // Close
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            // Close
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
