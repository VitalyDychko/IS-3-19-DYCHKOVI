using System;
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
    class ConnectionToMySQL
    {
        public MySqlConnection ConnectionDataBase()
        {
            string ConnStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            MySqlConnection conn = new MySqlConnection(ConnStr);
            return conn;
        }
    }
}
