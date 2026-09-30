using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormNhanVien : Form
{
    private NhanVien nvDangNhap;
    private string maNVDangChon = "";
    public FormNhanVien(NhanVien nv)
    {
        InitializeComponent();
        nvDangNhap = nv;
    }
    private void FormNhanVien_Load(object sender, EventArgs e)
    {
        dgvNhanVien.Columns.Clear();
        dgvNhanVien.Columns.Add("MaNV", "Mã NV");
        dgvNhanVien.Columns.Add("TenNV", "Tên nhân viên");
        dgvNhanVien.Columns.Add("ChucVu", "Chức vụ");
        cboChucVu.SelectedIndex = 1;
        NapLai();
    }
    private void NapLai()
    {
        NhanVien[] ds = DataAccess.LayDanhSachNhanVien();
        dgvNhanVien.Rows.Clear();
        for (int i = 0; i < ds.Length; i++)
        {
            dgvNhanVien.Rows.Add(ds[i].MaNV, ds[i].TenNV, ds[i].ChucVu);
        }
    }
    private void XoaONhap()
    {
        maNVDangChon = "";
        txtMaNV.Clear();
        txtTenNV.Clear();
        txtMatKhau.Clear();
        txtMaNV.Enabled = true;
        cboChucVu.SelectedIndex = 1;
    }
    private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        maNVDangChon = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
        txtMaNV.Text = maNVDangChon;
        txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
        cboChucVu.SelectedItem = dgvNhanVien.Rows[e.RowIndex].Cells["ChucVu"].Value.ToString();
        txtMatKhau.Clear();
        txtMaNV.Enabled = false;
    }
    private void btnThemNV_Click(object sender, EventArgs e)
    {
        string ma = txtMaNV.Text.Trim();
        string ten = txtTenNV.Text.Trim();
        string mk = txtMatKhau.Text.Trim();

        if (ma == "" || ten == "" || mk == "" || cboChucVu.SelectedItem == null)
        {
            MessageBox.Show("Nhap day du ma, ten, mat khau va chon chuc vu.");
            return;
        }
        if (mk.Length < 4)
        {
            MessageBox.Show("Mat khau it nhat 4 ky tu.");
            return;
        }

        if (DataAccess.ThemNhanVien(ma, ten, mk, cboChucVu.SelectedItem.ToString()))
        {
            MessageBox.Show("Da them nhan vien.");
            XoaONhap();
            NapLai();
        }
        else
        {
            MessageBox.Show("Ma nhan vien da ton tai.");
        }
    }
    private void btnSuaNV_Click(object sender, EventArgs e)
    {
        if (maNVDangChon == "")
        {
            MessageBox.Show("Chua chon nhan vien tren bang.");
            return;
        }

        string ten = txtTenNV.Text.Trim();
        string mkMoi = txtMatKhau.Text.Trim();
        string chucVu = cboChucVu.SelectedItem.ToString();

        if (ten == "")
        {
            MessageBox.Show("Ten khong duoc de trong.");
            return;
        }
        if (mkMoi != "" && mkMoi.Length < 4)
        {
            MessageBox.Show("Mat khau moi it nhat 4 ky tu.");
            return;
        }
        if (maNVDangChon == nvDangNhap.MaNV && chucVu != nvDangNhap.ChucVu)
        {
            MessageBox.Show("Khong duoc tu doi chuc vu cua chinh minh.");
            return;
        }

        bool ok = DataAccess.SuaNhanVien(maNVDangChon, ten, chucVu, mkMoi);
        MessageBox.Show(ok ? "Da sua." : "Khong tim thay.");
        XoaONhap();
        NapLai();
    }
    private void btnXoaNV_Click(object sender, EventArgs e)
    {
        if (maNVDangChon == "")
        {
            MessageBox.Show("Chua chon nhan vien tren bang.");
            return;
        }
        if (maNVDangChon == nvDangNhap.MaNV)
        {
            MessageBox.Show("Khong the tu xoa tai khoan dang dang nhap.");
            return;
        }

        DialogResult xacNhan = MessageBox.Show("Xoa nhan vien " + maNVDangChon + "?", "Xac nhan", MessageBoxButtons.YesNo);
        if (xacNhan != DialogResult.Yes) return;

        if (DataAccess.XoaNhanVien(maNVDangChon))
        {
            MessageBox.Show("Da xoa.");
            XoaONhap();
            NapLai();
        }
        else
        {
            MessageBox.Show("Khong xoa duoc (nhan vien nay da lap hoa don).");
        }
    }
    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        XoaONhap();
    }
}
