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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionToMySQL CtMSQL = new ConnectionToMySQL();
            CtMSQL.ConnectionDataBase().Open();
            string CommStr = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES (@fio,@date)";
            using (MySqlCommand MSC = new MySqlCommand(CommStr, CtMSQL.ConnectionDataBase()))
            {
                MSC.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
                MSC.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateTimePicker1.Text;
                MSC.Connection.Open();
                MSC.ExecuteNonQuery();
            }
            CtMSQL.ConnectionDataBase().Close();
        }
    }
}
