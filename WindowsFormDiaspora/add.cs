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
        int id;
        string tanda;
        

        //string url = "http://192.168.100.8/diaspora/ManipulateService.svc/";
        //string url1 = "http://192.168.100.8/diaspora/RetrieveService.svc/";

        public add(string st, int idinput, string t)
        {
            InitializeComponent();
            status = st;
            id = idinput;
            tanda = t;
            if (status == "update")
            {
                this.Text = "edit";
                getData(id.ToString());
                namatxt.Enabled = false;
                kontaktxt.Enabled = false;
                asaltxt.Enabled = false;
                jabatantxt.Enabled = false;
                angkatantxt.Enabled = false;
                periodetxt.Enabled = false;
                cb_organisasi.Enabled = false;
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
            int id_org = 0;
            if(cb_organisasi.Text.ToString()=="IMM")
            {
                id_org = 1;
            }
            else if(cb_organisasi.Text.ToString() == "BEM")
            {
                id_org = 2;
            }
            else if (cb_organisasi.Text.ToString() == "DPM")
            {
                id_org = 3;
            }

            //MessageBox.Show(id_org.ToString());
            pengurus p = new pengurus();
            p.nama = namatxt.Text;
            p.kontak = kontaktxt.Text;
            p.asal = asaltxt.Text;
            p.jabatan = jabatantxt.Text;
            p.angkatan = angkatantxt.Text;
            p.periode = periodetxt.Text;
            //p.id_organisasi = Convert.ToInt32(organisasitxt.Text);
            p.id_organisasi = id_org;            

            if (status == "tambah")
            {
                addData(p);
                //MessageBox.Show("ramashoq");
                beranda back = new beranda(tanda);
                back.Show();
                this.Hide();
            }

            else if (status == "update")
            {
                p.no_anggota = id;
                update(p);
                beranda back = new beranda(tanda);
                back.Show();
                this.Hide();
            }

            

        }
        void getData(string p)
        {
            pengurus pengurus = new pengurus();
            string result = new WebClient().DownloadString(address.basuriRetrive + "getdatabyid/id=" + p);
            pengurus = JsonConvert.DeserializeObject<pengurus>(result);
            List<pengurus> penguruslist = new List<pengurus>();
            penguruslist.Add(pengurus);
            namatxt.Text = pengurus.nama;
            kontaktxt.Text = pengurus.kontak;
            asaltxt.Text = pengurus.asal;
            jabatantxt.Text = pengurus.jabatan;
            angkatantxt.Text = pengurus.angkatan;
            periodetxt.Text = pengurus.periode;

            if(pengurus.id_organisasi == 1)
            {
                cb_organisasi.Text = "IMM";
            }
            else if (pengurus.id_organisasi == 2)
            {
                cb_organisasi.Text = "BEM";
            }
            else if (pengurus.id_organisasi == 3)
            {
                cb_organisasi.Text = "DPM";
            }
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
            string result = client.UploadString(address.basuriManipulate + "adddata", request);
            
            //return;
        }

       


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            beranda back = new beranda(tanda);
            back.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            namatxt.Enabled = true;
            kontaktxt.Enabled = true;
            asaltxt.Enabled = true;
            jabatantxt.Enabled = true;
            angkatantxt.Enabled = true;
            periodetxt.Enabled = true;
            cb_organisasi.Enabled = true;
        }

        private void deletebt_Click(object sender, EventArgs e)
        {
            
        }
    }
}
