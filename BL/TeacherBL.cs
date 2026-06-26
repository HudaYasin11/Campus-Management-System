using System.Collections.Generic;

namespace BA_WinForms.BL
{
    internal class Teacher
    {
        private string name;
        private string id;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public Teacher(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
    }
}