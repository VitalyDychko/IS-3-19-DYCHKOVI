using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_3_19_DYCHKOVI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionToMySQL CtMSQL = new ConnectionToMySQL();
            try
            {
                CtMSQL.ConnectionDataBase().Open();
            }
            catch(Exception oshibka)
            {
                MessageBox.Show($"{oshibka}");
            }
            finally
            {
                MessageBox.Show("Вы успешно подключились к базе данных!");
                CtMSQL.ConnectionDataBase().Close();
            }
        }
    }
}
