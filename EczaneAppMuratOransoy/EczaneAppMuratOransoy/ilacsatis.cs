using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EczaneAppMuratOransoy
{
    public partial class ilacsatis : Form
    {
        public ilacsatis()
        {
            InitializeComponent();
        }
        public ilacsatis(List<ilackaydetbilgi> ilist,List<hastauret> iliste)
        {
            InitializeComponent();
            ilaclist = ilist;
            hastalist = iliste;
            dataGridView1.DataSource = iliste;
            dataGridView2.DataSource = ilist;
        }
        List<ilackaydetbilgi> ilaclist = new List<ilackaydetbilgi>();
  
        List<hastauret> hastalist = new List<hastauret>();
        public object Interaction { get; private set; }

        private void button3_Click(object sender, EventArgs e)
        {
            ilac form1 = new ilac(ilaclist, hastalist);
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            ilac ilac = new ilac(ilaclist, hastalist);
            for (int i = 0; i < ilac.dataGridView1.RowCount; i++)
            {
                if (ilac.dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox2.Text)
                {
                    listBox2.Items.Add("---İLAÇ BİLGİLERİ---");
                    listBox2.Items.Add("İlacın BarkodNo'su = " + ilac.dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString());
                    listBox2.Items.Add("İlacın Adı = " + ilac.dataGridView1.Rows[i].Cells["ilacAdi"].Value.ToString());
                    listBox2.Items.Add("Fiyatı = " + ilac.dataGridView1.Rows[i].Cells["fiyati"].Value.ToString() + "TL");
                    listBox2.Items.Add("Kullanımı = " + ilac.dataGridView1.Rows[i].Cells["kullanim"].Value.ToString());
                    listBox2.Items.Add("--------------------------");
                }
            
            }
            try
            {
                for (int i = 0; i < sayidizisi.Length; i++)
                {
                    if (ilac.dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox2.Text)
                    {
                        if (sayidizisi[i] == 0)
                        {
                            sayidizisi[i] = Convert.ToDouble(ilac.dataGridView1.Rows[i].Cells["fiyati"].Value.ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                DialogResult sonuc;
                sonuc = MessageBox.Show("Aynı Barkod Numarası Sadece 1 Kere Girilebilir", "Dikkat");
            }
        

            for (int i = 0; i < ilacdizisi.Length; i++)
            {
                if (ilac.dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox2.Text)
                {
                    if (ilacdizisi[i] == null)
                    {
                        ilacdizisi[i] = ilac.dataGridView1.Rows[i].Cells["ilacAdi"].Value.ToString();
                        break;
                    }
                }
            }

            textBox2.Text = "";


        }
        private void button4_Click(object sender, EventArgs e)
        {
            HastaKayit hasta = new HastaKayit(hastalist,ilaclist);
            for (int i = 0; i < hasta.dataGridView2.RowCount; i++)
            {
                if (hasta.dataGridView2.Rows[i].Cells[0].Value.ToString() == textBox1.Text)
                {
                    listBox2.Items.Add("---HASTA BİLGİLERİ---");
                    listBox2.Items.Add("Hasta Tc = " + hasta.dataGridView2.Rows[i].Cells["tcNo"].Value.ToString());
                    listBox2.Items.Add("Hasta Adı Soyadı =" + hasta.dataGridView2.Rows[i].Cells["AdSoyad"].Value.ToString());
                    listBox2.Items.Add("Tel No =" + hasta.dataGridView2.Rows[i].Cells["telno"].Value.ToString());
                    listBox2.Items.Add("--------------------------");
                }
            }
         
                for (int i = 0; i < isimdizisi.Length; i++)
                {
                if (hasta.dataGridView2.Rows[i].Cells[0].Value.ToString() == textBox1.Text)
                {
                    if (isimdizisi[i] == null)
                    {
                        isimdizisi[i] = hasta.dataGridView2.Rows[i].Cells["AdSoyad"].Value.ToString();
                        break;
                    }

                }

            }
            for (int i = 0; i < tcnodizisi.Length; i++)
            {
                if (hasta.dataGridView2.Rows[i].Cells[0].Value.ToString() == textBox1.Text)
                {
                    if (tcnodizisi[i] == null)
                    {
                        tcnodizisi[i] = hasta.dataGridView2.Rows[i].Cells["tcNo"].Value.ToString();
                        break;
                    }

                }

            }
            textBox1.Text = "";
        }
        double toplamTutar = 0;
        string isimler ;
        string isimilac;
        string tcno;
        double[] sayidizisi = new double[20];
        string[] isimdizisi = new string[20];
        string[] ilacdizisi = new string[20];
        string[] tcnodizisi = new string[20];
        private void button2_Click(object sender, EventArgs e)
        {
            ilac ilac = new ilac(ilaclist, hastalist);
            foreach (double item in sayidizisi)
            {
             
                toplamTutar += item;
            }

            foreach (string item in isimdizisi)
            {
                isimler += item;
            }

            foreach(string item in ilacdizisi)
            {
                isimilac += item;
            }

            foreach (string item in tcnodizisi)
            {
                tcno += item;
            }

            MessageBox.Show("Tutar:" + toplamTutar + "\nHasta Adı : " + isimler+"\nHasta Tc No : " + tcno+"\nİlac İsimleri : "+" " + isimilac, "Hesap",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            toplamTutar = 0;
            isimler = null;
            isimilac = null;
            tcno = null;
            listBox2.Items.Clear();
            for (int i = 0; i < sayidizisi.Length; i++)
            {
                sayidizisi[i] = 0;
            }
            for (int i = 0; i < isimdizisi.Length; i++)
            {
                isimdizisi[i] = null;
            }

            for(int i = 0; i < ilacdizisi.Length; i++)
            {
                ilacdizisi[i] = null;
            }   
            for(int i = 0; i< tcnodizisi.Length; i++)
            {
                tcnodizisi[i] = null;
            }
            //double toplamTutar = 0;
            //double[] sayidizisi = new double[10];
            //foreach (double item in sayidizisi)
            //{
            //    toplamTutar += item;
            //}
            //MessageBox.Show("Tutar:" + toplamTutar, "Hesap",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            //toplamTutar = 0;

            //listBox2.Items.Clear();
            //for (int i = 0; i < sayidizisi.Length; i++)
            //{
            //    sayidizisi[i] = 0;
            //}
            //ilac ilac = new ilac(ilaclist, hastalist);
            //double toplam = 0;
            //for (int i = 0; i < listBox2.Items.Count; i++)
            //{
            //    toplam += Convert.ToDouble(listBox2.Items[i]);

            //    for (int j = 0; j < ilac.dataGridView1.RowCount; j++)
            //    {

            //        if (ilac.dataGridView1.Rows[i].Cells[1].Value.ToString() == )
            //        {
            //            MessageBox.Show($"Toplam Fiyat = {ilac.dataGridView1.Rows[j].Cells["id"].Value.ToString()}\n İlaçların Adı = {ilac.dataGridView1.Rows[j].Cells["IlacAdi"].Value.ToString()}\n Toplam Tutar = {toplam}", "Hesap Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }


            //    }
            //}

        }

     
    }
}
