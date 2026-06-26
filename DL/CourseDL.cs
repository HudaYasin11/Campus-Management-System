
using BA_WinForms.BL;                   
using BA_WinForms.DataBase;             
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static BA_WinForms.DataBase.DataBase_Helper;


namespace BA_WinForms.DL
{ 
    internal static class CourseDL
    {
        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT * FROM courses";

            var reader = DatabaseHelper.Instance.GetData(query);
            while (reader.Read())
            {
                courses.Add(new Course(
                    reader["Code"].ToString(),
                    reader["Title"].ToString(),
                    reader["Instructor"].ToString()
                ));
            }
            reader.Close();
            return courses;
        }

        public static Course FindByCode(string code)
        {
            string query = $"SELECT * FROM courses WHERE Code = '{code}'";
            var reader = DatabaseHelper.Instance.GetData(query);

            if (reader.Read())
            {
                Course course = new Course(
                    reader["Code"].ToString(),
                    reader["Title"].ToString(),
                    reader["Instructor"].ToString()
                );
                reader.Close();
                return course;
            }
            reader.Close();
            return null;
        }

        public static void Update(Course c)
        {
            string query = $"UPDATE courses SET Title = '{c.Title}', Instructor = '{c.Instructor}' WHERE Code = '{c.Code}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Add(Course c)
        {
            string query = $"INSERT INTO courses (Code, Title, Instructor) VALUES ('{c.Code}', '{c.Title}', '{c.Instructor}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static bool Delete(string code)
        {
            string query = $"DELETE FROM courses WHERE Code = '{code}'";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static void Save() { }
        public static void Load() { }
    }
}