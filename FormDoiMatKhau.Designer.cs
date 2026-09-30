namespace QuanLyQuanCafe_WF
{
    partial class FormDoiMatKhau
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
            lblMaNV = new Label();
            lblCu = new Label();
            txtMatKhauCu = new TextBox();
            lblMoi = new Label();
            txtMatKhauMoi = new TextBox();
            lblNhapLai = new Label();
            txtNhapLai = new TextBox();
            btnDoiMatKhau = new Button();
            SuspendLayout();
            lblMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaNV.Location = new Point(20, 20);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Text = "Tài khoản:";
            lblMaNV.AutoSize = true;
            lblMaNV.ForeColor = Color.FromArgb(44, 62, 80);
            lblCu.Font = new Font("Segoe UI", 10F);
            lblCu.Location = new Point(20, 60);
            lblCu.Name = "lblCu";
            lblCu.Text = "Mật khẩu cũ:";
            lblCu.AutoSize = true;
            txtMatKhauCu.Location = new Point(150, 57);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(180, 25);
            txtMatKhauCu.PasswordChar = '*';
            lblMoi.Font = new Font("Segoe UI", 10F);
            lblMoi.Location = new Point(20, 100);
            lblMoi.Name = "lblMoi";
            lblMoi.Text = "Mật khẩu mới:";
            lblMoi.AutoSize = true;
            txtMatKhauMoi.Location = new Point(150, 97);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(180, 25);
            txtMatKhauMoi.PasswordChar = '*';
            lblNhapLai.Font = new Font("Segoe UI", 10F);
            lblNhapLai.Location = new Point(20, 140);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Text = "Nhập lại:";
            lblNhapLai.AutoSize = true;
            txtNhapLai.Location = new Point(150, 137);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(180, 25);
            txtNhapLai.PasswordChar = '*';
            btnDoiMatKhau.BackColor = Color.FromArgb(52, 152, 219);
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            btnDoiMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDoiMatKhau.ForeColor = Color.White;
            btnDoiMatKhau.Location = new Point(100, 190);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(160, 38);
            btnDoiMatKhau.Text = "ĐỔI MẬT KHẨU";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.White;
            ClientSize = new Size(360, 250);
            AcceptButton = btnDoiMatKhau;
            Controls.Add(lblMaNV);
            Controls.Add(lblCu);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblMoi);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblNhapLai);
            Controls.Add(txtNhapLai);
            Controls.Add(btnDoiMatKhau);
            Name = "FormDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            Load += FormDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaNV;
        private Label lblCu;
        private TextBox txtMatKhauCu;
        private Label lblMoi;
        private TextBox txtMatKhauMoi;
        private Label lblNhapLai;
        private TextBox txtNhapLai;
        private Button btnDoiMatKhau;
    }
}
