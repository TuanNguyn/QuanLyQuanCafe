namespace QuanLyQuanCafe;
public class HoaDon
{
    public string MaHD;
    public DateTime NgayGioThang;
    public int SoBan;
    public string MaNV;
    public string TrangThai;
    public ChiTietHoaDon[] DanhSachChiTiet;
    public int SoLuongChiTiet;
    public HoaDon(string maHD, DateTime ngayGioThang, int soBan, string maNV, string trangThai)
    {
        MaHD = maHD;
        NgayGioThang = ngayGioThang;
        SoBan = soBan;
        MaNV = maNV;
        TrangThai = trangThai;
        DanhSachChiTiet = new ChiTietHoaDon[50];
        SoLuongChiTiet = 0;
    }
    private void MoRongMang()
    {
        ChiTietHoaDon[] mangMoi = new ChiTietHoaDon[DanhSachChiTiet.Length * 2];
        for (int i = 0; i < DanhSachChiTiet.Length; i++)
        {
            mangMoi[i] = DanhSachChiTiet[i];
        }
        DanhSachChiTiet = mangMoi;
    }
    public void ThemChiTiet(ChiTietHoaDon ct)
    {
        if (SoLuongChiTiet >= DanhSachChiTiet.Length)
        {
            MoRongMang();
        }
        DanhSachChiTiet[SoLuongChiTiet] = ct;
        SoLuongChiTiet++;
    }
    public int TinhTongTien()
    {
        int tong = 0;
        for (int i = 0; i < SoLuongChiTiet; i++)
        {
            tong += DanhSachChiTiet[i].ThanhTien;
        }
        return tong;
    }
}
