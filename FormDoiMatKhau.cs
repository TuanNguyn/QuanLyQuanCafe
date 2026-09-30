using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormDoiMatKhau : Form
{
    private NhanVien nvDangNhap;
    public FormDoiMatKhau(NhanVien nv)
    {
        InitializeComponent();
        nvDangNhap = nv;
    }
    private void FormDoiMatKhau_Load(object sender, EventArgs e)
    {
        lblMaNV.Text = "Tài khoản: " + nvDangNhap.MaNV;
    }
    private void btnDoiMatKhau_Click(object sender, EventArgs e)
    {
        string cu = txtMatKhauCu.Text.Trim();
        string moi = txtMatKhauMoi.Text.Trim();
        string nhapLai = txtNhapLai.Text.Trim();

        if (cu == "" || moi == "" || nhapLai == "")
        {
            MessageBox.Show("Vui long nhap day du 3 o.");
            return;
        }
        if (moi.Length < 4)
        {
            MessageBox.Show("Mat khau moi it nhat 4 ky tu.");
            return;
        }
        if (moi != nhapLai)
        {
            MessageBox.Show("Mat khau nhap lai khong khop.");
            return;
        }

        if (DataAccess.DoiMatKhau(nvDangNhap.MaNV, cu, moi))
        {
            nvDangNhap.MatKhau = moi;
            MessageBox.Show("Doi mat khau thanh cong.");
            this.Close();
        }
        else
        {
            MessageBox.Show("Mat khau cu khong dung.");
        }
    }
}
