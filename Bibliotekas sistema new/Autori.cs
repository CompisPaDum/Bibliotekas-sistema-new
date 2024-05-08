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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bibliotekas_sistema_new
{
    public partial class Autori : Form
    {
        public Autori()
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

        private void Autori_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ilya0\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            try
            {
                string SqlAutori = "SELECT * FROM Autori";
                SqlDataAdapter DataAdapterAutori = new SqlDataAdapter(SqlAutori, SqlCon);
                DataSet DsAutori = new DataSet();
                SqlCon.Open();
                DataAdapterAutori.Fill(DsAutori);
                SqlCon.Close();

                BindingSource BsAutori;
                BsAutori = new BindingSource();
                BsAutori.DataSource = DsAutori.Tables[0].DefaultView;
                dataGridView1.DataSource = BsAutori;

                dataGridView1.Columns["author_ID"].Width = 40;
                dataGridView1.Columns["author_ID"].HeaderText = "ID";
                dataGridView1.Columns["name"].Width = 120;
                dataGridView1.Columns["name"].HeaderText = "Vārds";
                dataGridView1.Columns["surname"].Width = 120;
                dataGridView1.Columns["surname"].HeaderText = "Uzvārds";
                dataGridView1.Columns["info"].HeaderText = "Info par autoru";
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //load form_autori_piev
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //load form_autori_piev ar rediģēšanu
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string SqlDeleteRecord = "DELETE FROM Autori WHERE author_ID='" + dataGridView1.CurrentRow.Cells["author_ID"].Value.ToString() + "';";

            DialogResult dialogResult = MessageBox.Show("Vai tiešām gribat dzēst šo autoru no datubāzes?", "Brīdinājums!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlDeleteRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();

                    string SqlAutori = "SELECT * FROM Autori";
                    SqlDataAdapter DataAdapterAutori = new SqlDataAdapter(SqlAutori, SqlCon);
                    DataSet DsAutori = new DataSet();
                    SqlCon.Open();
                    DataAdapterAutori.Fill(DsAutori);
                    SqlCon.Close();

                    BindingSource BsAutori;
                    BsAutori = new BindingSource();
                    BsAutori.DataSource = DsAutori.Tables[0].DefaultView;
                    dataGridView1.DataSource = BsAutori;
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string selected = "";
            switch (comboBox1.SelectedItem.ToString())
            {
                case "ID":
                    selected = "author_ID";
                    break;
                case "Vārds":
                    selected = "name";
                    break;
                case "Uzvārds":
                    selected = "surname";
                    break;
                default:
                    selected = "*";
                    break;
            }

            try
            {
                string SqlSearchRecord = "SELECT * FROM Autori WHERE " + selected + "='" + textBox1.Text + "';";
                SqlDataAdapter DataAdapterAutori = new SqlDataAdapter(SqlSearchRecord, SqlCon);
                DataSet DsAutori = new DataSet();
                SqlCon.Open();
                DataAdapterAutori.Fill(DsAutori);
                SqlCon.Close();

                BindingSource BsAutori;
                BsAutori = new BindingSource();
                BsAutori.DataSource = DsAutori.Tables[0].DefaultView;
                dataGridView1.DataSource = BsAutori;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string SqlSearchRecord = "SELECT * FROM Autori;";
            SqlDataAdapter DataAdapterAutori = new SqlDataAdapter(SqlSearchRecord, SqlCon);
            DataSet DsAutori = new DataSet();
            SqlCon.Open();
            DataAdapterAutori.Fill(DsAutori);
            SqlCon.Close();

            BindingSource BsAutori;
            BsAutori = new BindingSource();
            BsAutori.DataSource = DsAutori.Tables[0].DefaultView;
            dataGridView1.DataSource = BsAutori;
        }
    }
}
