using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekas_sistema_new
{
    public partial class Lietotaji : Form
    {
        public Lietotaji()
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
        }

        string ConnectionString;

        private void button6_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage();
            mainpage.Show();
            this.Hide();
        }

        private void Lietotaji_Load(object sender, EventArgs e)
        {
            metode = "";
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itrofimovs2\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ilya0\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            try
            {
                string SqlLietotaji = "SELECT * FROM Lietotaji";
                SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlLietotaji, SqlCon);
                DataSet DsLietotaji = new DataSet();
                SqlCon.Open();
                DataAdapterLietotaji.Fill(DsLietotaji);
                SqlCon.Close();

                BindingSource BsLietotaji;
                BsLietotaji = new BindingSource();
                BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
                dataGridView1.DataSource = BsLietotaji;

                dataGridView1.Columns["name"].Width = 155;
                dataGridView1.Columns["name"].HeaderText = "Vārds";
                dataGridView1.Columns["surname"].Width = 155;
                dataGridView1.Columns["surname"].HeaderText = "Uzvārds";
                dataGridView1.Columns["login"].Width = 155;
                dataGridView1.Columns["login"].HeaderText = "Lietotājvārds";
                dataGridView1.Columns["password"].Width = 155;
                dataGridView1.Columns["password"].HeaderText = "Parole";
                dataGridView1.Columns["isAdmin"].HeaderText = "Administrators";
            }
            catch { }
        }

        public string metode, id;

        private void button2_Click(object sender, EventArgs e) //pievienot
        {
            metode = "pievienot";
            Lietotaji_tabula liettabula = new Lietotaji_tabula(metode, id);
            liettabula.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //rediģēt
        {
            metode = "rediget";
            id = dataGridView1.CurrentRow.Cells["login"].Value.ToString();
            Lietotaji_tabula liettabula = new Lietotaji_tabula(metode, id);
            liettabula.Show();
            this.Hide();
            //fill textboxes with seleced values
        }

        private void button5_Click(object sender, EventArgs e) //dzēst
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string SqlDeleteRecord = "DELETE FROM Lietotaji WHERE login='" + dataGridView1.CurrentRow.Cells["login"].Value.ToString() + "';";

            DialogResult dialogResult = MessageBox.Show("Vai tiešām gribat dzēst šo lietotāju no datubāzes?", "Brīdinājums!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlDeleteRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();

                    string SqlLietotaji = "SELECT * FROM Lietotaji";
                    SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlLietotaji, SqlCon);
                    DataSet DsLietotaji = new DataSet();
                    SqlCon.Open();
                    DataAdapterLietotaji.Fill(DsLietotaji);
                    SqlCon.Close();

                    BindingSource BsLietotaji;
                    BsLietotaji = new BindingSource();
                    BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
                    dataGridView1.DataSource = BsLietotaji;
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e) //meklēt
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string selected = "";
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Vārds":
                    selected = "name";
                    break;
                case "Uzvārds":
                    selected = "surname";
                    break;
                case "Lietotājvārds":
                    selected = "login";
                    break;
                case "Parole":
                    selected = "password";
                    break;
                case "Administrators":
                    selected = "isAdmin";
                    break;
                default:
                    selected = "*";
                    break;
            }

            try
            {
                string SqlSearchRecord = "SELECT * FROM Lietotaji WHERE " + selected + "='" + textBox1.Text + "';";
                SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlSearchRecord, SqlCon);
                DataSet DsLietotaji = new DataSet();
                SqlCon.Open();
                DataAdapterLietotaji.Fill(DsLietotaji);
                SqlCon.Close();

                BindingSource BsLietotaji;
                BsLietotaji = new BindingSource();
                BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
                dataGridView1.DataSource = BsLietotaji;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string SqlSearchRecord = "SELECT * FROM Lietotaji;";
            SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlSearchRecord, SqlCon);
            DataSet DsLietotaji = new DataSet();
            SqlCon.Open();
            DataAdapterLietotaji.Fill(DsLietotaji);
            SqlCon.Close();

            BindingSource BsLietotaji;
            BsLietotaji = new BindingSource();
            BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
            dataGridView1.DataSource = BsLietotaji;
        }
    }
}
