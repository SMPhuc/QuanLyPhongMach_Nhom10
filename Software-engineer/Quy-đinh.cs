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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        

        //private void LoadData()
        //{
        //    string connectionString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
        //    string query = "SELECT Quy_dinh, Noi_dung FROM QUY_DINH";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            ListViewItem item = new ListViewItem(reader["Quy_dinh"].ToString());
        //            item.SubItems.Add(reader["Noi_dung"].ToString());
        //            listView1.Items.Add(item);
        //        }

        //        reader.Close();
        //    }
        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    ListViewItem selectedItem = listView1.SelectedItems[0];
            //    selectedItem.Selected = false;
            //    selectedItem.Focused = false;

            //    //int selectedColumnIndex = listView1.SelectedIndices[0];
            //    listView1.Items[selectedColumnIndex].Selected = true;
            //    listView1.Items[selectedColumnIndex].Focused = true;
            //}
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Lấy thông tin từ item được chọn và hiển thị lên textbox
                textBox1.Text = selectedItem.SubItems[0].Text;
                textBox2.Text = selectedItem.SubItems[1].Text;
                textBox1.ReadOnly = false; textBox2.ReadOnly = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
            textBox1.ReadOnly = false;
            textBox2.ReadOnly= false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Lấy thông tin từ item được chọn và hiển thị lên textbox
                textBox1.Text = selectedItem.SubItems[0].Text;
                textBox2.Text = selectedItem.SubItems[1].Text;

                // Tắt chế độ chỉnh sửa của textbox1 và textbox2
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;

                // Đưa con trỏ về textbox1
                textBox1.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string quyDinh = textBox1.Text;
            string noiDung = textBox2.Text;

            string connectionString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
            string checkQuery = "SELECT COUNT(*) FROM QUY_DINH WHERE Quy_dinh = @QuyDinh OR Noi_dung = @NoiDung";
            string insertQuery = "INSERT INTO QUY_DINH (Quy_dinh, Noi_dung) VALUES (@QuyDinh, @NoiDung)";
            string updateQuery = "UPDATE QUY_DINH SET Noi_dung = @NoiDung WHERE Quy_dinh = @QuyDinh";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@QuyDinh", quyDinh);
                checkCommand.Parameters.AddWithValue("@NoiDung", noiDung);
                connection.Open();

                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@QuyDinh", quyDinh);
                    updateCommand.Parameters.AddWithValue("@NoiDung", noiDung);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@QuyDinh", quyDinh);
                    insertCommand.Parameters.AddWithValue("@NoiDung", noiDung);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void LoadData(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
            string query = "SELECT Quy_dinh, Noi_dung FROM QUY_DINH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Quy_dinh"].ToString());
                    item.SubItems.Add(reader["Noi_dung"].ToString());
                    listView1.Items.Add(item);
                }

                reader.Close();
            }
        }
    }
}
