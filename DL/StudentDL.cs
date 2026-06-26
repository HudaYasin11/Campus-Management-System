using BA_WinForms.BL;
using BA_WinForms.DataBase;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static BA_WinForms.DataBase.DataBase_Helper;

namespace BA_WinForms.DL
{
    internal static class StudentDL
    {
        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM students";

            var reader = DatabaseHelper.Instance.GetData(query);
            while (reader.Read())
            {
                students.Add(new Student(
                    reader["Name"].ToString(),
                    reader["Roll"].ToString(),
                    reader["Program"].ToString()
                ));
            }
            reader.Close();
            return students;
        }

        public static Student FindByRoll(string roll)
        {
            string query = $"SELECT * FROM students WHERE Roll = '{roll}'";
            var reader = DatabaseHelper.Instance.GetData(query);

            if (reader.Read())
            {
                Student student = new Student(
                    reader["Name"].ToString(),
                    reader["Roll"].ToString(),
                    reader["Program"].ToString()
                );
                reader.Close();
                return student;
            }
            reader.Close();
            return null;
        }

        public static void Add(Student s)
        {
            // ✅ Fixed: Added column names
            string query = $"INSERT INTO students (Roll, Name, Program) VALUES ('{s.Roll}', '{s.Name}', '{s.Program}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static bool Delete(string roll)
        {
            string query = $"DELETE FROM students WHERE Roll = '{roll}'";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static void Update(Student s)
        {
            string query = $"UPDATE students SET Name = '{s.Name}', Program = '{s.Program}' WHERE Roll = '{s.Roll}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Save() { }
        public static void Load() { }
    }
}