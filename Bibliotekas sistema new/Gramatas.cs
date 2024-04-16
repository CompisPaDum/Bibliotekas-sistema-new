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
    public partial class Gramatas : Form
    {
        public Gramatas()
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
                string SqlGramatas = "SELECT * FROM Gramatas";
                SqlDataAdapter DataAdapterGramatas = new SqlDataAdapter(SqlGramatas, SqlCon);
                DataSet DsGramatas = new DataSet();
                SqlCon.Open();
                DataAdapterGramatas.Fill(DsGramatas);
                SqlCon.Close();

                BindingSource BsGramatas;
                BsGramatas = new BindingSource();
                BsGramatas.DataSource = DsGramatas.Tables[0].DefaultView;
                //bindingNavigator1.BindingSource = BsLietotaji;
                dataGridView1.DataSource = BsGramatas;

                dataGridView1.Columns["book_ID"].Width = 50;
                dataGridView1.Columns["book_ID"].HeaderText = "ID";
                dataGridView1.Columns["title"].Width = 145;
                dataGridView1.Columns["title"].HeaderText = "Nosaukums";
                dataGridView1.Columns["author"].Width = 145;
                dataGridView1.Columns["author"].HeaderText = "Autors";
                dataGridView1.Columns["quantity"].Width = 145;
                dataGridView1.Columns["quantity"].HeaderText = "Daudzums";
                dataGridView1.Columns["description"].Width = 145;
                dataGridView1.Columns["description"].HeaderText = "Apraksts";
                dataGridView1.Columns["published"].HeaderText = "Publicēta";
            }
            catch { }
        }
    }
}
