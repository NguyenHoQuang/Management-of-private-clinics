using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.IO;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using PDFCreatorPilotLib;
using PDFPreviewHandlerHostLib;

namespace QuhanLyPhongMachTu
{
    public partial class HoaDon : UserControl
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        private int dem = 2;
        public HoaDon()
        {
            InitializeComponent();
        }
        private void btn_in_Click(object sender, EventArgs e)
        {

        }
        public void loadhoadon()
        {
            //foreach (DataRow row in PHIEUKHAMBENH_BUS.LoadDaKham().Rows)
            //{
            //    int MaBenhNhan = int.Parse(row[0].ToString());
            //    HOADON_BUS.TaoHoaDon(MaBenhNhan);
            //    CTHD_BUS.TaoCTHoaDon(MaBenhNhan);
            //}
        }
        private void ThemHangBenhNhan(int n, string ten)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = ten;
            temp.Cells.Add(cell);
            dgv_benhnhan.Rows.Add(temp);
        }
        private void ThemHangThuoc(int n, string ten, string soluong, string dongia)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = ten;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = soluong;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = string.Format("{0:0,0}", (int)float.Parse(dongia)); ;
            temp.Cells.Add(cell);
            dgv_thuoc.Rows.Add(temp);
        }
        public void LoadDataBenhNhan()
        {
            int n = dgv_benhnhan.Rows.Count;
            for (int i = 1; i < n; i++)
                dgv_benhnhan.Rows.RemoveAt(0);
            //load benh nhan da kham
            int chiso = 1;
            foreach (DataRow row in PHIEUKHAMBENH_BUS.LoadDaKham().Rows)
            {
                ThemHangBenhNhan(chiso, row[1].ToString());
                chiso++;
            }
        }
        public void LoadDataThuoc(int MaHD)
        {
            int n = dgv_thuoc.Rows.Count;
            for (int i = 1; i < n; i++)
                dgv_thuoc.Rows.RemoveAt(0);
            //load benh nhan da kham
            int chiso = 1;
            foreach (DataRow row in CTHD_BUS.XuatCTHoaDon(MaHD).Rows)
            {
                ThemHangThuoc(chiso, row[0].ToString(), row[1].ToString(), row[2].ToString());
                chiso++;
            }
        }
        private void HoaDon_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true)
                {
                    if (startInfo.Arguments == "")
                        startInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    dgv_benhnhan.SelectionChanged -= dgv_benhnhan_SelectionChanged;
                    lbl_tienkham.Text = "Tiền khám: " + string.Format("{0:0,0}", QUYDINH_BUS.TienKham());
                    loadhoadon();
                    lbl_path.Text = startInfo.Arguments;
                    dgv_benhnhan.ReadOnly = true;
                    dgv_thuoc.ReadOnly = true;
                    LoadDataBenhNhan();
                    lbl_hoten.Text = "Họ tên:";
                    lbl_ngaykham.Text = "Ngày khám:";
                    lbl_tienthuoc.Text = "Tổng tiền:";
                    dgv_benhnhan.SelectionChanged += dgv_benhnhan_SelectionChanged;
                }
                else
                    if (Enabled == false)
                {
                    lbl_hoten.Text = "Họ tên:";
                    lbl_ngaykham.Text = "Ngày khám:";
                    lbl_tienkham.Text = "Tiền khám:";
                    lbl_tienthuoc.Text = "Tổng tiền:";
                    int n = dgv_benhnhan.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_benhnhan.Rows.RemoveAt(0);
                    n = dgv_thuoc.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_thuoc.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            { }
        }
        public void XuLyMaBN(int n)
        {
            if (n < 10)
                txt_mabn.Text = "BN00" + n.ToString();
            else
                if (n < 100 && n >= 10)
                txt_mabn.Text = "BN0" + n.ToString();
            else
                    if (n >= 100)
                txt_mabn.Text = "BN" + n.ToString();
        }
        public string MaBN(int n)
        {
            if (n < 10)
                return "BN00" + n.ToString();
            else
            {
                if (n < 100 && n >= 10)
                    return "BN0" + n.ToString();
                else
                    return "BN" + n.ToString();
            }
        }
        private void dgv_benhnhan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_thanhchu.Text = "Thành chữ: ";
                int now = dgv_benhnhan.CurrentCell.RowIndex;
                int k = int.Parse(dgv_benhnhan.Rows[now].Cells[0].Value.ToString());
                int MaBenhNhan = int.Parse(PHIEUKHAMBENH_BUS.LoadDaKham().Rows[k - 1][0].ToString());
                XuLyMaBN(MaBenhNhan);
                dt_ngaysinh.Value = Convert.ToDateTime(PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][0].ToString());
                txt_diachi.Text = PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][1].ToString();
                lbl_hoten.Text = "Họ tên: " + dgv_benhnhan.Rows[now].Cells[1].Value.ToString();
                lbl_tienkham.Text = "Tiền khám: " + string.Format("{0:0,0}", QUYDINH_BUS.TienKham());
                lbl_ngaykham.Text = "Ngày khám: " + Convert.ToDateTime(HOADON_BUS.XuatHoaDon(MaBenhNhan).Rows[0][1].ToString()).Date.ToShortDateString();
                LoadDataThuoc(int.Parse(HOADON_BUS.XuatHoaDon(MaBenhNhan).Rows[0][0].ToString()));
                lbl_tienthuoc.Text = "Tiền thuốc: " + string.Format("{0:0,0}", (int)float.Parse(HOADON_BUS.XuatHoaDon(MaBenhNhan).Rows[0][2].ToString()));
                lbl_tong.Text = "Tổng tiền: " + string.Format("{0:0,0}", ((int)float.Parse(HOADON_BUS.XuatHoaDon(MaBenhNhan).Rows[0][2].ToString()) + QUYDINH_BUS.TienKham()));
                DocTien(((int)float.Parse(HOADON_BUS.XuatHoaDon(MaBenhNhan).Rows[0][2].ToString()) + QUYDINH_BUS.TienKham()).ToString());
                lbl_thanhchu.Text = lbl_thanhchu.Text + "Đồng";
            }
            catch (Exception ex)
            { }
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (txt_ten.Text != "")
            {
                foreach (DataGridViewRow row in dgv_benhnhan.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string s1 = txt_ten.Text.ToLower();
                        string s = row.Cells[1].Value.ToString().ToLower();
                        if (s.IndexOf(s1) != -1)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_benhnhan.Rows)
                    row.Visible = true;
            }
        }
        private void HoaDon_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible == true && Enabled == true)
                {
                    dgv_benhnhan.SelectionChanged -= dgv_benhnhan_SelectionChanged;
                    if (startInfo.Arguments == "")
                        startInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    dgv_benhnhan.SelectionChanged -= dgv_benhnhan_SelectionChanged;
                    loadhoadon();
                    LoadDataBenhNhan();
                    dgv_benhnhan.SelectionChanged += dgv_benhnhan_SelectionChanged;
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_xuat_Click(object sender, EventArgs e)
        {
            if (dgv_thuoc.Rows.Count > 1)
            {
                int now = dgv_benhnhan.CurrentCell.RowIndex;
                int k = int.Parse(dgv_benhnhan.Rows[now].Cells[0].Value.ToString());
                int MaBenhNhan = int.Parse(PHIEUKHAMBENH_BUS.LoadDaKham().Rows[k - 1][0].ToString());
                PDFDocument4 pdf = new PDFDocument4();
                pdf.PageSize = PaperFormat.pfA4;
                pdf.PageOrientation = PaperOrientation.pPortrait;
                int fnt = pdf.AddFont("Times New Roman", true, false, false, false, fontCharset.fcDefault);
                pdf.UseFont(fnt, 25);
                pdf.ShowUnicodeTextAt(lbl_hoadon.Location.X + 20, lbl_hoadon.Location.Y + 20, lbl_hoadon.Text);
                pdf.UseFont(fnt, 12);
                pdf.ShowUnicodeTextAt(lbl_hoten.Location.X + 20, lbl_hoten.Location.Y + 20, lbl_hoten.Text);
                pdf.ShowUnicodeTextAt(lbl_ngaykham.Location.X + 20, lbl_ngaykham.Location.Y + 20, lbl_ngaykham.Text);
                pdf.ShowUnicodeTextAt(lbl_tienkham.Location.X + 20, lbl_tienkham.Location.Y + 20, lbl_tienkham.Text);
                pdf.ShowUnicodeTextAt(lbl_tienthuoc.Location.X + 20, lbl_tienthuoc.Location.Y + 20, lbl_tienthuoc.Text);
                int n = dgv_thuoc.Rows.Count;
                int hoadon = pdf.AddTable(4, n, fnt, 12);
                pdf.SetTableColumnSize(hoadon, 0, 50);
                pdf.SetTableColumnSize(hoadon, 1, 200);
                pdf.SetTableColumnSize(hoadon, 2, 70);
                pdf.SetTableColumnSize(hoadon, 3, 70);
                pdf.SetCellTableText(hoadon, 0, 0, "STT");
                pdf.SetCellTableText(hoadon, 1, 0, "Tên thuốc");
                pdf.SetCellTableText(hoadon, 2, 0, "Số Lượng");
                pdf.SetCellTableText(hoadon, 3, 0, "Đơn giá");
                pdf.SetCellTableTextAlign(hoadon, 0, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 1, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 2, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 3, 0, TextAlign.taCenter);
                int temp = 1;
                foreach (DataGridViewRow row in dgv_thuoc.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        pdf.SetCellTableText(hoadon, 0, temp, row.Cells[0].Value.ToString());
                        pdf.SetCellTableText(hoadon, 1, temp, row.Cells[1].Value.ToString());
                        pdf.SetCellTableText(hoadon, 2, temp, row.Cells[2].Value.ToString());
                        pdf.SetCellTableText(hoadon, 3, temp, row.Cells[3].Value.ToString());
                        pdf.SetCellTableTextAlign(hoadon, 0, temp, TextAlign.taCenter);
                        pdf.SetCellTableTextAlign(hoadon, 1, temp, TextAlign.taLeft);
                        pdf.SetCellTableTextAlign(hoadon, 2, temp, TextAlign.taCenter);
                        pdf.SetCellTableTextAlign(hoadon, 3, temp, TextAlign.taCenter);
                        temp++;
                    }
                }
                pdf.ShowTable(hoadon, dgv_thuoc.Location.X + 70, dgv_thuoc.Location.Y + 20, 1, 1);
                pdf.ShowUnicodeTextAt(lbl_tong.Location.X + 20, dgv_thuoc.Location.Y + 30 + 20 * n, lbl_tong.Text);
                pdf.ShowUnicodeTextAt(lbl_thanhchu.Location.X + 20, dgv_thuoc.Location.Y + 50 + 20 * n, lbl_thanhchu.Text);
                pdf.ShowUnicodeTextAt(dgv_thuoc.Location.X + 300, dgv_thuoc.Location.Y + 70 + 20 * n, "Tp.Hồ Chí Minh, ngày " + string.Format("{0:dd}", DateTime.Now.Date) + " tháng " + string.Format("{0:MM}", DateTime.Now.Date) + " năm " + DateTime.Now.Year.ToString());
                pdf.ShowUnicodeTextAt(dgv_thuoc.Location.X + 380, dgv_thuoc.Location.Y + 90 + 20 * n, "Chữ ký bác sỹ");
                timer1.Start();
                timer1.Enabled = true;
                lbl_thongbao.ForeColor = Color.Red;
                lbl_thongbao.Text = "Lưu thành công";
                timer1_Tick(sender, e);
                pdf.SaveToFile(lbl_path.Text + "\\" + MaBN(MaBenhNhan) + ".pdf", true);
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn bệnh nhân cần in hóa đơn!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ten.Focus();
            }
        }
        private void rd_xuat_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xuat.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_2));
        }
        private void rd_xuat_MouseHover(object sender, EventArgs e)
        {
            this.rd_xuat.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_1));
        }
        private void rd_xuat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xuat.Image = ((System.Drawing.Image)(Properties.Resources.btn_in));
        }
        private void radialMenu1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "|*.pdf";
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = Path.GetFullPath(startInfo.Arguments);
                int now = dgv_benhnhan.CurrentCell.RowIndex;
                int k = int.Parse(dgv_benhnhan.Rows[now].Cells[0].Value.ToString());
                int MaBenhNhan = int.Parse(PHIEUKHAMBENH_BUS.LoadDaKham().Rows[k - 1][0].ToString());
                sfd.FileName = MaBN(MaBenhNhan).ToString();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    lbl_path.Text = Path.GetDirectoryName(sfd.FileName);

                }
                startInfo.Arguments = Path.GetDirectoryName(sfd.FileName);
            }
            catch (Exception ex)
            { }
        }
        private void radialMenu1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save_2));
        }
        private void radialMenu1_MouseLeave(object sender, EventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save));
        }
        private void radialMenu1_MouseHover(object sender, EventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save_1));
        }

        private void rd_xuat_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xuat.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_1));
        }

        private void rd_save_MouseEnter(object sender, EventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save_1));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_thongbao.Visible = true;
            dem = dem - 1;
            if (dem == 0)
            {
                timer1.Stop();
                timer1.Enabled = false;
                dem = 2;
                lbl_thongbao.Visible = false;
            }
        }

        private void DocSo(int n, int vitri, string s)
        {
            switch (n)
            {
                case 0:
                    {
                        if (vitri == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Không";
                        else
                            if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text;
                        else
                                if (vitri % 3 == 1)
                        {
                            if (s[System.Math.Abs(vitri - (int)s.Length)] == '0')
                                lbl_thanhchu.Text = lbl_thanhchu.Text;
                            else
                                lbl_thanhchu.Text = lbl_thanhchu.Text + "Lẻ ";
                        }
                        else
                                    if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Không Trăm ";
                    }
                    break;
                case 1:
                    {
                        if (vitri == 0 && s.Length == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Một ";
                        else
                            if (vitri % 3 == 0)
                        {
                            if (s[Math.Abs(vitri - (int)s.Length + 2)] == '0' || s[Math.Abs(vitri - (int)s.Length + 2)] == '1' || Math.Abs(vitri - (int)s.Length + 2) == 0)
                                lbl_thanhchu.Text = lbl_thanhchu.Text + "Một ";
                            else
                                lbl_thanhchu.Text = lbl_thanhchu.Text + "Mốt ";
                        }
                        else
                                if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Mười ";
                        else
                                    if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Một Trăm ";
                    }
                    break;
                case 2:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Hai ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Hai Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Hai Trăm ";
                    }
                    break;
                case 3:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Ba ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Ba Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Ba Trăm ";
                    }
                    break;
                case 4:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bốn ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bốn Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bốn Trăm ";
                    }
                    break;
                case 5:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Năm ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Năm Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Năm Trăm ";
                    }
                    break;
                case 6:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Sáu ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Sáu Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Sáu Trăm ";
                    }
                    break;
                case 7:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bảy ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bảy Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Bảy Trăm ";
                    }
                    break;
                case 8:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Tám ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Tám Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Tám Trăm ";
                    }
                    break;
                case 9:
                    {
                        if (vitri % 3 == 0)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Chín ";
                        else
                            if (vitri % 3 == 1)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Chín Mươi ";
                        else
                                if (vitri % 3 == 2)
                            lbl_thanhchu.Text = lbl_thanhchu.Text + "Chín Trăm ";
                    }
                    break;
            }
        }

        private void DocTien(string s)
        {
            int m = s.Length - 1;
            int dem = s.Length - 1;
            while (s[m] == '0')
            {
                m = m - 1;
                if (m < 0)
                {
                    m = 0;
                    break;
                }
            }
            for (int i = 0; i <= m; i++)
            {
                if ((dem - i) % 3 == 2)
                {
                    if (s[i] == '0' && s[i + 1] == '0' && s[i + 2] == '0')
                    {
                        i = i + 2;
                        continue;
                    }
                }
                int k = s[i] - 48;
                DocSo(k, dem - i, s);
                if ((dem - i) % 3 == 0 || i == m)
                {
                    if ((dem - i) / 3 == 0)
                        continue;
                    else
                        if ((dem - i) / 3 == 1)
                        lbl_thanhchu.Text = lbl_thanhchu.Text + "Nghìn ";
                    else
                            if ((dem - i) / 3 == 2)
                        lbl_thanhchu.Text = lbl_thanhchu.Text + "Triệu ";
                    else
                                if ((dem - i) / 3 == 3)
                        lbl_thanhchu.Text = lbl_thanhchu.Text + "Tỷ ";
                }
            }
        }

        private void dgv_benhnhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_thuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grp_hoadon_Click(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}