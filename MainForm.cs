using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace SimpleBrowser
{
    public partial class MainForm : Form
    {
        private WebView2 webView;
        private ToolStrip toolStrip;
        private ToolStripButton backButton;
        private ToolStripButton forwardButton;
        private ToolStripButton refreshButton;
        private ToolStripTextBox addressBar;

        public MainForm()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private void InitializeComponent()
        {
            this.Text = "Simple Browser";
            this.Size = new Size(1024, 768);

            // Create toolbar
            toolStrip = new ToolStrip();
            this.Controls.Add(toolStrip);

            // Create buttons
            backButton = new ToolStripButton("Back");
            forwardButton = new ToolStripButton("Forward");
            refreshButton = new ToolStripButton("Refresh");
            addressBar = new ToolStripTextBox();
            addressBar.Size = new Size(400, 25);

            // Add buttons to toolbar
            toolStrip.Items.Add(backButton);
            toolStrip.Items.Add(forwardButton);
            toolStrip.Items.Add(refreshButton);
            toolStrip.Items.Add(addressBar);

            // Create WebView2
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);
        }

        private async void InitializeBrowser()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate("https://www.google.com");

            // Set up event handlers
            backButton.Click += (s, e) => webView.GoBack();
            forwardButton.Click += (s, e) => webView.GoForward();
            refreshButton.Click += (s, e) => webView.Reload();
            addressBar.KeyDown += AddressBar_KeyDown;
            webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = addressBar.Text;
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }
                webView.CoreWebView2.Navigate(url);
            }
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            addressBar.Text = webView.CoreWebView2.Source.ToString();
        }
    }
} 