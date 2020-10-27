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
using DevComponents.Editors;
using DTO;
using BUS;

namespace QuhanLyPhongMachTu
{
    public partial class PhieuKhamBenh : UserControl
    {
        public int thuoc;
        public int donvi;
        public int cachdung;
        public int benh;
        public int danhsach;
        private int n;
        private int luu;
        private int dem = 2;
        public PhieuKhamBenh()
        {
            InitializeComponent();
        }
        public bool CheckBenh()
        {
            int k = txt_dudoan.AutoCompleteCustomSource.Count;
            for (int i = 0; i < k; i++)
                if (txt_dudoan.Text.ToLower() == txt_dudoan.AutoCompleteCustomSource[i].ToLower())
                    return true;
            return false;
        }
        public bool CheckCachDung()
        {
            int k = cbo_cachdung.AutoCompleteCustomSource.Count;
            for (int i = 0; i < k; i++)
                if (cbo_cachdung.Text.ToLower() == cbo_cachdung.AutoCompleteCustomSource[i].ToLower())
                    return true;
            return false;
        }
        public bool CheckThuoc()
        {
            int k = txt_thuoc.AutoCompleteCustomSource.Count;
            for (int i = 0; i < k; i++)
                if (txt_thuoc.Text.ToLower() == txt_thuoc.AutoCompleteCustomSource[i].ToLower())
                    return true;
            return false;
        }
        public bool CheckDonVi()
        {
            int k = cbo_donvi.AutoCompleteCustomSource.Count;
            for (int i = 0; i < k; i++)
                if (cbo_donvi.Text.ToLower() == cbo_donvi.AutoCompleteCustomSource[i].ToLower())
                    return true;
            return false;
        }
        public int CheckSoLuong()
        {
            //kiem tra rong
            if (txt_soluong.Text == "")
                return 3;
            //kiem tra co ky tu khac so
            for (int i = 0; i < txt_soluong.Text.Length; i++)
                if (txt_soluong.Text[i] < '0' || txt_soluong.Text[i] > '9')
                    return 2;
            //kiem tra so luong nhap vao
            int k = CT_PHIEUKHAMBENH_BUS.CheckSoLuongThuoc(txt_thuoc.Text, int.Parse(txt_soluong.Text));
            if (k == 1)
                return 1;
            return 0;
        }
        public void LoadData()
        {
            //load dữ liệu vào datagridview
            int chiso = dgv_danhsachck.Rows.Count;
            foreach (DataRow row in PHIEUKHAMBENH_BUS.LoadChoKham().Rows)
            {
                ThemHang(chiso, row[1].ToString());
                chiso++;
            }
        }
        public void LoadDataDaKham()
        {
            //load benh nhan da kham
            int chiso = dgv_danhsachdk.Rows.Count;
            foreach (DataRow row in PHIEUKHAMBENH_BUS.LoadDaKham().Rows)
            {
                ThemHangDaKham(chiso, row[1].ToString());
                chiso++;
            }
        }
        public void XuLyMaBN(int n)
        {
            if (n < 10)
                txt_mabn.Text = "BN00" + n.ToString();
            else
                if (n < 100 && n >= 10)
                txt_mabn.Text = "BN0" + n.ToString();
            else
                    if (n >= 100)
                txt_mabn.Text = "BN" + n.ToString();
        }
        public void LoadThuoc()
        {
            int k = txt_thuoc.AutoCompleteCustomSource.Count;
            for (int i = 1; i <= k; i++)
                txt_thuoc.AutoCompleteCustomSource.RemoveAt(0);
            foreach (DataRow row in THUOC_BUS.LoadThuoc().Rows)
            {
                txt_thuoc.AutoCompleteCustomSource.Add(row[1].ToString());
            }
        }
        public void LoadBenh()
        {
            int k = txt_trieuchung.AutoCompleteCustomSource.Count;
            for (int i = 1; i <= k; i++)
                txt_trieuchung.AutoCompleteCustomSource.RemoveAt(0);
            foreach (DataRow row in BENH_BUS.LoadBenh().Rows)
            {
                txt_dudoan.AutoCompleteCustomSource.Add(row[1].ToString());
            }
        }
        public void LoadDonVi()
        {
            int k = cbo_donvi.Items.Count;
            for (int i = 1; i <= k; i++)
            {
                cbo_donvi.Items.RemoveAt(0);
                cbo_donvi.AutoCompleteCustomSource.RemoveAt(0);
            }
            foreach (DataRow row in DONVI_BUS.LoadDonVi().Rows)
            {
                ComboItem cb = new ComboItem(row[1].ToString());
                cbo_donvi.Items.Add(cb);
                cbo_donvi.AutoCompleteCustomSource.Add(row[1].ToString());
            }
        }
        public void LoadCachDung()
        {
            int k = cbo_cachdung.Items.Count;
            for (int i = 1; i <= k; i++)
            {
                cbo_cachdung.AutoCompleteCustomSource.RemoveAt(0);
                cbo_cachdung.Items.RemoveAt(0);
            }
            foreach (DataRow row in CACHDUNG_BUS.LoadCachDung().Rows)
            {
                ComboItem cb = new ComboItem(row[1].ToString());
                cbo_cachdung.Items.Add(cb);
                cbo_cachdung.AutoCompleteCustomSource.Add(row[1].ToString());
            }
        }
        public void XoaTrangO()
        {
            try
            {
                dgv_thuoc.CurrentCell.Selected = false;
                txt_thuoc.Text = "";
                txt_soluong.Text = "";
                cbo_cachdung.SelectedItem = cbo_cachdung.Items[0];
                cbo_cachdung.Text = cbo_cachdung.SelectedItem.ToString();
                cbo_donvi.SelectedItem = cbo_donvi.Items[0];
                cbo_donvi.Text = cbo_donvi.SelectedItem.ToString();
                txt_thuoc.Focus();
            }
            catch (Exception ex)
            { }
        }
        private void ThemHang(int n, string ten)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = ten;
            temp.Cells.Add(cell);
            dgv_danhsachck.Rows.Add(temp);
        }
        private void ThemHangDaKham(int n, string ten)
        {
            DataGridViewRow temp = new DataGridViewRow();
            DataGridViewCell cell;
            cell = new DataGridViewTextBoxCell();
            cell.Value = n.ToString();
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = ten;
            temp.Cells.Add(cell);
            dgv_danhsachdk.Rows.Add(temp);
        }
        private void ThemHangThuoc(int n, string tenthuoc, string donvi, string soluong, string cachdung)
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
            cell.Value = donvi;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = soluong;
            temp.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            cell.Value = cachdung;
            temp.Cells.Add(cell);
            dgv_thuoc.Rows.Add(temp);
        }
        private void PhieuKhamBenh_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible == true && Enabled == true)
                {
                    dgv_danhsachck.ReadOnly = true;
                    dgv_thuoc.ReadOnly = true;
                    if (benh == 1)
                    {
                        LoadBenh();
                        benh = 0;
                    }
                    if (cachdung == 1)
                    {
                        LoadCachDung();
                        cachdung = 0;
                    }
                    if (donvi == 1)
                    {
                        LoadDonVi();
                        donvi = 0;
                    }
                    if (thuoc == 1)
                    {
                        LoadThuoc();
                        thuoc = 0;
                    }
                    if (danhsach == 1)
                    {
                        dgv_danhsachck.SelectionChanged -= dgv_danhsachck_SelectionChanged;
                        n = dgv_danhsachck.Rows.Count;
                        for (int i = 1; i < n; i++)
                            dgv_danhsachck.Rows.RemoveAt(0);
                        LoadData();
                        dgv_danhsachck.CurrentCell.Selected = false;
                        dgv_danhsachck.SelectionChanged += dgv_danhsachck_SelectionChanged;
                        danhsach = 0;
                    }
                    if (luu == 1)
                    {
                        dgv_danhsachdk.SelectionChanged -= dgv_danhsachdk_SelectionChanged;
                        n = dgv_danhsachdk.Rows.Count;
                        for (int i = 1; i < n; i++)
                            dgv_danhsachdk.Rows.RemoveAt(0);
                        LoadDataDaKham();
                        dgv_danhsachck.CurrentCell.Selected = false;
                        dgv_danhsachdk.SelectionChanged += dgv_danhsachdk_SelectionChanged;
                        luu = 0;
                    }
                    cbo_cachdung.SelectedItem = cbo_cachdung.Items[0];
                    cbo_cachdung.Text = cbo_cachdung.SelectedItem.ToString();
                    cbo_donvi.SelectedItem = cbo_donvi.Items[0];
                    cbo_donvi.Text = cbo_donvi.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            { }
        }
        private void PhieuKhamBenh_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                if (Enabled == true)
                {
                    dgv_danhsachck.ReadOnly = true;
                    dgv_thuoc.ReadOnly = true;
                    dgv_danhsachck.Rows[0].Cells[0].Selected = true;
                    if (benh == 1)
                        LoadBenh();
                    if (cachdung == 1)
                        LoadCachDung();
                    if (donvi == 1)
                        LoadDonVi();
                    if (thuoc == 1)
                        LoadThuoc();
                    n = dgv_danhsachck.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_danhsachck.Rows.RemoveAt(0);
                    LoadData();
                    n = dgv_danhsachdk.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_danhsachdk.Rows.RemoveAt(0);
                    LoadDataDaKham();
                    dgv_danhsachck.CurrentCell = dgv_danhsachck.Rows[0].Cells[0];
                    dgv_danhsachck_SelectionChanged(sender, e);
                    cbo_cachdung.SelectedItem = cbo_cachdung.Items[0];
                    cbo_cachdung.Text = cbo_cachdung.SelectedItem.ToString();
                    cbo_donvi.SelectedItem = cbo_donvi.Items[0];
                    cbo_donvi.Text = cbo_donvi.SelectedItem.ToString();
                }
                else
                {
                    int k = dgv_danhsachck.Rows.Count;
                    for (int i = 1; i < k; i++)
                        dgv_danhsachck.Rows.RemoveAt(0);
                    k = dgv_danhsachdk.Rows.Count; ;
                    for (int i = 1; i < k; i++)
                        dgv_danhsachdk.Rows.RemoveAt(0);
                    k = dgv_thuoc.Rows.Count;
                    for (int i = 1; i < k; i++)
                        dgv_thuoc.Rows.RemoveAt(0);
                    txt_diachi.Text = "";
                    txt_dudoan.Text = "";
                    txt_mabn.Text = "";
                    txt_soluong.Text = "";
                    txt_tenck.Text = "";
                    txt_tendk.Text = "";
                    txt_thuoc.Text = "";
                    txt_trieuchung.Text = "";
                    dt_ngaysinh.Text = "";
                    cbo_cachdung.Text = "";
                    cbo_donvi.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }
        private void lbl_ten_Click(object sender, EventArgs e)
        {

        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (txt_tenck.Text != "")
            {
                foreach (DataGridViewRow row in dgv_danhsachck.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string s1 = txt_tenck.Text.ToLower();
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
                foreach (DataGridViewRow row in dgv_danhsachck.Rows)
                    row.Visible = true;
            }
        }
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void PhieuKhamBenh_Load(object sender, EventArgs e)
        {
            LoadBenh();
            LoadCachDung();
            LoadData();
            LoadDataDaKham();
            LoadDonVi();
            LoadThuoc();
            lbl_thongbao.Visible = false;
        }
        private void dgv_danhsachck_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int now = dgv_danhsachck.CurrentCell.RowIndex;
                int k = int.Parse(dgv_danhsachck.Rows[now].Cells[0].Value.ToString());
                int MaBenhNhan = int.Parse(PHIEUKHAMBENH_BUS.LoadChoKham().Rows[k - 1][0].ToString());
                XuLyMaBN(MaBenhNhan);
                dt_ngaysinh.Value = Convert.ToDateTime(PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][0].ToString());
                txt_diachi.Text = PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][1].ToString();
                int n = dgv_thuoc.Rows.Count;
                for (int i = 1; i < n; i++)
                    dgv_thuoc.Rows.RemoveAt(0);
                txt_dudoan.Text = "";
                txt_trieuchung.Text = "";
                txt_thuoc.Text = "";
                txt_soluong.Text = "";
                cbo_cachdung.SelectedItem = cbo_cachdung.Items[0];
                cbo_cachdung.Text = cbo_cachdung.SelectedItem.ToString();
                cbo_donvi.SelectedItem = cbo_donvi.Items[0];
                cbo_donvi.Text = cbo_donvi.SelectedItem.ToString();
            }
            catch (Exception ex)
            { }
        }
        private void txt_trieuchung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txt_trieuchung.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống ô, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_trieuchung.Focus();
                }
                else
                {
                    txt_dudoan.Focus();
                }
            }
        }
        private void txt_dudoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_dudoan.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống ô, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_dudoan.Focus();
                }
                else
                {
                    if (CheckBenh() == false)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Bệnh vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_dudoan.Focus();
                    }
                    else
                        txt_thuoc.Focus();
                }
            }
        }
        private void txt_thuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_thuoc.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống ô, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_thuoc.Focus();
                }
                else
                {
                    if (CheckThuoc() == false)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Loại thuốc vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_thuoc.Focus();
                    }
                    else
                        cbo_donvi.Focus();
                }
            }
        }
        private void cbo_donvi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbo_donvi.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống ô, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_donvi.Focus();
                }
                else
                {
                    if (CheckDonVi() == false)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Loại đơn vị vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbo_donvi.Focus();
                    }
                    else
                        txt_soluong.Focus();
                }
            }
        }
        private void txt_soluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_thuoc.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập loại thuốc!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_thuoc.Focus();
                }
                else
                {
                    if (CheckSoLuong() == 1)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Số lượng vừa nhập vượt quá còn lại, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_soluong.Focus();
                    }
                    else
                    {
                        if (CheckSoLuong() == 2)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_soluong.Focus();
                        }
                        else
                            if (CheckSoLuong() == 3)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show("Không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_soluong.Focus();
                        }
                        cbo_cachdung.Focus();
                    }
                }
            }
        }
        private void txt_thuoc_Leave(object sender, EventArgs e)
        {
            if (txt_thuoc.Text != "")
                if (CheckThuoc() == false)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Loại thuốc vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_thuoc.Focus();
                }
        }
        private void txt_dudoan_Leave(object sender, EventArgs e)
        {
            if (txt_dudoan.Text != "")
            {
                if (CheckBenh() == false)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bệnh vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_dudoan.Focus();
                }
            }
        }
        private void cbo_donvi_Leave(object sender, EventArgs e)
        {
            if (cbo_donvi.Text != "")
            {
                if (CheckDonVi() == false)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Loại đơn vị vừa nhập không có trong danh sách của phòng khám, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_donvi.Focus();
                }
            }
            if (cbo_donvi.Text == "")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập đơn vị!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_donvi.Focus();
            }
        }
        private void txt_soluong_Leave(object sender, EventArgs e)
        {
            if (txt_soluong.Text != "")
            {
                if (txt_thuoc.Text != "")
                {
                    if (CheckSoLuong() == 1)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Số lượng vừa nhập vượt quá còn lại, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_soluong.Focus();
                    }
                    else
                        if (CheckSoLuong() == 2)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Có ký tự khác số, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_soluong.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập loại thuốc!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_thuoc.Focus();
                }
            }
        }
        private void cbo_cachdung_Leave(object sender, EventArgs e)
        {
            if (cbo_cachdung.Text != "")
            {
                if (CheckCachDung() == false)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Cách dùng này hiện tại không có, hãy kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_cachdung.Focus();
                }
            }
            if (cbo_cachdung.Text == "")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập cách dùng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_cachdung.Focus();
            }
        }
        private void dgv_thuoc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (tcl_chokham.IsSelected == true)
                {
                    int k = dgv_thuoc.CurrentCell.RowIndex;
                    txt_thuoc.Text = dgv_thuoc.Rows[k].Cells[1].Value.ToString();
                    cbo_donvi.Text = dgv_thuoc.Rows[k].Cells[2].Value.ToString();
                    txt_soluong.Text = dgv_thuoc.Rows[k].Cells[3].Value.ToString();
                    cbo_cachdung.Text = dgv_thuoc.Rows[k].Cells[4].Value.ToString();
                    txt_thuoc.Focus();
                }
                if (tcl_dakham.IsSelected == true)
                {
                    txt_thuoc.Text = "";
                    cbo_donvi.Text = "";
                    txt_soluong.Text = "";
                    cbo_cachdung.Text = "";
                }
            }
            catch (Exception ex)
            { }
        }
        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            try
            {
                if (tcl_dakham.IsSelected == true)
                {
                    dgv_danhsachck.SelectionChanged -= dgv_danhsachck_SelectionChanged;
                    grp_khambenh.Enabled = false;
                    if (luu == 1)
                    {
                        int n = dgv_danhsachdk.Rows.Count;
                        dgv_danhsachdk.SelectionChanged -= dgv_danhsachdk_SelectionChanged;
                        for (int i = 1; i < n; i++)
                            dgv_danhsachdk.Rows.RemoveAt(0);
                        dgv_danhsachdk.ReadOnly = true;
                        LoadDataDaKham();
                        dgv_danhsachdk.SelectionChanged += dgv_danhsachdk_SelectionChanged;
                        luu = 0;
                    }
                    XoaTrangO();
                    int k = dgv_thuoc.Rows.Count;
                    for (int i = 1; i < k; i++)
                        dgv_thuoc.Rows.RemoveAt(0);
                    dgv_danhsachdk.CurrentCell.Selected = false;
                    txt_diachi.Text = "";
                    txt_mabn.Text = "";
                    txt_tenck.Text = "";
                    txt_trieuchung.Text = "";
                    txt_dudoan.Text = "";
                    dt_ngaysinh.Text = "";
                    dgv_danhsachdk.SelectionChanged += dgv_danhsachdk_SelectionChanged;
                }
                if (tcl_chokham.IsSelected == true)
                {
                    dgv_danhsachdk.SelectionChanged -= dgv_danhsachdk_SelectionChanged;
                    grp_khambenh.Enabled = true;
                    XoaTrangO();
                    int k = dgv_thuoc.Rows.Count;
                    for (int i = 1; i < k; i++)
                        dgv_thuoc.Rows.RemoveAt(0);
                    txt_diachi.Text = "";
                    txt_mabn.Text = "";
                    txt_tenck.Text = "";
                    txt_dudoan.Text = "";
                    txt_trieuchung.Text = "";
                    dt_ngaysinh.Text = "";
                    dgv_danhsachck.CurrentCell.Selected = false;
                    dgv_danhsachck.SelectionChanged += dgv_danhsachck_SelectionChanged;
                }
            }
            catch (Exception ex)
            { }
        }
        private void dgv_danhsachdk_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int chiso = 1;
                int n = dgv_thuoc.Rows.Count;
                for (int i = 1; i < n; i++)
                    dgv_thuoc.Rows.RemoveAt(0);
                int now = dgv_danhsachdk.CurrentCell.RowIndex;
                int k = int.Parse(dgv_danhsachdk.Rows[now].Cells[0].Value.ToString());
                int MaBenhNhan = int.Parse(PHIEUKHAMBENH_BUS.LoadDaKham().Rows[k - 1][0].ToString());
                XuLyMaBN(MaBenhNhan);
                dt_ngaysinh.Value = Convert.ToDateTime(PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][0].ToString());
                txt_diachi.Text = PHIEUKHAMBENH_BUS.HienThongTin(MaBenhNhan).Rows[0][1].ToString();
                foreach (DataRow row in CT_PHIEUKHAMBENH_BUS.LoadThongTin(int.Parse(PHIEUKHAMBENH_BUS.LoadDaKham().Rows[k - 1][2].ToString())).Rows)
                {
                    txt_trieuchung.Text = row[1].ToString();
                    txt_dudoan.Text = row[0].ToString();
                    ThemHangThuoc(chiso, row[2].ToString(), row[3].ToString(), row[5].ToString(), row[4].ToString());
                }
            }
            catch (Exception ex)
            { }
        }
        private void txt_tendk_TextChanged(object sender, EventArgs e)
        {
            if (txt_tendk.Text != "")
            {
                foreach (DataGridViewRow row in dgv_danhsachdk.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string s1 = txt_tendk.Text.ToLower();
                        string s = row.Cells[1].Value.ToString().ToLower();
                        if (s.IndexOf(s1) != -1)
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_danhsachdk.Rows)
                    row.Visible = true;
            }
        }
        private void radialMenu1_Click(object sender, EventArgs e)
        {
            if (txt_dudoan.Text != "" && txt_soluong.Text != "" && txt_trieuchung.Text != "" && txt_thuoc.Text != "" && CheckSoLuong() != 1)
            {
                int chiso = dgv_thuoc.Rows.Count;
                ThemHangThuoc(chiso, txt_thuoc.Text, cbo_donvi.Text, txt_soluong.Text, cbo_cachdung.Text);
                XoaTrangO();
                timer1.Start();
                timer1.Enabled = true;
                lbl_thongbao.ForeColor = Color.Red;
                lbl_thongbao.Text = "Thêm thành công";
                timer1_Tick(sender, e);
            }
            else
            {
                if (CheckSoLuong() == 1)
                    DevComponents.DotNetBar.MessageBoxEx.Show("Số lượng thuốc vượt quá số lượng còn lại, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập đầy đủ dữ liệu, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txt_trieuchung.Text == "")
                        txt_trieuchung.Focus();
                    else
                        if (txt_dudoan.Text == "")
                        txt_trieuchung.Focus();
                    else
                            if (txt_thuoc.Text == "")
                        txt_thuoc.Focus();
                    else
                                if (txt_soluong.Text == "")
                        txt_soluong.Focus();
                }
            }
        }
        private void radialMenu1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_themthuoc.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_3));
        }
        private void radialMenu1_MouseHover(object sender, EventArgs e)
        {
            this.rd_themthuoc.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void radialMenu1_MouseLeave(object sender, EventArgs e)
        {
            this.rd_themthuoc.Image = ((System.Drawing.Image)(Properties.Resources.btn_them_2));
        }
        private void radialMenu2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_thuoc.CurrentCell.Selected == true)
                {
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn thay đổi thông tin không?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int k = dgv_thuoc.CurrentCell.RowIndex;
                        dgv_thuoc.Rows[k].Cells[1].Value = txt_thuoc.Text;
                        dgv_thuoc.Rows[k].Cells[2].Value = cbo_donvi.Text;
                        dgv_thuoc.Rows[k].Cells[3].Value = txt_soluong.Text;
                        dgv_thuoc.Rows[k].Cells[4].Value = cbo_cachdung.Text;
                        XoaTrangO();
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Sửa thành công";
                        timer1_Tick(sender, e);
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập đầy đủ dữ liệu, xin kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txt_trieuchung.Text == "")
                            txt_trieuchung.Focus();
                        else
                            if (txt_dudoan.Text == "")
                            txt_trieuchung.Focus();
                        else
                                if (txt_thuoc.Text == "")
                            txt_thuoc.Focus();
                        else
                                    if (txt_soluong.Text == "")
                            txt_soluong.Focus();
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn thuốc cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập dữ liệu, không thể cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rd_capnhat_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_1));
        }
        private void rd_capnhat_MouseLeave(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat_2));
        }
        private void rd_capnhat_MouseHover(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_thuoc.CurrentCell.Selected == true)
                {
                    if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn xóa không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int k = dgv_thuoc.CurrentCell.RowIndex;
                        dgv_thuoc.Rows.RemoveAt(k);
                        XoaTrangO();
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Xóa thành công";
                        timer1_Tick(sender, e);
                    }
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa chọn thuốc cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập dữ liệu, không thể xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void rd_luu_Click(object sender, EventArgs e)
        {
            if (dgv_thuoc.Rows.Count > 0)
            {
                int now = dgv_danhsachck.CurrentCell.RowIndex;
                int k = int.Parse(dgv_thuoc.Rows[now].Cells[0].Value.ToString());
                int MaBN = int.Parse(PHIEUKHAMBENH_BUS.LoadChoKham().Rows[k - 1][0].ToString());
                int MaBE = HAMPHU_BUS.FMaBenh(txt_dudoan.Text);
                PHIEUKHAMBENH_DTO PKB = new PHIEUKHAMBENH_DTO(MaBN, MaBE, txt_trieuchung.Text);
                PHIEUKHAMBENH_BUS.ThemPhieuKhamBenh(PKB);
                foreach (DataGridViewRow row in dgv_thuoc.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        int MaTH = HAMPHU_BUS.FMaThuoc(row.Cells[1].Value.ToString());
                        int MaDV = HAMPHU_BUS.FMaDonVi(row.Cells[2].Value.ToString());
                        int MaCD = HAMPHU_BUS.FMaCachDung(row.Cells[4].Value.ToString());
                        int MaPK = HAMPHU_BUS.FMaPhieuKham(MaBN, MaBE);
                        CT_PHIEUKHAMBENH_DTO CTPKB = new CT_PHIEUKHAMBENH_DTO(MaPK, MaTH, MaDV, int.Parse(row.Cells[3].Value.ToString()), MaCD);
                        CT_PHIEUKHAMBENH_BUS.ThemChiTiet(CTPKB);
                    }
                }
                HOADON_BUS.TaoHoaDon(MaBN);
                CTHD_BUS.TaoCTHoaDon(MaBN);
                int n = dgv_danhsachck.Rows.Count;
                for (int i = 1; i < n; i++)
                    dgv_danhsachck.Rows.RemoveAt(0);
                LoadData();
                dgv_danhsachck_SelectionChanged(sender, e);
                luu = 1;
                rd_luu_MouseLeave(sender, e);
                timer1.Start();
                timer1.Enabled = true;
                lbl_thongbao.ForeColor = Color.Red;
                lbl_thongbao.Text = "Lưu thành công";
                timer1_Tick(sender, e);
            }
            else
            {
                if (txt_trieuchung.Text == "" || txt_dudoan.Text == "")
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập đầy đủ thông tin của một phiếu khám bệnh!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txt_trieuchung.Text == "")
                        txt_trieuchung.Focus();
                    else
                        txt_dudoan.Focus();
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Bạn chưa nhập chi tiết phiếu khám bệnh!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_thuoc.Focus();
                }
            }
        }
        private void rd_luu_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_update_2));
        }
        private void rd_luu_MouseHover(object sender, EventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_update_1));
        }
        private void rd_luu_MouseLeave(object sender, EventArgs e)
        {
            this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_update));
        }
        private void rd_themthuoc_MouseEnter(object sender, EventArgs e)
        {
            this.rd_themthuoc.Image = ((System.Drawing.Image)(Properties.Resources.btn_them));
        }
        private void rd_capnhat_MouseEnter(object sender, EventArgs e)
        {
            this.rd_capnhat.Image = ((System.Drawing.Image)(Properties.Resources.btn_capnhat));
        }
        private void rd_xoa_MouseEnter(object sender, EventArgs e)
        {
            this.rd_xoa.Image = ((System.Drawing.Image)(Properties.Resources.btn_xoa_1));
        }
        private void rd_luu_MouseEnter(object sender, EventArgs e)
        {
           this.rd_luu.Image = ((System.Drawing.Image)(Properties.Resources.btn_update_1));
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
        private void lbl_dsbenh_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_dsbenh.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }
        private void lbl_dsbenh_MouseEnter(object sender, EventArgs e)
        {
            lbl_dsbenh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsbenh_MouseHover(object sender, EventArgs e)
        {
            lbl_dsbenh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsbenh_MouseLeave(object sender, EventArgs e)
        {
            lbl_dsbenh.BackColor = Color.White;
        }
        private void lbl_dsbenh_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.PhieuKhamBenh.DanhSach temp = new QuanLyPhongMach.PhieuKhamBenh.DanhSach(1);
            temp.ShowDialog();
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_dsthuoc.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            lbl_dsthuoc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsthuoc_MouseHover(object sender, EventArgs e)
        {
            lbl_dsthuoc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsthuoc_MouseLeave(object sender, EventArgs e)
        {
            lbl_dsthuoc.BackColor = Color.White;
        }
        private void lbl_dsthuoc_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.PhieuKhamBenh.DanhSach temp = new QuanLyPhongMach.PhieuKhamBenh.DanhSach(2);
            temp.ShowDialog();
        }
        private void lbl_dsdonvi_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_dsdonvi.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }
        private void lbl_dsdonvi_MouseEnter(object sender, EventArgs e)
        {
            lbl_dsdonvi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsdonvi_MouseHover(object sender, EventArgs e)
        {
            lbl_dsdonvi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        private void lbl_dsdonvi_MouseLeave(object sender, EventArgs e)
        {
            lbl_dsdonvi.BackColor = Color.White;
        }
        private void lbl_dsdonvi_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.PhieuKhamBenh.DanhSach temp = new QuanLyPhongMach.PhieuKhamBenh.DanhSach(3);
            temp.ShowDialog();
        }

        private void label1_MouseDown_1(object sender, MouseEventArgs e)
        {
            lbl_dscachdung.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void label1_MouseEnter_1(object sender, EventArgs e)
        {
            lbl_dscachdung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            lbl_dscachdung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lbl_dscachdung.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            QuanLyPhongMach.PhieuKhamBenh.DanhSach temp = new QuanLyPhongMach.PhieuKhamBenh.DanhSach(4);
            temp.ShowDialog();
        }

        private void dgv_danhsachck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_thuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
