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
        public beranda(string tanda)
        {
            InitializeComponent();

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
            List<pengurus> pesanan = new List<pengurus>();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getalldatabem");
            //deserialization : ubah dari string json ke objek
            pesanan = JsonConvert.DeserializeObject<List<pengurus>>(result);
            dataGridView1.DataSource = pesanan;

        }
        void getData(string p)
        {
            pengurus pengurus = new pengurus();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getdata/nm="+p);
            pengurus = JsonConvert.DeserializeObject<pengurus>(result);
            List<pengurus> penguruslist = new List<pengurus>();
            penguruslist.Add(pengurus);
            dataGridView1.DataSource = penguruslist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add add = new add("add","");
            add.Show();
            this.Hide();
        }

        private void beranda_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        public class dataOrganisasi
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                getData(textBox1.Text);
            }
            else
            {
                getDataAll();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add add = new add("update",dataGridView1.CurrentRow.Cells[1].Value.ToString());
            add.Show();
        }
    }
}
