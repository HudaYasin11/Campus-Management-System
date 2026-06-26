using System;
using System.Windows.Forms;

namespace BA_WinForms.BL
{
    internal class Admin : User
    {
        private string adminID;
        private string department;
        private DateTime hireDate;

        public string AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        
        public Admin(string username, string password, string status, string adminID, string department)
            : base(username, password, "ADMIN", status)
        {
            this.adminID = adminID;
            this.department = department;
            this.hireDate = DateTime.Now;
        }


        public Admin(string username, string password, string status)
            : base(username, password, "ADMIN")
        {
            this.adminID = "ADMIN" + username;
            this.department = "General";
            this.hireDate = DateTime.Now;
            this.Status = status;
        }

        public override string GetRoleDescription()
        {
            return "Administrator with full system access";
        }

        public override Form GetDashboard()
        {
            return new AdminPortalForm();
        }
    }
}