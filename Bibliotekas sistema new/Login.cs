﻿using System;
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

            string SqlSearchLietotajs = "SELECT isAdmin FROM Lietotaji WHERE login = \'" + textBox1.Text + "\' AND password = \'" + textBox2.Text + "\';";

            try
            {
                SqlCon.Open();
                SqlCom.Connection = SqlCon;
                SqlCom.CommandText = SqlSearchLietotajs;
                SqlDataReader reader = SqlCom.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        if(reader["isAdmin"].ToString().Equals("True"))
                        {
                            MainPage mainpage = new MainPage();
                            mainpage.Show();
                            this.Hide();
                        }
                        else
                        {
                            //load normal page
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lietotājvārds vai parole ir nepareiza.", "Kļūda");
                }
                reader.Close();
                SqlCon.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                try {
                    SqlCon.Close();
                } catch { }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\ri.riga.lv\rv1g\Audzekni\mlogins2\My Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\itrofimovs2\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ilya0\source\repos\Bibliotekas sistema new\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
            SqlConnection SqlCon = new SqlConnection(ConnectionString);
            SqlCommand SqlCom = new SqlCommand();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter) //&& this.Visible == true)
            {
                MessageBox.Show("s");
                //button2.PerformClick();
            }
        }
    }
}
