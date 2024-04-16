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
    public partial class IzsniegtasGramatas : Form
    {
        public IzsniegtasGramatas()
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
                // !
                // TABULA => Izsniegtas_gramatas (vai tām līdzīgs) ((NEVIS Autori))

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

                dataGridView1.Columns["book_ID"].Width = 155;
                dataGridView1.Columns["book_ID"].HeaderText = "Grāmatas ID";
                dataGridView1.Columns["holder_ID"].Width = 155;
                dataGridView1.Columns["holder_ID"].HeaderText = "Lasītāja ID";
                dataGridView1.Columns["worker_login"].Width = 155;
                dataGridView1.Columns["worker_login"].HeaderText = "Bibliotekāra ID";
                dataGridView1.Columns["takingDate"].Width = 155;
                dataGridView1.Columns["takingDate"].HeaderText = "Paņemšanas datums";
                dataGridView1.Columns["returningDate"].HeaderText = "Atgriešanas datums";
            }
            catch { }
        }
    }
}
