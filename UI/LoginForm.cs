
using System;
using BA_WinForms.BL;
using BA_WinForms.DL;
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
    public partial class LoginForm : Form
    {
        private UserBL userBL = new UserBL();
        public LoginForm()
        {
             
        InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var users = UserDL.GetAll();

            // First find the user
            User loggedInUser = userBL.FindUser(username, users);

            if (loggedInUser == null || loggedInUser.Password != password)
            {
                MessageBox.Show("Invalid username or password!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if admin is pending
            if (loggedInUser.Role == "ADMIN" && loggedInUser.Status != "APPROVED")
            {
                MessageBox.Show("Your admin request is pending approval.", "Pending",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if user is approved
            if (loggedInUser.Status != "APPROVED")
            {
                MessageBox.Show("Your account is pending approval.", "Pending",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ POLYMORPHISM IN ACTION!
            // Same method call, different behavior based on actual object type
            string roleMessage = loggedInUser.GetRoleDescription();
            MessageBox.Show($"Login Successful!\n\nYou are: {roleMessage}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ✅ POLYMORPHISM IN ACTION AGAIN!
            // GetDashboard() returns different form for Admin vs Student
            Form dashboard = loggedInUser.GetDashboard();

            var parent = (StartingForm)this.ParentForm;
            parent.LoadForm(dashboard);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new MainMenuForm());
        }
    }
}
