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
        public frmAddSilence(AudioTaskItemsCollection audioTaskItemsCollection) {
            InitializeComponent();
            passInList = audioTaskItemsCollection;
        }

        // Values needed on start
        // public string TempPath { get; set; } // The temp dir for output
        public int Sequence { get; set; } // For file naming
        private AudioTaskItemsCollection passInList;

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
            // Using new classes
            if (passInList.Append((long) (numMins.Value * 60000 + numSecs.Value * 1000)) == null) {
                MessageBox.Show("無法新增音訊，程式遇到錯誤。", "失敗", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
                Close();
            }

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
