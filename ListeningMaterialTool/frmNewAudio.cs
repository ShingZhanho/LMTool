using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
