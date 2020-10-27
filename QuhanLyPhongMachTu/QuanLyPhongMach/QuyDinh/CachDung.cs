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

namespace QuhanLyPhongMachTu.QuanLyPhongMach.QuyDinh
{
    public partial class CachDung : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int dem = 2;
        public int thaydoi = 0;
        public int SoLuong = CACHDUNG_BUS.SoLuongCachDung();
        public CachDung()
        {
            InitializeComponent();
        }
        public void XoaTrangO()
        {
            dgv_cachdung.CurrentCell.Selected = false;
            int MaCD;
            txt_ten.Text = "";
            int k = CACHDUNG_BUS.LoadCachDung().Rows.Count;//đếm số hàng của datagridview
            if (k > 0)
                MaCD = (int)CACHDUNG_BUS.LoadCachDung().Rows[k - 1][0];//lấy mã bệnh nhân hiện tại
            else
                MaCD = 0;
            MaCD++;//mã bệnh nhân tiếp theo
            if (MaCD < 10)
                txt_ma.Text = "CD00" + MaCD.ToString();
            else
                if (MaCD < 100 && MaCD >= 10)
                txt_ma.Text = "CD0" + MaCD.ToString();
            else
                    if (MaCD >= 100)
                txt_ma.Text = "CD" + MaCD.ToString();
            txt_ten.Focus();
        }
        public int Check()
        {
            if (txt_ten.Text == "")
            {
                return 1;
            }
            foreach (DataGridViewRow row in dgv_cachdung.Rows)
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
            int chiso = dgv_cachdung.Rows.Count;
            foreach (DataRow row in CACHDUNG_BUS.LoadCachDung().Rows)
            {
                ThemHang(chiso, row[1].ToString());
                chiso++;
            }
        }
        private void ThemHang(int n, string tencachdung)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = tencachdung;
            temp.Cells.Add(cell);
            dgv_cachdung.Rows.Add(temp);
        }
        private void CachDung_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();//laod dữ liệu vào datagridview
                dgv_cachdung.ReadOnly = true;
                dgv_cachdung.Rows[0].Cells[0].Selected = false;
                XoaTrangO();
                thaydoi = 0;
            }
            catch (Exception ex)//không load được database
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Kết nối máy chủ thất bại, xin thử lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_cachdung_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã của bệnh nhân hiện tại
                int k = dgv_cachdung.CurrentCell.RowIndex;
                int MaCD = (int)CACHDUNG_BUS.LoadCachDung().Rows[k][0];
                if (MaCD < 10)
                    txt_ma.Text = "CD00" + MaCD.ToString();
                else
                    if (MaCD < 100 && MaCD >= 10)
                    txt_ma.Text = "CD0" + MaCD.ToString();
                else
                        if (MaCD >= 100)
                    txt_ma.Text = "CD" + MaCD.ToString();
                //load dữ liệu từ dòng đang chọn lên các control phía trên
                txt_ten.Text = dgv_cachdung.Rows[k].Cells[1].Value.ToString();
                txt_ten.Focus();//di chuyển con trỏ đến ô họ tên
            }
            catch (Exception ex)
            { }
        }
        private void grp_cachdung_Click(object sender, EventArgs e)
        {
            dgv_cachdung.CurrentCell.Selected = false;
            XoaTrangO();
        }
        private void radialMenu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)//nếu không có lỗi
                {
                    //thêm hàng vào csdl
                    CACHDUNG_DTO CachDung = new CACHDUNG_DTO(txt_ten.Text);
                    CACHDUNG_BUS.ThemCachDung(CachDung);
                    ThemHang(dgv_cachdung.Rows.Count, txt_ten.Text);
                    string s = txt_ten.Text;
                    string thongtin = "> Thêm cách dùng " + s + " vào dánh sách cách dùng vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                    THONGTIN_BUS.ThemThongTin(thongtin);
                    XoaTrangO();//xóa hết các ô dữ liệu
                    SoLuong++;
                    timer1.Start();
                    timer1.Enabled = true;
                    lbl_thongbao.ForeColor = Color.Red;
                    lbl_thongbao.Text = "Thêm thành công!";
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
                    DevComponents.DotNetBar.MessageBoxEx.Show("Loaị cách dùng vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgv_cachdung.CurrentCell.Selected == true)
                {
                    if (Check() == 0)//nếu không có lỗi
                    {
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //cập nhật thông tin vừa nhập
                            int now = dgv_cachdung.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                            int k = int.Parse(dgv_cachdung.Rows[now].Cells[0].Value.ToString());
                            string MaCD = CACHDUNG_BUS.LoadCachDung().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                            //cập nhật thông tin vài database
                            CACHDUNG_DTO CachDung = new CACHDUNG_DTO(txt_ten.Text);
                            CACHDUNG_BUS.SuaCachDung(CachDung, MaCD);
                            string s = dgv_cachdung.Rows[now].Cells[1].Value.ToString();
                            //cập nhật thông tin lại database
                            dgv_cachdung.Rows[now].Cells[1].Value = txt_ten.Text;
                            string thongtin = "> Cập nhật cách dùng " + s + " thành cách dùng " + dgv_cachdung.Rows[now].Cells[1].Value.ToString() + " vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                            THONGTIN_BUS.ThemThongTin(thongtin);
                            timer1.Start();
                            timer1.Enabled = true;
                            lbl_thongbao.ForeColor = Color.Red;
                            lbl_thongbao.Text = "Cập nhật thành công!";
                            timer1_Tick(sender, e);
                            dgv_cachdung.CurrentCell.Selected = false;
                            XoaTrangO();//xóa hết thông tin trên các  textbox
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
                        DevComponents.DotNetBar.MessageBoxEx.Show("Loại cách dùng vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ten.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn cách dùng cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgv_cachdung.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_cachdung.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        foreach (DataGridViewRow row in dgv_cachdung.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_cachdung.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        int k = int.Parse(dgv_cachdung.Rows[now].Cells[0].Value.ToString());
                        string MaCD = CACHDUNG_BUS.LoadCachDung().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                        CACHDUNG_BUS.XoaCachDung(MaCD);//xóa thông tin bệnh nhân trong database
                        string s = dgv_cachdung.Rows[now].Cells[1].Value.ToString();
                        string thongtin = "> Xóa cách dùng " + s + " ra khỏi dánh sách cách dùng vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                        THONGTIN_BUS.ThemThongTin(thongtin);
                        dgv_cachdung.Rows.RemoveAt(now);//xóa thông tin trên database
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        SoLuong--;
                        dgv_cachdung.CurrentCell.Selected = false;
                        XoaTrangO();
                        thaydoi = 1;
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn cách dùng cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//có lỗi xảy ra
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Loại cách dùng này đang được dùng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
