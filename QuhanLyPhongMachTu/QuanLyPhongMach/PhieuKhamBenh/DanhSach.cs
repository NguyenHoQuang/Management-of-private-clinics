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

namespace QuhanLyPhongMachTu.QuanLyPhongMach.PhieuKhamBenh
{
    public partial class DanhSach : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int vitri;
        public DanhSach()
        {
            InitializeComponent();
        }
        public DanhSach(int n)
        {
            InitializeComponent();
            vitri = n;
        }
        public void LoadBenh()
        {
            int k = dgv_benh.Rows.Count;
            for (int i = 1; i < k; i++)
                dgv_benh.Rows.RemoveAt(0);
            foreach (DataRow row in BENH_BUS.LoadBenh().Rows)
            {
                dgv_benh.Rows.Add(dgv_benh.Rows.Count.ToString(), row[1].ToString());
            }
        }
        public void LoadThuoc()
        {
            int k = dgv_thuoc.Rows.Count;
            for (int i = 1; i < k; i++)
                dgv_thuoc.Rows.RemoveAt(0);
            foreach (DataRow row in THUOC_BUS.LoadThuoc().Rows)
            {
                dgv_thuoc.Rows.Add(dgv_thuoc.Rows.Count.ToString(), row[1].ToString());
            }
        }
        public void LoadDonVi()
        {
            int k = dgv_donvi.Rows.Count;
            for (int i = 1; i < k; i++)
                dgv_donvi.Rows.RemoveAt(0);
            foreach (DataRow row in DONVI_BUS.LoadDonVi().Rows)
            {
                dgv_donvi.Rows.Add(dgv_donvi.Rows.Count.ToString(), row[1].ToString());
            }
        }
        public void LoadCachDung()
        {
            int k = dgv_cachdung.Rows.Count;
            for (int i = 1; i < k; i++)
                dgv_cachdung.Rows.RemoveAt(0);
            foreach (DataRow row in CACHDUNG_BUS.LoadCachDung().Rows)
            {
                dgv_cachdung.Rows.Add(dgv_cachdung.Rows.Count.ToString(), row[1].ToString());
            }
        }
        private void DanhSach_Load(object sender, EventArgs e)
        {
            LoadBenh();
            LoadThuoc();
            LoadDonVi();
            LoadCachDung();
            if (vitri == 1)
            {
                tab_quanly.SelectedTab = dsbenh;
            }
            else
                if (vitri == 2)
            {
                tab_quanly.SelectedTab = dsthuoc;
            }
            else
                    if (vitri == 3)
            {
                tab_quanly.SelectedTab = dsdonvi;
            }
            else
                        if (vitri == 4)
            {
                tab_quanly.SelectedTab = dscachdung;
            }
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_benh.Text != "")
                {
                    foreach (DataGridViewRow row in dgv_benh.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            string s1 = txt_benh.Text.ToLower();
                            string s = row.Cells[1].Value.ToString().ToLower();
                            if (s.IndexOf(s1) != -1)
                            {
                                row.Visible = true;
                            }
                            else
                                row.Visible = false; ;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgv_benh.Rows)
                        row.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }
        private void txt_thuoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_thuoc.Text != "")
                {
                    foreach (DataGridViewRow row in dgv_thuoc.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            string s1 = txt_thuoc.Text.ToLower();
                            string s = row.Cells[1].Value.ToString().ToLower();
                            if (s.IndexOf(s1) != -1)
                            {
                                row.Visible = true;
                            }
                            else
                                row.Visible = false; ;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgv_thuoc.Rows)
                        row.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }
        private void txt_donvi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_donvi.Text != "")
                {
                    foreach (DataGridViewRow row in dgv_donvi.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            string s1 = txt_donvi.Text.ToLower();
                            string s = row.Cells[1].Value.ToString().ToLower();
                            if (s.IndexOf(s1) != -1)
                            {
                                row.Visible = true;
                            }
                            else
                                row.Visible = false; ;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgv_donvi.Rows)
                        row.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }
        private void txt_cachdung_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_cachdung.Text != "")
                {
                    foreach (DataGridViewRow row in dgv_cachdung.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            string s1 = txt_cachdung.Text.ToLower();
                            string s = row.Cells[1].Value.ToString().ToLower();
                            if (s.IndexOf(s1) != -1)
                            {
                                row.Visible = true;
                            }
                            else
                                row.Visible = false; ;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgv_cachdung.Rows)
                        row.Visible = true;
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgv_benh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
