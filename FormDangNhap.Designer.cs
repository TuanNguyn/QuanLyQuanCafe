namespace QuanLyQuanCafe_WF
{
    partial class FormDangNhap
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
            lblTieuDe = new Label();
            lblMaNV = new Label();
            lblMatKhau = new Label();
            txtMaNV = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            SuspendLayout();
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(44, 62, 80);
            lblTieuDe.Location = new Point(0, 40);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(400, 40);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Text = "QUAN LY QUAN CAFE";
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 10F);
            lblMaNV.Location = new Point(60, 120);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Text = "Ma nhan vien:";
            txtMaNV.Font = new Font("Segoe UI", 10F);
            txtMaNV.Location = new Point(165, 117);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(175, 25);
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F);
            lblMatKhau.Location = new Point(60, 165);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Text = "Mat khau:";
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.Location = new Point(165, 162);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(175, 25);
            btnDangNhap.BackColor = Color.FromArgb(52, 152, 219);
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(140, 220);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(120, 40);
            btnDangNhap.Text = "DANG NHAP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AcceptButton = btnDangNhap;
            BackColor = Color.White;
            ClientSize = new Size(400, 300);
            Controls.Add(lblTieuDe);
            Controls.Add(lblMaNV);
            Controls.Add(txtMaNV);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(btnDangNhap);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dang nhap";
            Load += FormDangNhap_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblMaNV;
        private Label lblMatKhau;
        private TextBox txtMaNV;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
    }
}
