using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bibliotekas_sistema_new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ConnectionString;

        private void button1_Click(object sender, EventArgs e) //create table Lietotaji
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            const string SqlStrCreateLietotaji = "CREATE TABLE Lietotaji(" +
                "name varchar(25) NOT NULL, " +
                "surname varchar(25) NOT NULL, " +
                "login varchar(25) NOT NULL PRIMARY KEY, " +
                "password varchar(25) NOT NULL, " +
                "isAdmin bit NOT NULL);";
            const string SqlStrFillLietotaji = "INSERT INTO Lietotaji (name, surname, login, password, isAdmin) VALUES" +
                "('Marks', 'Logins', 'compispadum', 'password1', '0'), " +
                "('Ilja', 'Trofimovs', 'ilya', 'password2', '0');";

            try
            {
                SqlCon.Open();
                SqlCom.Connection = SqlCon;
                SqlCom.CommandText = SqlStrCreateLietotaji;
                SqlCom.ExecuteNonQuery();
                SqlCom.CommandText = SqlStrFillLietotaji;
                SqlCom.ExecuteNonQuery();
                MessageBox.Show("Lietotaji table created!");
                SqlCon.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                try {
                    SqlCon.Close();
                } catch { }
            }

            string SqlLietotaji = "SELECT * FROM Lietotaji";
            SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlLietotaji, SqlCon);
            DataSet DsLietotaji = new DataSet();
            SqlCon.Open();
            DataAdapterLietotaji.Fill(DsLietotaji);
            SqlCon.Close();

            BindingSource BsLietotaji;
            BsLietotaji = new BindingSource();
            BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
            bindingNavigator1.BindingSource = BsLietotaji;
            dataGridView1.DataSource = BsLietotaji;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            try
            {
                ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C: \Users\itrofimovs2\source\repos\CompisPaDum\Bibliotekas - sistema - new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
                SqlConnection SqlCon = new SqlConnection(ConnectionString);
                SqlCommand SqlCom = new SqlCommand();

                string SqlLietotaji = "SELECT * FROM Lietotaji";
                SqlDataAdapter DataAdapterLietotaji = new SqlDataAdapter(SqlLietotaji, SqlCon);
                DataSet DsLietotaji = new DataSet();
                SqlCon.Open();
                DataAdapterLietotaji.Fill(DsLietotaji);
                SqlCon.Close();

                BindingSource BsLietotaji;
                BsLietotaji = new BindingSource();
                BsLietotaji.DataSource = DsLietotaji.Tables[0].DefaultView;
                bindingNavigator1.BindingSource = BsLietotaji;
                dataGridView1.DataSource = BsLietotaji;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e) //delete table Lietotaji
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            const string SqlStrDropLietotaji = "DROP TABLE Lietotaji;";

            try
            {
                SqlCon.Open();
                SqlCom.Connection = SqlCon;
                SqlCom.CommandText = SqlStrDropLietotaji;
                SqlCom.ExecuteNonQuery();
                MessageBox.Show("Lietotaji table deleted!");
                SqlCon.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                try {
                    SqlCon.Close();
                } catch { }
            }

            bindingNavigator1.BindingSource = null;
            dataGridView1.DataSource = null;
        }
    }
}
