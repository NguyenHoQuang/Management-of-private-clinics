using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BUS;
using DTO;

namespace QuhanLyPhongMachTu
{
    public partial class QuyDinh : UserControl
    {
        public int thuoc;
        public int donvi;
        public int benh;
        public int cachdung;
        private int dem = 2;
        public QuyDinh()
        {
            InitializeComponent();
        }

        private void QuyDinh_Load(object sender, EventArgs e)
        {

        }
        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            DonViTinh temp = new DonViTinh();
            temp.ShowDialog();
            txt_donvi.Text = temp.SoLuong.ToString();
            donvi = temp.thaydoi;
        }

        private void btn_thuoc_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.QuyDinh.Thuoc temp = new QuanLyPhongMach.QuyDinh.Thuoc();
            temp.ShowDialog();
            txt_luongthuoc.Text = temp.SoLuong.ToString();
            thuoc = temp.thaydoi;
        }

        private void btn_benh_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.QuyDinh.Benh temp = new QuanLyPhongMach.QuyDinh.Benh();
            temp.ShowDialog();
            txt_loaibenh.Text = temp.SoLuong.ToString();
            benh = temp.thaydoi;
        }

        private void btn_cachdung_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.QuyDinh.CachDung temp = new QuanLyPhongMach.QuyDinh.CachDung();
            temp.ShowDialog();
            txt_cachdung.Text = temp.SoLuong.ToString();
            cachdung = temp.thaydoi;
        }
        private void QuyDinh_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true)
                {
                    thuoc = 0;
                    benh = 0;
                    cachdung = 0;
                    donvi = 0;
                    txt_benhnhan.Text = QUYDINH_BUS.BenhNhanToiDa().ToString();
                    txt_tienkham.Text = QUYDINH_BUS.TienKham().ToString();
                    grp_quydinh.Enabled = false;
                    rd_luu.Enabled = false;
                    rd_sua.Enabled = true;
                    //hien cac quy dinh cua phong kham
                    txt_luongthuoc.Text = THUOC_BUS.SoLuongThuoc().ToString();
                    txt_loaibenh.Text = BENH_BUS.SoLuongBenh().ToString();
                    txt_donvi.Text = DONVI_BUS.SoLuongDonVi().ToString();
                    txt_cachdung.Text = CACHDUNG_BUS.SoLuongCachDung().ToString();
                }
                else
                    if (Enabled == false)
                {
                    txt_benhnhan.Text = "";
                    txt_cachdung.Text = "";
                    txt_donvi.Text = "";
                    txt_loaibenh.Text = "";
                    txt_luongthuoc.Text = "";
                    txt_tienkham.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }

        private void QuyDinh_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible == true && Enabled == true)
                {
                    thuoc = 0;
                    benh = 0;
                    cachdung = 0;
                    donvi = 0;
                    txt_benhnhan.Text = QUYDINH_BUS.BenhNhanToiDa().ToString();
                    txt_tienkham.Text = QUYDINH_BUS.TienKham().ToString();
                    grp_quydinh.Enabled = false;
                    rd_luu.Enabled = false;
                    rd_sua.Enabled = true;
                    //hien cac quy dinh cua phong kham
                    txt_luongthuoc.Text = THUOC_BUS.SoLuongThuoc().ToString();
                    txt_loaibenh.Text = BENH_BUS.SoLuongBenh().ToString();
                    txt_donvi.Text = DONVI_BUS.SoLuongDonVi().ToString();
                    txt_cachdung.Text = CACHDUNG_BUS.SoLuongCachDung().ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private void rd_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxEx.Show("Bạn có muốn lưu những thông tin vừa thay đổi không", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    QUYDINH_BUS.CaiDat(int.Parse(txt_benhnhan.Text), int.Parse(txt_tienkham.Text));
                    timer1.Start();
                    timer1.Enabled = true;
                    lbl_thongbao.ForeColor = Color.Red;
                    lbl_thongbao.Text = "Lưu thành công";
                    timer1_Tick(sender, e);
                }
                else
                {
                    txt_benhnhan.Text = QUYDINH_BUS.BenhNhanToiDa().ToString();
                    txt_tienkham.Text = QUYDINH_BUS.TienKham().ToString();
                }
                grp_quydinh.Enabled = false;
                rd_luu.Enabled = false;
                rd_sua.Enabled = true;
                //hien cac quy dinh cua phong kham
                txt_luongthuoc.Text = THUOC_BUS.SoLuongThuoc().ToString();
                txt_loaibenh.Text = BENH_BUS.SoLuongBenh().ToString();
                txt_donvi.Text = DONVI_BUS.SoLuongDonVi().ToString();
                txt_cachdung.Text = CACHDUNG_BUS.SoLuongCachDung().ToString();
                rd_luu_MouseLeave(sender, e);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Nhập sai kiểu tiền, kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_benhnhan.Focus();
            }
        }
        private void rd_luu_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_quydinh_2));
        }
        private void rd_luu_MouseHover(object sender, EventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_quydinh_1));
        }
        private void rd_luu_MouseLeave(object sender, EventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_quydinh));
        }
        private void rd_sua_Click(object sender, EventArgs e)
        {
            grp_quydinh.Enabled = true;
            rd_luu.Enabled = true;
            rd_sua.Enabled = false;
        }
        private void rd_sua_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_sua.Image = ((System.Drawing.Image)(Properties.Resources.btn_sua_2));
        }
        private void rd_sua_MouseHover(object sender, EventArgs e)
        {
            this.rd_sua.Image = ((System.Drawing.Image)(Properties.Resources.btn_sua_1));
        }
        private void rd_sua_MouseLeave(object sender, EventArgs e)
        {
            this.rd_sua.Image = ((System.Drawing.Image)(Properties.Resources.btn_sua));
        }
        private void rd_luu_MouseEnter(object sender, EventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_quydinh_1));
        }
        private void rd_sua_MouseEnter(object sender, EventArgs e)
        {
            this.rd_sua.Image = ((System.Drawing.Image)(Properties.Resources.btn_sua_1));
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

        private void toolTip7_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
