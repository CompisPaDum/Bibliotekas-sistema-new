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
    public partial class Lietotaji : Form
    {
        public Lietotaji()
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

        private void Lietotaji_Load(object sender, EventArgs e)
        {
            ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Marks\Downloads\Bibliotekas sistema\Bibliotekas sistema new\Database1.mdf; Integrated Security = True";
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
                //bindingNavigator1.BindingSource = BsLietotaji;
                dataGridView1.DataSource = BsLietotaji;
            }
            catch { }
        }
    }
}