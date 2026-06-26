
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BA_WinForms.DL;
using BA_WinForms.BL;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA_WinForms.UI
{
    public partial class TeacherManagementForm : Form
    {
        public TeacherManagementForm()
        {
            InitializeComponent();
        }

        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count > 0)
            {
                Teacher t = (Teacher)dgvTeachers.SelectedRows[0].DataBoundItem;
                txtID.Text = t.ID;
                txtName.Text = t.Name;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            var all = TeacherDL.GetAll();

            if (search == "")
            {
                dgvTeachers.DataSource = all;
            }
            else
            {
                var filtered = all.Where(x => x.Name.ToLower().Contains(search) ||
                                              x.ID.ToLower().Contains(search)).ToList();
                dgvTeachers.DataSource = filtered;
            }
            lblCount.Text = $"Total: {dgvTeachers.RowCount}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Teacher ID and Name required!");
                return;
            }

            
            if (TeacherDL.IDExists(txtID.Text))
            {
                MessageBox.Show("Teacher ID already exists!");
                return;
            }

            Teacher t = new Teacher(txtName.Text, txtID.Text);
            TeacherDL.Add(t);
            LoadData();
            ClearFields();
            MessageBox.Show("Teacher Added!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher first!");
                return;
            }

            Teacher t = (Teacher)dgvTeachers.SelectedRows[0].DataBoundItem;

            DialogResult r = MessageBox.Show($"Delete {t.Name}?", "Confirm",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
               
                LoadData();
                ClearFields();
                MessageBox.Show("Teacher Deleted!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher first!");
                return;
            }

            Teacher t = (Teacher)dgvTeachers.SelectedRows[0].DataBoundItem;
            t.Name = txtName.Text;
           
            LoadData();
            MessageBox.Show("Teacher Updated!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new AdminPortalForm());
        }

        private void TeacherManagementForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var teachers = TeacherDL.GetAll();
            dgvTeachers.DataSource = null;
            dgvTeachers.DataSource = teachers;
            lblCount.Text = $"Total: {teachers.Count}";

        }
        private void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
        }
    }
}
