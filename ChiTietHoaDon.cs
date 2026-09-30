namespace QuanLyQuanCafe;
public class ChiTietHoaDon
{
    public string MaHD;
    public string MaSP;
    public string TenSP;
    public int SoLuong;
    public int DonGia;
    public int ThanhTien;
    public ChiTietHoaDon(string maHD, SanPham sp, int soLuong)
    {
        MaHD = maHD;
        MaSP = sp.MaSP;
        TenSP = sp.TenSP;
        SoLuong = soLuong;
        ThanhTien = sp.TinhThanhTien(soLuong);
        if (sp is ComboKhuyenMai)
        {
            DonGia = sp.GiaGoc;
        }
        else
        {
            DonGia = ThanhTien / soLuong;
        }
    }
    public ChiTietHoaDon(string maHD, string maSP, string tenSP, int soLuong, int donGia, int thanhTien)
    {
        MaHD = maHD;
        MaSP = maSP;
        TenSP = tenSP;
        SoLuong = soLuong;
        DonGia = donGia;
        ThanhTien = thanhTien;
    }
}
