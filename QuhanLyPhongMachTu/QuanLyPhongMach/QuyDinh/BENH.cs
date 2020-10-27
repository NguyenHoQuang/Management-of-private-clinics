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
    public partial class Benh : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int dem = 2;
        public int thaydoi = 0;
        public int SoLuong = BENH_BUS.SoLuongBenh();
        public Benh()
        {
            InitializeComponent();
        }
        public void XoaTrangO()
        {
            int MaBenh;
            dgv_benh.CurrentCell.Selected = false;
            txt_ten.Text = "";
            int k = BENH_BUS.LoadBenh().Rows.Count;//đếm số hàng của datagridview
            if (k > 0)
                MaBenh = (int)BENH_BUS.LoadBenh().Rows[k - 1][0];//lấy mã bệnh nhân hiện tại
            else
                MaBenh = 0;
            MaBenh++;//mã bệnh nhân tiếp theo
            if (MaBenh < 10)
                txt_ma.Text = "BE00" + MaBenh.ToString();
            else
                if (MaBenh < 100 && MaBenh >= 10)
                txt_ma.Text = "BE0" + MaBenh.ToString();
            else
                    if (MaBenh >= 100)
                txt_ma.Text = "BE" + MaBenh.ToString();
            txt_ten.Focus();
        }
        public int Check()
        {
            if (txt_ten.Text == "")
            {
                return 1;
            }
            foreach (DataGridViewRow row in dgv_benh.Rows)
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
            int chiso = dgv_benh.Rows.Count;
            foreach (DataRow row in BENH_BUS.LoadBenh().Rows)
            {
                ThemHang(chiso, row[1].ToString());
                chiso++;
            }
        }
        private void ThemHang(int n, string tenbenh)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = tenbenh;
            temp.Cells.Add(cell);
            dgv_benh.Rows.Add(temp);
        }
        private void BENH_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();//laod dữ liệu vào datagridview
                dgv_benh.ReadOnly = true;
                dgv_benh.Rows[0].Cells[0].Selected = false;
                XoaTrangO();
                thaydoi = 0;
            }
            catch (Exception ex)//không load được database
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Kết nối máy chủ thất bại, xin thử lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_benh_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã của bệnh nhân hiện tại
                int k = dgv_benh.CurrentCell.RowIndex;
                int MaBenh = (int)BENH_BUS.LoadBenh().Rows[k][0];
                if (MaBenh < 10)
                    txt_ma.Text = "BE00" + MaBenh.ToString();
                else
                    if (MaBenh < 100 && MaBenh >= 10)
                    txt_ma.Text = "BE0" + MaBenh.ToString();
                else
                        if (MaBenh >= 100)
                    txt_ma.Text = "BE" + MaBenh.ToString();
                //load dữ liệu từ dòng đang chọn lên các control phía trên
                txt_ten.Text = dgv_benh.Rows[k].Cells[1].Value.ToString();
                txt_ten.Focus();//di chuyển con trỏ đến ô họ tên
            }
            catch (Exception ex)
            { }
        }
        private void grp_benh_Click(object sender, EventArgs e)
        {
            dgv_benh.CurrentCell.Selected = false;
            XoaTrangO();
        }
        private void rd_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)//nếu không có lỗi
                {
                    //thêm hàng vào csdl
                    BENH_DTO Benh = new BENH_DTO(txt_ten.Text);
                    BENH_BUS.ThemBenh(Benh);
                    ThemHang(dgv_benh.Rows.Count, txt_ten.Text);
                    string thongtin = "> Thêm bệnh " + txt_ten.Text + " vào danh sách bệnh vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                    XoaTrangO();//xóa hết các ô dữ liệu
                    SoLuong++;
                    THONGTIN_BUS.ThemThongTin(thongtin);
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
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bệnh vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgv_benh.CurrentCell.Selected == true)
                {
                    if (Check() == 0)//nếu không có lỗi
                    {
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //cập nhật thông tin vừa nhập
                            int now = dgv_benh.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                            int k = int.Parse(dgv_benh.Rows[now].Cells[0].Value.ToString());
                            string MaBenh = BENH_BUS.LoadBenh().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                            //cập nhật thông tin vài database
                            BENH_DTO Benh = new BENH_DTO(txt_ten.Text);
                            BENH_BUS.SuaBenh(Benh, MaBenh);
                            string s = dgv_benh.Rows[now].Cells[1].Value.ToString();
                            //cập nhật thông tin lại database
                            dgv_benh.Rows[now].Cells[1].Value = txt_ten.Text;
                            dgv_benh.CurrentCell.Selected = false;
                            string thongtin = "> Cập nhật bệnh " + s + " thành bệnh " + dgv_benh.Rows[now].Cells[1].Value.ToString() + " vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                            THONGTIN_BUS.ThemThongTin(thongtin);
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
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bệnh vừa nhập đã tồn tại, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ten.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn bệnh cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void ra_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_benh.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_benh.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        int k = int.Parse(dgv_benh.Rows[now].Cells[0].Value.ToString());
                        foreach (DataGridViewRow row in dgv_benh.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_benh.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        string MaBenh = BENH_BUS.LoadBenh().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                        BENH_BUS.XoaBenh(MaBenh);//xóa thông tin bệnh nhân trong database
                        string s = dgv_benh.Rows[now].Cells[1].Value.ToString();
                        string thongtin = "> Xóa bệnh " + s + " ra khỏi dánh sách bệnh vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                        THONGTIN_BUS.ThemThongTin(thongtin);
                        dgv_benh.Rows.RemoveAt(now);//xóa thông tin trên database
                        SoLuong--;
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        dgv_benh.CurrentCell.Selected = false;
                        XoaTrangO();
                        thaydoi = 1;
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn bệnh cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//có lỗi xảy ra
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Loại bệnh này đang được dùng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ra_xoa_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_2));
        }
        private void ra_xoa_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void ra_xoa_MouseHover(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void ra_xoa_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa));
        }
        private void ra_xoa_MouseMove(object sender, MouseEventArgs e)
        {

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

        private void dgv_benh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
