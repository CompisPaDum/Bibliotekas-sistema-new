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
                "('Marks', 'Logins', 'compispadum', 'password1', '1'), " +
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
            ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ilya0\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            const string SqlStrCreateAutori = "CREATE TABLE Autori(" +
                "author_ID int NOT NULL PRIMARY KEY, " +
                "name varchar(25) NOT NULL, " +
                "surname varchar(25) NOT NULL, " +
                "info text NOT NULL);";
            const string SqlStrFillAutori = "INSERT INTO Autori (author_ID, name, surname, info) VALUES" +
                "('1', 'Kārlis', 'Skalbe', 'Labs ciļvēks.'), " +
                "('2', 'Rūdolfs', 'Blaumanis', 'Arī labs cilvēks.');";

            try
            {
                SqlCon.Open();
                SqlCom.Connection = SqlCon;
                SqlCom.CommandText = SqlStrCreateAutori;
                SqlCom.ExecuteNonQuery();
                SqlCom.CommandText = SqlStrFillAutori;
                SqlCom.ExecuteNonQuery();
                MessageBox.Show("Autori table created!");
                SqlCon.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                try
                {
                    SqlCon.Close();
                }
                catch { }
            }

            string SqlAutori = "SELECT * FROM Autori";
            SqlDataAdapter DataAdapterAutori = new SqlDataAdapter(SqlAutori, SqlCon);
            DataSet DsAutori = new DataSet();
            SqlCon.Open();
            DataAdapterAutori.Fill(DsAutori);
            SqlCon.Close();

            BindingSource BsAutori;
            BsAutori = new BindingSource();
            BsAutori.DataSource = DsAutori.Tables[0].DefaultView;
            dataGridView2.DataSource = BsAutori;
        }
    }
}
