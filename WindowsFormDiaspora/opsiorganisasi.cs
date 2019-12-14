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
    public partial class opsiorganisasi : Form
    {
        public opsiorganisasi()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }


        private void opsiorganisasi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            beranda imm = new beranda("imm");
            imm.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            beranda bem = new beranda("bem");
            bem.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            beranda dpm = new beranda("dpm");
            dpm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beranda all = new beranda("all");
            all.Show();
            this.Close();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }
    }
}
