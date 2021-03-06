﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;

// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();

            // Creates dirs
            if (!Directory.Exists($@"{Path.GetTempPath()}\LMTool"))
                Directory.CreateDirectory($@"{Path.GetTempPath()}LMTool");
            _tempPath = $@"{Path.GetTempPath()}LMTool\{DateTime.Now.ToString()
                .Replace("/", "").Replace(":", "")
                .Replace(" ", "")}";
            Directory.CreateDirectory(_tempPath);
            if (!Directory.Exists("./ProjectFiles/")) Directory.CreateDirectory("./ProjectFiles/");

            // Initialize AudioTaskItemsCollection
            _audioList = new AudioTaskItemsCollection(_tempPath);
        }

        //private bool isExported = true; // Indicates if all the changes are exported to a file
        private string _tempPath;
        private string _projectPath;
        private string _formTitle;
        private bool _firstSaved; // Indicates whether the application-generated project is saved somewhere.

        private AudioTaskItemsCollection _audioList;
        private List<SoundPlayer> _usedSoundPlayers; // Stores used players to be dispose when closing.

        private void frmMain_Load(object sender, EventArgs e) {
            // Shows version code if this is a beta version
            if (Settings.Default.App_VersionName.Contains("b"))
                _formTitle = $"{Text} {Settings.Default.App_VersionName}";
            Text = _formTitle;
            
            // Create project
            var i = 0;
            while (File.Exists($"./ProjectFiles/NewProject({i}).lmtproj")) i++;
            _projectPath = Path.GetFullPath($"./ProjectFiles/NewProject({i}).lmtproj");
            Text = $"{_formTitle} - {Path.GetFileNameWithoutExtension(_projectPath)}";
        }

        private void listPending_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            // Prevent columns width from being changed
            e.Cancel = true;
            e.NewWidth = listPending.Columns[e.ColumnIndex].Width;
        }

        #region Buttons Event Handler

        // Add audio to list
        private void btnAppend_Click(object sender, EventArgs e) {
            var opfDialog = new OpenFileDialog {
                Title = "選取音訊檔案",
                Filter = "音訊檔案|*.m4a;*.mp3;*.wav;*.wma;*.aac",
                RestoreDirectory = true
            };
            if (opfDialog.ShowDialog() != DialogResult.OK) return;
            var newAudio = new frmNewAudio(_audioList, opfDialog.FileName);
            if (newAudio.ShowDialog() != DialogResult.OK) return;

            // Update controls
            _audioList.ToListViewItemCollection(listPending);
            lblTotalTime.Text = $"總時長：{MsToTime(_audioList.totalDuration)}";
            btnExport.Enabled = listPending.Items.Count != 0;

            // Scroll to bottom
            if (listPending.Items.Count != 0)
                listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        // Remove audio from list
        private void btnRemove_Click(object sender, EventArgs e) {
            // Using new classes
            _audioList.Remove(listPending.SelectedItems[0]);
            lblTotalTime.Text = $"總時長：{MsToTime(_audioList.totalDuration)}";
            _audioList.ToListViewItemCollection(listPending);
            btnExport.Enabled = listPending.Items.Count != 0;
        }

        // Move item up
        private void btnUp_Click(object sender, EventArgs e) {
            // Using new classes
            var item = listPending.SelectedItems[0];
            var index = listPending.Items.IndexOf(item);
            _audioList.MoveItem(item, 1);
            _audioList.ToListViewItemCollection(listPending);

            // Select the item
            listPending.Items[index - 1].Selected = true;
        }

        // Move item down
        private void btnDown_Click(object sender, EventArgs e) {
            // Using new classes 
            var item = listPending.SelectedItems[0];
            var index = listPending.Items.IndexOf(item);
            _audioList.MoveItem(item, 0);
            _audioList.ToListViewItemCollection(listPending);

            // Select the item again
            listPending.Items[index + 1].Selected = true;
        }

        // Export
        private void btnExport_Click(object sender, EventArgs e) {
            if (!_audioList.ListIsValid()) {
                // List is invalid (files are missing)
                Alert();
                var s = "";
                foreach (var invalidItem in _audioList.GetInvalidItems())
                    s += $"音訊編號{invalidItem.Number.ToString()}，{invalidItem.Name}，檔案\n" +
                         $"　　{invalidItem.FilePath}已丟失 / 已被移動。\n\n";
                MessageBox.Show("警告：清單中的某些項目已經失效，程式沒有找到這些檔案。\n" +
                                "以下為失效的項目：\n\n" +
                                $"{s}在你從清單中刪除他們之前，程式將不能匯出檔案。",
                    "錯誤");
                return;
            }

            if (svfDialog.ShowDialog() == DialogResult.Cancel) return;
            var exportForm = new frmExport(_audioList);

            // TODO: Rebuild frmExport and rebuild these codes:
            exportForm.TempPath = _tempPath;
            exportForm.ProcessList = listPending.Items;
            exportForm.SavePath = svfDialog.FileName;
            exportForm.ShowDialog();
        }

        #endregion

        #region TimeConversion Related

        private string MsToTime(long ms) {
            var ts = TimeSpan.FromMilliseconds(ms);
            return $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}.{ts.Milliseconds:D3}";
        }

        private long TimeToMs(string time) {
            TimeSpan ts = new TimeSpan(0,
                int.Parse(time.Split(':')[0]),
                int.Parse(time.Split(':')[1]),
                int.Parse(time.Split(':')[2].Split('.')[1]),
                int.Parse(time.Split('.')[1]));
            return (long) ts.TotalMilliseconds;
        }

        #endregion

        #region ToolStripMenuItem Event Handler

        private void smtGreensleeves(object sender, EventArgs e) {
            var smItem = (ToolStripMenuItem) sender;
            if (smItem == smtGreen30) AppendGreensleeves(30);
            if (smItem == smtGreen60) AppendGreensleeves(60);
            if (smItem == smtGreen120) AppendGreensleeves(120);
            if (smItem == smtGreen180) AppendGreensleeves(180);
            if (smItem == smtGreen240) AppendGreensleeves(240);
            if (smItem == smtGreen300) AppendGreensleeves(300);
        }

        private void smtReset_Click(object sender, EventArgs e) {
            // Plays alert sound and show message
            Alert();
            var dialogResult =
                MessageBox.Show("你確定要重設所有內容？任何尚未儲存的變更都會丟失。",
                    "警告", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                Application.Restart();
            }
        }

        private void smtExit_Click(object sender, EventArgs e) {
            // Closes if changes not saved
            if (!_audioList.IsSaved) { // Changes not saved
                Alert();
                var dialogResult =
                    MessageBox.Show("你確定要退出嗎？你的專案仍有尚未儲存的變更。",
                        "警告", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
                else
                    return;
            }

            Application.Exit();
        }

        private void smtChkUpdate_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/ShingZhanho/LMTool/releases");
        }

        private void tsmTutorial_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/ShingZhanho/LMTool#readme");
        }

        private void tsmRIffmpeg_Click(object sender, EventArgs e) {
            Alert();
            MessageBox.Show(
                "此工具部分功能依賴ffmpeg運行。" +
                "如果你在使用應用程式的過程中遇到錯誤，重新安裝有關套件可能有助" +
                "解決有關問題。", "即將進行修復", MessageBoxButtons.OK);
            Directory.Delete("./ffmpeg/", true);
            Application.Restart();
        }

        private void smtRIGreensleeves_Click(object sender, EventArgs e) {
            Alert();
            MessageBox.Show(
                "此工具內置Greensleeves音樂及Beep聲效。" +
                "如果你在使用應用程式的過程中遇到錯誤，重置有關檔案可能有助" +
                "解決問題。", "即將進行修復", MessageBoxButtons.OK);
            Directory.Delete("./built_in_sound/", true);
            Application.Restart();
        }

        private void smtBeep_Click(object sender, EventArgs e) {
            // Using new classes
            _audioList.Append();
            _audioList.ToListViewItemCollection(listPending);

            lblTotalTime.Text = $"總時長：{MsToTime(_audioList.totalDuration)}";
            btnExport.Enabled = true;
            listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void smtClearCache_Click(object sender, EventArgs e) {
            var formClearCache = new frmClearCache();
            formClearCache.TempPath = Path.GetDirectoryName(_tempPath);
            formClearCache.ShowDialog();
            if (Settings.Default.CacheClear_ClearNow) Application.Restart();
        }

        private void smtAddSilence_Click(object sender, EventArgs e) {
            var formSilence = new frmAddSilence(_audioList);
            formSilence.ShowDialog();
            if (formSilence.DialogResult != DialogResult.OK) return;

            // Using new classes
            _audioList.ToListViewItemCollection(listPending);

            lblTotalTime.Text = $"總時長：{MsToTime(_audioList.totalDuration)}";
            btnExport.Enabled = true;
            listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void tsmAbout_Click(object sender, EventArgs e) {
            var formAbout = new frmAbout();
            formAbout.Show();
        }

        // Save list
        private void tsmSave_Click(object sender, EventArgs e) {
            if (!_firstSaved) {
                tsmSaveAs_Click(sender, e);
                return;
            }

            _audioList.SaveFile(_projectPath);
        }

        private void tsmSaveAs_Click(object sender, EventArgs e) {
            // Save File as
            var saveProjectDialog = new SaveFileDialog {
                Filter = "LMTool專案|*.lmtproj",
                AddExtension = true,
                FileName = $"{Path.GetFileName(_projectPath)}",
                RestoreDirectory = true,
                Title = "儲存專案"
            };
            if (saveProjectDialog.ShowDialog() != DialogResult.OK) return;
            _projectPath = _audioList.SaveFile(saveProjectDialog.FileName);
            _firstSaved = true;
        }

        private void tsmNewProject_Click(object sender, EventArgs e) {
            // Check if current project saved
            if (!_audioList.IsSaved) {
                Alert();
                var dr = MessageBox.Show(
                    "現有的專案尚未儲存，你是否要儲存變更？",
                    "儲存變更",
                    MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes) tsmSave_Click(sender, e);
                if (dr == DialogResult.Cancel) return;
            }

            // Creates new temp dir
            _tempPath = $@"{Path.GetTempPath()}LMTool\{DateTime.Now.ToString()
                .Replace("/", "").Replace(":", "").Replace(" ", "")}";
            Directory.CreateDirectory(_tempPath);

            // Re-create AudioTaskItemsCollection object
            _audioList = new AudioTaskItemsCollection(_tempPath);

            // Create a new file
            var i = 0;
            while (File.Exists($"./ProjectFiles/NewProject({i}).lmtproj")) i++;
            _projectPath = Path.GetFullPath($"./ProjectFiles/NewProject({i}).lmtproj");
            Text = $"{_formTitle} - {Path.GetFileNameWithoutExtension(_projectPath)}";
            _audioList.SaveFile(_projectPath);
            _firstSaved = false;

            // Clean up UI
            _audioList.ToListViewItemCollection(listPending);
            btnExport.Enabled = false;
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            lblTotalTime.Text = $"總時間：{MsToTime(_audioList.totalDuration)}";
        }

        // Load list from a project file (.lmtproj)
        private void tsmOpenProject_Click(object sender, EventArgs e) {
            // Check if current project saved
            if (!_audioList.IsSaved) {
                Alert();
                var dr = MessageBox.Show(
                    "現有的專案尚未儲存，你是否要儲存變更？",
                    "儲存變更",
                    MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes) tsmSave_Click(sender, e);
                if (dr == DialogResult.Cancel) return;
            }

            // Chooses file
            var openDialog = new OpenFileDialog {
                Filter = "LMTool專案|*.lmtproj",
                Title = "開啟舊檔",
                RestoreDirectory = true
            };
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            _projectPath = openDialog.FileName;

            // Creates new temp dir
            _tempPath = $@"{Path.GetTempPath()}LMTool\{DateTime.Now.ToString()
                .Replace("/", "").Replace(":", "").Replace(" ", "")}";
            Directory.CreateDirectory(_tempPath);

            // Re-create AudioTaskItemsCollection object
            _audioList = new AudioTaskItemsCollection(openDialog.FileName, _tempPath);

            // Clean up UI
            _audioList.ToListViewItemCollection(listPending);
            btnExport.Enabled = false;
            btnDown.Enabled = false;
            btnUp.Enabled = false;
            lblTotalTime.Text = $"總時間：{MsToTime(_audioList.totalDuration)}";
        }

        #endregion

        private void AppendGreensleeves(int sec) {
            // Using new classes
            _audioList.Append(sec);
            _audioList.ToListViewItemCollection(listPending);

            lblTotalTime.Text = $"總時長：{MsToTime(_audioList.totalDuration)}";
            btnExport.Enabled = true;
            listPending.Items[listPending.Items.Count - 1].EnsureVisible();
        }

        private void listPending_SelectedIndexChanged(object sender, EventArgs e) {
            if (listPending.SelectedItems.Count == 0) {
                btnRemove.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else {
                btnRemove.Enabled = true;
                btnUp.Enabled = listPending.SelectedItems[0] != listPending.Items[0];
                btnDown.Enabled =
                    listPending.SelectedItems[0] != listPending.Items[listPending.Items.Count - 1];
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Closes if changes not saved
            if (!_audioList.IsSaved && e.CloseReason != CloseReason.ApplicationExitCall) { // Changes not saved
                Alert();
                var dialogResult =
                    MessageBox.Show("你確定要退出嗎？你的專案有尚未儲存的變更。",
                        "警告", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }

            // Clear cache
            if (Settings.Default.CacheClear_OnClose) {
                foreach (var dir in Directory.GetDirectories(Path.GetDirectoryName(_tempPath))) {
                    Directory.Delete(dir, true);
                }
            }

            if (!Settings.Default.CacheClear_Auto) {
                Settings.Default.CacheClear_ClearNow = false;
                Settings.Default.CacheClear_OnClose = false;
            }

            Settings.Default.Save();
            Application.Exit();

            // Dispose SoundPlayer
            if (_usedSoundPlayers != null) foreach (var player in _usedSoundPlayers) player.Dispose();
        }

        private void Alert() {
            var player = new SoundPlayer(Resources.chord);
            player.Play();
            _usedSoundPlayers = _usedSoundPlayers ?? new List<SoundPlayer>();
            _usedSoundPlayers.Add(player);
        }
    }
}