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
            ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ilya0\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
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
                //bindingNavigator1.BindingSource = BsLietotaji;
                dataGridView1.DataSource = BsAutori;

                dataGridView1.Columns["author_ID"].Width = 190;
                dataGridView1.Columns["author_ID"].HeaderText = "Autora ID";
                dataGridView1.Columns["name"].Width = 190;
                dataGridView1.Columns["name"].HeaderText = "Vārds";
                dataGridView1.Columns["surname"].Width = 190;
                dataGridView1.Columns["surname"].HeaderText = "Uzvārds";
                dataGridView1.Columns["info"].HeaderText = "Info par autoru";
            }
            catch { }
        }
    }
}
