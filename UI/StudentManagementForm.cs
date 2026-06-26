
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BA_WinForms.DL;
using BA_WinForms.BL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BA_WinForms.UI
{
    public partial class StudentManagementForm : Form
    {
        public StudentManagementForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var students = StudentDL.GetAllStudents();
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
            lblCount.Text = $"Total: {students.Count}";
          
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtRoll.Text = "";
            txtProgram.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtRoll.Text == "")
            {
                MessageBox.Show("Name and Roll required!");
                return;
            }

            // Check duplicate
            if (StudentDL.FindByRoll(txtRoll.Text) != null)
            {
                MessageBox.Show("Roll already exists!");
                return;
            }

            Student s = new Student(txtName.Text, txtRoll.Text, txtProgram.Text);
            StudentDL.Add(s);
            LoadData();
            ClearFields();
            MessageBox.Show("Added!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student first!");
                return;
            }

            Student s = (Student)dgvStudents.SelectedRows[0].DataBoundItem;

            DialogResult r = MessageBox.Show($"Delete {s.Name}?", "Confirm",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                StudentDL.Delete(s.Roll);
                LoadData();
                ClearFields();
                MessageBox.Show("Deleted!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student first!");
                return;
            }

            Student s = (Student)dgvStudents.SelectedRows[0].DataBoundItem;
            s.Name = txtName.Text;
            s.Program = txtProgram.Text;
            StudentDL.Update(s);
            LoadData();
            MessageBox.Show("Updated!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new AdminPortalForm());
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                Student selected = (Student)dgvStudents.SelectedRows[0].DataBoundItem;
                txtName.Text = selected.Name;
                txtRoll.Text = selected.Roll;
                txtProgram.Text = selected.Program;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
    var all = StudentDL.GetAllStudents();
    
    if (search == "")
    {
        dgvStudents.DataSource = all;
    }
    else
    {
        var filtered = all.Where(x => x.Name.ToLower().Contains(search) || 
                                      x.Roll.ToLower().Contains(search)).ToList();
        dgvStudents.DataSource = filtered;
    }
    lblCount.Text = $"Total: {dgvStudents.RowCount}";
        }
    }
}
