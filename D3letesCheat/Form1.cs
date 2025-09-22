using EasyTabs;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;

namespace D3letesCheat
{
    public partial class Form1 : Form
    {
        private WebView2 webView; // Actual browser control
        public TitleBarTab ParentTab { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true; // Capture key events at form level
            this.KeyDown += Form1_KeyDown;
            this.Resize += Form1_Resize;

            // Initialize WebView2 and add to panel
            webView = new WebView2 { Dock = DockStyle.Fill };
            webView21.Controls.Add(webView);
            InitializeAsync();

            // Search box setup
            guna2TextBox1.Visible = true;
            guna2TextBox1.LostFocus += guna2TextBox1_LostFocus;
            guna2TextBox1.KeyDown += guna2TextBox1_KeyDown;
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

        private async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);

            webView.CoreWebView2.Settings.IsScriptEnabled = true;
            webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
            webView.CoreWebView2.Settings.AreDevToolsEnabled = true;

            // Update search box after navigation
            webView.CoreWebView2.NavigationCompleted += (s, e) =>
            {
                if (webView?.CoreWebView2 != null)
                    guna2TextBox1.Text = webView.Source?.AbsoluteUri ?? "";
            };

            // Navigate to home page
            string homePageHtml = @"
<!DOCTYPE html>
<html>
<head>
    <title>D3 Home</title>
    <style>
        html, body { height: 100%; margin: 0; background-color: rgb(36,36,36); color: white; font-family: Arial,sans-serif; }
        body { display: flex; justify-content: center; align-items: center; flex-direction: column; text-align: center; }
        h1 { margin:0 0 20px 0; font-size:5vw; }
        img { width:20vw; max-width:400px; height:auto; }
    </style>
</head>
<body>
    <h1>Chomp Browser!</h1>
    <h2>take a byte out the web</h2>
    <img src='https://raw.githubusercontent.com/d3letereal/image/refs/heads/main/Screenshot_2025-09-22_022548-removebg-preview.png' alt='Home Image'>
</body>
</html>";

            string htmlDataUri = "data:text/html;charset=utf-8," + Uri.EscapeDataString(homePageHtml);
            webView.CoreWebView2.Navigate(htmlDataUri);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (guna2TextBox1 == null || webView21 == null || guna2ImageButton1 == null || guna2ImageButton2 == null)
                return;

            int topMargin = 5;
            int sideMargin = 10;
            int spacing = 5;

            // Search box
            guna2TextBox1.Top = topMargin;
            guna2TextBox1.Left = sideMargin;
            guna2TextBox1.Width = this.ClientSize.Width - (guna2ImageButton1.Width + guna2ImageButton2.Width + (spacing * 3) + sideMargin * 2);

            // YouTube button
            guna2ImageButton1.Top = topMargin;
            guna2ImageButton1.Left = guna2TextBox1.Right + spacing;

            // Discord button
            guna2ImageButton2.Top = topMargin;
            guna2ImageButton2.Left = guna2ImageButton1.Right + spacing;

            // Resize panel for WebView2
            int webViewTop = guna2TextBox1.Bottom + topMargin;
            webView21.Top = webViewTop;
            webView21.Left = 0;
            webView21.Width = this.ClientSize.Width;
            webView21.Height = this.ClientSize.Height - webViewTop;
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                guna2TextBox1.Visible = false;
            else if (e.KeyCode == Keys.Enter)
            {
                string input = guna2TextBox1.Text.Trim();
                string url = (input.Contains(".") && !input.Contains(" "))
                    ? (input.StartsWith("http://") || input.StartsWith("https://") ? input : "https://" + input)
                    : "https://duckduckgo.com/?q=" + Uri.EscapeDataString(input);

                webView?.CoreWebView2?.Navigate(url);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            webView?.CoreWebView2?.Navigate("https://www.youtube.com");
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            webView?.CoreWebView2?.Navigate("https://www.discord.com");
        }

        private void guna2TextBox1_LostFocus(object sender, EventArgs e)
        {
            guna2TextBox1.SelectionLength = 0;
            guna2TextBox1.SelectionStart = 0;
        }
    }
}
