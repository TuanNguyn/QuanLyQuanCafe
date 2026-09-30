using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormHoaDon : Form
{
    private SanPham[] danhSachSanPham;
    private string maHDHienTai = "";
    private int soBanHienTai = 0;
    private NhanVien nvDangNhap;
    public FormHoaDon(NhanVien nv)
    {
        InitializeComponent();
        nvDangNhap = nv;
    }
    private void FormHoaDon_Load(object sender, EventArgs e)
    {
        dgvChiTiet.Columns.Clear();
        dgvChiTiet.Columns.Add("MaSP", "Mã SP");
        dgvChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
        dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
        dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
        dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");

        NapSanPham();
        NapBan();
    }
    private void NapSanPham()
    {
        danhSachSanPham = DataAccess.LayDanhSachSanPham();
        cboSanPham.Items.Clear();
        for (int i = 0; i < danhSachSanPham.Length; i++)
        {
            cboSanPham.Items.Add(danhSachSanPham[i].HienThiThongTin());
        }
    }
    private void NapBan()
    {
        Ban[] trong = DataAccess.LayBanTheoTrangThai("Trong");
        cboBan.Items.Clear();
        for (int i = 0; i < trong.Length; i++)
        {
            cboBan.Items.Add(trong[i]);
        }
        if (trong.Length > 0) cboBan.SelectedIndex = 0;

        Ban[] dangDung = DataAccess.LayBanTheoTrangThai("Dang dung");
        cboBanDangDung.Items.Clear();
        for (int i = 0; i < dangDung.Length; i++)
        {
            cboBanDangDung.Items.Add(dangDung[i]);
        }
        if (dangDung.Length > 0) cboBanDangDung.SelectedIndex = 0;
    }
    private void btnTaoHoaDon_Click(object sender, EventArgs e)
    {
        if (cboBan.SelectedItem == null)
        {
            MessageBox.Show("Khong con ban trong.");
            return;
        }
        if (maHDHienTai != "")
        {
            MessageBox.Show("Dang co hoa don " + maHDHienTai + " chua thanh toan. Hay thanh toan truoc.");
            return;
        }

        Ban ban = (Ban)cboBan.SelectedItem;
        maHDHienTai = DataAccess.TaoHoaDonMoi(ban.SoBan, nvDangNhap.MaNV);
        DataAccess.DoiTrangThaiBan(ban.SoBan, "Dang dung");
        soBanHienTai = ban.SoBan;

        lblMaHD.Text = "Hoa don " + maHDHienTai + " - Ban " + soBanHienTai;
        CapNhatBangChiTiet();
        NapBan();
    }
    private void btnMoHoaDon_Click(object sender, EventArgs e)
    {
        if (cboBanDangDung.SelectedItem == null)
        {
            MessageBox.Show("Khong co ban nao dang dung.");
            return;
        }
        if (maHDHienTai != "")
        {
            MessageBox.Show("Hay thanh toan hoa don " + maHDHienTai + " truoc.");
            return;
        }

        Ban ban = (Ban)cboBanDangDung.SelectedItem;
        string ma = DataAccess.LayMaHDChuaThanhToan(ban.SoBan);
        if (ma == "")
        {
            MessageBox.Show("Khong tim thay hoa don chua thanh toan cua ban nay.");
            return;
        }

        maHDHienTai = ma;
        soBanHienTai = ban.SoBan;
        lblMaHD.Text = "Hoa don " + maHDHienTai + " - Ban " + soBanHienTai;
        CapNhatBangChiTiet();
    }
    private void btnThemMon_Click(object sender, EventArgs e)
    {
        if (maHDHienTai == "")
        {
            MessageBox.Show("Ban phai tao hoac mo hoa don truoc.");
            return;
        }
        if (cboSanPham.SelectedIndex < 0)
        {
            MessageBox.Show("Chua chon san pham.");
            return;
        }

        int soLuong;
        if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong <= 0)
        {
            MessageBox.Show("So luong khong hop le.");
            return;
        }

        SanPham sp = danhSachSanPham[cboSanPham.SelectedIndex];
        if (!DataAccess.ThemMonVaoHoaDon(maHDHienTai, sp, soLuong))
        {
            MessageBox.Show("Khong du hang ton kho.");
            return;
        }

        int viTri = cboSanPham.SelectedIndex;
        NapSanPham();
        cboSanPham.SelectedIndex = viTri;
        txtSoLuong.Clear();
        CapNhatBangChiTiet();
    }
    private void CapNhatBangChiTiet()
    {
        dgvChiTiet.Rows.Clear();
        int tong = 0;
        if (maHDHienTai != "")
        {
            ChiTietHoaDon[] ct = DataAccess.LayChiTietTheoMaHD(maHDHienTai);
            for (int i = 0; i < ct.Length; i++)
            {
                dgvChiTiet.Rows.Add(ct[i].MaSP, ct[i].TenSP, ct[i].SoLuong, ct[i].DonGia, ct[i].ThanhTien);
                tong += ct[i].ThanhTien;
            }
        }
        lblTongTien.Text = "Tong tien: " + tong.ToString("N0") + " d";
    }
    private void btnThanhToan_Click(object sender, EventArgs e)
    {
        if (maHDHienTai == "")
        {
            MessageBox.Show("Chua co hoa don de thanh toan.");
            return;
        }
        if (dgvChiTiet.Rows.Count == 0)
        {
            MessageBox.Show("Hoa don chua co mon nao.");
            return;
        }

        DialogResult xacNhan = MessageBox.Show(lblTongTien.Text + "\nXac nhan thanh toan hoa don " + maHDHienTai + "?", "Thanh toan", MessageBoxButtons.YesNo);
        if (xacNhan != DialogResult.Yes) return;

        DataAccess.ThanhToanHoaDon(maHDHienTai, soBanHienTai);
        MessageBox.Show("Da thanh toan hoa don " + maHDHienTai);

        maHDHienTai = "";
        soBanHienTai = 0;
        lblMaHD.Text = "Chua co hoa don";
        CapNhatBangChiTiet();
        NapBan();
    }
}
