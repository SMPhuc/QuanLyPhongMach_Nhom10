using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_engineer
{
    public partial class Hoa_don : Form
    {
        int tienKham = 30000;

        SqlConnection sqlCon;
        SqlCommand cmd;
        string query;
        string insert;
        string update;
        string delete;
        string connectString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";

        public Hoa_don()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(connectString);
            sqlCon.Open();
            cmd = new SqlCommand();
            cmd.Connection = sqlCon;
        }

        private void Hoa_don_Load(object sender, EventArgs e)
        {
            //// load comboBox maSoPKB
            query = "select MA_SO_PHIEU_KHAM_BENH From PHIEU_KHAM_BENH";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbMaSoPKB.Items.Add(reader[0].ToString());
                }
            }
            reader.Close();

            txtMoney.Text = tienKham+"";
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // NV
            if (cbMaSoPKB.Text == "")
            {
                errorMaSoPKB.SetError(cbMaSoPKB, "Không được bỏ trống");
                MessageBox.Show("Hãy chọn mã số PHIẾU KHÁM BỆNH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string maSoHD = "MP" + GeneratePatientID(cbMaSoPKB.Text);
                query = "select * from HOA_DON_THANH_TOAN where MA_SO_HOA_DON = '" + maSoHD + "'";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    cbMaSoPKB.ResetText();
                    cbMaSoPKB.SelectedIndex = -1;
                    MessageBox.Show("Hóa đơn này đã được lập trước đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                reader.Close();

                listView1.Items.Clear();

                string maSoBN = "";
                query = "select MA_SO_BENH_NHAN from PHIEU_KHAM_BENH where MA_SO_PHIEU_KHAM_BENH = '" + cbMaSoPKB.Text + "'";
                //query = "select MA_SO_BENH_NHAN from PHIEU_KHAM_BENH where MA_SO_PHIEU_KHAM_BENH = 'MP691'";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        maSoBN = reader.GetString(0);
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Error khi lấy maSoBN từ maSoPKB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                int tongTien = tienKham;
                MessageBox.Show("Đang tính tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                query = "select t.MA_THUOC, t.TEN_THUOC, t.GIA_THUOC, t.DON_VI_TINH, t.CACH_DUNG From KE_TOA kt join THUOC t on kt.MA_THUOC = t.MA_THUOC where MA_SO_PHIEU_KHAM_BENH = '" + cbMaSoPKB.Text + "'";
                //query = "select t.MA_THUOC, t.TEN_THUOC, t.GIA_THUOC, t.DON_VI_TINH, t.CACH_DUNG From KE_TOA kt join THUOC t on kt.MA_THUOC = t.MA_THUOC where MA_SO_PHIEU_KHAM_BENH = 'MP098'";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tongTien += int.Parse(reader.GetString(2));
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetString(3));
                        item.SubItems.Add(reader.GetString(4));
                        listView1.Items.Add(item);
                    }
                    txtTotal.Text = tongTien + "";
                }
                else
                {
                    MessageBox.Show("Phiếu khám bệnh không tồn tại thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                reader.Close();

                insert = "insert into HOA_DON_THANH_TOAN(MA_SO_HOA_DON, MA_SO_BENH_NHAN, NGAY_LAP_HOA_DON, TONG_CHI_PHI) \r\nvalues('" + maSoHD + "', '" + maSoBN + "', CONVERT(datetime, '" + DateTime.Now.ToString("MM/dd/yyyy") + "'), " + tongTien + ");";
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();

            }
        }

        private void cbMaSoPKB_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorMaSoPKB.SetError(cbMaSoPKB, "");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMaSoPKB.ResetText();
            cbMaSoPKB.SelectedIndex = -1;

            listView1.Items.Clear();

            txtTotal.Text = "";
        }

        public static string GeneratePatientID(string maSoPKB)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Tạo chuỗi hash từ mã số phòng khám
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(maSoPKB));

                // Chuyển đổi chuỗi hash sang dạng hex string để sử dụng làm ID
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string hexString = builder.ToString();

                // Loại bỏ các ký tự không phải số khỏi chuỗi hex string
                string numericString = Regex.Replace(hexString, "[^0-9]", "");

                // Trả về 4 ký tự đầu tiên của chuỗi số
                return numericString.Substring(0, 3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            Home.Show();
            this.Hide();
        }
    }
}
