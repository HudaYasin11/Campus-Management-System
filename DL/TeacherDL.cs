
using BA_WinForms.BL;
using BA_WinForms.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using static BA_WinForms.DataBase.DataBase_Helper;

namespace BA_WinForms.DL
{
    internal static class TeacherDL
    {
        public static List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            string query = "SELECT * FROM teachers";

            var reader = DatabaseHelper.Instance.GetData(query);
            while (reader.Read())
            {
                teachers.Add(new Teacher(
                    reader["Name"].ToString(),
                    reader["ID"].ToString()
                ));
            }
            reader.Close();
            return teachers;
        }

        public static Teacher FindByID(string id)
        {
            string query = $"SELECT * FROM teachers WHERE ID = '{id}'";
            var reader = DatabaseHelper.Instance.GetData(query);

            if (reader.Read())
            {
                Teacher teacher = new Teacher(
                    reader["Name"].ToString(),
                    reader["ID"].ToString()
                );
                reader.Close();
                return teacher;
            }
            reader.Close();
            return null;
        }

        public static bool IDExists(string id)
        {
            string query = $"SELECT COUNT(*) FROM teachers WHERE ID = '{id}'";
            var reader = DatabaseHelper.Instance.GetData(query);
            reader.Read();
            int count = Convert.ToInt32(reader[0]);
            reader.Close();
            return count > 0;
        }

        public static void Add(Teacher t)
        {
            // ✅ Fixed: Added column names
            string query = $"INSERT INTO teachers (ID, Name) VALUES ('{t.ID}', '{t.Name}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Update(Teacher t)
        {
            string query = $"UPDATE teachers SET Name = '{t.Name}' WHERE ID = '{t.ID}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Delete(string id)
        {
            string query = $"DELETE FROM teachers WHERE ID = '{id}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Save() { }
        public static void Load() { }
    }
}