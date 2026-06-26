
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BA_WinForms.BL;  
using BA_WinForms.DL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA_WinForms.UI
{
    public partial class RegisterForm : Form
    {
        private UserBL userBL = new UserBL();
        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string roleChoice = cmbRole.SelectedIndex == 0 ? "1" : "2"; // 1=Student, 2=Admin

            var users = UserDL.GetAll();
            bool isFirstUser = users.Count == 0;
            var pendingList = userBL.GetPendingAdmins(users);

            string result = userBL.Signup(username, password, roleChoice, isFirstUser, users, pendingList);

            if (result == "success" || result == "pending")
            {
                string role = roleChoice == "1" ? "STUDENT" : "ADMIN";
                string status = isFirstUser ? "APPROVED" : "PENDING";

                if (role == "ADMIN")
                {
                    Admin admin = new Admin(username, password, status);
                    UserDL.Add(admin);
                }
                else
                {
                    StudentUser student = new StudentUser(username, password, status);
                    UserDL.Add(student);
                }

                MessageBox.Show(result == "success" ? "Registration successful!" : "Admin request submitted. Awaiting approval.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var parent = (StartingForm)this.ParentForm;
                parent.LoadForm(new LoginForm());
            }
            else if (result == "duplicate")
            {
                MessageBox.Show("Username already exists!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new MainMenuForm());
        }
    }
}
