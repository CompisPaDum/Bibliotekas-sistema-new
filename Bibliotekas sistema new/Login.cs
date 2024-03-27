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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Location = new Point(400, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }
    }
}
