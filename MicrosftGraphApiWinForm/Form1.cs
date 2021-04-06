using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosftGraphApiWinForm
{
    public partial class Form1 : Form
    {
        string clientId = null;

        public static string[] Scopes = { "User.Read" };

        public Form1()
        {
            InitializeComponent();

            clientId = Properties.Settings.Default.ClientId;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // 設定チェック
            if (string.IsNullOrEmpty(Properties.Settings.Default.ClientId) &&
                Program.AccessToken == null)
            {
                this.InvokeOnClick(this.buttonConfig, e);
                return;
            }
        }
        DelegateAuthenticationProvider authProvider
        {
            get
            {
                var authProvider = new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        {
                            if (Program.AccessToken == null)
                            {
                                Program.AccessToken = await GetTokenForUserAsync();
                            }
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", Program.AccessToken);
                        });
                return authProvider;
            }
        }

        GraphServiceClient graphClient
        {
            get
            {
                if (_graphClient == null)
                {
                    _graphClient = new GraphServiceClient(authProvider);
                }

                return _graphClient;
            }
        }
        GraphServiceClient _graphClient;

        private async Task<HttpClient> getHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();

                if (Program.AccessToken == null)
                {
                    Program.AccessToken = await GetTokenForUserAsync();
                }
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Program.AccessToken);
            }

            return _httpClient;
        }
        HttpClient _httpClient;

        public async Task<string> GetTokenForUserAsync()
        {
            var pca = PublicClientApplicationBuilder.Create(clientId)
                .Build();

            AuthenticationResult authResult = await pca.AcquireTokenInteractive(Scopes)

                .ExecuteAsync().ConfigureAwait(false);
            return authResult.AccessToken;
        }

        void Display(Entity data)
        {
            string txt = Newtonsoft.Json.JsonConvert.SerializeObject(data, Formatting.Indented);
            this.textBox2.Text = txt;
        }

        void Display(IEnumerable<Entity> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{ value: [");
            foreach (Entity data in list)
            {
                string txt = Newtonsoft.Json.JsonConvert.SerializeObject(data, Formatting.Indented);
                sb.AppendLine(txt);
                sb.AppendLine(",");
            }
            sb.AppendLine("]");
            sb.AppendLine("}");
            this.textBox2.Text = sb.ToString();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            ConfigForm frm = new ConfigForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.clientId = Properties.Settings.Default.ClientId;
                _graphClient = null;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // URL を使った Microsoft Graph API アクセス

            var http = await getHttpClient();

            var result = await http.GetAsync(this.textBox1.Text);
            string txt = await result.Content.ReadAsStringAsync();

            // 結果表示
            this.textBox2.Text = txt;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Microsoft.Graph.GraphServiceClient を使った データ取得

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var user = await graphClient.Me
                   .Request()
                   .Select("displayName,givenName,postalCode")
                   .GetAsync();

            // 結果表示
            Display(user);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var messages = await graphClient.Me.Messages
                .Request()
                .GetAsync();

            // 結果表示
            Display(messages);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var applications = await graphClient.Applications
                .Request()
                .GetAsync();

            // 結果表示
            Display(applications);
        }
    }
}
