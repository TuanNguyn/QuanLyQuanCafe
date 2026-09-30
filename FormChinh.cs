using QuanLyQuanCafe;

namespace QuanLyQuanCafe_WF
{
    public partial class FormChinh : Form
    {
        private NhanVien nvDangNhap;
        public FormChinh(NhanVien nv)
        {
            InitializeComponent();
            nvDangNhap = nv;
        }
        private void FormChinh_Load(object sender, EventArgs e)
        {
            lblNhanVien.Text = "Xin chao " + nvDangNhap.TenNV + " (" + nvDangNhap.ChucVu + ")";

            if (!nvDangNhap.LaQuanLy())
            {
                KhoaNut(btnSanPham);
                KhoaNut(btnThongKe);
                KhoaNut(btnNhanVien);
            }
        }
        private void KhoaNut(Button nut)
        {
            nut.Enabled = false;
            nut.BackColor = Color.Gray;
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FormSanPham f = new FormSanPham();
            f.ShowDialog();
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FormHoaDon f = new FormHoaDon(nvDangNhap);
            f.ShowDialog();
        }
        private void btnBan_Click(object sender, EventArgs e)
        {
            FormBan f = new FormBan(nvDangNhap.LaQuanLy());
            f.ShowDialog();
        }
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            FormLichSu f = new FormLichSu();
            f.ShowDialog();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe f = new FormThongKe();
            f.ShowDialog();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien f = new FormNhanVien(nvDangNhap);
            f.ShowDialog();
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau f = new FormDoiMatKhau(nvDangNhap);
            f.ShowDialog();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
