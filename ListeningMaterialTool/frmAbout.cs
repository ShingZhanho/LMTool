﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListeningMaterialTool.Properties;

// ReSharper Disable LocalizableElement

namespace ListeningMaterialTool {
    public partial class frmAbout : Form {
        public frmAbout() {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/ShingZhanho/LMTool/releases");
        }

        private void frmAbout_Load(object sender, EventArgs e) {
            label2.Text = $"版本：{Settings.Default.App_VersionName}";
        }
    }
}
