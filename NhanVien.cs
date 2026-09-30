namespace QuanLyQuanCafe;
public class NhanVien
{
    public string MaNV;
    public string TenNV;
    public string MatKhau;
    public string ChucVu;
    public NhanVien(string maNV, string tenNV, string matKhau, string chucVu)
    {
        MaNV = maNV;
        TenNV = tenNV;
        MatKhau = matKhau;
        ChucVu = chucVu;
    }
    public bool LaQuanLy()
    {
        return ChucVu == "Quan ly";
    }
}
