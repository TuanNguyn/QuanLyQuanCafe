using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormThongKe : Form
{
    private HoaDon[] tatCaHoaDon;
    public FormThongKe()
    {
        InitializeComponent();
    }
    private void FormThongKe_Load(object sender, EventArgs e)
    {
        tatCaHoaDon = DataAccess.LayTatCaHoaDon();
        cboKieuTop5.SelectedIndex = 0;
    }
    private int TinhDoanhThu(DateTime tu, DateTime den)
    {
        int tong = 0;
        for (int i = 0; i < tatCaHoaDon.Length; i++)
        {
            HoaDon hd = tatCaHoaDon[i];
            if (hd != null && hd.TrangThai == "Da thanh toan" && hd.NgayGioThang >= tu && hd.NgayGioThang < den)
            {
                tong += hd.TinhTongTien();
            }
        }
        return tong;
    }
    private void btnTheoNgay_Click(object sender, EventArgs e)
    {
        DateTime tu = dtpNgay.Value.Date;
        DateTime den = tu.AddDays(1);
        int doanhThu = TinhDoanhThu(tu, den);
        lblKetQua.Text = "Doanh thu ngay " + tu.ToString("dd/MM/yyyy") + ": " + doanhThu.ToString("N0") + " d";
    }
    private void btnTheoThang_Click(object sender, EventArgs e)
    {
        int thang = (int)nudThang.Value;
        int nam = (int)nudNam1.Value;
        DateTime tu = new DateTime(nam, thang, 1);
        DateTime den = tu.AddMonths(1);
        int doanhThu = TinhDoanhThu(tu, den);
        lblKetQua.Text = "Doanh thu thang " + thang + "/" + nam + ": " + doanhThu.ToString("N0") + " d";
    }
    private void btnTheoQuy_Click(object sender, EventArgs e)
    {
        int quy = (int)nudQuy.Value;
        int nam = (int)nudNam2.Value;
        int thangBatDau = (quy - 1) * 3 + 1;
        DateTime tu = new DateTime(nam, thangBatDau, 1);
        DateTime den = tu.AddMonths(3);
        int doanhThu = TinhDoanhThu(tu, den);
        lblKetQua.Text = "Doanh thu quy " + quy + "/" + nam + ": " + doanhThu.ToString("N0") + " d";
    }
    private void btnTheoNam_Click(object sender, EventArgs e)
    {
        int nam = (int)nudNam3.Value;
        DateTime tu = new DateTime(nam, 1, 1);
        DateTime den = tu.AddYears(1);
        int doanhThu = TinhDoanhThu(tu, den);
        lblKetQua.Text = "Doanh thu nam " + nam + ": " + doanhThu.ToString("N0") + " d";
    }
    private void btnTop5_Click(object sender, EventArgs e)
    {
        if (cboKieuTop5.SelectedIndex < 0)
        {
            MessageBox.Show("Chua chon Ngay / Thang / Nam.");
            return;
        }

        DateTime chon = dtpTop5.Value.Date;
        DateTime tu;
        DateTime den;
        string tenKhoang;

        if (cboKieuTop5.SelectedIndex == 0)
        {
            tu = chon;
            den = chon.AddDays(1);
            tenKhoang = "ngay " + chon.ToString("dd/MM/yyyy");
        }
        else if (cboKieuTop5.SelectedIndex == 1)
        {
            tu = new DateTime(chon.Year, chon.Month, 1);
            den = tu.AddMonths(1);
            tenKhoang = "thang " + chon.Month + "/" + chon.Year;
        }
        else
        {
            tu = new DateTime(chon.Year, 1, 1);
            den = tu.AddYears(1);
            tenKhoang = "nam " + chon.Year;
        }

        ChiTietHoaDon[] top = DataAccess.LayTop5(tu, den);

        lstTop5.Items.Clear();
        lstTop5.Items.Add("TOP 5 SAN PHAM BAN CHAY " + tenKhoang);
        if (top.Length == 0)
        {
            lstTop5.Items.Add("Khong co du lieu.");
            return;
        }
        for (int i = 0; i < top.Length; i++)
        {
            lstTop5.Items.Add((i + 1) + ". " + top[i].TenSP + " (" + top[i].MaSP + ") - da ban " + top[i].SoLuong);
        }
    }
}
