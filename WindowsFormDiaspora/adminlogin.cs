using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //untuk verifikasi ke tabel admin
                admin nm = getDataAdmin().Find(x => x.adminname == usernametxt.Text);
                admin pw = getDataAdmin().Find(x => x.password == passtxt.Text);

                if (usernametxt.Text == "" && passtxt.Text == "")
                {
                    MessageBox.Show("masukkan username dan password");
                }
                else
                {
                    if (usernametxt.Text == nm.adminname && passtxt.Text == pw.password)
                    {
                        opsiorganisasi form3 = new opsiorganisasi();
                        form3.Show();
                        this.Hide();
                    }

                    else if (usernametxt.Text != nm.adminname || passtxt.Text != pw.password)
                    {
                        MessageBox.Show("username atau password salah");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("username atau password salah");
            }
        }
        public List<admin> getDataAdmin()
        {
            List<admin> pesanan = new List<admin>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldatadm");
            //deserialization : ubah dari string json ke objek
            pesanan = JsonConvert.DeserializeObject<List<admin>>(result);
            return pesanan;
        }
    }
}
