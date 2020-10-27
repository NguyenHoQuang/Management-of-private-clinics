using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BUS;
using DTO;
using PDFCreatorPilotLib;

namespace QuhanLyPhongMachTu
{
    public partial class BaoCaoSuDungThuoc : UserControl
    {
        private int dem = 2;
        ProcessStartInfo startInfo = new ProcessStartInfo();
        public BaoCaoSuDungThuoc()
        {
            InitializeComponent();
        }
        public int CheckNhap()
        {
            //kiem tra de trong
            if (cbo_thang.Text == "")
                return 1;
            //
            try
            {
                NgayDauThang(cbo_thang.Text);
            }
            catch
            {
                return 3;
            }
            //
            int k = cbo_thang.AutoCompleteCustomSource.IndexOf(cbo_thang.Text);
            if (k == -1)
                return 2;
            //
            return 0;
        }
        public void LoadThang()
        {
            int n = cbo_thang.AutoCompleteCustomSource.Count;
            for (int i = 0; i < n; i++)
            {
                cbo_thang.AutoCompleteCustomSource.RemoveAt(0);
                cbo_thang.Items.RemoveAt(0);
            }
            foreach (DataRow row in BAOCAO_BUS.ChonThangNam().Rows)
            {
                DevComponents.Editors.ComboItem cbo = new DevComponents.Editors.ComboItem(row[0].ToString());
                cbo_thang.Items.Add(cbo);
                cbo_thang.AutoCompleteCustomSource.Add(row[0].ToString());
            }
        }
        public void ThemHang(int n, string tenthuoc, string dongia, string soluong, string solandung)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = tenthuoc;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = string.Format("{0:0,0}", (int)float.Parse(dongia));
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = soluong;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = solandung;
            temp.Cells.Add(cell);
            dgv_baocao.Rows.Add(temp);

        }
        private DateTime NgayDauThang(string ThangNam)
        {
            return Convert.ToDateTime("01/" + ThangNam);
        }
        private DateTime NgayCuoiThang(string ThangNam)
        {
            string temp = "", temp1 = "";
            for (int i = 0; i < ThangNam.Length; i++)
            {
                if (ThangNam[i] != '/')
                    temp = temp + ThangNam[i];
                if (ThangNam[i] == '/')
                {
                    for (int j = i + 1; j < ThangNam.Length; j++)
                        temp1 = temp1 + ThangNam[j];
                    break;
                }
            }
            int Thang = int.Parse(temp);
            int Nam = int.Parse(temp1);
            int[] temp2 = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((Nam % 400 == 0) || (Nam % 4 == 0 && Nam % 100 != 0))
                temp2[1] = 29;
            return Convert.ToDateTime(temp2[Thang - 1].ToString() + '/' + ThangNam);
        }
        private void BaoCaoSuDungThuoc_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true && Visible == true)
                {
                    if (startInfo.Arguments == "")
                        startInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    lbl_path.Text = startInfo.Arguments;
                    LoadThang();
                    cbo_thang.SelectedItem = cbo_thang.Items[0];
                    cbo_thang.Text = cbo_thang.SelectedItem.ToString();
                }
                else
                {
                    cbo_thang.SelectedItem = false;
                    cbo_thang.Text = "";
                    lbl_path.Text = "";
                    int n = dgv_baocao.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_baocao.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            { }
        }
        private void BaoCaoSuDungThuoc_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible == true && Enabled == true)
                {
                    if (startInfo.Arguments == "")
                        startInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    lbl_path.Text = startInfo.Arguments;
                    LoadThang();
                    cbo_thang.SelectedItem = cbo_thang.Items[0];
                    cbo_thang.Text = cbo_thang.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            { }
        }
        private void cbo_thang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rd_xem_Click(sender, e);
            }
        }
        private void rd_xem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckNhap() == 0)
                {
                    lbl_tong.Text = "Tổng tiền: ";
                    lbl_thanhchu.Text = "Thành chữ: ";
                    int tongtien = 0;
                    int n = dgv_baocao.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_baocao.Rows.RemoveAt(0);
                    int chiso = 1;
                    foreach (DataRow row in BAOCAO_BUS.ChiTietThuoc(NgayDauThang(cbo_thang.Text), NgayCuoiThang(cbo_thang.Text)).Rows)
                    {
                        ThemHang(chiso, row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                        tongtien = tongtien + int.Parse(row[2].ToString()) * (int)float.Parse(row[1].ToString());
                        chiso++;
                    }
                    lbl_tong.Text = lbl_tong.Text + string.Format("{0:0,0}", tongtien);
                    DocTien(tongtien.ToString());
                    lbl_thanhchu.Text = lbl_thanhchu.Text + "Đồng";
                    timer1.Start();
                    timer1.Enabled = true;
                    lbl_thongbao.ForeColor = Color.Red;
                    lbl_thongbao.Text = "Xem thành công";
                    timer1_Tick(sender, e);
                }
                else
                    if (CheckNhap() == 1)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_thang.Focus();
                }
                else
                        if (CheckNhap() == 2)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không có báo cáo tháng đã nhâp, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_thang.Focus();
                }
                else
                            if (CheckNhap() == 3)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Nhập không đúng định dạng, xin nhập lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_thang.Focus();
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_xem_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xem.Image = ((System.Drawing.Image)(Properties.Resources.btn_xem_2));
        }
        private void rd_xem_MouseHover(object sender, EventArgs e)
        {
            this.rd_xem.Image = ((System.Drawing.Image)(Properties.Resources.btn_xem_1));
        }
        private void rd_xem_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xem.Image = ((System.Drawing.Image)(Properties.Resources.btn_xem));
        }
        private void radialMenu1_Click(object sender, EventArgs e)
        {
            if (dgv_baocao.Rows.Count > 1)
            {
                PDFDocument4 pdf = new PDFDocument4();
                pdf.PageSize = PaperFormat.pfA4;
                pdf.PageOrientation = PaperOrientation.pPortrait;
                int fnt = pdf.AddFont("Times New Roman", true, false, false, false, fontCharset.fcDefault);
                pdf.UseFont(fnt, 25);
                pdf.ShowUnicodeTextAt(lbl_baocao.Location.X - 70, lbl_baocao.Location.Y + 25, lbl_baocao.Text);
                pdf.UseFont(fnt, 12);
                pdf.ShowUnicodeTextAt(lbl_thang.Location.X - 80, lbl_thang.Location.Y + 10, lbl_thang.Text);
                pdf.ShowUnicodeTextAt(cbo_thang.Location.X - 80, cbo_thang.Location.Y + 10, cbo_thang.Text);
                int n = dgv_baocao.Rows.Count;
                int hoadon = pdf.AddTable(5, n, fnt, 12);
                pdf.SetTableColumnSize(hoadon, 0, 50);
                pdf.SetTableColumnSize(hoadon, 1, 200);
                pdf.SetTableColumnSize(hoadon, 2, 70);
                pdf.SetTableColumnSize(hoadon, 3, 70);
                pdf.SetTableColumnSize(hoadon, 4, 100);
                pdf.SetCellTableText(hoadon, 0, 0, "STT");
                pdf.SetCellTableText(hoadon, 1, 0, "Thuốc");
                pdf.SetCellTableText(hoadon, 2, 0, "Đơn giá");
                pdf.SetCellTableText(hoadon, 3, 0, "Số lượng");
                pdf.SetCellTableText(hoadon, 4, 0, "Số lần dùng");
                pdf.SetCellTableTextAlign(hoadon, 0, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 1, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 2, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 3, 0, TextAlign.taCenter);
                pdf.SetCellTableTextAlign(hoadon, 4, 0, TextAlign.taCenter);
                int temp = 1;
                foreach (DataGridViewRow row in dgv_baocao.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        pdf.SetCellTableText(hoadon, 0, temp, row.Cells[0].Value.ToString());
                        pdf.SetCellTableText(hoadon, 1, temp, row.Cells[1].Value.ToString());
                        pdf.SetCellTableText(hoadon, 2, temp, row.Cells[2].Value.ToString());
                        pdf.SetCellTableText(hoadon, 3, temp, row.Cells[3].Value.ToString());
                        pdf.SetCellTableText(hoadon, 4, temp, row.Cells[4].Value.ToString());
                        pdf.SetCellTableTextAlign(hoadon, 0, temp, TextAlign.taCenter);
                        pdf.SetCellTableTextAlign(hoadon, 1, temp, TextAlign.taLeft);
                        pdf.SetCellTableTextAlign(hoadon, 2, temp, TextAlign.taCenter);
                        pdf.SetCellTableTextAlign(hoadon, 3, temp, TextAlign.taCenter);
                        pdf.SetCellTableTextAlign(hoadon, 4, temp, TextAlign.taCenter);
                        temp++;
                    }
                }
                pdf.ShowTable(hoadon, dgv_baocao.Location.X + 25, dgv_baocao.Location.Y, 1, 1);
                pdf.ShowUnicodeTextAt(lbl_tong.Location.X + 20, dgv_baocao.Location.Y + 10 + 20 * n, lbl_tong.Text);
                pdf.ShowUnicodeTextAt(lbl_thanhchu.Location.X + 20, dgv_baocao.Location.Y + 30 + 20 * n, lbl_thanhchu.Text);
                pdf.ShowUnicodeTextAt(dgv_baocao.Location.X + 275, dgv_baocao.Location.Y + 50 + 20 * n, "Tp.Hồ Chí Minh, ngày " + string.Format("{0:dd}", DateTime.Now.Date) + " tháng " + string.Format("{0:MM}", DateTime.Now.Date) + " năm " + DateTime.Now.Year.ToString());
                pdf.ShowUnicodeTextAt(dgv_baocao.Location.X + 350, dgv_baocao.Location.Y + 70 + 20 * n, "Người lập báo cáo");
                timer1.Start();
                timer1.Enabled = true;
                lbl_thongbao.ForeColor = Color.Red;
                lbl_thongbao.Text = "Lưu thành công";
                timer1_Tick(sender, e);
                pdf.SaveToFile(lbl_path.Text + "\\bao cao thuoc (" + string.Format("{0:MM-yyyy}", NgayDauThang(cbo_thang.Text)) + ").pdf", true);
                rd_in_MouseLeave(sender, e);
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Bạn cần xem báo cáo trước khi in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_thang.Focus();
            }
        }
        private void rd_in_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_in.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_2));
        }
        private void rd_in_MouseHover(object sender, EventArgs e)
        {
            this.rd_in.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_1));
        }
        private void rd_in_MouseLeave(object sender, EventArgs e)
        {
            this.rd_in.Image = ((System.Drawing.Image)(Properties.Resources.btn_in));
        }
        private void rd_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "|*.pdf";
            sfd.RestoreDirectory = true;
            sfd.InitialDirectory = Path.GetFullPath(startInfo.Arguments);
            sfd.FileName = "bao-cao";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lbl_path.Text = Path.GetDirectoryName(sfd.FileName);

            }
            if (startInfo.Arguments != "")
                startInfo.Arguments = Path.GetFullPath(sfd.FileName);
        }
        private void rd_save_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save_2));
        }
        private void rd_save_MouseHover(object sender, EventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save_1));
        }
        private void rd_save_MouseLeave(object sender, EventArgs e)
        {
            this.rd_save.Image = ((System.Drawing.Image)(Properties.Resources.btn_save));
        }
        private void rd_xem_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xem.Image = ((System.Drawing.Image)(Properties.Resources.btn_xem_1));
        }
        private void rd_in_MouseEnter(object sender, EventArgs e)
        {
            this.rd_in.Image = ((System.Drawing.Image)(Properties.Resources.btn_in_1));
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
                            if (s[Math.Abs(vitri - (int)s.Length + 2)] == '0' || s[Math.Abs(vitri - (int)s.Length + 2)] == '1' || Math.Abs(vitri - (int)s.Length + 1) == 0)
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

        private void BaoCaoSuDungThuoc_Load(object sender, EventArgs e)
        {

        }

        private void dgv_baocao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
