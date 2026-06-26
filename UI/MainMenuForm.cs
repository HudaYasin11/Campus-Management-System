using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BA_WinForms.UI;

namespace BA_WinForms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new LoginForm());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new RegisterForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
