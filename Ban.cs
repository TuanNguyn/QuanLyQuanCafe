namespace QuanLyQuanCafe;
public class Ban
{
    public int SoBan;
    public string TrangThai;
    public Ban(int soBan, string trangThai)
    {
        SoBan = soBan;
        TrangThai = trangThai;
    }
    public override string ToString()
    {
        return "Ban " + SoBan + " (" + TrangThai + ")";
    }
}
