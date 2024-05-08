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
    public partial class Lietotaji_tabula : Form
    {
        string metode, id, ConnectionString;

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            if (metode == "pievienot")
            {
                string SqlAddRecord;
                if (checkBox1.Checked)
                {
                    SqlAddRecord = "INSERT INTO Lietotaji (name, surname, login, password, isAdmin) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "', '1');";
                }
                else
                {
                    SqlAddRecord = "INSERT INTO Lietotaji (name, surname, login, password, isAdmin) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox3.Text + "', '0');";
                }

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlAddRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();
                    MessageBox.Show("Jauns lietotājs pievienots datubāzei.");
                }
                catch { }

                Lietotaji lietotaji = new Lietotaji();
                lietotaji.Show();
                this.Hide();
            }
            else
            {
                string SqlUpdateRecord;

                if (checkBox1.Checked)
                {

                    SqlUpdateRecord = "UPDATE Lietotaji SET name = '" + textBox1.Text + "', surname = '" + textBox2.Text + "', login = '" + textBox4.Text + "', password = '" + textBox3.Text + "', isAdmin = 1 WHERE login = '" + id + "';";
                }
                else
                {
                    SqlUpdateRecord = "UPDATE Lietotaji SET name = '" + textBox1.Text + "', surname = '" + textBox2.Text + "', login = '" + textBox4.Text + "', password = '" + textBox3.Text + "', isAdmin = 0 WHERE login = '" + id + "';";
                }

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlUpdateRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();
                    MessageBox.Show("Lietotāja izmaiņas pievienotas datubāzei.");
                }
                catch { }

                Lietotaji lietotaji = new Lietotaji();
                lietotaji.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lietotaji lietotaji = new Lietotaji();
            lietotaji.Show();
            this.Hide();
        }

        public Lietotaji_tabula(string m, string i)
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
            metode = m;
            id = i;
        }

        private void Lietotaji_tabula_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itrofimovs2\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf;Integrated Security=True;Connect Timeout=30";

            if (metode == "rediget")
            {
                SqlConnection SqlCon = new SqlConnection(ConnectionString);
                SqlCommand SqlCom = new SqlCommand();

                string SqlName = "SELECT name FROM Lietotaji WHERE login = '" + id + "';";
                string SqlSurname = "SELECT surname FROM Lietotaji WHERE login = '" + id + "';";
                string SqlPassword = "SELECT password FROM Lietotaji WHERE login = '" + id + "';";
                string SqlIsAdmin = "SELECT isAdmin FROM Lietotaji WHERE login = '" + id + "';";

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlName;
                    SqlDataReader readerName = SqlCom.ExecuteReader();
                    if (readerName.HasRows)
                    {
                        while (readerName.Read())
                        {
                            textBox1.Text = readerName["name"].ToString();
                        }
                    }
                    readerName.Close();
                    SqlCom.CommandText = SqlSurname;
                    SqlDataReader readerSurname = SqlCom.ExecuteReader();
                    if (readerSurname.HasRows)
                    {
                        while (readerSurname.Read())
                        {
                            textBox2.Text = readerSurname["surname"].ToString();
                        }
                    }
                    readerSurname.Close();
                    textBox4.Text = id;
                    SqlCom.CommandText = SqlPassword;
                    SqlDataReader readerPassword = SqlCom.ExecuteReader();
                    if (readerPassword.HasRows)
                    {
                        while (readerPassword.Read())
                        {
                            textBox3.Text = readerPassword["password"].ToString();
                        }
                    }
                    readerPassword.Close();
                    SqlCom.CommandText = SqlIsAdmin;
                    SqlDataReader readerIsAdmin = SqlCom.ExecuteReader();
                    if (readerIsAdmin.HasRows)
                    {
                        while (readerIsAdmin.Read())
                        {
                            //textBox3.Text = readerIsAdmin["isAdmin"].ToString();
                            if(readerIsAdmin["isAdmin"].ToString().Equals("True"))
                            {
                                checkBox1.Checked = true;
                            }
                            else
                            {
                                checkBox1.Checked = false;
                            }
                        }
                    }
                    readerIsAdmin.Close();
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
            }
        }
    }
}
