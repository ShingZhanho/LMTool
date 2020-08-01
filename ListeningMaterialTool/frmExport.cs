using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmExport : Form {
        public frmExport() {
            InitializeComponent();
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
            // Create a output dir
            int i = 0;
            while (Directory.Exists($"{TempPath}/out{i}")) {
                i++;
            }
            Directory.CreateDirectory($"{TempPath}/out{i}");
            _outputPath = $"{TempPath}/out{i}";
            _totalSteps = ProcessList.Count + 1;
            pgbProgress.Maximum = _totalSteps;
            pgbProgress.Value = _currentStep;
            lblProgress.Text = $"正在進行第{_currentStep}步，共{_totalSteps}步";
            rtbLog.Text += "開始匯出檔案...";
        }
    }
}
