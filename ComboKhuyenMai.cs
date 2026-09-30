namespace QuanLyQuanCafe;
public class ComboKhuyenMai : SanPham, IKhuyenMai
{
    public int PhanTramGiam;
    public ComboKhuyenMai(string maSP, string tenSP, int giaGoc, int phanTramGiam) : base(maSP, tenSP, giaGoc)
    {
        PhanTramGiam = phanTramGiam;
    }
    public override int TinhThanhTien(int soLuong)
    {
        int tongGoc = GiaGoc * soLuong;
        int tienGiam = TinhSoTienGiam(tongGoc);
        return tongGoc - tienGiam;
    }
    public override string LayThongTinRieng()
    {
        return PhanTramGiam.ToString();
    }
    public override string LayLoai()
    {
        return "Combo";
    }
    public int TinhSoTienGiam(int tongTien)
    {
        return tongTien * PhanTramGiam / 100;
    }
    public string LayThongTinKhuyenMai()
    {
        return "Giam " + PhanTramGiam + "%";
    }
}
