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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bibliotekas_sistema_new
{
    public partial class Autori_piev : Form
    {
        string metode, id, ConnectionString;
        int numRows;

        public Autori_piev(string m, string i, int r)
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
            metode = m;
            id = i;
            numRows = r;
        }

        private void Autori_piev_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itrofimovs2\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            
            //ja metode=rediget, tad fill textbox with data
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();
            numRows++;

            if (metode == "pievienot")
            {
                string SqlAddRecord;
                SqlAddRecord = "INSERT INTO Autori (author_ID, name, surname, info) VALUES ('" + numRows++.ToString() + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + richTextBox1.Text + "');";

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlAddRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();
                    MessageBox.Show("Jauns autors pievienots datubāzei.");
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

                Autori autori = new Autori();
                autori.Show();
                this.Hide();
            }
            else
            {
                string SqlUpdateRecord;
                SqlUpdateRecord = "UPDATE Autori SET name = '" + textBox1.Text + "', surname = '" + textBox2.Text + "', info = '" + richTextBox1.Text + "' WHERE author_ID = '" + numRows--.ToString() + "';";

                try
                {
                    SqlCon.Open();
                    SqlCom.Connection = SqlCon;
                    SqlCom.CommandText = SqlUpdateRecord;
                    SqlCom.ExecuteNonQuery();
                    SqlCon.Close();
                    MessageBox.Show("Autora izmaiņas pievienotas datubāzei.");
                }
                catch { }

                Autori autori = new Autori();
                autori.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e) //back
        {
            Autori autori = new Autori();
            autori.Show();
            this.Hide();
        }
    }
}
