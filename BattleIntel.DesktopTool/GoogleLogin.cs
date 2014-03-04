﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleIntel.DesktopTool
{
    /// <summary>
    /// Navigate to the google oath2 auth url and wait for a page with the Access Code in the title.
    /// </summary>
    public partial class GoogleLogin : Form
    {
        private readonly Uri authUri;

        public string AccessCode { get; private set; }

        public GoogleLogin(Uri authUri)
        {
            this.authUri = authUri;
            InitializeComponent();
        }

        private void GoogleLogin_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = authUri;
        }

        private void Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string title = webBrowser1.DocumentTitle;
            if (title.StartsWith("Source code="))
            {
                AccessCode = title.Split('=').Skip(1).First();
                DialogResult = AccessCode != null ? DialogResult.OK : DialogResult.Cancel;
            }
        }
    }
}
