using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormDangNhap : Form
{
    public FormDangNhap()
    {
        InitializeComponent();
    }
    private void FormDangNhap_Load(object sender, EventArgs e)
    {
        if (!DataAccess.KiemTraKetNoi())
        {
            MessageBox.Show("Khong ket noi duoc MySQL. Hay bat MySQL va kiem tra connectionString trong DataAccess.cs");
        }
    }
    private void btnDangNhap_Click(object sender, EventArgs e)
    {
        string maNV = txtMaNV.Text.Trim();
        string matKhau = txtMatKhau.Text.Trim();

        if (maNV == "" || matKhau == "")
        {
            MessageBox.Show("Vui long nhap day du ma NV va mat khau.");
            return;
        }

        NhanVien nv = DataAccess.DangNhap(maNV, matKhau);
        if (nv == null)
        {
            MessageBox.Show("Sai ma nhan vien hoac mat khau.");
            return;
        }

        this.Hide();
        FormChinh fc = new FormChinh(nv);
        fc.ShowDialog();
        txtMatKhau.Clear();
        this.Show();
    }
}
