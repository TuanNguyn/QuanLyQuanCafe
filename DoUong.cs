namespace QuanLyQuanCafe;
public class DoUong : SanPham
{
    public char Size;
    public DoUong(string maSP, string tenSP, int giaGoc, char size) : base(maSP, tenSP, giaGoc)
    {
        Size = size;
    }
    private int LayHeSo()
    {
        if (Size == 'S') return 1;
        else if (Size == 'M') return 2;
        else return 3;
    }
    public override int TinhThanhTien(int soLuong)
    {
        return GiaGoc * soLuong * LayHeSo();
    }
    public override string LayThongTinRieng()
    {
        return Size.ToString();
    }
    public override string LayLoai()
    {
        return "DoUong";
    }
}
