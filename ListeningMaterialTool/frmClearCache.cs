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
using ListeningMaterialTool.Properties;

namespace ListeningMaterialTool {
    public partial class frmClearCache : Form {
        public frmClearCache() {
            InitializeComponent();
        }

        private void frmClearCache_Load(object sender, EventArgs e) {
            // Load settings
            radAutoClear.Checked = Settings.Default.CacheClear_Auto;

            // Get cache size
            lblCacheSize.Text = GetCacheSize(TempPath) + " " + _sizeUnit;
        }

        public string TempPath { get; set; }

        private string _sizeUnit = "KB";

        private int GetCacheSize(string path) {
            int size = 0;
            foreach (var directory in Directory.GetDirectories(path)) {
                size += GetCacheSize(directory);
            }

            foreach (var file in Directory.GetFiles(path)) {
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(file).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1) {
                    order++;
                    len = len / 1024;
                }
                _sizeUnit = sizes[order];

                size += (int) len;
            }

            return size;
        }

        private void radManually_CheckedChanged(object sender, EventArgs e) {
            chbAutoClear.Enabled = radManually.Checked;
            chbClearNow.Enabled = radManually.Checked;
            lblWarning.Visible = false;
        }

        private void chbClearNow_CheckedChanged(object sender, EventArgs e) {
            lblWarning.Visible = chbClearNow.Checked;
            if (chbClearNow.Checked) chbAutoClear.Checked = false;
        }

        private void chbAutoClear_CheckedChanged(object sender, EventArgs e) {
            if (chbAutoClear.Checked) chbClearNow.Checked = false;
        }

        private void btnApply_Click(object sender, EventArgs e) {
            Settings.Default.CacheClear_Auto = radAutoClear.Checked;
            Settings.Default.CacheClear_OnClose = chbAutoClear.Checked || chbClearNow.Checked;
            Settings.Default.CacheClear_ClearNow = chbClearNow.Checked;
            Settings.Default.Save();
            Close();
        }
    }
}
