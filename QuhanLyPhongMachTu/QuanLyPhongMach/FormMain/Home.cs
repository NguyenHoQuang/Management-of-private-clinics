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

namespace QuhanLyPhongMachTu.QuanLyPhongMach
{
    public partial class Home : UserControl
    {
        public int login;
        private int k = 2;
        private List<String> A = new List<string>();
        private string ten;
        public Home()
        {
            InitializeComponent();
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
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string matkhau = md5(txt_matkhau.Text);
            login = DANGNHAP_BUS.TrangThai(txt_taikhoan.Text, matkhau);
            if (login != 0)
            {
                ten = txt_taikhoan.Text;
                ThongBao temp = new ThongBao(login);
                lbl_matkhau.BackColor = Color.Transparent;
                lbl_ten.BackColor = Color.Transparent;
                grp_dangnhap.BackColor = Color.Transparent;

                temp.ShowDialog();
                //lbl_loai.BackColor = Color.Transparent;
                //grp_thongtin.BackColor = Color.Transparent;
                //lbl_taikhoan.Text = "Tài khoản: " + txt_taikhoan.Text;
                //if (login == 1)
                //    lbl_loai.Text = "Loại tài khoản: Admin";
                //else
                //    if (login == 2)
                //        lbl_loai.Text = "Loại tài khoản: Bác Sĩ";
                //    else
                //        if (login == 3)
                //            lbl_loai.Text = "Loại tài khoản: Nhân viên";
                txt_taikhoan.Text = "";
                txt_matkhau.Text = "";
                //grp_thongtin.Visible = true;
                grp_dangnhap.Visible = false;
            }
            else
            {
                timer1.Start();
                timer1.Enabled = true;
                timer1_Tick(sender, e);
            }
        }
        private string DinhDangChuoi(string s)
        {
            if (s.Length > 157)
            {
                string s1 = "";
                for (int i = 0; i < 154; i++)
                    s1 = s1 + s[i];
                return s1 + "...";
            }
            else
                return s;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //grp_thongtin.Visible = false;
            //lbl_taikhoan.BackColor = Color.Transparent;
            //lbl_loai.BackColor = Color.Transparent;
            //grp_thongtin.BackColor = Color.Transparent;
            lbl_thongbao.BackColor = Color.Transparent;
            lbl_thongbao.Visible = false;
            lbl_thongbao.ForeColor = Color.Red;
            txt_matkhau.UseSystemPasswordChar = true;
            lbl_matkhau.BackColor = Color.Transparent;
            lbl_ten.BackColor = Color.Transparent;
            grp_dangnhap.BackColor = Color.Transparent;


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k >= 0)
                lbl_thongbao.Visible = true;
            k--;
            if (k == 0)
            {
                timer1.Enabled = false;
                timer1.Stop();
                lbl_thongbao.Visible = false;
                k = 2;
            }
        }
        private void txt_taikhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_dangnhap_Click(sender, e);
            }
        }
        private void txt_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_dangnhap_Click(sender, e);
            }
        }

        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.DoiMatKhau temp = new DoiMatKhau(ten);
            //lbl_taikhoan.BackColor = Color.Transparent;
            lbl_thongbao.ForeColor = Color.Red;
            //lbl_loai.BackColor = Color.Transparent;
            //grp_thongtin.BackColor = Color.Transparent;
            grp_dangnhap.BackColor = Color.Transparent;


            temp.ShowDialog();
        }

        private void Home_VisibleChanged(object sender, EventArgs e)
        {
            lbl_thongbao.BackColor = Color.Transparent;
            lbl_thongbao.ForeColor = Color.Red;
            txt_matkhau.UseSystemPasswordChar = true;
            lbl_matkhau.BackColor = Color.Transparent;
            lbl_ten.BackColor = Color.Transparent;
            grp_dangnhap.BackColor = Color.Transparent;


        }
        public void logout()
        {
            grp_dangnhap.Visible = true;
            //grp_thongtin.Visible = false;
        }
        public void DieuChinh()
        {
            //lbl_taikhoan.BackColor = Color.Transparent;
            //lbl_loai.BackColor = Color.Transparent;
            lbl_thongbao.ForeColor = Color.Red;
            //grp_thongtin.BackColor = Color.Transparent;
            lbl_matkhau.BackColor = Color.Transparent;
            lbl_ten.BackColor = Color.Transparent;
            grp_dangnhap.BackColor = Color.Transparent;
            grp_dangnhap.BackColor = Color.Transparent;


        }


    }
}
