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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Software_engineer
{
    public partial class Kham_benh : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        string query;
        string insert;
        string update;
        string delete;
        string connectString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
        public Kham_benh()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(connectString);
            sqlCon.Open();
            cmd = new SqlCommand();
            cmd.Connection = sqlCon;
        }

        private void Kham_benh_Load(object sender, EventArgs e)
        {
            lblID.Text = "ID tự động";
            lblID.ForeColor = Color.White;


            //// load comboBox maBenhNhan
            query = "select MA_SO_BENH_NHAN from BENH_NHAN";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    cbMaSoBN.Items.Add(reader[0].ToString());
                }
            }
            reader.Close();


            //// load comboBox maBacSi
            query = "select MA_BAC_SI from BAC_SI";
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

            // load comboBox Thuoc
            query = "select MA_THUOC, TEN_THUOC from THUOC";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cbChooseMed.Items.Add(reader[0].ToString() + "-" + reader[1].ToString());
                }
            }
            reader.Close();



            ////////////////////////////// Nếu thay đổi số lượng loại bệnh thì chổ này
            for (int i = 1; i <= 5; i++)
            {
                cbResult.Items.Add("Bệnh " + i);
            }


            // load listView
            query = "SELECT pkb.MA_SO_PHIEU_KHAM_BENH, pkb.MA_SO_BENH_NHAN, pkb.MA_BAC_SI, pkb.TRIEU_CHUNG, pkb.KET_QUA_KHAM_BENH, pkb.NGAY_KHAM_BENH, kt.MA_THUOC, t.TEN_THUOC\r\nFROM (PHIEU_KHAM_BENH pkb\r\nJOIN KE_TOA kt ON pkb.MA_SO_PHIEU_KHAM_BENH = kt.MA_SO_PHIEU_KHAM_BENH)\r\nJOIN THUOC t ON kt.MA_THUOC = t.MA_THUOC;";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                string id = "";
                bool loaded = false;
                ListViewItem item = null;
                List<string> thuoc = new List<string>();

                while (reader.Read())
                {
                    if (id != reader[0].ToString())
                    {

                        if (item != null && thuoc.Count != 0)
                        {
                            string thuocTmp = string.Join(",", thuoc);
                            item.SubItems.Add(thuocTmp);
                            listView1.Items.Add(item);

                        }

                        id = reader[0].ToString();
                        loaded = false;
                        thuoc.Clear();
                    }

                    if (!loaded)
                    {
                        item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetString(3));
                        item.SubItems.Add(reader.GetString(4));

                        item.SubItems.Add(reader.GetDateTime(5).ToString("MM/dd/yyyy"));
                        loaded = true;
                    }
                    thuoc.Add(reader.GetString(6) + "-" + reader.GetString(7));
                }
                if (item != null && thuoc.Count != 0)
                {
                    string thuocTmp = string.Join(",", thuoc);
                    item.SubItems.Add(thuocTmp);
                    listView1.Items.Add(item);
                }
            }
            reader.Close();


            /////// THÊM DATA CHO "THUOC"
            //string id = "";
            //string type = "";
            //Random random = new Random();


            //for (int i = 1; i <= 30; i++)
            //{
            //    int use = random.Next(1, 5);

            //    if (i < 10)
            //    {
            //        id = "0" + i;
            //    }
            //    else
            //    {
            //        id = i+"";
            //    }

            //    type = i % 2 == 0 ?  "Viên" :  "Chai";

            //    insert = "insert into THUOC (MA_THUOC, TEN_THUOC, GIA_THUOC, DON_VI_TINH, CACH_DUNG) values ('MT0"+ id + "', N'Thuốc "+i+"', N'10000', N'"+type+"', N'Cách "+use+"')";

            //    cmd.CommandText = insert;
            //    cmd.ExecuteNonQuery();
            //}
        }

        private void txtTrieuChung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ' || e.KeyChar == ','))
            {
                errorTrieuChung.SetError(txtTrieuChung, "Giá trị không đúng định dạng");
                e.Handled = true;
            }
            else
            {
                errorTrieuChung.SetError(txtTrieuChung, "");
            }
        }

        private void txtTrieuChung_Leave(object sender, EventArgs e)
        {
            errorTrieuChung.SetError(txtTrieuChung, "");
            if (txtTrieuChung.Text == "") return;
            if (txtTrieuChung.Text[txtTrieuChung.Text.Length - 1].ToString() == " ")
            {
                txtTrieuChung.Text = txtTrieuChung.Text.Substring(0, txtTrieuChung.Text.Length - 1).Trim(' ');
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbMaSoBSi.Enabled = true;
            cbMaSoBN.Enabled = true;
            btnGetId.Enabled = true;
            btnAdd.Enabled = true;

            cbMaSoBN.ResetText();
            cbMaSoBN.SelectedIndex = -1;

            cbMaSoBSi.ResetText();
            cbMaSoBSi.SelectedIndex = -1;

            cbResult.ResetText();
            cbResult.SelectedIndex = -1;

            dtpDate.Value = DateTime.Now;

            txtTrieuChung.Text = "";

            lblID.Text = "ID tự động";
            lblID.ForeColor = Color.White;

            cbChoosed.Items.Clear();

            //BenhNhan
                errorMaBN.SetError(cbMaSoBN, "");

            //BacSi
                errorMaBSi.SetError(cbMaSoBSi, "");

            //Result
                errorResult.SetError(cbResult, "");

            //TrieuCung
                errorTrieuChung.SetError(txtTrieuChung, "");

            //datTime
                errorDate.SetError(dtpDate, "");

            //Medicine
                errorMedicine.SetError(cbChoosed, "");

            //ID
                errorID.SetError(lblID, "");

        }

        private void btnAddMed_Click_1(object sender, EventArgs e)
        {
            if (cbChooseMed.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn thuốc để thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbChoosed.Items.Contains(cbChooseMed.SelectedItem.ToString()))
            {
                cbChooseMed.ResetText();
                cbChooseMed.SelectedIndex = -1;
                MessageBox.Show("Thuốc này đã thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            cbChoosed.Items.Add(cbChooseMed.SelectedItem.ToString());
            cbChooseMed.ResetText();
            cbChooseMed.SelectedIndex = -1;
        }

        private void btnDeleteMed_Click(object sender, EventArgs e)
        {
            if (cbChoosed.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn thuốc để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbChoosed.Items.RemoveAt(cbChoosed.SelectedIndex);
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {

            bool fullFill = true;
            //BenhNhan
            if (cbMaSoBN.SelectedIndex == -1)
            {
                errorMaBN.SetError(cbMaSoBN, "Không được bỏ trống");
                fullFill = false;
            }
            else
            {
                errorMaBN.SetError(cbMaSoBN, "");
            }

            //BacSi
            if (cbMaSoBSi.SelectedIndex == -1)
            {
                errorMaBSi.SetError(cbMaSoBSi, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorMaBSi.SetError(cbMaSoBSi, "");
            }

            //Result
            if (cbResult.SelectedIndex == -1)
            {
                errorResult.SetError(cbResult, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorResult.SetError(cbResult, "");
            }


            if (!fullFill)
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lblID.Text != "ID tự động") return;


            lblID.Text = "MP"+GeneratePatientID(cbMaSoBN.Text, cbMaSoBSi.Text, cbResult.Text);
            lblID.ForeColor = Color.Black;

            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool fullFill = true;
            //BenhNhan
            if (cbMaSoBN.SelectedIndex == -1)
            {
                errorMaBN.SetError(cbMaSoBN, "Không được bỏ trống");
                fullFill = false;
            }
            else
            {
                errorMaBN.SetError(cbMaSoBN, "");
            }

            //BacSi
            if (cbMaSoBSi.SelectedIndex == -1)
            {
                errorMaBSi.SetError(cbMaSoBSi, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorMaBSi.SetError(cbMaSoBSi, "");
            }

            //Result
            if (cbResult.SelectedIndex == -1)
            {
                errorResult.SetError(cbResult, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorResult.SetError(cbResult, "");
            }

            //TrieuCung
            if (txtTrieuChung.Text == "")
            {
                errorTrieuChung.SetError(txtTrieuChung, "Không được bỏ trống");
                fullFill = false;

            }
            else
            {
                errorTrieuChung.SetError(txtTrieuChung, "");
            }

            //datTime
            if (DateTime.Parse(dtpDate.Value.ToString("MM-dd-yyyy")) > DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")))
            {
                errorDate.SetError(dtpDate, "Không hợp lệ");
                fullFill = false;

            }
            else
            {
                errorDate.SetError(dtpDate, "");
            };

            //Medicine
            if (cbChoosed.Items.Count == 0)
            {
                errorMedicine.SetError(cbChoosed, "Hãy chọn thuốc");
                fullFill = false;

            }
            else
            {
                errorMedicine.SetError(cbChoosed, "");
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

            if (!fullFill)
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            {// ktra xem đã có chưa
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == lblID.Text || item.SubItems[1].Text == cbMaSoBN.Text)
                    {
                        MessageBox.Show("Bệnh nhân đã có PKB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear.PerformClick();
                        return;
                    }
                }
            }

            { ///thêm vào listView
                var tmpItem = new ListViewItem(lblID.Text);
                tmpItem.SubItems.Add(cbMaSoBN.Text);
                tmpItem.SubItems.Add(cbMaSoBSi.Text);
                tmpItem.SubItems.Add(txtTrieuChung.Text);
                tmpItem.SubItems.Add(cbResult.Text);
                tmpItem.SubItems.Add(dtpDate.Value.ToString("MM/dd/yyyy"));

                string tmpThuoc = cbChoosed.Items[0].ToString();
                for (int i = 1; i < cbChoosed.Items.Count; i++)
                {
                    string item = cbChoosed.Items[i].ToString();
                    tmpThuoc += "," + cbChoosed.Items[i].ToString();
                }
                tmpItem.SubItems.Add(tmpThuoc);

                listView1.Items.Add(tmpItem);
            }


            //insert dtb
            insert = "insert into PHIEU_KHAM_BENH(MA_SO_PHIEU_KHAM_BENH, MA_SO_BENH_NHAN, MA_BAC_SI, TRIEU_CHUNG, KET_QUA_KHAM_BENH, NGAY_KHAM_BENH) \r\nvalues('"+lblID.Text+"', '"+cbMaSoBN.Text+"', '"+cbMaSoBSi.Text+"', N'"+txtTrieuChung.Text+"', N'"+cbResult.Text+"', CONVERT(datetime, '"+ dtpDate.Value.ToString("MM/dd/yyyy") + "'))";
            cmd.CommandText = insert;
            cmd.ExecuteNonQuery();


            for (int i = 0; i < cbChoosed.Items.Count; i++)
            {
                string item = cbChoosed.Items[i].ToString().Substring(0, 5);
                insert = "insert into KE_TOA(MA_SO_PHIEU_KHAM_BENH, MA_THUOC) values(N'"+lblID.Text+"', '"+item+"')";
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();
            }
            
            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    listView1.SelectedItems[0].Remove();

                    delete = "delete from PHIEU_KHAM_BENH where MA_SO_PHIEU_KHAM_BENH = '" + lblID.Text + "'";
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                cbMaSoBSi.Enabled = false;
                cbMaSoBN.Enabled = false;
                btnGetId.Enabled = false;
                btnAdd.Enabled = false;



                var x = listView1.SelectedItems[0];

                lblID.ForeColor = Color.Black;
                lblID.Text = x.SubItems[0].Text;

               cbMaSoBN.Text = x.SubItems[1].Text;
                cbMaSoBSi.Text = x.SubItems[2].Text;
                txtTrieuChung.Text = x.SubItems[3].Text;
               cbResult.Text = x.SubItems[4].Text;
                dtpDate.Value = DateTime.Parse(x.SubItems[5].Text);

                cbChoosed.Items.Clear();
                var split = x.SubItems[6].Text.Split(',');
                for(int i = 0; i < split.Length; i++)
                {
                    cbChoosed.Items.Add(split[i]);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn CHỈNH SỬA?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string tmpThuoc = cbChoosed.Items[0].ToString();
                    for (int i = 1; i < cbChoosed.Items.Count; i++)
                    {
                        string item = cbChoosed.Items[i].ToString();
                        tmpThuoc += "," + cbChoosed.Items[i].ToString();
                    }


                    listView1.SelectedItems[0].SubItems[0].Text = lblID.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = cbMaSoBN.Text;
                    listView1.SelectedItems[0].SubItems[2].Text = cbMaSoBSi.Text;
                    listView1.SelectedItems[0].SubItems[3].Text = txtTrieuChung.Text;
                    listView1.SelectedItems[0].SubItems[4].Text = cbResult.Text;
                    listView1.SelectedItems[0].SubItems[5].Text = dtpDate.Value.ToString("MM/dd/yyyy");
                    listView1.SelectedItems[0].SubItems[6].Text = tmpThuoc;


                    update = "update PHIEU_KHAM_BENH set KET_QUA_KHAM_BENH = N'"+cbResult.Text+"' ,TRIEU_CHUNG = N'" + txtTrieuChung.Text + "', NGAY_KHAM_BENH = CONVERT(datetime, '" + dtpDate.Value.ToString("MM/dd/yyyy") + "') where MA_SO_PHIEU_KHAM_BENH = '" + lblID.Text + "'";
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();


                    delete = "delete from KE_TOA where MA_SO_PHIEU_KHAM_BENH = '" + lblID.Text + "'";
                    cmd.CommandText = delete;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < cbChoosed.Items.Count; i++)
                    {
                        string item = cbChoosed.Items[i].ToString().Substring(0, 5);
                        insert = "insert into KE_TOA(MA_SO_PHIEU_KHAM_BENH, MA_THUOC) values(N'" + lblID.Text + "', '" + item + "')";
                        cmd.CommandText = insert;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                 
            }
            else
            {
                MessageBox.Show("Chọn đối tượng để CHỈNH SỬA", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public static string GeneratePatientID(string maBN, string maBS, string ketQua)
        {
            //lblID.Text = "MP" + GeneratePatientID(cbMaSoBN.Text, cbMaSoBSi.Text, cbResult.Text);

            string input = $"{maBN}{maBS}{ketQua}";

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
                return numericString.Substring(0, 3);
            }
        }


        /// Dư
        private void cbMaSoBN_Leave(object sender, EventArgs e)
        {
        }
        private void cbMaSoBN_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void cbMaSoBN_TextChanged(object sender, EventArgs e)
        {
        }
        private void cbMaSoBSi_Leave(object sender, EventArgs e)
        {
           
        }
        private void cbMaSoBN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbMaSoBSi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbMaSoBSi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTrieuChung_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void cbChoosed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddMed_Click(object sender, EventArgs e)
        {
            if (cbChooseMed.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbChoosed.Items.Contains(cbChooseMed.SelectedItem.ToString()))
            {
                cbChooseMed.ResetText();
                cbChooseMed.SelectedIndex = -1;
                MessageBox.Show("Thuốc này đã thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cbChoosed.Items.Add(cbChooseMed.SelectedItem.ToString());
            cbChooseMed.ResetText();
            cbChooseMed.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            Home.Show();
            this.Hide();
        }
    }
}
