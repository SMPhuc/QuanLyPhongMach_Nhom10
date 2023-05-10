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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem TextBox đã được nhập hay chưa
			if (textBox1.Text == "")
			{
				MessageBox.Show("Vui lòng nhập dữ liệu vào Mã đăng nhập!");
				return;
			}
			if (textBox2.Text == "")
			{
				MessageBox.Show("Vui lòng nhập dữ liệu vào mật khẩu!");
				return;
			}
			// Kiểm tra xem RadioButton đã được chọn hay chưa
			if (!radioButton1.Checked && !radioButton2.Checked)
			{
				MessageBox.Show("Vui lòng chọn chức vụ!");
				return;
			}
			string connectionString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			string username = textBox1.Text;
			string password = textBox2.Text;

			string query = "";
			if (radioButton1.Checked)
			{
				// Truy vấn dữ liệu từ bảng 1
				query = "SELECT * FROM BAC_SI WHERE MA_BAC_SI = @Username AND Password = @Password";
			}
			else if (radioButton2.Checked)
			{
				// Truy vấn dữ liệu từ bảng 2
				query = "SELECT * FROM NHAN_VIEN_TIEP_NHAN WHERE MA_NHAN_VIEN = @Username AND Password = @Password";
			}

			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Username", username);
			command.Parameters.AddWithValue("@Password", password);

			SqlDataReader reader = command.ExecuteReader();

			if (reader.Read())
			{
				// Đăng nhập thành công
				MessageBox.Show("Đăng nhập thành công!");

				// Mở form chính hoặc thực hiện các hành động khác
				Home Home = new Home();
				Home.Show();
				this.Hide();
			}
			else
			{
				// Đăng nhập thất bại
				MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
				// Cho phép người dùng thử lại
			}

			connection.Close();
		}
	}
}

