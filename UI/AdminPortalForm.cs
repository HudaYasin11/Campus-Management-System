using System;
using BA_WinForms.BL;  // ← ADD THIS

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
    public partial class AdminPortalForm : Form
    {
        public AdminPortalForm()
        {
            InitializeComponent();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new StudentManagementForm());
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new CourseManagementForm());
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new TeacherManagementForm());
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new ApproveAdminForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
               "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StartingForm parent = (StartingForm)this.ParentForm;
                parent.LoadForm(new MainMenuForm());
                lblStatus.Text = "Logged out successfully";
            }
        }

        // Hover effects for buttons
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            }
        }

        private void AdminPortalForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready - Select an option";
        }

    }
}
