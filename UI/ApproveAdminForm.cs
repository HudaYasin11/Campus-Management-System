
using BA_WinForms.BL; 
using BA_WinForms.DL;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BA_WinForms.UI
{
    public partial class ApproveAdminForm : Form
    {
        UserBL userBL = new UserBL();
        public ApproveAdminForm()
        {
            InitializeComponent();
        }

        private void listPending_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lstPending.SelectedItem == null)
            {
                MessageBox.Show("Select an admin to approve!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = lstPending.SelectedItem.ToString();

            if (username == "No pending admin requests")
            {
                return;
            }

            DialogResult result = MessageBox.Show($"Approve {username}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserDL.UpdateStatus(username, "APPROVED");
                MessageBox.Show($"{username} approved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingAdmins();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingAdmins();
            lblStatus.Text = "List refreshed";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new AdminPortalForm());


        }

        private void ApproveAdminForm_Load(object sender, EventArgs e)
        {
            LoadPendingAdmins();
        }

        private void LoadPendingAdmins()
        {
            var users = UserDL.GetAll();
            var pending = userBL.GetPendingAdmins(users);

            lstPending.Items.Clear();

            if (pending.Count == 0)
            {
                lstPending.Items.Add("No pending admin requests");
                btnApprove.Enabled = false;
            }
            else
            {
                foreach (var user in pending)
                {
                    lstPending.Items.Add(user.Username);
                }
                btnApprove.Enabled = true;
            }

            lblStatus.Text = $"Found {pending.Count} pending requests";
        }
    }
}
