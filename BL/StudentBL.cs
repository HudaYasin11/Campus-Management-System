using System.Collections.Generic;

namespace BA_WinForms.BL
{
    internal class Student
    {
        private string name;
        private string roll;
        private string program;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Roll
        {
            get { return roll; }
            set { roll = value; }
        }

        public string Program
        {
            get { return program; }
            set { program = value; }
        }

        public Student(string name, string roll, string program)
        {
            this.name = name;
            this.roll = roll;
            this.program = program;
        }

       public string AddStudent(string name, string roll, string program, List<Student> studentList)
        {
            if (name == "" || roll == "" || program == "")
                return "invalid";

            if (SearchStudent(roll, studentList) != null)
                return "duplicate";

            Student s = new Student(name, roll, program);
            studentList.Add(s);
            return "success";
        }

        public Student SearchStudent(string roll, List<Student> studentList)
        {
            foreach (Student s in studentList)
            {
                if (s.Roll == roll)
                    return s;
            }
            return null;
        }

        public string UpdateStudent(string roll, string newName, string newProgram, List<Student> studentList)
        {
            Student s = SearchStudent(roll, studentList);
            if (s == null)
                return "not Found";

            if (newName != "") { s.Name = newName; }
            if (newProgram != "") { s.Program = newProgram; }
            return "success";
        }

        public string DeleteStudent(string roll, List<Student> studentList)
        {
            Student s = SearchStudent(roll, studentList);
            if (s != null)
            {
                studentList.Remove(s);
                return "success";
            }
            else
                return "not Found";
        }

        public List<Student> ListStudents(List<Student> studentList)
        {
            return studentList;
        }

        public bool CanAddStudent(string roll, List<Student> studentList)
        {
            return SearchStudent(roll, studentList) == null;
        }

        public bool ValidateStudent(Student student)
        {
            return student != null &&
                   !string.IsNullOrEmpty(student.Name) &&
                   !string.IsNullOrEmpty(student.Roll);
        }

        public int StudentCount(List<Student> studentList)
        {
            return studentList.Count;
        }
    }
}