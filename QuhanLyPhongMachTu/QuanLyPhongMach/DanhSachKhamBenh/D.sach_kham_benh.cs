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
using System.Data;

namespace QuhanLyPhongMachTu
{
    public partial class D : UserControl
    {
        public int thaydoi;
        private int dem = 2;
        public D()
        {
            InitializeComponent();
        }
        //kiểm tra các lỗi xảy ra
        public int Check()
        {
            //có số trong tên
            string s = txt_hoten.Text;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                    return 2;
            }
            //còn ô trống
            if (txt_hoten.Text == "" || txt_diachi.Text == "")
            {
                return 1;
            }
            //ngày khám nhỏ hơn ngày sinh
            if (dt_ngaykham.Value < dt_ngaysinh.Value)
            {
                return 3;
            }
            return 0;//nếu không có lỗi
        }
        private void D_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true && Visible == true)
                {
                    thaydoi = 0;
                    txt_hoten.Focus();
                    cbo_gioitinh.SelectedItem = cbo_gioitinh.Items[0];
                    cbo_gioitinh.Text = cbo_gioitinh.SelectedItem.ToString();
                    dt_ngaykham.Value = DateTime.Today;
                    dt_ngaysinh.Value = DateTime.Today;
                }
            }
            catch (Exception ex)
            { }
        }
        private void D_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true)
                {
                    thaydoi = 0;
                    txt_hoten.Focus();
                    LoadData();
                    cbo_gioitinh.SelectedItem = cbo_gioitinh.Items[0];
                    cbo_gioitinh.Text = cbo_gioitinh.SelectedItem.ToString();
                    dt_ngaykham.Value = DateTime.Today;
                    dt_ngaysinh.Value = DateTime.Today;
                }
                else
                {
                    int k = dgv_danhsach.Rows.Count;
                    for (int i = 1; i < k; i++)
                        dgv_danhsach.Rows.RemoveAt(0);
                    txt_diachi.Text = "";
                    txt_hoten.Text = "";
                    txt_ma.Text = "";
                    cbo_gioitinh.Text = "";
                    dt_ngaykham.Text = "";
                    dt_ngaysinh.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }
        public void LoadData()
        {
            //load dữ liệu vào datagridview
            int chiso = dgv_danhsach.Rows.Count;
            foreach (DataRow row in DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows)
            {
                if (row[0].ToString() != "")
                {
                    ThemHang(chiso, row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    chiso++;
                }
            }
            XoaTrangO();
        }
        //thêm một hàng vào datagridview
        private void ThemHang(int n, string hoten, string gioitinh, string ngaysinh, string ngaykham, string diachi)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = hoten;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = gioitinh;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = Convert.ToDateTime(ngaysinh).Date.ToShortDateString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = Convert.ToDateTime(ngaykham).Date.ToShortDateString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = diachi;
            temp.Cells.Add(cell);
            dgv_danhsach.Rows.Add(temp);

        }
        private void D_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();//laod dữ liệu vào datagridview
                dgv_danhsach.ReadOnly = true;
                dgv_danhsach.CurrentCell.Selected = false;
                XoaTrangO();
                lbl_thongbao1.ForeColor = Color.Red;
                lbl_thongbao1.Visible = false;
                thaydoi = 0;
            }
            catch (Exception ex)//không load được database
            { }
        }
        //xóa toàn bộ dữ liệu hiện có trong các textbox
        private void XoaTrangO()
        {
            dgv_danhsach.CurrentCell.Selected = false;
            int MaBN;
            txt_diachi.Text = "";
            txt_hoten.Text = "";
            cbo_gioitinh.SelectedItem = cbo_gioitinh.Items[0];
            cbo_gioitinh.Text = cbo_gioitinh.SelectedItem.ToString();
            dt_ngaykham.Value = DateTime.Now.Date;
            dt_ngaysinh.Value = DateTime.Now.Date;
            int k = DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows.Count;
            if (k > 0)
                MaBN = (int)DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows[k - 1][0];
            else
                MaBN = 0;
            MaBN++;
            if (MaBN < 10)
                txt_ma.Text = "BN00" + MaBN.ToString();
            else
                if (MaBN < 100 && MaBN >= 10)
                txt_ma.Text = "BN0" + MaBN.ToString();
            else
                    if (MaBN >= 100)
                txt_ma.Text = "BN" + MaBN.ToString();
            txt_hoten.Focus();
        }
        private void dgv_danhsach_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lấy mã của bệnh nhân hiện tại
                int k = dgv_danhsach.CurrentCell.RowIndex;
                int MaBN = (int)DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows[k][0];
                if (MaBN < 10)
                    txt_ma.Text = "BN00" + MaBN.ToString();
                else
                    if (MaBN < 100 && MaBN >= 10)
                    txt_ma.Text = "BN0" + MaBN.ToString();
                else
                        if (MaBN >= 100)
                    txt_ma.Text = "BN" + MaBN.ToString();
                //load dữ liệu từ dòng đang chọn lên các control phía trên
                txt_hoten.Text = dgv_danhsach.Rows[k].Cells[1].Value.ToString();
                cbo_gioitinh.Text = dgv_danhsach.Rows[k].Cells[2].Value.ToString();
                txt_diachi.Text = dgv_danhsach.Rows[k].Cells[5].Value.ToString();
                dt_ngaysinh.Value = Convert.ToDateTime(dgv_danhsach.Rows[k].Cells[3].Value.ToString());
                dt_ngaykham.Value = Convert.ToDateTime(dgv_danhsach.Rows[k].Cells[4].Value.ToString());
                txt_hoten.Focus();//di chuyển con trỏ đến ô họ tên
            }
            catch (Exception ex)
            { }
        }
        private void grp_nhapdulieu_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_danhsach.CurrentCell.Selected = false;
                //bỏ chọn dòng hiện tại trên datagridview
                XoaTrangO();
            }
            catch (Exception ex)
            { }
        }
        private void txt_hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_diachi.Focus();
            }
        }
        private void txt_diachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbo_gioitinh.Focus();
            }
        }
        private void cbo_gioitinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dt_ngaysinh.Focus();
            }
        }
        private int dem_enter = 0;
        private void dt_ngaysinh_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dem_enter++;
                if (dem_enter % 3 == 0)
                    dt_ngaykham.Focus();
            }
        }
        private void rd_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_danhsach.Rows.Count - 1 < QUYDINH_BUS.BenhNhanToiDa())
                {
                    if (Check() == 0)//nếu không có lỗi
                    {
                        //thêm hàng vào csdl
                        DANHSACHBENHNHAN_DTO ds = new DANHSACHBENHNHAN_DTO(txt_hoten.Text, cbo_gioitinh.Text, dt_ngaysinh.Text, txt_diachi.Text, dt_ngaykham.Text);
                        DANHSACHBENHNHAN_BUS.ThemBenhNhan(ds);
                        ThemHang(dgv_danhsach.Rows.Count, txt_hoten.Text, cbo_gioitinh.Text, dt_ngaysinh.Text, dt_ngaykham.Text, txt_diachi.Text);
                        XoaTrangO();//xóa hết các ô dữ liệu
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao1.ForeColor = Color.Red;
                        lbl_thongbao1.Text = "Thêm thành công!";
                        timer1_Tick(sender, e);
                        thaydoi = 1;
                    }
                    else
                        if (Check() == 1)//nếu còn ô trống
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txt_hoten.Text == "")
                        {
                            txt_hoten.Focus();
                        }
                        else
                            txt_diachi.Focus();
                    }
                    else
                            if (Check() == 2)//có số trong tên
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Trong tên không được có số, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_hoten.Focus();
                    }
                    else
                                if (Check() == 3)//ngày khám nhỏ hơn ngày sinh
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Ngày khám bệnh không được nhỏ hơn ngày sinh, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dt_ngaykham.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Phòng khám đã đạt số bệnh nhân tối đa, xin quay lại vào hôm sau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    XoaTrangO();
                    txt_hoten.Focus();
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_them_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_3));
        }
        private void rd_them_MouseHover(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_1));
        }
        private void rd_them_MouseLeave(object sender, EventArgs e)
        {
            this.rd_them.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_1));
        }
        private void rd_capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_danhsach.CurrentCell.Selected == true)
                {
                    if (Check() == 0)//không có lỗi
                    {
                        //chắc chắn muốn thay đổi thông tin bệnh nhân đã chọn
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //cập nhật thông tin vừa nhập
                            int now = dgv_danhsach.CurrentCell.RowIndex;//lấy số thứ tự hiện tại trên datagridview
                            int k = int.Parse(dgv_danhsach.Rows[now].Cells[0].Value.ToString());
                            string MaBN = DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                            //cập nhật thông tin vài database
                            DANHSACHBENHNHAN_DTO ds = new DANHSACHBENHNHAN_DTO(txt_hoten.Text, cbo_gioitinh.Text, dt_ngaysinh.Text, txt_diachi.Text, dt_ngaykham.Text);
                            DANHSACHBENHNHAN_BUS.SuaBenhNhan(ds, MaBN);
                            //cập nhật thông tin lại database
                            dgv_danhsach.Rows[now].Cells[1].Value = txt_hoten.Text;
                            dgv_danhsach.Rows[now].Cells[2].Value = cbo_gioitinh.Text;
                            dgv_danhsach.Rows[now].Cells[3].Value = dt_ngaysinh.Value.ToShortDateString();
                            dgv_danhsach.Rows[now].Cells[4].Value = dt_ngaykham.Value.ToShortDateString();
                            dgv_danhsach.Rows[now].Cells[5].Value = txt_diachi.Text;
                            dgv_danhsach.CurrentCell.Selected = false;
                            XoaTrangO();//xóa hết thông tin trên các  textbox
                            timer1.Start();
                            timer1.Enabled = true;
                            lbl_thongbao1.ForeColor = Color.Red;
                            lbl_thongbao1.Text = "Cập nhật thành công!";
                            timer1_Tick(sender, e);
                            thaydoi = 1;
                        }
                    }
                    else//nếu có lỗi
                        if (Check() == 1)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ dữ liệu, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txt_hoten.Text == "")
                        {
                            txt_hoten.Focus();
                        }
                        else
                            txt_diachi.Focus();
                    }
                    else
                            if (Check() == 2)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Trong tên không được có số, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_hoten.Focus();
                    }
                    else
                                if (Check() == 3)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Ngày khám bệnh không được nhỏ hơn ngày sinh, xin hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dt_ngaykham.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn bệnh nhân cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)//nếu không lưu được
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Đã có lỗi xảy ra, xin thao tác lại sau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_capnhat_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseHover(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_danhsach.CurrentCell.Selected == true)
                {
                    //có chắc chắn muốn xóa không
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa bệnh nhân đã chọn không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int now = dgv_danhsach.CurrentCell.RowIndex;//lấy số thứ tự cua dòng
                        foreach (DataGridViewRow row in dgv_danhsach.Rows)
                        {
                            if (row.Cells[0].Value != null)
                                if (int.Parse(row.Cells[0].Value.ToString()) > int.Parse(dgv_danhsach.Rows[now].Cells[0].Value.ToString()))
                                {
                                    row.Cells[0].Value = (int.Parse(row.Cells[0].Value.ToString()) - 1).ToString();
                                }
                        }
                        int k = int.Parse(dgv_danhsach.Rows[now].Cells[0].Value.ToString());
                        string MaBN = DANHSACHBENHNHAN_BUS.LoadDanhSachHienTai().Rows[k - 1][0].ToString();//lấy mã bệnh nhân
                        DANHSACHBENHNHAN_BUS.XoaBenhNhan(MaBN);//xóa thông tin bệnh nhân trong database
                        dgv_danhsach.Rows.RemoveAt(now);//xóa thông tin trên database
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao1.ForeColor = Color.Red;
                        lbl_thongbao1.Text = "Xóa thành công!";
                        timer1_Tick(sender, e);
                        XoaTrangO();
                        thaydoi = 1;
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn bênh nhân cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Người này đã khám bệnh, không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_xoa_MouseLeave(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa));
        }
        private void rd_xoa_MouseHover(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void rd_xoa_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_2));
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_thongbao1.Visible = true;
            dem = dem - 1;
            if (dem == 0)
            {
                timer1.Stop();
                timer1.Enabled = false;
                lbl_thongbao1.Visible = false;
                dem = 2;
            }
        }
    }
}
