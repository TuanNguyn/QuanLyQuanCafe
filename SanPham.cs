namespace QuanLyQuanCafe;
public abstract class SanPham
{
    public string MaSP;
    public string TenSP;
    public int GiaGoc;
    public int SoLuongTon;
    public SanPham(string maSP, string tenSP, int giaGoc)
    {
        MaSP = maSP;
        TenSP = tenSP;
        GiaGoc = giaGoc;
        SoLuongTon = 0;
    }
    public abstract int TinhThanhTien(int soLuong);
    public abstract string LayThongTinRieng();
    public abstract string LayLoai();
    public virtual string HienThiThongTin()
    {
        return MaSP + " - " + TenSP + " - " + GiaGoc + " VND - Ton kho: " + SoLuongTon;
    }
    public static string TaoMaTuDong(string tienTo, int soThuTu)
    {
        return tienTo + soThuTu.ToString("D3");
    }
}
