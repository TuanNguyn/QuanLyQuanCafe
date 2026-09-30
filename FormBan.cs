using QuanLyQuanCafe;
using QuanLyQuanCafe_WinForms;

namespace QuanLyQuanCafe_WF;
public partial class FormBan : Form
{
    private bool laQuanLy;
    private int soBanDangChon = 0;
    public FormBan(bool quanLy)
    {
        InitializeComponent();
        laQuanLy = quanLy;
    }
    private void FormBan_Load(object sender, EventArgs e)
    {
        dgvBan.Columns.Clear();
        dgvBan.Columns.Add("SoBan", "Số bàn");
        dgvBan.Columns.Add("TrangThai", "Trạng thái");

        if (!laQuanLy)
        {
            txtSoBanMoi.Enabled = false;
            btnThemBan.Enabled = false;
            btnXoaBan.Enabled = false;
            btnThemBan.BackColor = Color.Gray;
            btnXoaBan.BackColor = Color.Gray;
        }
        NapLai();
    }
    private void NapLai()
    {
        Ban[] ds = DataAccess.LayTatCaBan();
        dgvBan.Rows.Clear();
        int soTrong = 0;
        for (int i = 0; i < ds.Length; i++)
        {
            dgvBan.Rows.Add(ds[i].SoBan, ds[i].TrangThai);
            if (ds[i].TrangThai == "Trong")
            {
                soTrong++;
            }
            else
            {
                dgvBan.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }
        lblThongKeBan.Text = "Tổng: " + ds.Length + " bàn | Trống: " + soTrong + " | Đang dùng: " + (ds.Length - soTrong);
        soBanDangChon = 0;
    }
    private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        soBanDangChon = int.Parse(dgvBan.Rows[e.RowIndex].Cells["SoBan"].Value.ToString());
    }
    private void btnThemBan_Click(object sender, EventArgs e)
    {
        int soBan;
        if (!int.TryParse(txtSoBanMoi.Text.Trim(), out soBan) || soBan <= 0)
        {
            MessageBox.Show("So ban phai la so nguyen duong.");
            return;
        }

        if (DataAccess.ThemBan(soBan))
        {
            txtSoBanMoi.Clear();
            NapLai();
        }
        else
        {
            MessageBox.Show("Ban " + soBan + " da ton tai.");
        }
    }
    private void btnXoaBan_Click(object sender, EventArgs e)
    {
        if (soBanDangChon == 0)
        {
            MessageBox.Show("Chua chon ban tren bang.");
            return;
        }

        DialogResult xacNhan = MessageBox.Show("Xoa ban " + soBanDangChon + "?", "Xac nhan", MessageBoxButtons.YesNo);
        if (xacNhan != DialogResult.Yes) return;

        if (DataAccess.XoaBan(soBanDangChon))
        {
            NapLai();
        }
        else
        {
            MessageBox.Show("Khong xoa duoc (ban dang co khach).");
        }
    }
    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        NapLai();
    }
}
