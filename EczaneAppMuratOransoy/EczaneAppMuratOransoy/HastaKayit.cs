using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EczaneAppMuratOransoy
{
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }
        public HastaKayit(List<hastauret> ilist, List<ilackaydetbilgi> iliste)
        {
            InitializeComponent();
            hastalist = ilist;
            ilaclist = iliste;
            dataGridView2.DataSource = ilist;

            if (hastalist.Count() > 0)
            {
                sayac = hastalist[hastalist.Count() - 1].id + 1;
            }
            else sayac = 1;


        }
        List<hastauret> hastalist = new List<hastauret>();
        List<ilackaydetbilgi> ilaclist = new List<ilackaydetbilgi>();

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(hastalist,ilaclist);
            form1.Show();
            this.Hide();

        }

      
        int sayac = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            hastauret hasta = new hastauret();
            hasta.id = sayac;
            try
            {

                hasta.tcNo = textBox1.Text;
                hasta.AdSoyad = textBox2.Text;
                hasta.sosyal = comboBox1.Text;
                hasta.telNo = textBox3.Text;
                hastalist.Add(hasta);
                dataGridView2.DataSource = "";
                dataGridView2.DataSource = hastalist;
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
            comboBox1.Text = " ";
        
        }
        public int a, b;
        hastauret hastauret = new hastauret();
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hastalist.Count(); i++)
            {
                if (hastalist[i].id == hastauret.id)
                {
                    hastalist.RemoveAt(i);
                    break;
                }
            }
            dataGridView2.DataSource = "";
            dataGridView2.DataSource = hastalist;
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 11)
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Tc Kimlik No 11 Haneden Büyük Olamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
       
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 10)
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Lütfen Telefon Numaranızın Başında 0 (sıfır) Kullanmayınız veya \n 10 haneden büyük telefon numarası girilemez.  ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Clear();
            }
       
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hastauret.id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void HastaKayit_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SSK");
            a = Convert.ToInt32(comboBox1.Items.IndexOf(0));
            comboBox1.Items.Add("SGK");
            a = Convert.ToInt32(comboBox1.Items.IndexOf(1));
            textBox1.MaxLength = 260;

        }
    }
}
