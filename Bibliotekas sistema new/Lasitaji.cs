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
    public partial class Lasitaji : Form
    {
        public Lasitaji()
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
                string SqlLasitaji = "SELECT * FROM Lasitaji";
                SqlDataAdapter DataAdapterLasitaji = new SqlDataAdapter(SqlLasitaji, SqlCon);
                DataSet DsLasitaji = new DataSet();
                SqlCon.Open();
                DataAdapterLasitaji.Fill(DsLasitaji);
                SqlCon.Close();

                BindingSource BsLasitaji;
                BsLasitaji = new BindingSource();
                BsLasitaji.DataSource = DsLasitaji.Tables[0].DefaultView;
                //bindingNavigator1.BindingSource = BsLietotaji;
                dataGridView1.DataSource = BsLasitaji;

                dataGridView1.Columns["client_ID"].Width = 190;
                dataGridView1.Columns["client_ID"].HeaderText = "Lasītāja ID";
                dataGridView1.Columns["name"].Width = 190;
                dataGridView1.Columns["name"].HeaderText = "Vārds";
                dataGridView1.Columns["surname"].Width = 190;
                dataGridView1.Columns["surname"].HeaderText = "Uzvārds";
                dataGridView1.Columns["registrationDate"].HeaderText = "Reģistrēšanas datums";
            }
            catch { }
        }
    }
}
