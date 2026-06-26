using System;
using System.Windows.Forms;

namespace BA_WinForms.UI
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
            this.Load += MapForm_Load;
        }

        private async void MapForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Initializing map...";

                // Initialize WebView2
                await webView21.EnsureCoreWebView2Async(null);

                // Google Maps URL for UET Lahore
                string url = "https://www.google.com/maps/place/University+of+Engineering+and+Technology,+Lahore/@31.579944,74.354982,17z";

                // Navigate to Google Maps
                webView21.CoreWebView2.Navigate(url);

                lblStatus.Text = "Map loaded successfully!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading map: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error loading map";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}