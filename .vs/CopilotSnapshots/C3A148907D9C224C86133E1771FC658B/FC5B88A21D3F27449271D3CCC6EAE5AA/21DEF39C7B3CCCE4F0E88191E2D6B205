using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  BA_WinForms.DataBase
{
    internal class DataBase_Helper
    {
        internal class DatabaseHelper
        {

            private string password = "Hud@933901";
            private string server = "127.0.0.1";
            private string port = "3306";
            private string database = "campusdb";
            private string username = "root";

            private static DatabaseHelper instance;

            public static DatabaseHelper Instance
            {
                get
                {
                    if (instance == null)
                        instance = new DatabaseHelper();
                    return instance;
                }
            }

            private DatabaseHelper() { }

            public MySqlConnection GetConnection()
            {
                string connString = $"server={server};port={port};user={username};database={database};password={password};";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                return conn;
            }

            public MySqlDataReader GetData(string query)
            {
                var conn = GetConnection();
                var cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }

            public int Update(string query)
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }



        }
    }
}