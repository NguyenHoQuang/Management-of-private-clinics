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
    public partial class Thuoc : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int dem = 2;
        public int thaydoi = 0;
        public int SoLuong = THUOC_BUS.SoLuongThuoc();
        public Thuoc()
        {
            InitializeComponent();
        }
        public void XoaTrangO()
        {
            dgv_thuoc.CurrentCell.Selected = false;
            txt_ten.Text = "";
            txt_soluong.Text = "";
            txt_gia.Text = "";
            int k = THUOC_BUS.LoadThuoc().Rows.Count;//đếm số hàng của datagridview
            int MaThuoc = (int)THUOC_BUS.LoadThuoc().Rows[k - 1][0];//lấy mã bệnh nhân hiện tại
            MaThuoc++;//mã bệnh nhân tiếp theo
            if (MaThuoc < 10)
                txt_ma.Text = "TH00" + MaThuoc.ToString();
            else
                if (MaThuoc < 100 && MaThuoc >= 10)
                txt_ma.Text = "TH0" + MaThuoc.ToString();
            else
                    if (MaThuoc >= 100)
                txt_ma.Text = "TH" + MaThuoc.ToString();
            txt_ten.Focus();
        }
        public int Check()
        {
            if (txt_ten.Text == "" || txt_gia.Text == "" || txt_soluong.Text == "")
            {
                return 1;
            }
            for (int i = 0; i < txt_soluong.Text.Length; i++)
            {
                if (txt_soluong.Text[i] < '0' || txt_soluong.Text[i] > '9')
                    return 2;
            }
            for (int i = 0; i < txt_gia.Text.Length; i++)
            {
                if (txt_gia.Text[i] < '0' || txt_gia.Text[i] > '9')
                    return 3;
            }
            return 0;
        }
        public void LoadData()
        {
            //load dữ liệu vào datagridview
            int chiso = dgv_thuoc.Rows.Count;
            foreach (DataRow row in THUOC_BUS.LoadThuoc().Rows)
            {
                ThemHang(chiso, row[1].ToString(), row[3].ToString(), row[2].ToString());
                chiso++;
            }
        }
        private void ThemHang(int n, string tenthuoc, string soluong, string dongia)
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
            cell.Value = soluong;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = string.Format("{0:0,0}", (int)float.Parse(dongia));
            temp.Cells.Add(cell);
            dgv_thuoc.Rows.Add(temp);
        }
        private void Thuoc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();//laod dữ liệu vào datagridview
                dgv_thuoc.ReadOnly = true;
                dgv_thuoc.CurrentCell.Selected = false;
                XoaTrangO();
                thaydoi = 0;
            }
            catch (Exception ex)//không load được database
            { }
        }
        private void grp_thuoc_Click(object sender, EventArgs e)
        {
            dgv_thuoc.CurrentCell.Selected = false;
            XoaTrangO();
        }
        private void dgv_thuoc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã của bệnh nhân hiện tại
                int k = dgv_thuoc.CurrentCell.RowIndex;
                int MaThuoc = (int)THUOC_BUS.LoadThuoc().Rows[k][0];
                if (MaThuoc < 10)
                    txt_ma.Text = "TH00" + MaThuoc.ToString();
                else
                    if (MaThuoc < 100 && MaThuoc >= 10)
                    txt_ma.Text = "TH0" + MaThuoc.ToString();
                else
                        if (MaThuoc >= 100)
                    txt_ma.Text = "TH" + MaThuoc.ToString();
                //load dữ liệu từ dòng đang chọn lên các control phía trên
                txt_ten.Text = dgv_thuoc.Rows[k].Cells[1].Value.ToString();
                txt_soluong.Text = dgv_thuoc.Rows[k].Cells[2].Value.ToString();
                txt_gia.Text = dgv_thuoc.Rows[k].Cells[3].Value.ToString();
                txt_ten.Focus();//di chuyển con trỏ đến ô họ tên
            }
            catch (Exception ex)
            { }
        }
        private void txt_ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_soluong.Focus();
        }
        private void txt_soluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_gia.Focus();
        }
        private void rd_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)//nếu không có lỗi
                {
                    //thêm hàng vào csdl
                    THUOC_DTO Thuoc = new THUOC_DTO(txt_ten.Text, txt_gia.Text, txt_soluong.Text);
                    THUOC_BUS.ThemThuoc(Thuoc);
                    string thongtin = "> Thêm thuốc " + txt_ten.Text + " với số lượng " + txt_soluong.Text + " vào danh sách thuốc vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                    ThemHang(dgv_thuoc.Rows.Count, txt_ten.Text, txt_soluong.Text, txt_gia.Text);
                    XoaTrangO();//xóa hết các ô dữ liệu
                    THONGTIN_BUS.ThemThongTin(thongtin);
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
                    if (txt_ten.Text == "")
                    {
                        txt_ten.Focus();
                    }
                    else
                        if (txt_soluong.Text == "")
                    {
                        txt_soluong.Focus();
                    }
                    else
                        txt_gia.Focus();
                }
                else
                        if (Check() == 2)//có số trong ten
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số trong ô số lượng, xin kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_soluong.Focus();
                }
                else
                            if (Check() == 3)//ngày khám nhỏ hơn ngày sinh
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số trong ô giá, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_gia.Focus();
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
                if (dgv_thuoc.CurrentCell.Selected == true)
                {
                    if (Check() == 0)//không có lỗi
                    {
                        //chắc chắn muốn thay đổi thông tin bệnh nhân đã chọn
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //cập nhật thông tin vừa nhập
                            int now = dgv_thuoc.CurrentCell.RowIndex;
                            int k = int.Parse(dgv_thuoc.Rows[now].Cells[0].Value.ToString());//lấy số thứ tự hiện tại trên datagridview
                            string MaThuoc = THUOC_BUS.LoadThuoc().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                            //cập nhật thông tin vài database
                            THUOC_DTO Thuoc = new THUOC_DTO(txt_ten.Text, txt_gia.Text, txt_soluong.Text);
                            THUOC_BUS.SuaThuoc(Thuoc, MaThuoc);
                            //cập nhật thông tin lại database
                            string ten = txt_ten.Text;
                            dgv_thuoc.Rows[now].Cells[1].Value = txt_ten.Text;
                            dgv_thuoc.Rows[now].Cells[2].Value = txt_soluong.Text;
                            dgv_thuoc.Rows[now].Cells[3].Value = txt_gia.Text;
                            string thongtin = "> Cập nhật thuốc " + ten + " thành thuốc " + txt_ten.Text + " có số lượng " + txt_soluong.Text + " với mức giá " + txt_gia.Text + " vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                            THONGTIN_BUS.ThemThongTin(thongtin);
                            XoaTrangO();
                            timer1.Start();
                            timer1.Enabled = true;
                            lbl_thongbao.ForeColor = Color.Red;
                            lbl_thongbao.Text = "Cập nhật thành công!";
                            timer1_Tick(sender, e);
                            thaydoi = 1;//xóa hết thông tin trên các  textbox
                        }
                    }
                    else
                        if (Check() == 1)//nếu còn ô trống
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txt_ten.Text == "")
                        {
                            txt_ten.Focus();
                        }
                        else
                            if (txt_soluong.Text == "")
                        {
                            txt_soluong.Focus();
                        }
                        else
                            txt_gia.Focus();
                    }
                    else
                            if (Check() == 2)//có số trong ten
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số trong ô số lượng, xin kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_soluong.Focus();
                    }
                    else
                                if (Check() == 3)//ngày khám nhỏ hơn ngày sinh
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số trong ô giá, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_gia.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn thuốc cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Đã có lỗi xảy ra, xin thao tác lại sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_capnhat_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_capnhat_MouseHover(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_2));
        }
        private void rd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_thuoc.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_thuoc.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        int k = int.Parse(dgv_thuoc.Rows[now].Cells[0].Value.ToString());
                        foreach (DataGridViewRow row in dgv_thuoc.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_thuoc.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        string MaThuoc = THUOC_BUS.LoadThuoc().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                        THUOC_BUS.XoaThuoc(MaThuoc);//xóa thông tin bệnh nhân trong database
                        string thongtin = "> Xóa thuốc " + dgv_thuoc.Rows[now].Cells[1].Value.ToString() + " ra khỏi danh sách thuốc vào lúc " + DateTime.Now.ToShortTimeString() + " ngày " + DateTime.Now.ToShortDateString() + ".";
                        THONGTIN_BUS.ThemThongTin(thongtin);
                        dgv_thuoc.Rows.RemoveAt(now);//xóa thông tin trên database
                        SoLuong--;
                        dgv_thuoc.CurrentCell.Selected = false;
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        XoaTrangO();
                        thaydoi = 1;
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn thuốc cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//có lỗi xảy ra
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Loại thuốc này đang sử dụng, không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_xoa_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_2));
        }
        private void rd_xoa_MouseHover(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void rd_xoa_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa));
        }
        private void rd_them_MouseEnter(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_capnhat_MouseEnter(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_xoa_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
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
