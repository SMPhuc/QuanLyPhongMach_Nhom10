using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_engineer
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

		private void Home_Load(object sender, EventArgs e)
		{
			string connectionString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string query = "SELECT HO_TEN FROM BAC_SI WHERE MA_BAC_SI = @Ma_Bac_Si";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Ma_Bac_Si", "BS001");

			SqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				label1.Text = reader["HO_TEN"].ToString();
			}

			connection.Close();
		
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
