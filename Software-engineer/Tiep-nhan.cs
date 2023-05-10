using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Software_engineer
{
    public partial class Tiep_nhan : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        string query;
        string insert;
        string update;
        int count = 0;  
        string connectString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
        
        public Tiep_nhan()
        {
            InitializeComponent();
                sqlCon = new SqlConnection(connectString);
                sqlCon.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlCon;
        }

        private void Tiep_nhan_Load(object sender, EventArgs e)
        {
            /// Nhớ thêm bảng này vào để làm yêu cầu 1: mỗi ngày nhập tối đa 40 bệnh nhân


            //CREATE TABLE DEM_BENH_NHAN(
            //    count INT,
            //    date DATE
            //)

            //INSERT INTO DEM_BENH_NHAN(count, date) VALUES(0, GETDATE());


            lblID.Text = "ID tự động";
            lblID.ForeColor = Color.White;


            query = "select * from DEM_BENH_NHAN";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                if (reader.Read())
                {
                    DateTime dateFromSql = Convert.ToDateTime(reader[1]);
                    if (dateFromSql.Date == DateTime.Now.Date)
                    {
                        count = int.Parse(reader[0].ToString());

                    }
                }
            }
            reader.Close();


            //// load comboBox maNhanVien
            query = "select MA_NHAN_VIEN from NHAN_VIEN_TIEP_NHAN";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbMaSoBSi.Items.Add(reader[0].ToString());
                }
            }
            reader.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(count >= 40)
            {

                MessageBox.Show("Số lượng bệnh nhân hôm nay đã tối đa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Text = "";
                txtPhone.Text = "";
                txtAdress.Text = "";
                lblID.Text = "ID tự động";
                lblID.ForeColor = Color.White;
                lblSTT.Text = "";
                dtpDate.Value = DateTime.Now;
                return;
            }

            bool fullFill = true;

            // NV
            if (cbMaSoBSi.Text == "")
            {
                errorNhanVien.SetError(cbMaSoBSi, "Không được bỏ trống");
                fullFill = false;
            }
            else
            {
                errorNhanVien.SetError(cbMaSoBSi, "");
            }

            //ID
            if (lblID.Text == "ID tự động")
            {
                errorID.SetError(lblID, "Không được bỏ trống");
                fullFill = false;
            }
            else
            {
                errorID.SetError(lblID, "");
            }



            //Name
            if (txtName.Text == "")
            {
                errorName.SetError(txtName, "Không được bỏ trống") ;
                fullFill = false;
            }
            else
            {
                errorName.SetError(txtName, "");
            }

            //Phone
            if (txtPhone.Text == "")
            {
                errorPhone.SetError(txtPhone, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorPhone.SetError(txtPhone, "");
            }

            //Address
            if (txtAdress.Text == "")
            {
                errorAdress.SetError(txtAdress, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorAdress.SetError(txtAdress, "");
            }

            //datTime
            if (DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")))
            {
                errorDate.SetError(dtpDate, "Không hợp lệ");
                fullFill = false;

            }
            else
            {
                errorDate.SetError(dtpDate, "");
            }


            if(!fullFill)
            {
                MessageBox.Show("Cần nhập ĐẦY ĐỦ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                string id = GeneratePatientID(txtName.Text, dtpDate.Value.ToString("MM/dd/yyyy"), txtPhone.Text);

                query = "select * from BENH_NHAN where MA_SO_BENH_NHAN = 'BN" + id.ToUpper() + "'";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Thông tin bệnh nhân đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Text = "";
                        txtPhone.Text = "";
                        txtAdress.Text = "";
                        lblID.Text = "ID tự động";
                        lblID.ForeColor = Color.White;
                        lblSTT.Text = "";
                        dtpDate.Value = DateTime.Now;
                        reader.Close();
                        return;
                    }
                    
                }
                reader.Close();


                count++;
                insert = "insert into BENH_NHAN(MA_SO_BENH_NHAN, MA_NHAN_VIEN, TEN_BENH_NHAN, NGAY_SINH,DIA_CHI, SO_DIEN_THOAI) \r\nvalues('"+lblID.Text+"', '"+cbMaSoBSi.Text+"', N'"+txtName.Text+"', CONVERT(datetime, '"+dtpDate.Value.ToString("MM/dd/yyyy")+"'), N'"+txtAdress.Text+"', '"+txtPhone.Text+"')";
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();
                lblSTT.Text = count +"";
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName.Text = "";
                txtPhone.Text = "";
                txtAdress.Text = "";
                lblID.Text = "ID tự động";
                lblID.ForeColor = Color.White;
                lblSTT.Text = "";
                dtpDate.Value = DateTime.Now;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' '))
            {
                errorName.SetError(txtName, "Giá trị không đúng định dạng");
                e.Handled = true;
            }
            else
            {
                errorName.SetError(txtName, "");
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                errorPhone.SetError(txtPhone, "Giá trị không hợp lệ (Chỉ nhập số)");
                e.Handled = true;
            }
            else if (txtPhone.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                errorPhone.SetError(txtPhone, "Số điện thoại không đúng định dạng (Yêu cầu tối đa 10 số)");
                e.Handled = true;
            }
            else
            {
                errorPhone.SetError(txtPhone, "");
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 10)
            {
                errorPhone.SetError(txtPhone, "Số điện thoại không đúng định dạng (Yêu cầu 10 số)");
            }
            else
            {
                errorPhone.SetError(txtPhone, "");
            }

            
        }

        private void txtAdress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ',' || e.KeyChar == '/' || e.KeyChar == ' '))
            {
                errorAdress.SetError(txtAdress, "Giá trị không đúng định dạng (Cho phép , / chữ và số)");
                e.Handled = true;
            }
            else
            {
                errorAdress.SetError(txtAdress, "");
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                errorName.SetError(txtName, "Không được bỏ trống");
            }
            else
            {
                errorName.SetError(txtName, "");
                if (txtName.Text[txtName.Text.Length - 1].ToString() == " ")
                {
                    txtName.Text = txtName.Text.Substring(0, txtName.Text.Length - 1).Trim(' ');
                }
            }
        }

        private void txtAdress_Leave(object sender, EventArgs e)
        {
            if (txtAdress.Text == "")
            {
                errorAdress.SetError(txtAdress, "Không được bỏ trống");
            }
            else
            {
                errorAdress.SetError(txtAdress, "");
                if (txtAdress.Text[txtAdress.Text.Length - 1].ToString() == " ")
                {
                    txtAdress.Text = txtAdress.Text.Substring(0, txtAdress.Text.Length - 1).Trim(' ');
                }


            }




        }

        private void Tiep_nhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            update = "update DEM_BENH_NHAN set count = "+count+", date = GETDATE()";
            cmd.CommandText = update;
            cmd.ExecuteNonQuery();

        }

        private void dtpDate_Leave(object sender, EventArgs e)
        {
            if (DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")))
            {
                errorDate.SetError(dtpDate, "Không hợp lệ");
            }
            else
            {
                errorDate.SetError(dtpDate, "");

            }
        }

        private void lblID_Enter(object sender, EventArgs e)
        {
            //if (lblID.Text == "")
            //{
            //    string id = GeneratePatientID(txtName.Text, dtpDate.Value.ToString("MM/dd/yyyy"), txtPhone.Text);
            //    lblID.Text = "BN" + id.ToUpper();
            //    lblID.ForeColor = Color.Black;
            //}
        }
        public static string GeneratePatientID(string name, string dob, string phone)
        {
            string input = $"{name}{dob}{phone}";

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Tạo chuỗi hash từ thông tin bệnh nhân
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

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
                return numericString.Substring(0, 4);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMaSoBSi.ResetText();
            cbMaSoBSi.SelectedIndex = -1;
            txtName.Text = "";
            txtPhone.Text = "";
            txtAdress.Text = "";
            lblID.Text = "ID tự động";
            lblID.ForeColor = Color.White;
            lblSTT.Text = "";
            dtpDate.Value = DateTime.Now;

            //Name
                errorName.SetError(txtName, "");

            //Phone
                errorPhone.SetError(txtPhone, "");

            //Address
                errorAdress.SetError(txtAdress, "");

            //datTime
                errorDate.SetError(dtpDate, "");
            // id
            errorID.SetError(lblID, "");

            //NV
            errorNhanVien.SetError(cbMaSoBSi, "");
        }

        private void btnGetID_Click(object sender, EventArgs e)
        {
            bool fullFill = true;
            //Name
            if (txtName.Text == "")
            {
                errorName.SetError(txtName, "Không được bỏ trống");
                fullFill = false;
            }
            else
            {
                errorName.SetError(txtName, "");
            }

            //Phone
            if (txtPhone.Text == "")
            {
                errorPhone.SetError(txtPhone, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorPhone.SetError(txtPhone, "");
            }

            //datTime
            if (DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")))
            {
                errorDate.SetError(dtpDate, "Không hợp lệ");
                fullFill = false;
            }
            else
            {
                errorDate.SetError(dtpDate, "");
            }


            if(!fullFill)
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                //Generate ID
                    string id = GeneratePatientID(txtName.Text, dtpDate.Value.ToString("MM/dd/yyyy"), txtPhone.Text);
                    lblID.Text = "BN" + id.ToUpper();
                    lblID.ForeColor = Color.Black;
            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMaSoBSi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            Home.Show();
            this.Hide();
        }
    }
    
}
