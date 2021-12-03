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
    public partial class Form4 : Form
    {
        MySqlDataAdapter MySQLData = new MySqlDataAdapter();
        BindingSource SourceBind = new BindingSource();
        DataTable datatable = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnDB conndb = new ConnDB();
            try
            {
                conndb.CMS().Open();
                string ConnSTR = "SELECT idStud AS 'ID', fioStud AS 'ФИО', drStud AS 'Дата рождения' FROM t_datetime";
                MySQLData.SelectCommand = new MySqlCommand(ConnSTR, conndb.CMS());
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
                conndb.CMS().Close();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime date = new DateTime();
            date = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            MessageBox.Show(DateTime.Today.Subtract(date.Date).Days.ToString() + " прошло дней от рождения");
        }
    }
}
