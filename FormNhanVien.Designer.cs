namespace QuanLyQuanCafe_WF
{
    partial class FormNhanVien
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
            dgvNhanVien = new DataGridView();
            grpNV = new GroupBox();
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblTenNV = new Label();
            txtTenNV = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblChucVu = new Label();
            cboChucVu = new ComboBox();
            btnThemNV = new Button();
            btnSuaNV = new Button();
            btnXoaNV = new Button();
            btnLamMoi = new Button();
            grpNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.Location = new Point(20, 20);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(480, 360);
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            grpNV.Font = new Font("Segoe UI", 9F);
            grpNV.Location = new Point(520, 20);
            grpNV.Name = "grpNV";
            grpNV.Size = new Size(300, 360);
            grpNV.Text = "Thông tin nhân viên";
            grpNV.Controls.Add(lblMaNV);
            grpNV.Controls.Add(txtMaNV);
            grpNV.Controls.Add(lblTenNV);
            grpNV.Controls.Add(txtTenNV);
            grpNV.Controls.Add(lblMatKhau);
            grpNV.Controls.Add(txtMatKhau);
            grpNV.Controls.Add(lblChucVu);
            grpNV.Controls.Add(cboChucVu);
            grpNV.Controls.Add(btnThemNV);
            grpNV.Controls.Add(btnSuaNV);
            grpNV.Controls.Add(btnXoaNV);
            grpNV.Controls.Add(btnLamMoi);
            lblMaNV.Font = new Font("Segoe UI", 9F);
            lblMaNV.Location = new Point(15, 35);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Text = "Mã NV:";
            lblMaNV.AutoSize = true;
            txtMaNV.Location = new Point(110, 32);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(170, 25);
            lblTenNV.Font = new Font("Segoe UI", 9F);
            lblTenNV.Location = new Point(15, 75);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Text = "Họ tên:";
            lblTenNV.AutoSize = true;
            txtTenNV.Location = new Point(110, 72);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(170, 25);
            lblMatKhau.Font = new Font("Segoe UI", 9F);
            lblMatKhau.Location = new Point(15, 115);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Text = "Mật khẩu:";
            lblMatKhau.AutoSize = true;
            txtMatKhau.Location = new Point(110, 112);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(170, 25);
            txtMatKhau.PasswordChar = '*';
            lblChucVu.Font = new Font("Segoe UI", 9F);
            lblChucVu.Location = new Point(15, 155);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Text = "Chức vụ:";
            lblChucVu.AutoSize = true;
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.AddRange(new object[] { "Quan ly", "Nhan vien" });
            cboChucVu.Location = new Point(110, 152);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(170, 25);
            btnThemNV.BackColor = Color.FromArgb(46, 204, 113);
            btnThemNV.FlatStyle = FlatStyle.Flat;
            btnThemNV.FlatAppearance.BorderSize = 0;
            btnThemNV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemNV.ForeColor = Color.White;
            btnThemNV.Location = new Point(15, 205);
            btnThemNV.Name = "btnThemNV";
            btnThemNV.Size = new Size(125, 35);
            btnThemNV.Text = "THÊM";
            btnThemNV.UseVisualStyleBackColor = false;
            btnThemNV.Click += btnThemNV_Click;
            btnSuaNV.BackColor = Color.FromArgb(52, 152, 219);
            btnSuaNV.FlatStyle = FlatStyle.Flat;
            btnSuaNV.FlatAppearance.BorderSize = 0;
            btnSuaNV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSuaNV.ForeColor = Color.White;
            btnSuaNV.Location = new Point(155, 205);
            btnSuaNV.Name = "btnSuaNV";
            btnSuaNV.Size = new Size(125, 35);
            btnSuaNV.Text = "SỬA";
            btnSuaNV.UseVisualStyleBackColor = false;
            btnSuaNV.Click += btnSuaNV_Click;
            btnXoaNV.BackColor = Color.FromArgb(231, 76, 60);
            btnXoaNV.FlatStyle = FlatStyle.Flat;
            btnXoaNV.FlatAppearance.BorderSize = 0;
            btnXoaNV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaNV.ForeColor = Color.White;
            btnXoaNV.Location = new Point(15, 255);
            btnXoaNV.Name = "btnXoaNV";
            btnXoaNV.Size = new Size(125, 35);
            btnXoaNV.Text = "XÓA";
            btnXoaNV.UseVisualStyleBackColor = false;
            btnXoaNV.Click += btnXoaNV_Click;
            btnLamMoi.BackColor = Color.FromArgb(127, 140, 141);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(155, 255);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(125, 35);
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.White;
            ClientSize = new Size(840, 400);
            Controls.Add(dgvNhanVien);
            Controls.Add(grpNV);
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            Load += FormNhanVien_Load;
            grpNV.ResumeLayout(false);
            grpNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvNhanVien;
        private GroupBox grpNV;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblTenNV;
        private TextBox txtTenNV;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Button btnThemNV;
        private Button btnSuaNV;
        private Button btnXoaNV;
        private Button btnLamMoi;
    }
}
