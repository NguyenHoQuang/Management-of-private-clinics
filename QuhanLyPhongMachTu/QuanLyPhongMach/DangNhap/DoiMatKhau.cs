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

namespace QuhanLyPhongMachTu.QuanLyPhongMach
{
    public partial class DoiMatKhau : DevComponents.DotNetBar.Metro.MetroForm
    {
        private string ten;
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(string taikhoan)
        {
            InitializeComponent();
            ten = taikhoan;
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
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_cu.UseSystemPasswordChar = true;
            txt_moi.UseSystemPasswordChar = true;
            txt_remoi.UseSystemPasswordChar = true;
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
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_capnhat_Click(object sender, EventArgs e)
        {
            if (txt_cu.Text == "" || txt_moi.Text == "" || txt_remoi.Text == "")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập đủ dữ liệu kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txt_cu.Text == "")
                {
                    txt_cu.Focus();
                }
                else
                    if (txt_moi.Text == "")
                {
                    txt_moi.Focus();
                }
                else
                        if (txt_remoi.Text == "")
                {
                    txt_remoi.Focus();
                }
            }
            else
            {
                if (DANGNHAP_BUS.TrangThai(ten, md5(txt_cu.Text)) == 0)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Mật khẩu hiện tại không đúng, kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_cu.Focus();
                }
                else
                {
                    if (txt_moi.Text != txt_remoi.Text)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Mật khẩu mới và mật khẩu nhập lại không khớp!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_remoi.Focus();
                    }
                    else
                    {
                        DANGNHAP_BUS.CapNhatMatKhau(ten, md5(txt_moi.Text));
                        this.Close();
                    }
                }
            }
        }
    }
}
