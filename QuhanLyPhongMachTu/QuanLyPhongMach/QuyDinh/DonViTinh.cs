using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuhanLyPhongMachTu
{
    public partial class DonViTinh : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int dem = 2;
        public int thaydoi = 0;
        public int SoLuong = DONVI_BUS.SoLuongDonVi();
        public DonViTinh()
        {
            InitializeComponent();
        }
        public void XoaTrangO()
        {
            dgv_donvi.CurrentCell.Selected = false;
            int MaDV;
            txt_ten.Text = "";
            int k = DONVI_BUS.LoadDonVi().Rows.Count;//đếm số hàng của datagridview
            if (k > 0)
                MaDV = (int)DONVI_BUS.LoadDonVi().Rows[k - 1][0];//lấy mã bệnh nhân hiện tại
            else
                MaDV = 0;
            MaDV++;//mã bệnh nhân tiếp theo
            if (MaDV < 10)
                txt_ma.Text = "DV00" + MaDV.ToString();
            else
                if (MaDV < 100 && MaDV >= 10)
                txt_ma.Text = "DV0" + MaDV.ToString();
            else
                    if (MaDV >= 100)
                txt_ma.Text = "DV" + MaDV.ToString();
            txt_ten.Focus();
        }
        public int Check()
        {
            if (txt_ten.Text == "")
            {
                return 1;
            }
            foreach (DataGridViewRow row in dgv_donvi.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if (txt_ten.Text.ToLower() == row.Cells[1].Value.ToString().ToLower())
                        return 2;
                }
            }
            return 0;
        }
        public void LoadData()
        {
            //load dữ liệu vào datagridview
            int chiso = dgv_donvi.Rows.Count;
            foreach (DataRow row in DONVI_BUS.LoadDonVi().Rows)
            {
                ThemHang(chiso, row[1].ToString());
                chiso++;
            }
        }
        private void ThemHang(int n, string tendonvi)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = tendonvi;
            temp.Cells.Add(cell);
            dgv_donvi.Rows.Add(temp);
        }
        private void DonViTinh_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();//laod dữ liệu vào datagridview
                dgv_donvi.ReadOnly = true;
                dgv_donvi.Rows[0].Cells[0].Selected = false;
                XoaTrangO();
                thaydoi = 0;
            }
            catch (Exception ex)//không load được database
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Kết nối máy chủ thất bại, xin thử lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_donvi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã của bệnh nhân hiện tại
                int k = dgv_donvi.CurrentCell.RowIndex;
                int MaDV = (int)DONVI_BUS.LoadDonVi().Rows[k][0];
                if (MaDV < 10)
                    txt_ma.Text = "DV00" + MaDV.ToString();
                else
                    if (MaDV < 100 && MaDV >= 10)
                    txt_ma.Text = "DV0" + MaDV.ToString();
                else
                        if (MaDV >= 100)
                    txt_ma.Text = "DV" + MaDV.ToString();
                //load dữ liệu từ dòng đang chọn lên các control phía trên
                txt_ten.Text = dgv_donvi.Rows[k].Cells[1].Value.ToString();
                txt_ten.Focus();//di chuyển con trỏ đến ô họ tên
            }
            catch (Exception ex)
            { }
        }
        private void grp_donvi_Click(object sender, EventArgs e)
        {
            dgv_donvi.CurrentCell.Selected = false;
            XoaTrangO();
        }
        private void rd_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)//nếu không có lỗi
                {
                    //thêm hàng vào csdl
                    DONVI_DTO DonVi = new DONVI_DTO(txt_ten.Text);
                    DONVI_BUS.ThemDonVi(DonVi);
                    ThemHang(dgv_donvi.Rows.Count, txt_ten.Text);
                    string s = txt_ten.Text;
                    string thongtin = "> Thêm đơn vị " + s + " vào dánh sách đơn vị vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                    THONGTIN_BUS.ThemThongTin(thongtin);
                    XoaTrangO();//xóa hết các ô dữ liệu
                    SoLuong++;
                    timer1.Start();
                    timer1.Enabled = true;
                    lbl_thongbao.ForeColor = Color.Red;
                    lbl_thongbao.Text = "Thêm thành công";
                    timer1_Tick(sender, e);
                    thaydoi = 1;
                }
                else
                    if (Check() == 1)//nếu còn ô trống
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten.Focus();
                }
                else
                        if (Check() == 2)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Loại đơn vị vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten.Focus();
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Đã có lỗi xảy ra, xin thao tác lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_them_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_3));
        }
        private void rd_them_MouseEnter(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_them_MouseHover(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_them_MouseLeave(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_2));
        }
        private void rd_capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_donvi.CurrentCell.Selected == true)
                {
                    if (Check() == 0)//nếu không có lỗi
                    {
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //cập nhật thông tin vừa nhập
                            int now = dgv_donvi.CurrentCell.RowIndex;
                            int k = int.Parse(dgv_donvi.Rows[now].Cells[0].Value.ToString());//lấy số thứ tự hiện tại trên datagridview
                            string MaDV = DONVI_BUS.LoadDonVi().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                            //cập nhật thông tin vài database
                            DONVI_DTO DonVi = new DONVI_DTO(txt_ten.Text);
                            DONVI_BUS.SuaDonVi(DonVi, MaDV);
                            string s = dgv_donvi.Rows[now].Cells[1].Value.ToString();
                            //cập nhật thông tin lại database
                            dgv_donvi.Rows[now].Cells[1].Value = txt_ten.Text;
                            string thongtin = "> Cập nhật đơn vị " + s + " thành đơn vị " + dgv_donvi.Rows[now].Cells[1].Value.ToString() + " vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                            THONGTIN_BUS.ThemThongTin(thongtin);
                            dgv_donvi.CurrentCell.Selected = false;
                            XoaTrangO();//xóa hết thông tin trên các  textbox
                            timer1.Start();
                            timer1.Enabled = true;
                            lbl_thongbao.ForeColor = Color.Red;
                            lbl_thongbao.Text = "Cập nhật thành công!";
                            timer1_Tick(sender, e);
                            thaydoi = 1;
                        }
                    }
                    else
                        if (Check() == 1)//nếu còn ô trống
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ten.Focus();
                    }
                    else
                            if (Check() == 2)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Loại đơn vị vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ten.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn đơn vị cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Đã có lỗi xảy ra, xin thao tác lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_capnhat_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseEnter(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_capnhat_MouseHover(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_2));
        }
        private void rd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_donvi.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_donvi.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        foreach (DataGridViewRow row in dgv_donvi.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_donvi.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        int k = int.Parse(dgv_donvi.Rows[now].Cells[0].Value.ToString());
                        string MaDV = DONVI_BUS.LoadDonVi().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                        DONVI_BUS.XoaDonVi(MaDV);//xóa thông tin bệnh nhân trong database
                        string s = dgv_donvi.Rows[now].Cells[1].Value.ToString();
                        string thongtin = "> Xóa đơn vị " + s + " ra khỏi dánh sách đơn vị vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                        THONGTIN_BUS.ThemThongTin(thongtin);
                        dgv_donvi.Rows.RemoveAt(now);//xóa thông tin trên database
                        SoLuong--;
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        dgv_donvi.CurrentCell.Selected = false;
                        XoaTrangO();
                        thaydoi = 1;
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn đơn vị cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//có lỗi xảy ra
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Loại đơn vị tính này đang được dùng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_xoa_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_2));
        }
        private void rd_xoa_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void rd_xoa_MouseHover(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void rd_xoa_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa));
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
    }
}
