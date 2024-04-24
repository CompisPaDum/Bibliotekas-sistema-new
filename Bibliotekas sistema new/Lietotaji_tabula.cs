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
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itrofimovs2\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf;Integrated Security=True;Connect Timeout=30";
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
                MessageBox.Show(id);
                string SqlUpdateRecord;
                if (checkBox1.Checked)
                {

                    SqlUpdateRecord = "update Lietotaji set name = '" + textBox1.Text + "', surname = '" + textBox2.Text + "', login = '" + textBox4.Text + "', password = '" + textBox3.Text + "', isAdmin = 1 where login = '" + id + "';";
                }
                else
                {
                    SqlUpdateRecord = "update Lietotaji set name = '" + textBox1.Text + "', surname = '" + textBox2.Text + "', login = '" + textBox4.Text + "', password = '" + textBox3.Text + "', isAdmin = 0 where login = '" + id + "';";
                }

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlUpdateRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();
                    MessageBox.Show("lietotāja izmaiņas pievienotas datubāzei.");
                }
                catch { }

                Lietotaji lietotaji = new Lietotaji();
                lietotaji.Show();
                this.Hide();
            }

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
            //fill form
        }
    }
}
