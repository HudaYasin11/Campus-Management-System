using BA_WinForms.BL;
using BA_WinForms.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using static BA_WinForms.DataBase.DataBase_Helper;

namespace BA_WinForms.DL
{
    internal static class UserDL
    {
        public static List<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM users";

            var reader = DatabaseHelper.Instance.GetData(query);
            while (reader.Read())
            {
                string username = reader["Username"].ToString();          
                string password = reader["Password"].ToString();
                string role = reader["Role"].ToString();
                string status = reader["Status"].ToString();

                if (role == "ADMIN")
                {
                    users.Add(new Admin(username, password, status, "ADMIN" + username, "General"));
                }
                else if (role == "STUDENT")
                {
                    users.Add(new StudentUser(username, password, status, "STU" + username, "2025"));
                }

            }
            reader.Close();
            return users;
        }

        public static User Find(string username)
        {
            string query = $"SELECT * FROM users WHERE Username = '{username}'";
            var reader = DatabaseHelper.Instance.GetData(query);

            if (reader.Read())
            {
                string user = reader["Username"].ToString();
                string password = reader["Password"].ToString();
                string role = reader["Role"].ToString();
                string status = reader["Status"].ToString();
                reader.Close();

                if (role == "ADMIN")
                {
                    return new Admin(user, password, status, "ADMIN" + user, "General");
                }
                else if (role == "STUDENT")
                {
                    return new StudentUser(user, password, status, "STU" + user, "2025");
                }
            }
            reader.Close();
            return null;
        }

        public static bool UsernameExists(string username)
        {
            string query = $"SELECT COUNT(*) FROM users WHERE Username = '{username}'";
            var reader = DatabaseHelper.Instance.GetData(query);
            reader.Read();
            int count = Convert.ToInt32(reader[0]);
            reader.Close();
            return count > 0;
        }

        public static void Add(User user)
        {
            string query = $"INSERT INTO users (Username, Password, Role, Status) VALUES ('{user.Username}', '{user.Password}', '{user.Role}', '{user.Status}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void UpdateStatus(string username, string status)
        {
            string query = $"UPDATE users SET Status = '{status}' WHERE Username = '{username}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void Save() { }
        public static void Load() { }
    }
}