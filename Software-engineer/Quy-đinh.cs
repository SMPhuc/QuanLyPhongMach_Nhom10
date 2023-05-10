using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_engineer
{
    public partial class Quy_đinh : Form
    {
        public Quy_đinh()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tiep_nhan tiep_Nhan = new Tiep_nhan();
            tiep_Nhan.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kham_benh kham_Benh = new Kham_benh();
            kham_Benh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hoa_don hoa_Don = new Hoa_don();
            hoa_Don.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tra_cuu tra_Cuu = new Tra_cuu();
            tra_Cuu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bao_cao bao_Cao = new Bao_cao();
            bao_Cao.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Quy_đinh quy_Đinh = new Quy_đinh();
            quy_Đinh.Show();
            this.Hide();
        }
    }
}
