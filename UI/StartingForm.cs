using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA_WinForms
{
    public partial class StartingForm : Form
    {
        public static Panel MainPanel;

        public StartingForm()
        {
            InitializeComponent();
            MainPanel = panelContainer;
            this.Load += StartingForm_Load;
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            LoadForm(new MainMenuForm());
        }

        public void LoadForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(form);
            form.Show();
        }
    }
}
