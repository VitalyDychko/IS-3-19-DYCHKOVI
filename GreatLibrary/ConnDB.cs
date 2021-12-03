using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GreatLibrary
{
    public class ConnDB
    {
        public MySqlConnection CMS()
        {
            string ConnStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            MySqlConnection conn = new MySqlConnection(ConnStr);
            return conn;
        }
    }
}