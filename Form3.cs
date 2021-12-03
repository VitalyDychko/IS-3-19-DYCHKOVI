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
    public partial class Form3 : Form
    {
        MySqlDataAdapter MySQLData = new MySqlDataAdapter();
        BindingSource SourceBind = new BindingSource();
        DataTable datatable = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionToMySQL CtMSQL = new ConnectionToMySQL();
            try
            {
                CtMSQL.connDB().Open();
                string ConnSTR = "SELECT id AS 'ID', fio AS 'ФИО', theme_kurs AS 'Тема' FROM t_stud";
                MySQLData.SelectCommand = new MySqlCommand(ConnSTR, CtMSQL.connDB());
                MySQLData.Fill(datatable);
                SourceBind.DataSource = datatable;
                dataGridView1.DataSource = SourceBind;
            }
            catch (Exception oshibka)
            {
                MessageBox.Show($"{oshibka}");
            }
            finally
            {
                MessageBox.Show("Вы успешно подключились к базе данных!");
                CtMSQL.connDB().Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
    }
}
