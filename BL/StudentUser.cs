using BA_WinForms.UI;
using System.Windows.Forms;

namespace BA_WinForms.BL
{
    internal class StudentUser : User
    {
        private string studentID;
        private string batch;
        private double gpa;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string Batch
        {
            get { return batch; }
            set { batch = value; }
        }

        public double GPA
        {
            get { return gpa; }
            set { gpa = value; }
        }

        public StudentUser(string username, string password, string status, string studentID, string batch)
            : base(username, password, "STUDENT", status)
        {
            this.studentID = studentID;
            this.batch = batch;
            this.gpa = 0.0;
        }


        public StudentUser(string username, string password, string status)
            : base(username, password, "STUDENT")
        {
            this.studentID = "STU" + username;
            this.batch = "2025";
            this.gpa = 0.0;
            this.Status = status;
        }

        public override string GetRoleDescription()
        {
            return "Student with campus navigation and course viewing access";
        }

        public override Form GetDashboard()
        {
            return new StudentPortalForm();
        }
    }
}