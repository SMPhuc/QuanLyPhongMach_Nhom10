using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Software_engineer
{
    public partial class Tra_cuu : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        string query;
        string insert;
        string update;
        string delete;
        int count = 0;
        string connectString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";

        public Tra_cuu()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(connectString);
            sqlCon.Open();
            cmd = new SqlCommand();
            cmd.Connection = sqlCon;
        }

        //Tra_cuu load
        private void txtName_Load(object sender, EventArgs e)
        {
            // load listView
            query = "select * from BENH_NHAN";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDateTime(3).ToString("MM/dd/yyyy"));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetString(5));
                    listView1.Items.Add(item);
                }
            }
            reader.Close();


            //// load comboBox maBenhNhan
            query = "select MA_SO_BENH_NHAN from BENH_NHAN";
            cmd.CommandText = query;
             reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbMaSoBN.Items.Add(reader[0].ToString());
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

        ///btnQuery click
        private void button10_Click(object sender, EventArgs e)
        {

            bool filled = false;
            string where = "";

            //Name
            if (txtName.Text != "")
            {
                filled = true;

                if (where != "")
                {
                    where += "and";
                }
                where += " TEN_BENH_NHAN = N'" + txtName.Text + "' ";

                
            }

            //Phone
            if (txtPhone.Text != "")
            {
                filled = true;

                if (where != "")
                {
                    where += "and";
                }
                where += " SO_DIEN_THOAI = '"+txtPhone.Text+"' ";

            }

            //address
            if (txtAddress.Text != "")
            {
                filled = true;

                if (where != "")
                {
                    where += "and";
                }
                where += " DIA_CHI = N'" + txtAddress.Text + "' ";

            }

            //maBenhNhan
            if (cbMaSoBN.Text != "")
            {
                filled = true;

                if (where != "")
                {
                    where += "and";
                }
                where += " MA_SO_BENH_NHAN = '" + cbMaSoBN.Text + "' ";

            }

            //maBenhNhan
            if (cbMaSoBSi.Text != "")
            {
                filled = true;

                if (where != "")
                {
                    where += "and";
                }
                where += " MA_NHAN_VIEN = '" + cbMaSoBSi.Text + "' ";

            }

            // DOB
            if (DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) < DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")))
            {
                filled = true;


                if (where != "")
                {
                    where += "and";
                }
                where += " CONVERT(datetime,NGAY_SINH) = CONVERT(datetime, '"+ DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) + "') ";
            }

            if (!filled)
            {
                MessageBox.Show("Vui lòng điền thông tin để tra cứu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //MessageBox.Show(where);

            query = "select * from BENH_NHAN where "+where+"";
            cmd.CommandText = query;
            //MessageBox.Show(query);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                listView1.Items.Clear();
                while (reader.Read())
                {

                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDateTime(3).ToString("MM/dd/yyyy"));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetString(5));
                    listView1.Items.Add(item);

                }
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Close();

            }
            else
            {
                reader.Close();

                MessageBox.Show("Không có kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // load listView
                query = "select * from BENH_NHAN";
                cmd.CommandText = query;
                 reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetDateTime(3).ToString("MM/dd/yyyy"));
                        item.SubItems.Add(reader.GetString(4));
                        item.SubItems.Add(reader.GetString(5));
                        listView1.Items.Add(item);
                    }
                }
                reader.Close();


                cbMaSoBN.ResetText();
                cbMaSoBN.SelectedIndex = -1;

                cbMaSoBSi.ResetText();
                cbMaSoBSi.SelectedIndex = -1;

                dtpDate.Value = DateTime.Now;

                txtName.Text = "";

                txtPhone.Text = "";
                txtAddress.Text = "";

                //BenhNhan
                errorMaBN.SetError(cbMaSoBN, "");

                //BacSi
                errorMaBSi.SetError(cbMaSoBSi, "");

                //Result
                errorName.SetError(txtName, "");

                //datTime
                errorDate.SetError(dtpDate, "");

                //SDT
                errorSDT.SetError(txtPhone, "");

                //Address
                errorAddress.SetError(txtAddress, "");
            }


        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //cbResult.Enabled = false;
                cbMaSoBSi.Enabled = false;
                cbMaSoBN.Enabled = false;
                //btnGetId.Enabled = false;
                //btnAdd.Enabled = false;



                var x = listView1.SelectedItems[0];

                cbMaSoBN.Text = x.SubItems[0].Text;
                cbMaSoBSi.Text = x.SubItems[1].Text;
                txtName.Text = x.SubItems[2].Text;
                dtpDate.Value = DateTime.Parse(x.SubItems[3].Text);
                txtAddress.Text = x.SubItems[4].Text;
                txtPhone.Text = x.SubItems[5].Text;

            }
        }
        
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' '))
            {
                errorName.SetError(txtName, "Giá trị không đúng định dạng");
                e.Handled = true;
            }
            else
            {
                errorName.SetError(txtName, "");

            }
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            errorName.SetError(txtName, "");
            if (txtName.Text == "") return;
            if (txtName.Text[txtName.Text.Length - 1].ToString() == " ")
            {
                txtName.Text = txtName.Text.Substring(0, txtName.Text.Length - 1).Trim(' ');
            }

        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                errorSDT.SetError(txtPhone, "Giá trị không hợp lệ (Chỉ nhập số)");
                e.Handled = true;
            }
            else if (txtPhone.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                errorSDT.SetError(txtPhone, "Số điện thoại không đúng định dạng (Yêu cầu tối đa 10 số)");
                e.Handled = true;
            }
            else
            {
                errorSDT.SetError(txtPhone, "");
            }
        }
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                errorSDT.SetError(txtPhone, "");
                return;
            }

            if (txtPhone.Text.Length != 10)
            {
                errorSDT.SetError(txtPhone, "Số điện thoại không đúng định dạng (Yêu cầu 10 số)");
            }
            else
            {
                errorSDT.SetError(txtPhone, "");
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMaSoBSi.Enabled = true;
            cbMaSoBN.Enabled = true;


            query = "select * from BENH_NHAN";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDateTime(3).ToString("MM/dd/yyyy"));
                    item.SubItems.Add(reader.GetString(4));
                    item.SubItems.Add(reader.GetString(5));
                    listView1.Items.Add(item);
                }
            }
            reader.Close();


            cbMaSoBN.ResetText();
            cbMaSoBN.SelectedIndex = -1;

            cbMaSoBSi.ResetText();
            cbMaSoBSi.SelectedIndex = -1;

            dtpDate.Value = DateTime.Now;

            txtName.Text = "";

            txtPhone.Text = "";
            txtAddress.Text = "";

            //BenhNhan
            errorMaBN.SetError(cbMaSoBN, "");

            //BacSi
            errorMaBSi.SetError(cbMaSoBSi, "");

            //Result
            errorName.SetError(txtName, "");

            //datTime
            errorDate.SetError(dtpDate, "");

            //SDT
            errorSDT.SetError(txtPhone, "");

            //Address
            errorAddress.SetError(txtAddress, "");
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?\nViệc này sẽ xóa TẤT CẢ liên quan tới BỆNH NHÂN này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    listView1.SelectedItems[0].Remove();

                    delete = "delete from BENH_NHAN where MA_SO_BENH_NHAN = '" + cbMaSoBN.Text + "'";
                    cmd.CommandText = delete;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chọn đối tượng để XÓA", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn CHỈNH SỬA?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    listView1.SelectedItems[0].SubItems[0].Text = cbMaSoBN.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = cbMaSoBSi.Text;
                    listView1.SelectedItems[0].SubItems[2].Text = txtName.Text;
                    listView1.SelectedItems[0].SubItems[3].Text = dtpDate.Value.ToString("MM/dd/yyyy");
                    listView1.SelectedItems[0].SubItems[4].Text = txtAddress.Text;
                    listView1.SelectedItems[0].SubItems[5].Text = txtPhone.Text;


                    update = "update BENH_NHAN set TEN_BENH_NHAN = N'"+txtName.Text+"', NGAY_SINH = CONVERT(datetime, '"+ dtpDate.Value.ToString("MM/dd/yyyy") + "'), SO_DIEN_THOAI = '"+txtPhone.Text+"', DIA_CHI = N'"+txtAddress.Text+"'\r\nwhere MA_SO_BENH_NHAN = '"+cbMaSoBN.Text+"'";
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();




                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Chọn đối tượng để CHỈNH SỬA", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
