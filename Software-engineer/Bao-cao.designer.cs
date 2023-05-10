
namespace Software_engineer
{
    partial class Bao_cao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.lblThuoc = new System.Windows.Forms.Label();
            this.txtMoneyThuoc = new System.Windows.Forms.TextBox();
            this.lvThuoc = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThuoc = new System.Windows.Forms.Button();
            this.lvBenhNhan = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBenhNhan = new System.Windows.Forms.TextBox();
            this.lblBenhNhan = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(704, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 38);
            this.lblTitle.TabIndex = 114;
            this.lblTitle.Text = "BÁO CÁO THÁNG";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button8.Location = new System.Drawing.Point(904, 668);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(148, 47);
            this.button8.TabIndex = 126;
            this.button8.Text = "In báo cáo";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // lblThuoc
            // 
            this.lblThuoc.AutoSize = true;
            this.lblThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuoc.Location = new System.Drawing.Point(40, 103);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(252, 25);
            this.lblThuoc.TabIndex = 127;
            this.lblThuoc.Text = "Doanh thu bán thuốc tháng ";
            // 
            // txtMoneyThuoc
            // 
            this.txtMoneyThuoc.Enabled = false;
            this.txtMoneyThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneyThuoc.Location = new System.Drawing.Point(334, 103);
            this.txtMoneyThuoc.Name = "txtMoneyThuoc";
            this.txtMoneyThuoc.Size = new System.Drawing.Size(186, 30);
            this.txtMoneyThuoc.TabIndex = 128;
            this.txtMoneyThuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lvThuoc
            // 
            this.lvThuoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvThuoc.GridLines = true;
            this.lvThuoc.HideSelection = false;
            this.lvThuoc.Location = new System.Drawing.Point(45, 232);
            this.lvThuoc.Name = "lvThuoc";
            this.lvThuoc.Size = new System.Drawing.Size(763, 320);
            this.lvThuoc.TabIndex = 129;
            this.lvThuoc.UseCompatibleStateImageBehavior = false;
            this.lvThuoc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã thuốc";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên thuốc";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 111;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 108;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tổng tiền";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 137;
            // 
            // btnThuoc
            // 
            this.btnThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuoc.Location = new System.Drawing.Point(752, 567);
            this.btnThuoc.Name = "btnThuoc";
            this.btnThuoc.Size = new System.Drawing.Size(166, 78);
            this.btnThuoc.TabIndex = 130;
            this.btnThuoc.Text = "Xuất file EXCEL";
            this.btnThuoc.UseVisualStyleBackColor = true;
            this.btnThuoc.Click += new System.EventHandler(this.btnThuoc_Click);
            // 
            // lvBenhNhan
            // 
            this.lvBenhNhan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvBenhNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBenhNhan.GridLines = true;
            this.lvBenhNhan.HideSelection = false;
            this.lvBenhNhan.Location = new System.Drawing.Point(877, 232);
            this.lvBenhNhan.Name = "lvBenhNhan";
            this.lvBenhNhan.Size = new System.Drawing.Size(651, 320);
            this.lvBenhNhan.TabIndex = 133;
            this.lvBenhNhan.UseCompatibleStateImageBehavior = false;
            this.lvBenhNhan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mã số BN";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tên BN";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mã số PKB";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 111;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ngày khám";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 129;
            // 
            // txtBenhNhan
            // 
            this.txtBenhNhan.Enabled = false;
            this.txtBenhNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBenhNhan.Location = new System.Drawing.Point(1108, 103);
            this.txtBenhNhan.Name = "txtBenhNhan";
            this.txtBenhNhan.Size = new System.Drawing.Size(186, 30);
            this.txtBenhNhan.TabIndex = 132;
            this.txtBenhNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBenhNhan
            // 
            this.lblBenhNhan.AutoSize = true;
            this.lblBenhNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenhNhan.Location = new System.Drawing.Point(872, 103);
            this.lblBenhNhan.Name = "lblBenhNhan";
            this.lblBenhNhan.Size = new System.Drawing.Size(189, 25);
            this.lblBenhNhan.TabIndex = 131;
            this.lblBenhNhan.Text = "Số bệnh nhân tháng";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(45, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 41);
            this.button1.TabIndex = 134;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bao_cao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1681, 753);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvBenhNhan);
            this.Controls.Add(this.txtBenhNhan);
            this.Controls.Add(this.lblBenhNhan);
            this.Controls.Add(this.btnThuoc);
            this.Controls.Add(this.lvThuoc);
            this.Controls.Add(this.txtMoneyThuoc);
            this.Controls.Add(this.lblThuoc);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Bao_cao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bao_cao";
            this.Load += new System.EventHandler(this.Bao_cao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lblThuoc;
        private System.Windows.Forms.TextBox txtMoneyThuoc;
        private System.Windows.Forms.ListView lvThuoc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnThuoc;
        private System.Windows.Forms.ListView lvBenhNhan;
        private System.Windows.Forms.TextBox txtBenhNhan;
        private System.Windows.Forms.Label lblBenhNhan;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button button1;
    }
}