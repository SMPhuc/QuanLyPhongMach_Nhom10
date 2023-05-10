using System;
using System.Collections;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace Software_engineer
{
    public partial class Bao_cao : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        string query;
        string insert;
        string update;
        string delete;
        string connectString = "Data Source=.;Initial Catalog=QuanLyPhongMach;Integrated Security=True";
        string year = DateTime.Now.Year + "";
        string month = DateTime.Now.Month + "";
        public Bao_cao()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(connectString);
            sqlCon.Open();
            cmd = new SqlCommand();
            cmd.Connection = sqlCon;
        }

        private void Bao_cao_Load(object sender, EventArgs e)
        {
            lblBenhNhan.Text += " " + "5";
            lblThuoc.Text += " " + "5";
            lblTitle.Text += " " + "5";

            query = "SELECT kt.MA_THUOC, t.TEN_THUOC, COUNT(*) AS COUNT_THUOC, t.GIA_THUOC, COUNT(*) * t.GIA_THUOC AS TONG_TIEN\r\nFROM KE_TOA kt \r\nJOIN PHIEU_KHAM_BENH pkb ON kt.MA_SO_PHIEU_KHAM_BENH = pkb.MA_SO_PHIEU_KHAM_BENH\r\nJOIN THUOC t ON kt.MA_THUOC = t.MA_THUOC \r\nWHERE YEAR(pkb.NGAY_KHAM_BENH) = "+year+" AND MONTH(pkb.NGAY_KHAM_BENH) = "+month+"\r\nGROUP BY kt.MA_THUOC, t.TEN_THUOC, t.GIA_THUOC";
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetInt32(2)+"");
                    item.SubItems.Add(reader.GetString(3));
                    item.SubItems.Add(reader.GetInt32(4) + "");
                    lvThuoc.Items.Add(item);
                }
            }
            reader.Close();

            int tongTienThuoc = 0;
            foreach (ListViewItem item in lvThuoc.Items)
            {
                tongTienThuoc += int.Parse(item.SubItems[4].Text);
            }
            txtMoneyThuoc.Text = tongTienThuoc+"";



            query = "SELECT bn.MA_SO_BENH_NHAN, bn.TEN_BENH_NHAN, pkb.MA_SO_PHIEU_KHAM_BENH, pkb.NGAY_KHAM_BENH \r\nFROM BENH_NHAN bn \r\nJOIN PHIEU_KHAM_BENH pkb ON bn.MA_SO_BENH_NHAN = pkb.MA_SO_BENH_NHAN \r\nWHERE MONTH(pkb.NGAY_KHAM_BENH) = "+month+" AND YEAR(pkb.NGAY_KHAM_BENH) = "+year+";";
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
                    lvBenhNhan.Items.Add(item);
                }
            }
            reader.Close();

            txtBenhNhan.Text = lvBenhNhan.Items.Count+"";
            
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Application và Workbook của Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

            try
            {
                // Thêm sheet thứ nhất vào Workbook
                Excel.Worksheet sheet1 = excelWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                sheet1.Name = "baoCaoThuoc";

                for (int i = 1; i <= lvThuoc.Columns.Count; i++)
                {
                    sheet1.Cells[1, i] = lvThuoc.Columns[i - 1].Text;
                }

                // Lưu dữ liệu từ bảng ListView1 vào sheet1
                for (int i = 0; i < lvThuoc.Items.Count; i++)
                {
                    for (int j = 0; j < lvThuoc.Columns.Count; j++)
                    {
                        sheet1.Cells[i + 2, j + 1] = lvThuoc.Items[i].SubItems[j].Text;
                    }
                }

                // Thêm sheet thứ hai vào Workbook
                Excel.Worksheet sheet2 = excelWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                sheet2.Name = "baoCaoBenhNhan";

                // Đặt tiêu đề cho các cột
                for (int i = 1; i <= lvBenhNhan.Columns.Count; i++)
                {
                    sheet2.Cells[1, i] = lvBenhNhan.Columns[i - 1].Text;
                }

                // Lưu dữ liệu từ bảng ListView2 vào sheet2
                for (int i = 0; i < lvBenhNhan.Items.Count; i++)
                {
                    for (int j = 0; j < lvBenhNhan.Columns.Count; j++)
                    {
                        sheet2.Cells[i + 2, j + 1] = lvBenhNhan.Items[i].SubItems[j].Text;
                    }
                }

                // Lưu Workbook vào file Excel
                string name = "baoCaoThang" + month;
                excelWorkbook.SaveAs(@"C:\"+name+".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing, Type.Missing);

                MessageBox.Show("Lưu file Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng Workbook và Application của Excel
                excelWorkbook.Close();
                excelApp.Quit();

                // Giải phóng tài nguyên
                Marshal.ReleaseComObject(excelWorkbook);
                Marshal.ReleaseComObject(excelApp);
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
