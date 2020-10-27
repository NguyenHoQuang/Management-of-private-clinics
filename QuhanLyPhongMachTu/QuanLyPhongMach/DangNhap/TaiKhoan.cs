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

namespace QuhanLyPhongMachTu.QuanLyPhongMach.DangNhap
{
    public partial class TaiKhoan : UserControl
    {
        private int dem = 2;
        int loai;
        public TaiKhoan()
        {
            InitializeComponent();
        }
        private void ThemHang(int n, string loai, string ten, string matkhau)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = loai;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = ten;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = matkhau;
            temp.Cells.Add(cell);
            dgv_taikhoan.Rows.Add(temp);

        }
        private void XoaTrangO()
        {
            dgv_taikhoan.CurrentCell.Selected = false;
            cb_loai.SelectedItem = cb_loai.Items[0];
            cb_loai.Text = cb_loai.SelectedItem.ToString();
            txt_ten.Enabled = true;
            txt_ten.Text = "";
            txt_matkhau.Text = "";
            txt_ten.Focus();
        }
        public int Check()
        {
            if (txt_matkhau.Text == "" || txt_ten.Text == "" || cb_loai.Text == "")
                return 1;
            if (cb_loai.AutoCompleteCustomSource.IndexOf(cb_loai.Text) == -1)
                return 2;
            foreach (DataGridViewRow row in dgv_taikhoan.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if (row.Cells[2].Value.ToString() == txt_ten.Text)
                        return 3;
                }
            }
            return 0;
        }
        public void LoadData()
        {
            int n = dgv_taikhoan.Rows.Count;
            for (int i = 1; i < n; i++)
                dgv_taikhoan.Rows.RemoveAt(0);
            //load dữ liệu vào datagridview
            int chiso = 1;
            string Loai;
            foreach (DataRow row in DANGNHAP_BUS.LoadTaiKhoan().Rows)
            {
                if (row[0].ToString() != "")
                {
                    if (row[0].ToString() == "1")
                        Loai = "Admin";
                    else
                        if (row[0].ToString() == "2")
                        Loai = "Bác Sĩ";
                    else
                        Loai = "Nhân viên";
                    ThemHang(chiso, Loai, row[1].ToString(), row[2].ToString());
                    chiso++;
                }
            }
            XoaTrangO();
        }
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }
        private void TaiKhoan_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true)
                {
                    LoadData();
                    XoaTrangO();
                }
                else
                    if (Enabled == false)
                {
                    cb_loai.Text = "";
                    txt_ten.Text = "";
                    txt_matkhau.Text = "";
                    dgv_taikhoan.SelectionChanged -= dgv_taikhoan_SelectionChanged;
                    int n = dgv_taikhoan.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_taikhoan.Rows.RemoveAt(0);
                    dgv_taikhoan.SelectionChanged += dgv_taikhoan_SelectionChanged;
                }
            }
            catch (Exception ex)
            { }
        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
        }
        private void dgv_taikhoan_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_taikhoan.CurrentCell.Value != null)
                {
                    int k = dgv_taikhoan.CurrentCell.RowIndex;
                    //load dữ liệu từ dòng đang chọn lên các control phía trên
                    cb_loai.Text = dgv_taikhoan.Rows[k].Cells[1].Value.ToString();
                    txt_ten.Text = dgv_taikhoan.Rows[k].Cells[2].Value.ToString();
                    txt_ten.Enabled = false;
                    txt_matkhau.Text = "";
                    cb_loai.Focus();//di chuyển con trỏ đến ô họ tên
                }
            }
            catch (Exception ex)
            { }
        }
        private void cb_loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ten.Focus();
            }
        }
        private void txt_ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_matkhau.Focus();
            }
        }
        private void TaiKhoan_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible == true && Enabled == true)
                {
                    LoadData();
                    XoaTrangO();
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_them_ItemClick(object sender, EventArgs e)
        {

        }
        private void rd_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)//nếu không có lỗi
                {
                    //thêm hàng vào csdl
                    if (cb_loai.Text == "Admin")
                        loai = 1;
                    else
                        if (cb_loai.Text == "Bác Sĩ")
                        loai = 2;
                    else
                            if (cb_loai.Text == "Nhân viên")
                        loai = 3;
                    string matkhau = md5(txt_matkhau.Text);
                    DANGNHAP_DTO TaiKhoan = new DANGNHAP_DTO(loai, txt_ten.Text, matkhau);
                    DANGNHAP_BUS.ThemTaiKhoan(TaiKhoan);
                    ThemHang(dgv_taikhoan.Rows.Count, cb_loai.Text, txt_ten.Text, matkhau);
                    timer1.Start();
                    timer1.Enabled = true;
                    lbl_thongbao.ForeColor = Color.Red;
                    lbl_thongbao.Text = "Thêm thành công!";
                    timer1_Tick(sender, e);
                    XoaTrangO();//xóa hết các ô dữ liệu
                }
                else
                    if (Check() == 1)//nếu còn ô trống
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (cb_loai.Text == "")
                        cb_loai.Focus();
                    if (txt_ten.Text == "")
                    {
                        txt_ten.Focus();
                    }
                    else
                        txt_matkhau.Focus();
                }
                else
                        if (Check() == 2)//có số trong tên
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không có loại tài khoản vừa nhập, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_loai.Focus();
                }
                else
                            if (Check() == 3)//ngày khám nhỏ hơn ngày sinh
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bị trùng tên đăng nhập, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void rd_capnhat_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv_taikhoan.CurrentCell.Selected == true)
                {
                    if (sender.ToString() == "Cả hai")
                    {
                        if (Check() == 3)//không có lỗi
                        {
                            //chắc chắn muốn thay đổi thông tin bệnh nhân đã chọn
                            if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn cập nhật tài khoản không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                string matkhau;
                                //cập nhật thông tin vừa nhập
                                int now = dgv_taikhoan.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                                int k = int.Parse(dgv_taikhoan.Rows[now].Cells[0].Value.ToString());
                                string TenTaiKhoan = DANGNHAP_BUS.LoadTaiKhoan().Rows[k - 1][1].ToString();//lấy mã bệnh nhân
                                //cập nhật thông tin vài database
                                if (cb_loai.Text == "Admin")
                                    loai = 1;
                                else
                                    if (cb_loai.Text == "Bác Sĩ")
                                    loai = 2;
                                else
                                        if (cb_loai.Text == "Nhân viên")
                                    loai = 3;
                                matkhau = md5(txt_matkhau.Text);
                                DANGNHAP_DTO TaiKhoan = new DANGNHAP_DTO(loai, TenTaiKhoan, matkhau);
                                DANGNHAP_BUS.CapNhatTaiKhoan(TaiKhoan);
                                //cập nhật thông tin lại database
                                dgv_taikhoan.Rows[now].Cells[1].Value = cb_loai.Text;
                                dgv_taikhoan.Rows[now].Cells[2].Value = txt_ten.Text;
                                dgv_taikhoan.Rows[now].Cells[3].Value = txt_matkhau.Text;
                                timer1.Start();
                                timer1.Enabled = true;
                                lbl_thongbao.ForeColor = Color.Red;
                                lbl_thongbao.Text = "Cập nhật thành công!";
                                timer1_Tick(sender, e);
                                dgv_taikhoan.CurrentCell.Selected = false;
                                XoaTrangO();//xóa hết thông tin trên các  textbox
                            }
                        }
                        else
                            if (Check() == 1)//nếu còn ô trống
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (cb_loai.Text == "")
                                cb_loai.Focus();
                            if (txt_ten.Text == "")
                            {
                                txt_ten.Focus();
                            }
                            else
                                txt_matkhau.Focus();
                        }
                        else
                                if (Check() == 2)//có số trong tên
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Không có loại tài khoản vừa nhập, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb_loai.Focus();
                        }
                    }
                    if (sender.ToString() == "Loại")
                    {
                        if (cb_loai.Text != "" && cb_loai.AutoCompleteCustomSource.IndexOf(cb_loai.Text) != -1)
                        {
                            if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn cập nhật loại của tài khoản này không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //cập nhật thông tin vừa nhập
                                int now = dgv_taikhoan.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                                int k = int.Parse(dgv_taikhoan.Rows[now].Cells[0].Value.ToString());
                                string TenTaiKhoan = DANGNHAP_BUS.LoadTaiKhoan().Rows[k - 1][1].ToString();//lấy mã bệnh nhân
                                //cập nhật thông tin vài database
                                if (cb_loai.Text == "Admin")
                                    loai = 1;
                                else
                                    if (cb_loai.Text == "Bác Sĩ")
                                    loai = 2;
                                else
                                        if (cb_loai.Text == "Nhân viên")
                                    loai = 3;
                                DANGNHAP_BUS.CapNhatLoai(TenTaiKhoan, loai);
                                //cập nhật thông tin lại database
                                dgv_taikhoan.Rows[now].Cells[1].Value = cb_loai.Text;
                                dgv_taikhoan.Rows[now].Cells[2].Value = txt_ten.Text;
                                timer1.Start();
                                timer1.Enabled = true;
                                lbl_thongbao.ForeColor = Color.Red;
                                lbl_thongbao.Text = "Cập nhật thành công!";
                                timer1_Tick(sender, e);
                                dgv_taikhoan.CurrentCell.Selected = false;
                                XoaTrangO();//xóa hết thông tin trên các  textbox
                            }
                        }
                        else
                            if (cb_loai.Text == "")
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập loại tài khoản!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb_loai.Focus();
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Loại tài khoẳn vừa nhập không có trong danh sách, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb_loai.Focus();
                        }
                    }
                    else
                        if (sender.ToString() == "Mật khẩu")
                    {
                        if (txt_matkhau.Text != "")
                        {
                            if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn cập nhật mật khẩu của tài khoản này không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //cập nhật thông tin vừa nhập
                                int now = dgv_taikhoan.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                                int k = int.Parse(dgv_taikhoan.Rows[now].Cells[0].Value.ToString());
                                string TenTaiKhoan = DANGNHAP_BUS.LoadTaiKhoan().Rows[k - 1][1].ToString();//lấy mã bệnh nhân
                                                                                                           //cập nhật thông tin vài database
                                string matkhau;
                                matkhau = md5(txt_matkhau.Text);
                                DANGNHAP_BUS.CapNhatMatKhau(TenTaiKhoan, matkhau);
                                //cập nhật thông tin lại database
                                dgv_taikhoan.Rows[now].Cells[3].Value = matkhau;
                                dgv_taikhoan.Rows[now].Cells[2].Value = txt_ten.Text;
                                timer1.Start();
                                timer1.Enabled = true;
                                lbl_thongbao.ForeColor = Color.Red;
                                lbl_thongbao.Text = "Cập nhật thành công!";
                                timer1_Tick(sender, e);
                                dgv_taikhoan.CurrentCell.Selected = false;
                                XoaTrangO();//xóa hết thông tin trên các  textbox
                            }
                        }
                        else
                            if (txt_matkhau.Text == "")
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập mật khẩu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb_loai.Focus();
                        }
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn tài khoản cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_taikhoan.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa tài khoản đã chọn không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_taikhoan.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        foreach (DataGridViewRow row in dgv_taikhoan.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_taikhoan.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        int k = int.Parse(dgv_taikhoan.Rows[now].Cells[0].Value.ToString());
                        string TenBenhNhan = DANGNHAP_BUS.LoadTaiKhoan().Rows[k - 1][1].ToString();//lấy mã bệnh nhân
                        DANGNHAP_BUS.XoaTaiKhoan(TenBenhNhan);//xóa thông tin bệnh nhân trong database
                        dgv_taikhoan.Rows.RemoveAt(now);//xóa thông tin trên database
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        XoaTrangO();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa chọn tài khoản cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//có lỗi xảy ra
            {
            }
        }
        private void rd_them_MouseHover(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_them_MouseLeave(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_2));
        }
        private void rd_them_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_3));
        }
        private void rd_them_MouseUp(object sender, MouseEventArgs e)
        {
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
        private void rd_capnhat_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.rd_capnhat.IsOpen == false)
                this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseHover(object sender, EventArgs e)
        {
            this.rd_capnhat.Symbol = null;
            if (this.rd_capnhat.IsOpen == false)
                this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Symbol = null;
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_capnhat_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.rd_capnhat.IsOpen == true)
               this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_them_MouseEnter(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_capnhat_MouseEnter(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_xoa_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }

        private void grp_taikhoan_Click(object sender, EventArgs e)
        {
            XoaTrangO();
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

        private void dgv_taikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
