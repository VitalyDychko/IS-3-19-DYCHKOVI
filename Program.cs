﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_3_19_DYCHKOVI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
    public class ConnectionToMySQL
    {
        public MySqlConnection connDB()
        {
            string host = "caseum.ru";
            string port = "33333";
            string user = "test_user";
            string db = "db_test";
            string password = "test_pass";
            string ConnStr = $"server={host};port={port};user={user};database={db};password={password};";
            MySqlConnection conn = new MySqlConnection(ConnStr);
            return conn;
        }
    }
}
