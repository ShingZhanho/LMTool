using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace ListeningMaterialTool {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            
        }

        private void listPending_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            e.Cancel = true;
            e.NewWidth = listPending.Columns[e.ColumnIndex].Width;
        }

        private void btnAppend_Click(object sender, EventArgs e) {
            frmNewAudio newAudio = new frmNewAudio();
            newAudio.ShowDialog();
        }
    }
}