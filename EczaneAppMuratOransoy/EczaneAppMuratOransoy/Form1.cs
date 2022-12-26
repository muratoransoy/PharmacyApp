using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EczaneAppMuratOransoy
{
    public partial class Form1 : Form
    {
         public Form1()
        {
            InitializeComponent();
        }
        public Form1(List<hastauret> ilist,List<ilackaydetbilgi> iliste)
        {
            InitializeComponent();
            hastalist = ilist;
            ilaclist = iliste;
          
        }
        List<hastauret> hastalist = new List<hastauret>();
        List<ilackaydetbilgi> ilaclist = new List<ilackaydetbilgi>();
        private void button1_Click(object sender, EventArgs e)
        {
            ilac form2 = new ilac(ilaclist,hastalist);
            form2.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HastaKayit hasta = new HastaKayit(hastalist, ilaclist);
            hasta.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
               
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }




         private void button4_Click_1(object sender, EventArgs e)
        {
            ilacsatis ilacsatis = new ilacsatis();
            ilacsatis.Show();
            this.Hide();
        }

  


       
    }
}
