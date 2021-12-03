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
using GreatLibrary;

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
            ConnDB conndb = new ConnDB();
            if (textBox1.TextLength != 0)
            {
                try
                {
                    conndb.CMS().Open();
                    string commandStr = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES (@fio,@date)";
                    using (MySqlCommand cmnd = new MySqlCommand(commandStr, conndb.CMS()))
                    {
                        cmnd.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
                        cmnd.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateTimePicker1.Text;
                        cmnd.Connection.Open();
                        cmnd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                finally
                {
                    MessageBox.Show("Соединение закрыто.");
                    conndb.CMS().Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните поле ФИО");
            }
        }
    }
}