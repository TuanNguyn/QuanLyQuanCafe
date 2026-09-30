using MySqlConnector;
using QuanLyQuanCafe;

namespace QuanLyQuanCafe_WinForms;
public static class DataAccess
{
    private static string connectionString = "Server=localhost;Port=3306;Database=quanlyquancafe;Uid=root;Pwd=123456;";
    public static bool KiemTraKetNoi()
    {
        try
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }
    private static int Dem(string sql)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }
    private static int Dem(string sql, string tenThamSo, object giaTri)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue(tenThamSo, giaTri);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }
    private static string TaoMaMoi(string tenBang, string tenCot, string tienTo)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string sql = "SELECT " + tenCot + " FROM " + tenBang + " WHERE " + tenCot + " LIKE '" + tienTo + "%' ORDER BY " + tenCot + " DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        object ketQua = cmd.ExecuteScalar();

        int soThuTu = 0;
        if (ketQua != null)
        {
            string maCuoi = ketQua.ToString();
            soThuTu = int.Parse(maCuoi.Substring(tienTo.Length));
        }
        soThuTu++;
        return tienTo + soThuTu.ToString("D3");
    }
    public static SanPham[] LayDanhSachSanPham()
    {
        SanPham[] ds = new SanPham[Dem("SELECT COUNT(*) FROM sanpham")];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT MaSP, Loai, TenSP, GiaGoc, ThuocTinhRieng, SoLuongTon FROM sanpham ORDER BY MaSP", conn);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < ds.Length)
        {
            string maSP = reader.GetString("MaSP");
            string loai = reader.GetString("Loai");
            string tenSP = reader.GetString("TenSP");
            int giaGoc = reader.GetInt32("GiaGoc");
            string thuocTinh = "";
            if (!reader.IsDBNull(reader.GetOrdinal("ThuocTinhRieng")))
            {
                thuocTinh = reader.GetString("ThuocTinhRieng");
            }

            SanPham sp;
            if (loai == "DoUong")
            {
                sp = new DoUong(maSP, tenSP, giaGoc, thuocTinh[0]);
            }
            else if (loai == "DoAn")
            {
                sp = new DoAn(maSP, tenSP, giaGoc, bool.Parse(thuocTinh));
            }
            else
            {
                sp = new ComboKhuyenMai(maSP, tenSP, giaGoc, int.Parse(thuocTinh));
            }
            sp.SoLuongTon = reader.GetInt32("SoLuongTon");

            ds[i] = sp;
            i++;
        }
        return ds;
    }
    public static string TaoMaSanPhamMoi(string tienTo)
    {
        return TaoMaMoi("sanpham", "MaSP", tienTo);
    }
    public static void ThemSanPham(SanPham sp)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string sql = "INSERT INTO sanpham (MaSP, Loai, TenSP, GiaGoc, ThuocTinhRieng, SoLuongTon) " +
                     "VALUES (@maSP, @loai, @tenSP, @giaGoc, @thuocTinh, @soLuongTon)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@maSP", sp.MaSP);
        cmd.Parameters.AddWithValue("@loai", sp.LayLoai());
        cmd.Parameters.AddWithValue("@tenSP", sp.TenSP);
        cmd.Parameters.AddWithValue("@giaGoc", sp.GiaGoc);
        cmd.Parameters.AddWithValue("@thuocTinh", sp.LayThongTinRieng());
        cmd.Parameters.AddWithValue("@soLuongTon", sp.SoLuongTon);
        cmd.ExecuteNonQuery();
    }
    public static bool XoaSanPham(string maSP)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("DELETE FROM sanpham WHERE MaSP = @maSP", conn);
        cmd.Parameters.AddWithValue("@maSP", maSP);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static bool SuaTenGia(string maSP, string tenMoi, int giaMoi)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("UPDATE sanpham SET TenSP = @ten, GiaGoc = @gia WHERE MaSP = @maSP", conn);
        cmd.Parameters.AddWithValue("@ten", tenMoi);
        cmd.Parameters.AddWithValue("@gia", giaMoi);
        cmd.Parameters.AddWithValue("@maSP", maSP);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static bool NhapHang(string maSP, int soLuongNhap)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("UPDATE sanpham SET SoLuongTon = SoLuongTon + @soLuong WHERE MaSP = @maSP", conn);
        cmd.Parameters.AddWithValue("@soLuong", soLuongNhap);
        cmd.Parameters.AddWithValue("@maSP", maSP);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static NhanVien[] LayDanhSachNhanVien()
    {
        NhanVien[] ds = new NhanVien[Dem("SELECT COUNT(*) FROM nhanvien")];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT MaNV, TenNV, MatKhau, ChucVu FROM nhanvien ORDER BY MaNV", conn);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < ds.Length)
        {
            ds[i] = new NhanVien(reader.GetString("MaNV"), reader.GetString("TenNV"), reader.GetString("MatKhau"), reader.GetString("ChucVu"));
            i++;
        }
        return ds;
    }
    public static NhanVien DangNhap(string maNV, string matKhau)
    {
        NhanVien[] ds = LayDanhSachNhanVien();
        for (int i = 0; i < ds.Length; i++)
        {
            if (ds[i] != null && ds[i].MaNV == maNV && ds[i].MatKhau == matKhau)
            {
                return ds[i];
            }
        }
        return null;
    }
    public static bool ThemNhanVien(string maNV, string tenNV, string matKhau, string chucVu)
    {
        try
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO nhanvien (MaNV, TenNV, MatKhau, ChucVu) VALUES (@ma, @ten, @mk, @cv)", conn);
            cmd.Parameters.AddWithValue("@ma", maNV);
            cmd.Parameters.AddWithValue("@ten", tenNV);
            cmd.Parameters.AddWithValue("@mk", matKhau);
            cmd.Parameters.AddWithValue("@cv", chucVu);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool SuaNhanVien(string maNV, string tenNV, string chucVu, string matKhauMoi)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd;
        if (matKhauMoi == "")
        {
            cmd = new MySqlCommand("UPDATE nhanvien SET TenNV = @ten, ChucVu = @cv WHERE MaNV = @ma", conn);
        }
        else
        {
            cmd = new MySqlCommand("UPDATE nhanvien SET TenNV = @ten, ChucVu = @cv, MatKhau = @mk WHERE MaNV = @ma", conn);
            cmd.Parameters.AddWithValue("@mk", matKhauMoi);
        }
        cmd.Parameters.AddWithValue("@ten", tenNV);
        cmd.Parameters.AddWithValue("@cv", chucVu);
        cmd.Parameters.AddWithValue("@ma", maNV);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static bool XoaNhanVien(string maNV)
    {
        try
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM nhanvien WHERE MaNV = @ma", conn);
            cmd.Parameters.AddWithValue("@ma", maNV);
            return cmd.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
    public static bool DoiMatKhau(string maNV, string matKhauCu, string matKhauMoi)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("UPDATE nhanvien SET MatKhau = @moi WHERE MaNV = @ma AND MatKhau = @cu", conn);
        cmd.Parameters.AddWithValue("@moi", matKhauMoi);
        cmd.Parameters.AddWithValue("@ma", maNV);
        cmd.Parameters.AddWithValue("@cu", matKhauCu);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static Ban[] LayTatCaBan()
    {
        Ban[] ds = new Ban[Dem("SELECT COUNT(*) FROM ban")];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT SoBan, TrangThai FROM ban ORDER BY SoBan", conn);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < ds.Length)
        {
            ds[i] = new Ban(reader.GetInt32("SoBan"), reader.GetString("TrangThai"));
            i++;
        }
        return ds;
    }
    public static Ban[] LayBanTheoTrangThai(string trangThai)
    {
        Ban[] ds = new Ban[Dem("SELECT COUNT(*) FROM ban WHERE TrangThai = @tt", "@tt", trangThai)];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT SoBan, TrangThai FROM ban WHERE TrangThai = @tt ORDER BY SoBan", conn);
        cmd.Parameters.AddWithValue("@tt", trangThai);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < ds.Length)
        {
            ds[i] = new Ban(reader.GetInt32("SoBan"), reader.GetString("TrangThai"));
            i++;
        }
        return ds;
    }
    public static bool ThemBan(int soBan)
    {
        try
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO ban (SoBan, TrangThai) VALUES (@ban, 'Trong')", conn);
            cmd.Parameters.AddWithValue("@ban", soBan);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool XoaBan(int soBan)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("DELETE FROM ban WHERE SoBan = @ban AND TrangThai = 'Trong'", conn);
        cmd.Parameters.AddWithValue("@ban", soBan);
        return cmd.ExecuteNonQuery() > 0;
    }
    public static void DoiTrangThaiBan(int soBan, string trangThai)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("UPDATE ban SET TrangThai = @tt WHERE SoBan = @ban", conn);
        cmd.Parameters.AddWithValue("@tt", trangThai);
        cmd.Parameters.AddWithValue("@ban", soBan);
        cmd.ExecuteNonQuery();
    }
    public static string TaoHoaDonMoi(int soBan, string maNV)
    {
        string maHD = TaoMaMoi("hoadon", "MaHD", "HD");

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string sql = "INSERT INTO hoadon (MaHD, NgayGioThang, SoBan, MaNV, TrangThai) VALUES (@maHD, @ngayGio, @soBan, @maNV, 'Chua thanh toan')";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@maHD", maHD);
        cmd.Parameters.AddWithValue("@ngayGio", DateTime.Now);
        cmd.Parameters.AddWithValue("@soBan", soBan);
        cmd.Parameters.AddWithValue("@maNV", maNV);
        cmd.ExecuteNonQuery();
        return maHD;
    }
    public static string LayMaHDChuaThanhToan(int soBan)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        string sql = "SELECT MaHD FROM hoadon WHERE SoBan = @ban AND TrangThai = 'Chua thanh toan' ORDER BY MaHD DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ban", soBan);
        object ketQua = cmd.ExecuteScalar();
        if (ketQua == null) return "";
        return ketQua.ToString();
    }
    public static bool ThemMonVaoHoaDon(string maHD, SanPham sp, int soLuong)
    {
        if (sp.SoLuongTon < soLuong) return false;

        ChiTietHoaDon ct = new ChiTietHoaDon(maHD, sp, soLuong);

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();

        string sqlInsert = "INSERT INTO chitiethoadon (MaHD, MaSP, TenSP, SoLuong, DonGia, ThanhTien) " +
                           "VALUES (@maHD, @maSP, @tenSP, @soLuong, @donGia, @thanhTien)";
        MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
        cmd.Parameters.AddWithValue("@maHD", ct.MaHD);
        cmd.Parameters.AddWithValue("@maSP", ct.MaSP);
        cmd.Parameters.AddWithValue("@tenSP", ct.TenSP);
        cmd.Parameters.AddWithValue("@soLuong", ct.SoLuong);
        cmd.Parameters.AddWithValue("@donGia", ct.DonGia);
        cmd.Parameters.AddWithValue("@thanhTien", ct.ThanhTien);
        cmd.ExecuteNonQuery();

        MySqlCommand cmd2 = new MySqlCommand("UPDATE sanpham SET SoLuongTon = SoLuongTon - @soLuong WHERE MaSP = @maSP", conn);
        cmd2.Parameters.AddWithValue("@soLuong", soLuong);
        cmd2.Parameters.AddWithValue("@maSP", sp.MaSP);
        cmd2.ExecuteNonQuery();

        return true;
    }
    public static void ThanhToanHoaDon(string maHD, int soBan)
    {
        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();

        MySqlCommand cmd = new MySqlCommand("UPDATE hoadon SET TrangThai = 'Da thanh toan' WHERE MaHD = @ma", conn);
        cmd.Parameters.AddWithValue("@ma", maHD);
        cmd.ExecuteNonQuery();

        MySqlCommand cmd2 = new MySqlCommand("UPDATE ban SET TrangThai = 'Trong' WHERE SoBan = @ban", conn);
        cmd2.Parameters.AddWithValue("@ban", soBan);
        cmd2.ExecuteNonQuery();
    }
    public static ChiTietHoaDon[] LayChiTietTheoMaHD(string maHD)
    {
        ChiTietHoaDon[] ds = new ChiTietHoaDon[Dem("SELECT COUNT(*) FROM chitiethoadon WHERE MaHD = @ma", "@ma", maHD)];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT MaHD, MaSP, TenSP, SoLuong, DonGia, ThanhTien FROM chitiethoadon WHERE MaHD = @ma", conn);
        cmd.Parameters.AddWithValue("@ma", maHD);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < ds.Length)
        {
            ds[i] = new ChiTietHoaDon(reader.GetString("MaHD"), reader.GetString("MaSP"), reader.GetString("TenSP"),
                                      reader.GetInt32("SoLuong"), reader.GetInt32("DonGia"), reader.GetInt32("ThanhTien"));
            i++;
        }
        return ds;
    }
    public static HoaDon[] LayTatCaHoaDon()
    {
        HoaDon[] ds = new HoaDon[Dem("SELECT COUNT(*) FROM hoadon")];

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT MaHD, NgayGioThang, SoBan, MaNV, TrangThai FROM hoadon ORDER BY NgayGioThang DESC", conn);
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            int i = 0;
            while (reader.Read() && i < ds.Length)
            {
                string maNV = "";
                if (!reader.IsDBNull(reader.GetOrdinal("MaNV"))) maNV = reader.GetString("MaNV");
                ds[i] = new HoaDon(reader.GetString("MaHD"), reader.GetDateTime("NgayGioThang"), reader.GetInt32("SoBan"), maNV, reader.GetString("TrangThai"));
                i++;
            }
        }
        MySqlCommand cmd2 = new MySqlCommand("SELECT MaHD, MaSP, TenSP, SoLuong, DonGia, ThanhTien FROM chitiethoadon", conn);
        using (MySqlDataReader reader2 = cmd2.ExecuteReader())
        {
            while (reader2.Read())
            {
                string maHD = reader2.GetString("MaHD");
                ChiTietHoaDon ct = new ChiTietHoaDon(maHD, reader2.GetString("MaSP"), reader2.GetString("TenSP"),
                                                     reader2.GetInt32("SoLuong"), reader2.GetInt32("DonGia"), reader2.GetInt32("ThanhTien"));
                for (int j = 0; j < ds.Length; j++)
                {
                    if (ds[j] != null && ds[j].MaHD == maHD)
                    {
                        ds[j].ThemChiTiet(ct);
                        break;
                    }
                }
            }
        }
        return ds;
    }
    public static ChiTietHoaDon[] LayTop5(DateTime tu, DateTime den)
    {
        string sql = "SELECT c.MaSP, c.TenSP, SUM(c.SoLuong) AS Tong " +
                     "FROM chitiethoadon c JOIN hoadon h ON c.MaHD = h.MaHD " +
                     "WHERE h.TrangThai = 'Da thanh toan' AND h.NgayGioThang >= @tu AND h.NgayGioThang < @den " +
                     "GROUP BY c.MaSP, c.TenSP ORDER BY Tong DESC LIMIT 5";
        ChiTietHoaDon[] tam = new ChiTietHoaDon[5];
        int dem = 0;

        using MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@tu", tu);
        cmd.Parameters.AddWithValue("@den", den);
        using MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read() && dem < 5)
        {
            tam[dem] = new ChiTietHoaDon("", reader.GetString("MaSP"), reader.GetString("TenSP"), Convert.ToInt32(reader["Tong"]), 0, 0);
            dem++;
        }

        ChiTietHoaDon[] ketQua = new ChiTietHoaDon[dem];
        for (int i = 0; i < dem; i++)
        {
            ketQua[i] = tam[i];
        }
        return ketQua;
    }
}
