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
    public partial class add : Form
    {
        string status = "pembeda";
        string nama;
        

        string url = "http://192.168.100.8/diaspora/ManipulateService.svc/";
        string url1 = "http://192.168.100.8/diaspora/RetrieveService.svc/";

        public add(string st, string nm)
        {
            InitializeComponent();
            status = st;
            nama = nm;
            if (status == "update")
            {
                this.Text = "edit";
                getData(nama);

            }
        }

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    beranda back = new beranda("imm");
        //    back.Show();
        //    this.Hide();
        //}

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            pengurus p = new pengurus();
            p.nama = namatxt.Text;
            p.kontak = kontaktxt.Text;
            p.asal = asaltxt.Text;
            p.jabatan = jabatantxt.Text;
            p.angkatan = angkatantxt.Text;
            p.periode = periodetxt.Text;
            p.id_organisasi = Convert.ToInt32(organisasitxt.Text);
            addData(p);
            //MessageBox.Show("ramashoq");
            beranda back = new beranda("imm");
            back.Show();
            this.Hide();

        }
        void getData(string p)
        {
            pengurus pengurus = new pengurus();
            string result = new WebClient().DownloadString(url1 + "getdata/nm=" + p);
            pengurus = JsonConvert.DeserializeObject<pengurus>(result);
            List<pengurus> penguruslist = new List<pengurus>();
            penguruslist.Add(pengurus);
            namatxt.Text = pengurus.nama;
            kontaktxt.Text = pengurus.kontak;
            asaltxt.Text = pengurus.asal;
            jabatantxt.Text = pengurus.jabatan;
            angkatantxt.Text = pengurus.angkatan;
            periodetxt.Text = pengurus.periode;
            organisasitxt.Text = pengurus.id_organisasi.ToString();
        }
        void update(pengurus p)
        {
            string request = JsonConvert.SerializeObject(p);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string result = client.UploadString(address.basuriManipulate + "updatedata", request);
        }


        void addData(pengurus p)
        {
            string request = JsonConvert.SerializeObject(p);
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string result = client.UploadString(url + "adddata", request);
            
            //return;
        }


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            beranda back = new beranda("imm");
            back.Show();
            this.Hide();
        }
    }
}
