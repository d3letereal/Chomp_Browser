using Chomp;
using Chomp.HTML;
using EasyTabs;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;

namespace D3letesCheat
{
    public partial class Main : Form
    {
        private WebView2 webView;
        public TitleBarTab ParentTab { get; set; }

        private string currentFriendlyUrl = "Chomp://home";

        public Main()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.Resize += Form1_Resize;

            webView = new WebView2 { Dock = DockStyle.Fill };
            webView21.Controls.Add(webView);

            // Setup textbox
            guna2TextBox1.Visible = true;
            guna2TextBox1.LostFocus += guna2TextBox1_LostFocus;
            guna2TextBox1.KeyDown += guna2TextBox1_KeyDown;
            guna2TextBox1.Text = currentFriendlyUrl;

            InitializeAsync();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oem3) // ` key
            {
                guna2TextBox1.Visible = !guna2TextBox1.Visible;
                if (guna2TextBox1.Visible)
                {
                    guna2TextBox1.BringToFront();
                    guna2TextBox1.Focus();
                }
                e.Handled = true;
            }
        }

        private void CoreWebView2_DocumentTitleChanged(object sender, object e)
        {
            if (webView?.CoreWebView2 == null) return;

            string title = webView.CoreWebView2.DocumentTitle;

            this.Text = string.IsNullOrWhiteSpace(title) ? "New Tab" : title;
        }

        private async void InitializeAsync()
        {
            if (webView.CoreWebView2 != null) return;

            try
            {
                string userDataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "ChompBrowserWebView2"
                );
                Directory.CreateDirectory(userDataFolder);

                var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: userDataFolder);
                await webView.EnsureCoreWebView2Async(env);

                webView.CoreWebView2.Settings.IsScriptEnabled = true;
                webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
                webView.CoreWebView2.Settings.AreDevToolsEnabled = true;

                // Prevent about:blank from ever showing
                webView.CoreWebView2.NavigationStarting += (s, e) =>
                {
                    if (e.Uri == "about:blank")
                    {
                        e.Cancel = true;
                        NavigateHome();
                    }
                };

                // Navigate immediately to Home
                NavigateHome();

                // Update textbox after navigation
                webView.CoreWebView2.NavigationCompleted += (s, e) =>
                {
                    guna2TextBox1.Text = currentFriendlyUrl;

                    if (!e.IsSuccess)
                        NavigateOffline();
                };

                webView.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("WebView2 initialization failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateHome()
        {
            currentFriendlyUrl = "Chomp://home";
            webView?.CoreWebView2?.Navigate(HTML.HomePage());
        }

        private void NavigateBytePage()
        {
            currentFriendlyUrl = "Chomp://byte";
            webView?.CoreWebView2?.Navigate(HTML.BytePage());
        }

        private void NavigateOffline()
        {
            currentFriendlyUrl = "Chomp://offline";
            webView?.CoreWebView2?.Navigate(HTML.OfflinePage());
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (guna2TextBox1 == null || webView21 == null || guna2ImageButton1 == null || guna2ImageButton2 == null)
                return;

            int topMargin = 5;
            int sideMargin = 10;
            int spacing = 5;

            guna2TextBox1.Top = topMargin;
            guna2TextBox1.Left = sideMargin;
            guna2TextBox1.Width = this.ClientSize.Width - (guna2ImageButton1.Width + guna2ImageButton2.Width + (spacing * 3) + sideMargin * 2);

            guna2ImageButton1.Top = topMargin;
            guna2ImageButton1.Left = guna2TextBox1.Right + spacing;

            guna2ImageButton2.Top = topMargin;
            guna2ImageButton2.Left = guna2ImageButton1.Right + spacing;

            int webViewTop = guna2TextBox1.Bottom + topMargin;
            webView21.Top = webViewTop;
            webView21.Left = 0;
            webView21.Width = this.ClientSize.Width;
            webView21.Height = this.ClientSize.Height - webViewTop;
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                guna2TextBox1.Visible = false;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                string input = guna2TextBox1.Text.Trim();

                if (string.Equals(input, "Chomp://home", StringComparison.OrdinalIgnoreCase))
                    NavigateHome();
                else if (string.Equals(input, "Chomp://byte", StringComparison.OrdinalIgnoreCase))
                    NavigateBytePage();
                else
                {
                    if (!IsInternetAvailable())
                        NavigateOffline();
                    else
                    {
                        string url = (input.Contains(".") && !input.Contains(" "))
                            ? (input.StartsWith("http://") || input.StartsWith("https://") ? input : "https://" + input)
                            : "https://duckduckgo.com/?q=" + Uri.EscapeDataString(input);

                        currentFriendlyUrl = url;
                        webView?.CoreWebView2?.Navigate(url);
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (webView?.CoreWebView2?.CanGoBack == true)
                webView.CoreWebView2.GoBack();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            webView?.CoreWebView2?.Reload();
        }

        private void guna2TextBox1_LostFocus(object sender, EventArgs e)
        {
            guna2TextBox1.SelectionLength = 0;
            guna2TextBox1.SelectionStart = 0;
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.duckduckgo.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
