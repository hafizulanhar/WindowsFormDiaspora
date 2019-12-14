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
using Newtonsoft.Json;

namespace WindowsFormDiaspora
{
    public partial class beranda : Form
    {
        string tanda;

        public beranda(string t)
        {
            InitializeComponent();
            tanda = t;
            if (t == "imm")
            {
                getDataAllimm();
            }
            else if (t == "dpm")
            {
                getDataAlldpm();
            }
            else if (t == "bem")
            {
                getDataAllbem();
            }
            else
            {
                getDataAll();
            }
            
            //getDataAll();
        }

        public void getDataAll()
        {
            List<pengurus> pesanan = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldata");
            //deserialization : ubah dari string json ke objek
            pesanan = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pesanan;
        }

        public void getDataAllimm()
        {
            List<pengurus> pesanan = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldataimm");
            //deserialization : ubah dari string json ke objek
            pesanan = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pesanan;

        }

        public void getDataAlldpm()
        {
            List<pengurus> pesanan = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldatadpm");
            //deserialization : ubah dari string json ke objek
            pesanan = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pesanan;

        }

        public void getDataAllbem()
        {
            List<pengurus> pengurus = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldatabem");
            //deserialization : ubah dari string json ke objek
            pengurus = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pengurus;
        }
        void search(string p)
        {
            List<pengurus> pengurus = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "search/nm="+p);
            pengurus = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pengurus;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add add = new add("tambah",0, tanda);
            add.Show();
            this.Close();
        }

        private void beranda_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opsiorganisasi opsi = new opsiorganisasi();
            opsi.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                search(textBox1.Text);
            }
            else
            {
                if (tanda == "imm")
                {
                    getDataAllimm();
                }
                else if (tanda == "dpm")
                {
                    getDataAlldpm();
                }
                else if (tanda == "bem")
                {
                    getDataAllbem();
                }
                else
                {
                    getDataAll();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add add = new add("update",Convert.ToInt32 (dataGridView1.CurrentRow.Cells[0].Value), tanda);
            add.Show();
            this.Close();
        }

        void delete(pengurus p)
        {
            string request = JsonConvert.SerializeObject(p);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string result = client.UploadString(address.basuriManipulate + "deletedata", request);
        }

        private void delbt_Click(object sender, EventArgs e)
        {
            int del = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Anda Yakin Menghapus " + dataGridView1.CurrentRow.Cells[1].Value + "?", "Yakin Menghapus ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                pengurus pengurus = new pengurus();
                pengurus.no_anggota = del;

                delete(pengurus);
                getDataAll();
            }
        }
    }
}
