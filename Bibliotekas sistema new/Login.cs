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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
        }

        string ConnectionString;

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

            string SqlSearchName = "SELECT name FROM Lietotaji WHERE (name LIKE " + textBox1.Text + ")";
            string SqlSearchSurname = "SELECT surname FROM Lietotaji Where (surname LIKE " + textBox2.Text + ")";

            /* if(textBox1.Text == name && textBox2.Text == password)
             * {
             *      load next page
             * }
             * else
             * {
             *      name or password is incorrect
             * }
             */
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();

        }
    }
}
