using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotekas_sistema_new
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //load gramatas
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //load lasitaji
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //load izsniegtas gramatas
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //load autori
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //load lietotaji
        }
    }
}
