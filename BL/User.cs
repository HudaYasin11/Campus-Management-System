using System.Windows.Forms;

namespace BA_WinForms.BL
{
    public abstract class User  
    {
        private string username;
        private string password;
        private string role;
        private string status;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public User(string username, string password, string role, string status)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.status = status;
        }

        public User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.status = "PENDING";
        }

       

        public abstract string GetRoleDescription();


        public virtual Form GetDashboard()
        {
            return new MainMenuForm();
        }
    }
}