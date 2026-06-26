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
    public partial class CourseManagementForm : Form
    {
        public CourseManagementForm()
        {
            InitializeComponent();
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                Course c = (Course)dgvCourses.SelectedRows[0].DataBoundItem;
                txtCode.Text = c.Code;
                txtTitle.Text = c.Title;
                txtInstructor.Text = c.Instructor;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            var all = CourseDL.GetAllCourses();

            if (search == "")
            {
                dgvCourses.DataSource = all;
            }
            else
            {
                var filtered = all.Where(x => x.Code.ToLower().Contains(search) ||
                                              x.Title.ToLower().Contains(search)).ToList();
                dgvCourses.DataSource = filtered;
            }
            lblCount.Text = $"Total: {dgvCourses.RowCount}";
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void CourseManagementForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var courses = CourseDL.GetAllCourses();
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = courses;
            lblCount.Text = $"Total: {courses.Count}";
            
        }

        private void ClearFields()
        {
            txtCode.Text = "";
            txtTitle.Text = "";
            txtInstructor.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtTitle.Text == "")
            {
                MessageBox.Show("Course Code and Title required!");
                return;
            }

            // Check duplicate
            if (CourseDL.FindByCode(txtCode.Text) != null)
            {
                MessageBox.Show("Course Code already exists!");
                return;
            }

            Course c = new Course(txtCode.Text, txtTitle.Text, txtInstructor.Text);
            CourseDL.Add(c);
            LoadData();
            ClearFields();
            MessageBox.Show("Course Added!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a course first!");
                return;
            }

            Course c = (Course)dgvCourses.SelectedRows[0].DataBoundItem;

            DialogResult r = MessageBox.Show($"Delete {c.Code} - {c.Title}?", "Confirm",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                CourseDL.Delete(c.Code);
                LoadData();
                ClearFields();
                MessageBox.Show("Course Deleted!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a course first!");
                return;
            }

            Course c = (Course)dgvCourses.SelectedRows[0].DataBoundItem;
            c.Title = txtTitle.Text;
            c.Instructor = txtInstructor.Text;
            CourseDL.Update(c);
            LoadData();
            MessageBox.Show("Course Updated!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartingForm parent = (StartingForm)this.ParentForm;
            parent.LoadForm(new AdminPortalForm());

        }
    }
}
