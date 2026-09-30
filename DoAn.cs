namespace QuanLyQuanCafe;
public class DoAn : SanPham
{
    public bool Cay;
    public DoAn(string maSP, string tenSP, int giaGoc, bool cay) : base(maSP, tenSP, giaGoc)
    {
        Cay = cay;
    }
    public override int TinhThanhTien(int soLuong)
    {
        return GiaGoc * soLuong;
    }
    public override string LayThongTinRieng()
    {
        return Cay.ToString();
    }
    public override string LayLoai()
    {
        return "DoAn";
    }
}
