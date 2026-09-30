namespace QuanLyQuanCafe_WF
{
    partial class FormLichSu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTu = new Label();
            dtpTu = new DateTimePicker();
            lblDen = new Label();
            dtpDen = new DateTimePicker();
            btnLoc = new Button();
            btnTatCa = new Button();
            dgvHoaDon = new DataGridView();
            lblChiTiet = new Label();
            dgvChiTiet = new DataGridView();
            lblTongCong = new Label();
            btnThanhToanHD = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // lblTu: nhãn chữ Từ ngày
            lblTu.Font = new Font("Segoe UI", 9F);
            lblTu.Location = new Point(20, 20);
            lblTu.Name = "lblTu";
            lblTu.Text = "Từ ngày:";
            lblTu.AutoSize = true;
            // dtpTu: chọn ngày bắt đầu
            dtpTu.Format = DateTimePickerFormat.Short;
            dtpTu.Location = new Point(85, 17);
            dtpTu.Name = "dtpTu";
            dtpTu.Size = new Size(120, 25);
            // lblDen: nhãn chữ Đến ngày
            lblDen.Font = new Font("Segoe UI", 9F);
            lblDen.Location = new Point(225, 20);
            lblDen.Name = "lblDen";
            lblDen.Text = "Đến ngày:";
            lblDen.AutoSize = true;
            // dtpDen: chọn ngày kết thúc
            dtpDen.Format = DateTimePickerFormat.Short;
            dtpDen.Location = new Point(295, 17);
            dtpDen.Name = "dtpDen";
            dtpDen.Size = new Size(120, 25);
            // btnLoc: nút lọc hóa đơn theo khoảng ngày
            btnLoc.BackColor = Color.FromArgb(52, 152, 219);
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.FlatAppearance.BorderSize = 0;
            btnLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(435, 15);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(90, 28);
            btnLoc.Text = "LỌC";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // btnTatCa: nút bỏ lọc, hiện mọi hóa đơn
            btnTatCa.BackColor = Color.FromArgb(127, 140, 141);
            btnTatCa.FlatStyle = FlatStyle.Flat;
            btnTatCa.FlatAppearance.BorderSize = 0;
            btnTatCa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTatCa.ForeColor = Color.White;
            btnTatCa.Location = new Point(535, 15);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(90, 28);
            btnTatCa.Text = "TẤT CẢ";
            btnTatCa.UseVisualStyleBackColor = false;
            btnTatCa.Click += btnTatCa_Click;
            // dgvHoaDon: bảng danh sách hóa đơn, click 1 dòng để xem chi tiết
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.Location = new Point(20, 55);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(860, 250);
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // lblChiTiet: nhãn chữ tiêu đề bảng chi tiết
            lblChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChiTiet.Location = new Point(20, 315);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Text = "Chi tiết hóa đơn đã chọn:";
            lblChiTiet.AutoSize = true;
            lblChiTiet.Anchor = AnchorStyles.Left;
            // dgvChiTiet: bảng các món của hóa đơn đang chọn
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.Location = new Point(20, 340);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(860, 190);
            // lblTongCong: hiện số hóa đơn và tổng tiền đã thu
            lblTongCong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongCong.Location = new Point(380, 545);
            lblTongCong.Name = "lblTongCong";
            lblTongCong.Text = "";
            lblTongCong.AutoSize = false;
            lblTongCong.Size = new Size(500, 28);
            lblTongCong.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongCong.TextAlign = ContentAlignment.MiddleRight;
            lblTongCong.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            // btnThanhToanHD: nút cho nhân viên tự tay xác nhận đã thu tiền hóa đơn đang chọn (chỉ bật khi hóa đơn đó Chua thanh toan)
            btnThanhToanHD.BackColor = Color.Gray;
            btnThanhToanHD.Enabled = false;
            btnThanhToanHD.FlatStyle = FlatStyle.Flat;
            btnThanhToanHD.FlatAppearance.BorderSize = 0;
            btnThanhToanHD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThanhToanHD.ForeColor = Color.White;
            btnThanhToanHD.Location = new Point(20, 545);
            btnThanhToanHD.Name = "btnThanhToanHD";
            btnThanhToanHD.Size = new Size(220, 28);
            btnThanhToanHD.Text = "XAC NHAN DA THANH TOAN";
            btnThanhToanHD.UseVisualStyleBackColor = false;
            btnThanhToanHD.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnThanhToanHD.Click += btnThanhToanHD_Click;
            // FormLichSu: cấu hình chính của form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 585);
            Controls.Add(lblTu);
            Controls.Add(dtpTu);
            Controls.Add(lblDen);
            Controls.Add(dtpDen);
            Controls.Add(btnLoc);
            Controls.Add(btnTatCa);
            Controls.Add(dgvHoaDon);
            Controls.Add(lblChiTiet);
            Controls.Add(dgvChiTiet);
            Controls.Add(lblTongCong);
            Controls.Add(btnThanhToanHD);
            MinimumSize = new Size(750, 500);
            Name = "FormLichSu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lich su hoa don";
            Load += FormLichSu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTu;
        private DateTimePicker dtpTu;
        private Label lblDen;
        private DateTimePicker dtpDen;
        private Button btnLoc;
        private Button btnTatCa;
        private DataGridView dgvHoaDon;
        private Label lblChiTiet;
        private DataGridView dgvChiTiet;
        private Label lblTongCong;
        private Button btnThanhToanHD;
    }
}