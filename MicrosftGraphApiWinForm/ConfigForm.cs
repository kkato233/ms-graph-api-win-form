using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosftGraphApiWinForm
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-v2-windows-desktop";
            System.Diagnostics.Process.Start(url);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (clientIdChange)
            {
                Properties.Settings.Default.ClientId = this.textClientId.Text;
                Properties.Settings.Default.Save();
            }

            if (accessTokenChange)
            {
                Program.AccessToken = this.textAccessToken.Text;
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private bool accessTokenChange = false;

        private void textAccessToken_TextChanged(object sender, EventArgs e)
        {
            accessTokenChange = true;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            if (Program.AccessToken != null)
            {
                this.textAccessToken.Text = Program.AccessToken;
            }
            this.textClientId.Text = Properties.Settings.Default.ClientId;
            clientIdChange = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://developer.microsoft.com/ja-jp/graph/graph-explorer";
            System.Diagnostics.Process.Start(url);
        }

        bool clientIdChange = false;

        private void textClientId_TextChanged(object sender, EventArgs e)
        {
            clientIdChange = true;
        }
    }
}
