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

namespace EczaneAppMuratOransoy
{
    public partial class ilac : Form
    {
        public ilac()
        {
            InitializeComponent();
        }
        public ilac(List<ilackaydetbilgi> iliste, List<hastauret> ilist)
        {
            InitializeComponent();
            hastalist = ilist;
            ilaclist = iliste;
            dataGridView1.DataSource = ilaclist;

            if (ilaclist.Count() > 0)
            {
                sayac = ilaclist[ilaclist.Count() - 1].id + 1;
            }
            else sayac = 1;

        }
        public int sayac;
        List<hastauret> hastalist = new List<hastauret>();
        List<ilackaydetbilgi> ilaclist = new List<ilackaydetbilgi>();
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(hastalist,ilaclist);
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilackaydet ilackaydet = new ilackaydet(ilaclist,hastalist);
            ilackaydet.Show();
            this.Hide();
            
        }
        ilackaydetbilgi secilenilack = new ilackaydetbilgi();
        private void button3_Click(object sender, EventArgs e)
        {
 
            for(int i= 0; i < ilaclist.Count(); i++)
            {
                if (ilaclist[i].id == secilenilack.id)
                {
                    ilaclist.RemoveAt(i);
                    break;
                }
            }
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = ilaclist;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenilack.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ilacsatis ilacsatis = new ilacsatis(ilaclist,hastalist);
            ilacsatis.Show();
            this.Hide();
        }

       
    }
}
