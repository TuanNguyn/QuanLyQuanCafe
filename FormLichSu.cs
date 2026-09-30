using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;

public partial class FormLichSu : Form
{
    private HoaDon[] tatCaHoaDon;       
    private HoaDon[] dangHienThi;     
    private int soDangHienThi = 0;      
    private HoaDon hoaDonDangChon = null;   

    public FormLichSu()
    {
        InitializeComponent();
    }

    private void FormLichSu_Load(object sender, EventArgs e)
    {
        dgvHoaDon.Columns.Clear();
        dgvHoaDon.Columns.Add("MaHD", "Mã HĐ");
        dgvHoaDon.Columns.Add("Ngay", "Ngày giờ");
        dgvHoaDon.Columns.Add("Ban", "Bàn");
        dgvHoaDon.Columns.Add("MaNV", "Nhân viên");
        dgvHoaDon.Columns.Add("TrangThai", "Trạng thái");
        dgvHoaDon.Columns.Add("TongTien", "Tổng tiền");

        dgvChiTiet.Columns.Clear();
        dgvChiTiet.Columns.Add("MaSP", "Mã SP");
        dgvChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
        dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
        dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
        dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");

        tatCaHoaDon = DataAccess.LayTatCaHoaDon();
        HienThiHoaDon(tatCaHoaDon, tatCaHoaDon.Length);
    }

    private void HienThiHoaDon(HoaDon[] ds, int soLuong)
    {
        dangHienThi = ds;
        soDangHienThi = soLuong;
        dgvHoaDon.Rows.Clear();
        dgvChiTiet.Rows.Clear();

        int tongDaThu = 0;
        for (int i = 0; i < soLuong; i++)
        {
            int tien = ds[i].TinhTongTien();
            dgvHoaDon.Rows.Add(ds[i].MaHD, ds[i].NgayGioThang.ToString("dd/MM/yyyy HH:mm"), ds[i].SoBan, ds[i].MaNV, ds[i].TrangThai, tien.ToString("N0"));
            if (ds[i].TrangThai == "Da thanh toan")
            {
                tongDaThu += tien;
            }
            else
            {
                dgvHoaDon.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
        }
        lblTongCong.Text = soLuong + " hoa don | Da thu: " + tongDaThu.ToString("N0") + " d";

        hoaDonDangChon = null;
        CapNhatNutThanhToan();
    }

    private void CapNhatNutThanhToan()
    {
        bool duocBam = hoaDonDangChon != null && hoaDonDangChon.TrangThai == "Chua thanh toan";
        btnThanhToanHD.Enabled = duocBam;
        btnThanhToanHD.BackColor = duocBam ? Color.FromArgb(231, 76, 60) : Color.Gray;
    }

    private void btnLoc_Click(object sender, EventArgs e)
    {
        DateTime tu = dtpTu.Value.Date;
        DateTime den = dtpDen.Value.Date.AddDays(1);

        HoaDon[] ketQua = new HoaDon[tatCaHoaDon.Length];
        int dem = 0;
        for (int i = 0; i < tatCaHoaDon.Length; i++)
        {
            if (tatCaHoaDon[i].NgayGioThang >= tu && tatCaHoaDon[i].NgayGioThang < den)
            {
                ketQua[dem] = tatCaHoaDon[i];
                dem++;
            }
        }
        HienThiHoaDon(ketQua, dem);
    }

    private void btnTatCa_Click(object sender, EventArgs e)
    {
        HienThiHoaDon(tatCaHoaDon, tatCaHoaDon.Length);
    }

    private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= soDangHienThi) return;

        HoaDon hd = dangHienThi[e.RowIndex];
        hoaDonDangChon = hd;
        CapNhatNutThanhToan();

        dgvChiTiet.Rows.Clear();
        for (int i = 0; i < hd.SoLuongChiTiet; i++)
        {
            ChiTietHoaDon ct = hd.DanhSachChiTiet[i];
            dgvChiTiet.Rows.Add(ct.MaSP, ct.TenSP, ct.SoLuong, ct.DonGia, ct.ThanhTien);
        }
    }

    private void btnThanhToanHD_Click(object sender, EventArgs e)
    {
        if (hoaDonDangChon == null || hoaDonDangChon.TrangThai != "Chua thanh toan")
        {
            MessageBox.Show("Chon 1 hoa don chua thanh toan tren bang truoc.");
            return;
        }

        string maHD = hoaDonDangChon.MaHD;
        int soBan = hoaDonDangChon.SoBan;
        int tongTien = hoaDonDangChon.TinhTongTien();

        DialogResult xacNhan = MessageBox.Show(
            "Xac nhan da thu " + tongTien.ToString("N0") + " d cho hoa don " + maHD + " (ban " + soBan + ")?\n" +
            "Hoa don se chuyen sang 'Da thanh toan' va ban " + soBan + " se tro lai 'Trong'.",
            "Xac nhan thanh toan", MessageBoxButtons.YesNo);
        if (xacNhan != DialogResult.Yes) return;

        DataAccess.ThanhToanHoaDon(maHD, soBan);
        MessageBox.Show("Da cap nhat hoa don " + maHD + " sang Da thanh toan.");

        tatCaHoaDon = DataAccess.LayTatCaHoaDon();
        HienThiHoaDon(tatCaHoaDon, tatCaHoaDon.Length);
        dgvChiTiet.Rows.Clear();
    }
}