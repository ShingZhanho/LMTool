using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ListeningMaterialTool.Properties;

// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmExport : Form {
        public frmExport(AudioTaskItemsCollection collection) {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            passInList = collection;
        }

        // values to receive
        public string SavePath { get; set; } // The path of the exported file
        public string TempPath { get; set; } // The temp path
        public ListView.ListViewItemCollection ProcessList { get; set; } // Trimming queue
        private AudioTaskItemsCollection passInList;

        private List<SoundPlayer> _usedSoundPlayers;

        private void frmExport_Load(object sender, EventArgs e) {
            TempPath = TempPath.Replace("\\", "/");

            // Creates output object
            var outputObj = new Output(rtbLog, pgbProgress);
            
            // Export (works in a new thread)
            var exportThread = new Thread(
                () => {
                    var isSuccess = passInList.ExportFile(outputObj, SavePath);
                    
                    // Changes controls' states
                    chbClose.Enabled = false;
                    chbOpenDir.Enabled = false;
                    ControlBox = true;
                    
                    if (isSuccess) {
                        // Is succeeded
                        Alert();
                        MessageBox.Show(
                            "檔案已成功匯出，請在關閉程式前先試聽匯出的檔案，如發現內容有誤，你應立即嘗試重新匯出。",
                            "成功");

                        if (chbOpenDir.Checked) Process.Start(Path.GetDirectoryName(SavePath));
                        if (chbClose.Checked) Close();
                    }
                    else {
                        // Is failed
                        Alert();
                        MessageBox.Show(
                            "由於原因不明的錯誤，檔案未能成功匯出。你可嘗試重新匯出。",
                            "失敗");
                        
                        if (chbClose.Checked) Close();
                    }
                });
            exportThread.Start();
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (var player in _usedSoundPlayers) player.Dispose(); // Dispose used players
        }

        private void Alert() {
            var player = new SoundPlayer(Resources.chord);
            _usedSoundPlayers = _usedSoundPlayers ?? new List<SoundPlayer>();
            player.Play();
            _usedSoundPlayers.Add(player);
        }
    }
}
