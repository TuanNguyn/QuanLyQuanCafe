namespace QuanLyQuanCafe_WF
{
    partial class FormBan
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
            dgvBan = new DataGridView();
            grpBan = new GroupBox();
            lblSoBanMoi = new Label();
            txtSoBanMoi = new TextBox();
            btnThemBan = new Button();
            btnXoaBan = new Button();
            btnLamMoi = new Button();
            lblThongKeBan = new Label();
            grpBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBan).BeginInit();
            SuspendLayout();
            dgvBan.AllowUserToAddRows = false;
            dgvBan.AllowUserToDeleteRows = false;
            dgvBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBan.Location = new Point(20, 20);
            dgvBan.MultiSelect = false;
            dgvBan.Name = "dgvBan";
            dgvBan.ReadOnly = true;
            dgvBan.RowHeadersVisible = false;
            dgvBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBan.Size = new Size(300, 330);
            dgvBan.CellClick += dgvBan_CellClick;
            grpBan.Font = new Font("Segoe UI", 9F);
            grpBan.Location = new Point(340, 20);
            grpBan.Name = "grpBan";
            grpBan.Size = new Size(220, 200);
            grpBan.Text = "Chức năng bàn";
            grpBan.Controls.Add(lblSoBanMoi);
            grpBan.Controls.Add(txtSoBanMoi);
            grpBan.Controls.Add(btnThemBan);
            grpBan.Controls.Add(btnXoaBan);
            lblSoBanMoi.Font = new Font("Segoe UI", 9F);
            lblSoBanMoi.Location = new Point(15, 35);
            lblSoBanMoi.Name = "lblSoBanMoi";
            lblSoBanMoi.Text = "Số bàn mới:";
            lblSoBanMoi.AutoSize = true;
            txtSoBanMoi.Location = new Point(15, 58);
            txtSoBanMoi.Name = "txtSoBanMoi";
            txtSoBanMoi.Size = new Size(180, 25);
            btnThemBan.BackColor = Color.FromArgb(46, 204, 113);
            btnThemBan.FlatStyle = FlatStyle.Flat;
            btnThemBan.FlatAppearance.BorderSize = 0;
            btnThemBan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemBan.ForeColor = Color.White;
            btnThemBan.Location = new Point(15, 95);
            btnThemBan.Name = "btnThemBan";
            btnThemBan.Size = new Size(180, 33);
            btnThemBan.Text = "THÊM BÀN";
            btnThemBan.UseVisualStyleBackColor = false;
            btnThemBan.Click += btnThemBan_Click;
            btnXoaBan.BackColor = Color.FromArgb(231, 76, 60);
            btnXoaBan.FlatStyle = FlatStyle.Flat;
            btnXoaBan.FlatAppearance.BorderSize = 0;
            btnXoaBan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaBan.ForeColor = Color.White;
            btnXoaBan.Location = new Point(15, 140);
            btnXoaBan.Name = "btnXoaBan";
            btnXoaBan.Size = new Size(180, 33);
            btnXoaBan.Text = "XÓA BÀN ĐANG CHỌN";
            btnXoaBan.UseVisualStyleBackColor = false;
            btnXoaBan.Click += btnXoaBan_Click;
            btnLamMoi.BackColor = Color.FromArgb(52, 152, 219);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(340, 235);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(220, 33);
            btnLamMoi.Text = "LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            lblThongKeBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThongKeBan.Location = new Point(20, 360);
            lblThongKeBan.Name = "lblThongKeBan";
            lblThongKeBan.Text = "";
            lblThongKeBan.AutoSize = true;
            lblThongKeBan.ForeColor = Color.FromArgb(44, 62, 80);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.White;
            ClientSize = new Size(580, 395);
            Controls.Add(dgvBan);
            Controls.Add(grpBan);
            Controls.Add(btnLamMoi);
            Controls.Add(lblThongKeBan);
            Name = "FormBan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý bàn";
            Load += FormBan_Load;
            grpBan.ResumeLayout(false);
            grpBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBan;
        private GroupBox grpBan;
        private Label lblSoBanMoi;
        private TextBox txtSoBanMoi;
        private Button btnThemBan;
        private Button btnXoaBan;
        private Button btnLamMoi;
        private Label lblThongKeBan;
    }
}
