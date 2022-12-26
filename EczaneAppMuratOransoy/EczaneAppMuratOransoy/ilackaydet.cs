using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneAppMuratOransoy
{
    public partial class ilackaydet : Form
    {
        public ilackaydet(List<ilackaydetbilgi> iliste, List<hastauret> ilist)
        {
            InitializeComponent();
            ilaclist = iliste;
            hastalist = ilist;

            if (ilaclist.Count() > 0)
            {
                sayac = ilaclist[ilaclist.Count() - 1].id + 1;
            }
            else sayac = 1;

        }
        List<ilackaydetbilgi> ilaclist = new List<ilackaydetbilgi>();
        List<hastauret> hastalist = new List<hastauret>();
   
        private void button3_Click(object sender, EventArgs e)
        {
            ilac ilac = new ilac(ilaclist,hastalist);
            ilac.Show();
            this.Hide();

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
              && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
         && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
    && !char.IsSeparator(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
&& !char.IsSeparator(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
&& !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 7 )
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Barkod 7 Haneden Büyük Olamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
        }

        int sayac = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            ilackaydetbilgi i = new ilackaydetbilgi();
            i.id = sayac;
            try
            {
                i.BarkodNo =Convert.ToInt32(textBox1.Text);
                i.IlacAdi = textBox2.Text;
                i.UreticiFirme = textBox3.Text;
                i.KutuSayisi = Convert.ToInt32(textBox4.Text);
                i.Fiyati = Convert.ToInt32(textBox5.Text);
                i.KullanimAmaci = textBox6.Text;
                i.YanEtkileri = textBox7.Text;
                i.kullanim = comboBox1.Text;
                i.İlaciTeslim = textBox8.Text;
                ilaclist.Add(i);
                sayac++;
            }
            catch (Exception)
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Ürün Kaydedilirken Boş Bırakılamaz", "Dikkat");
            }
            temizle();
  
        }

        private void temizle()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            comboBox1.Text = " ";
            textBox8.Text = " ";
        }

        public int a, b, c, d, i;

 

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 2 )
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Bir İlaç için En fazla 99 Kutu Alabilirsiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Clear();
            }
        }

        private void ilackaydet_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Oftalmik(Göze)");
            a = Convert.ToInt32(comboBox1.Items.IndexOf(0));
            comboBox1.Items.Add("İntranazal(Buruna)");
            b = Convert.ToInt32(comboBox1.Items.IndexOf(1));
            comboBox1.Items.Add("Otik(Dış Kulak Yoluna)");
            c = Convert.ToInt32(comboBox1.Items.IndexOf(2));
            comboBox1.Items.Add("Bukkal(Ağız İçine)");
            d = Convert.ToInt32(comboBox1.Items.IndexOf(3));
            comboBox1.Items.Add("Epidermal(Cilt Üzerine)");
            i = Convert.ToInt32(comboBox1.Items.IndexOf(4));
        }

        
    }
}
