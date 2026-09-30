using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormSanPham : Form
{
    private SanPham[] danhSachGoc;
    private string maSPDangChon = "";
    public FormSanPham()
    {
        InitializeComponent();
    }
    private void FormSanPham_Load(object sender, EventArgs e)
    {
        TaoCot();
        NapDuLieu();
    }
    private void TaoCot()
    {
        dgvSanPham.Columns.Clear();
        dgvSanPham.Columns.Add("MaSP", "Mã SP");
        dgvSanPham.Columns.Add("TenSP", "Tên sản phẩm");
        dgvSanPham.Columns.Add("Loai", "Loại");
        dgvSanPham.Columns.Add("GiaGoc", "Giá gốc");
        dgvSanPham.Columns.Add("SoLuongTon", "Tồn kho");
        dgvSanPham.Columns.Add("ThongTinRieng", "Size / Cay / %Giảm");
    }
    private void NapDuLieu()
    {
        danhSachGoc = DataAccess.LayDanhSachSanPham();
        HienThiLenLuoi(danhSachGoc, danhSachGoc.Length);
    }
    private void HienThiLenLuoi(SanPham[] ds, int soLuong)
    {
        dgvSanPham.Rows.Clear();
        for (int i = 0; i < soLuong; i++)
        {
            dgvSanPham.Rows.Add(ds[i].MaSP, ds[i].TenSP, ds[i].LayLoai(), ds[i].GiaGoc, ds[i].SoLuongTon, ds[i].LayThongTinRieng());
            if (ds[i].SoLuongTon <= 5)
            {
                dgvSanPham.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }
    }
    private SanPham TimSanPham(string maSP)
    {
        for (int i = 0; i < danhSachGoc.Length; i++)
        {
            if (danhSachGoc[i].MaSP == maSP) return danhSachGoc[i];
        }
        return null;
    }
    private void btnTimKiem_Click(object sender, EventArgs e)
    {
        string tuKhoa = txtTimKiem.Text.Trim().ToLower();
        SanPham[] ketQua = new SanPham[danhSachGoc.Length];
        int dem = 0;
        for (int i = 0; i < danhSachGoc.Length; i++)
        {
            if (danhSachGoc[i].TenSP.ToLower().Contains(tuKhoa))
            {
                ketQua[dem] = danhSachGoc[i];
                dem++;
            }
        }
        HienThiLenLuoi(ketQua, dem);
    }
    private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        maSPDangChon = dgvSanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
        lblMaDaChon.Text = maSPDangChon;

        SanPham sp = TimSanPham(maSPDangChon);
        if (sp != null)
        {
            txtTenSua.Text = sp.TenSP;
            txtGiaSua.Text = sp.GiaGoc.ToString();
        }
    }
    private void cboLoaiMoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboLoaiMoi.SelectedIndex == 0) lblThuocTinh.Text = "Size (S/M/L):";
        else if (cboLoaiMoi.SelectedIndex == 1) lblThuocTinh.Text = "Cay (true/false):";
        else lblThuocTinh.Text = "% giảm (0-100):";
    }
    private void btnThemSanPham_Click(object sender, EventArgs e)
    {
        if (cboLoaiMoi.SelectedIndex < 0)
        {
            MessageBox.Show("Chua chon loai san pham.");
            return;
        }

        string ten = txtTenMoi.Text.Trim();
        if (ten == "")
        {
            MessageBox.Show("Chua nhap ten san pham.");
            return;
        }

        int gia;
        if (!int.TryParse(txtGiaMoi.Text.Trim(), out gia) || gia <= 0)
        {
            MessageBox.Show("Gia khong hop le.");
            return;
        }

        int soLuongTon;
        if (!int.TryParse(txtSoLuongTonMoi.Text.Trim(), out soLuongTon) || soLuongTon < 0)
        {
            soLuongTon = 0;
        }

        string thuocTinh = txtThuocTinhMoi.Text.Trim().ToUpper();
        SanPham spMoi;

        if (cboLoaiMoi.SelectedIndex == 0)
        {
            if (thuocTinh != "S" && thuocTinh != "M" && thuocTinh != "L")
            {
                MessageBox.Show("Do uong: size phai la S, M hoac L.");
                return;
            }
            spMoi = new DoUong(DataAccess.TaoMaSanPhamMoi("DU"), ten, gia, thuocTinh[0]);
        }
        else if (cboLoaiMoi.SelectedIndex == 1)
        {
            bool cay;
            if (!bool.TryParse(thuocTinh, out cay))
            {
                MessageBox.Show("Do an: nhap true hoac false.");
                return;
            }
            spMoi = new DoAn(DataAccess.TaoMaSanPhamMoi("DA"), ten, gia, cay);
        }
        else
        {
            int phanTram;
            if (!int.TryParse(thuocTinh, out phanTram) || phanTram < 0 || phanTram > 100)
            {
                MessageBox.Show("Combo: % giam phai tu 0 den 100.");
                return;
            }
            spMoi = new ComboKhuyenMai(DataAccess.TaoMaSanPhamMoi("CB"), ten, gia, phanTram);
        }

        spMoi.SoLuongTon = soLuongTon;
        DataAccess.ThemSanPham(spMoi);

        MessageBox.Show("Da them san pham " + spMoi.MaSP);
        txtTenMoi.Clear();
        txtGiaMoi.Clear();
        txtThuocTinhMoi.Clear();
        txtSoLuongTonMoi.Clear();
        NapDuLieu();
    }
    private void btnSua_Click(object sender, EventArgs e)
    {
        if (maSPDangChon == "")
        {
            MessageBox.Show("Chua chon san pham nao tren bang.");
            return;
        }

        string tenMoi = txtTenSua.Text.Trim();
        int giaMoi;
        if (tenMoi == "" || !int.TryParse(txtGiaSua.Text.Trim(), out giaMoi) || giaMoi <= 0)
        {
            MessageBox.Show("Ten hoac gia khong hop le.");
            return;
        }

        bool ok = DataAccess.SuaTenGia(maSPDangChon, tenMoi, giaMoi);
        MessageBox.Show(ok ? "Da sua." : "Khong tim thay.");
        NapDuLieu();
    }
    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (maSPDangChon == "")
        {
            MessageBox.Show("Chua chon san pham nao tren bang.");
            return;
        }

        DialogResult xacNhan = MessageBox.Show("Xac nhan xoa " + maSPDangChon + "?", "Xac nhan", MessageBoxButtons.YesNo);
        if (xacNhan != DialogResult.Yes) return;

        bool ok = DataAccess.XoaSanPham(maSPDangChon);
        MessageBox.Show(ok ? "Da xoa." : "Khong tim thay.");
        maSPDangChon = "";
        lblMaDaChon.Text = "chưa chọn";
        NapDuLieu();
    }
    private void btnNhapHang_Click(object sender, EventArgs e)
    {
        if (maSPDangChon == "")
        {
            MessageBox.Show("Chua chon san pham nao tren bang.");
            return;
        }

        int soLuongNhap;
        if (!int.TryParse(txtSoLuongNhap.Text.Trim(), out soLuongNhap) || soLuongNhap <= 0)
        {
            MessageBox.Show("So luong nhap khong hop le.");
            return;
        }

        bool ok = DataAccess.NhapHang(maSPDangChon, soLuongNhap);
        MessageBox.Show(ok ? "Da nhap them hang." : "Khong tim thay.");
        txtSoLuongNhap.Clear();
        NapDuLieu();
    }
}
