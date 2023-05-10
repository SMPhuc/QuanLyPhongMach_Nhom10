
namespace Software_engineer
{
    partial class Kham_benh
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
            this.components = new System.ComponentModel.Container();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMaSoBN = new System.Windows.Forms.ComboBox();
            this.cbMaSoBSi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrieuChung = new System.Windows.Forms.TextBox();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorTrieuChung = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddMed = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChoosed = new System.Windows.Forms.ComboBox();
            this.cbChooseMed = new System.Windows.Forms.ComboBox();
            this.btnGetId = new System.Windows.Forms.Button();
            this.errorMaBN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorMaBSi = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorResult = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorMedicine = new System.Windows.Forms.ErrorProvider(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorID = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteMed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTrieuChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMaBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMaBSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorID)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(37, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 25);
            this.label8.TabIndex = 86;
            this.label8.Text = "Mã số bệnh nhân";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 38);
            this.label1.TabIndex = 73;
            this.label1.Text = "PHIẾU KHÁM BỆNH";
            // 
            // cbMaSoBN
            // 
            this.cbMaSoBN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMaSoBN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaSoBN.BackColor = System.Drawing.Color.White;
            this.cbMaSoBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaSoBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaSoBN.FormattingEnabled = true;
            this.cbMaSoBN.Location = new System.Drawing.Point(237, 91);
            this.cbMaSoBN.Name = "cbMaSoBN";
            this.cbMaSoBN.Size = new System.Drawing.Size(372, 33);
            this.cbMaSoBN.TabIndex = 113;
            this.cbMaSoBN.SelectedIndexChanged += new System.EventHandler(this.cbMaSoBN_SelectedIndexChanged);
            this.cbMaSoBN.TextChanged += new System.EventHandler(this.cbMaSoBN_TextChanged);
            this.cbMaSoBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMaSoBN_KeyPress);
            this.cbMaSoBN.Leave += new System.EventHandler(this.cbMaSoBN_Leave);
            // 
            // cbMaSoBSi
            // 
            this.cbMaSoBSi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMaSoBSi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaSoBSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaSoBSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaSoBSi.FormattingEnabled = true;
            this.cbMaSoBSi.Location = new System.Drawing.Point(237, 153);
            this.cbMaSoBSi.Name = "cbMaSoBSi";
            this.cbMaSoBSi.Size = new System.Drawing.Size(372, 33);
            this.cbMaSoBSi.TabIndex = 114;
            this.cbMaSoBSi.SelectedIndexChanged += new System.EventHandler(this.cbMaSoBSi_SelectedIndexChanged);
            this.cbMaSoBSi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMaSoBSi_KeyPress);
            this.cbMaSoBSi.Leave += new System.EventHandler(this.cbMaSoBSi_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(649, 216);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 115;
            this.label2.Text = "Mã phiếu";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.Gainsboro;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTrieuChung.SetIconAlignment(this.lblID, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.lblID.Location = new System.Drawing.Point(812, 214);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(259, 35);
            this.lblID.TabIndex = 116;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(37, 281);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 120;
            this.label5.Text = "Triệu chứng";
            // 
            // txtTrieuChung
            // 
            this.txtTrieuChung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrieuChung.Location = new System.Drawing.Point(237, 278);
            this.txtTrieuChung.Name = "txtTrieuChung";
            this.txtTrieuChung.Size = new System.Drawing.Size(372, 30);
            this.txtTrieuChung.TabIndex = 119;
            this.txtTrieuChung.TextChanged += new System.EventHandler(this.txtTrieuChung_TextChanged);
            this.txtTrieuChung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrieuChung_KeyPress);
            this.txtTrieuChung.Leave += new System.EventHandler(this.txtTrieuChung_Leave);
            // 
            // cbResult
            // 
            this.cbResult.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbResult.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Location = new System.Drawing.Point(237, 340);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(372, 33);
            this.cbResult.TabIndex = 122;
            this.cbResult.SelectedIndexChanged += new System.EventHandler(this.cbResult_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(37, 340);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 121;
            this.label7.Text = "Kết quả ";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(237, 216);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(372, 28);
            this.dtpDate.TabIndex = 123;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(37, 216);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 25);
            this.label9.TabIndex = 124;
            this.label9.Text = "Ngày khám";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(37, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 126;
            this.label6.Text = "Mã số bác sĩ";
            // 
            // errorDate
            // 
            this.errorDate.ContainerControl = this;
            // 
            // errorTrieuChung
            // 
            this.errorTrieuChung.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(812, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 40);
            this.btnDelete.TabIndex = 127;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(1113, 281);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 40);
            this.btnAdd.TabIndex = 128;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(654, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 40);
            this.btnClear.TabIndex = 129;
            this.btnClear.Text = "Nhập mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(967, 281);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 40);
            this.btnEdit.TabIndex = 130;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(649, 95);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 25);
            this.label10.TabIndex = 142;
            this.label10.Text = "Thuốc";
            // 
            // btnAddMed
            // 
            this.btnAddMed.BackColor = System.Drawing.Color.White;
            this.btnAddMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMed.Location = new System.Drawing.Point(1098, 99);
            this.btnAddMed.Name = "btnAddMed";
            this.btnAddMed.Size = new System.Drawing.Size(119, 40);
            this.btnAddMed.TabIndex = 139;
            this.btnAddMed.Text = "Thêm thuốc";
            this.btnAddMed.UseVisualStyleBackColor = false;
            this.btnAddMed.Click += new System.EventHandler(this.btnAddMed_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(649, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 140;
            this.label4.Text = "Thuốc đã chọn";
            // 
            // cbChoosed
            // 
            this.cbChoosed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChoosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChoosed.FormattingEnabled = true;
            this.cbChoosed.Location = new System.Drawing.Point(812, 153);
            this.cbChoosed.Name = "cbChoosed";
            this.cbChoosed.Size = new System.Drawing.Size(259, 33);
            this.cbChoosed.TabIndex = 137;
            this.cbChoosed.SelectedIndexChanged += new System.EventHandler(this.cbChoosed_SelectedIndexChanged);
            // 
            // cbChooseMed
            // 
            this.cbChooseMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChooseMed.FormattingEnabled = true;
            this.cbChooseMed.Location = new System.Drawing.Point(812, 98);
            this.cbChooseMed.Name = "cbChooseMed";
            this.cbChooseMed.Size = new System.Drawing.Size(259, 33);
            this.cbChooseMed.TabIndex = 136;
            // 
            // btnGetId
            // 
            this.btnGetId.BackColor = System.Drawing.Color.White;
            this.btnGetId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetId.Location = new System.Drawing.Point(1113, 217);
            this.btnGetId.Name = "btnGetId";
            this.btnGetId.Size = new System.Drawing.Size(104, 40);
            this.btnGetId.TabIndex = 143;
            this.btnGetId.Text = "Lấy mã";
            this.btnGetId.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGetId.UseVisualStyleBackColor = false;
            this.btnGetId.Click += new System.EventHandler(this.btnGetId_Click);
            // 
            // errorMaBN
            // 
            this.errorMaBN.ContainerControl = this;
            // 
            // errorMaBSi
            // 
            this.errorMaBSi.ContainerControl = this;
            // 
            // errorResult
            // 
            this.errorResult.ContainerControl = this;
            // 
            // errorMedicine
            // 
            this.errorMedicine.ContainerControl = this;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(42, 417);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1175, 236);
            this.listView1.TabIndex = 144;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã số PKB";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã số BN";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 103;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã số BS";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Triệu chứng";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 230;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kết quả";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 143;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ngày khám";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 145;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Thuốc";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 167;
            // 
            // errorID
            // 
            this.errorID.ContainerControl = this;
            // 
            // btnDeleteMed
            // 
            this.btnDeleteMed.BackColor = System.Drawing.Color.White;
            this.btnDeleteMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMed.Location = new System.Drawing.Point(1098, 154);
            this.btnDeleteMed.Name = "btnDeleteMed";
            this.btnDeleteMed.Size = new System.Drawing.Size(119, 40);
            this.btnDeleteMed.TabIndex = 145;
            this.btnDeleteMed.Text = "Xóa thuốc";
            this.btnDeleteMed.UseVisualStyleBackColor = false;
            this.btnDeleteMed.Click += new System.EventHandler(this.btnDeleteMed_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(42, 674);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 36);
            this.button1.TabIndex = 146;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Kham_benh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1263, 722);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeleteMed);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnGetId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddMed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbChoosed);
            this.Controls.Add(this.cbChooseMed);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cbResult);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTrieuChung);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMaSoBSi);
            this.Controls.Add(this.cbMaSoBN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Kham_benh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kham_benh";
            this.Load += new System.EventHandler(this.Kham_benh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTrieuChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMaBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMaBSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMaSoBN;
        private System.Windows.Forms.ComboBox cbMaSoBSi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrieuChung;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorDate;
        private System.Windows.Forms.ErrorProvider errorTrieuChung;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddMed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbChoosed;
        private System.Windows.Forms.ComboBox cbChooseMed;
        private System.Windows.Forms.Button btnGetId;
        private System.Windows.Forms.ErrorProvider errorMaBN;
        private System.Windows.Forms.ErrorProvider errorMaBSi;
        private System.Windows.Forms.ErrorProvider errorResult;
        private System.Windows.Forms.ErrorProvider errorMedicine;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ErrorProvider errorID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnDeleteMed;
        private System.Windows.Forms.Button button1;
    }
}