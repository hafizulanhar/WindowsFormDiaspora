using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormDiaspora
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usernametxt.Text == "" && passtxt.Text == "")
            {
                MessageBox.Show("masukkan username dan password");
            }
            else
            {
                if (usernametxt.Text == "admin" && passtxt.Text == "admin")
                {
                    opsiorganisasi form3 = new opsiorganisasi();
                    form3.Show();
                    this.Hide();
                }
                
                else if (usernametxt.Text != "admin" || passtxt.Text != "admin")
                {
                    MessageBox.Show("username atau password salah");
                }
            }
        }
    }
}
