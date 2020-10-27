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

namespace QuhanLyPhongMachTu
{
    public partial class TimTheoNgay : UserControl
    {
        private int dem = 2;
        public TimTheoNgay()
        {
            InitializeComponent();
        }
        private int Check()
        {
            if (txt_ten.Text == "")
                return 1;
            for (int i = 0; i < txt_ten.Text.Length; i++)
                if (txt_ten.Text[i] >= '0' && txt_ten.Text[i] <= '9')
                    return 2;
            return 0;
        }
        private void TimTheoNgay_Load(object sender, EventArgs e)
        {
            grp_timten_Click_1(sender, e);
        }

        private void grp_timngay_Click_1(object sender, EventArgs e)
        {
            dt_ngaykham.Enabled = true;
            dt_ngaykham.Focus();
            dt_ngaykham.Value = DateTime.Now.Date;
            lbl_ngay.Enabled = true;
            rd_timngay.Enabled = true;
            txt_ten.Enabled = false;
            lbl_ten.Enabled = false;
            rd_timten.Enabled = false;
            grp_timngay.Style.BackgroundImage = null;
            grp_timten.Style.BackgroundImage = null;
            int n = dgv_thongtin.Rows.Count;
            for (int i = 1; i < n; i++)
                dgv_thongtin.Rows.RemoveAt(0);
        }
        private void grp_timten_Click_1(object sender, EventArgs e)
        {
            dt_ngaykham.Enabled = false;
            dt_ngaykham.Text = "";
            lbl_ngay.Enabled = false;
            rd_timngay.Enabled = false;
            txt_ten.Enabled = true;
            lbl_ten.Enabled = true;
            rd_timten.Enabled = true;
            grp_timngay.Style.BackgroundImage = null;
            grp_timten.Style.BackgroundImage = null;
            int n = dgv_thongtin.Rows.Count;
            for (int i = 1; i < n; i++)
                dgv_thongtin.Rows.RemoveAt(0);
            txt_ten.Focus();
        }

        private void TimTheoNgay_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled == true)
            {
                grp_timten_Click_1(sender, e);
                txt_ten.Focus();
            }
            else
            {
                grp_timngay.Style.BackgroundImage = null;
                grp_timten.Style.BackgroundImage = null;
                int n = dgv_thongtin.Rows.Count;
                for (int i = 1; i < n; i++)
                    dgv_thongtin.Rows.RemoveAt(0);
            }
        }
        private void txt_ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rd_timten_Click(sender, e);
        }
        private void dt_ngaykham_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rd_timngay_Click(sender, e);
            }
        }
        private void rd_timten_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check() == 0)
                {
                    int n = dgv_thongtin.Rows.Count;
                    for (int i = 1; i < n; i++)
                        dgv_thongtin.Rows.RemoveAt(0);
                    if (TIMKIEM_BUS.TimTen(txt_ten.Text).Rows.Count == 0)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Không có bệnh nhân nào có tên bắt đầu hoặc chứa từ này,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_ten.Focus();
                    }
                    else
                    {
                        int chiso = 1;
                        foreach (DataRow row in TIMKIEM_BUS.TimTen(txt_ten.Text).Rows)
                        {
                            DataGridViewRow temp = new DataGridViewRow();
                            DataGridViewCell cell;
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = chiso.ToString();
                            temp.Cells.Add(cell);
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = row[0].ToString();
                            temp.Cells.Add(cell);
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = Convert.ToDateTime(row[1].ToString()).Date.ToShortDateString();
                            temp.Cells.Add(cell);
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = row[2].ToString();
                            temp.Cells.Add(cell);
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = row[3].ToString();
                            temp.Cells.Add(cell);
                            dgv_thongtin.Rows.Add(temp);
                            chiso++;
                        }
                        timer1.Start();
                        timer1.Enabled = true;
                        lbl_thongbao.ForeColor = Color.Red;
                        lbl_thongbao.Text = "Tìm thành công";
                        timer1_Tick(sender, e);
                        txt_ten.Text = "";
                    }

                }
                else
                    if (Check() == 1)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Chưa nhập họ tên cần tìm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten.Focus();
                }
                else
                        if (Check() == 2)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Trong tên không có số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ten.Focus();
                }
            }
            catch (Exception ex)
            { }
        }
        private void rd_timten_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_2));
        }
        private void rd_timten_MouseHover(object sender, EventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_1));
        }
        private void rd_timten_MouseLeave(object sender, EventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim));
        }
        private void rd_timngay_Click(object sender, EventArgs e)
        {
            try
            {
                int n = dgv_thongtin.Rows.Count;
                for (int i = 1; i < n; i++)
                    dgv_thongtin.Rows.RemoveAt(0);
                int chiso = 1;
                if (TIMKIEM_BUS.TimNgay(Convert.ToDateTime(dt_ngaykham.Value.ToString())).Rows.Count == 0)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Không bệnh nhân nào khám vào ngày này!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dt_ngaykham.Focus();
                }
                foreach (DataRow row in TIMKIEM_BUS.TimNgay(Convert.ToDateTime(dt_ngaykham.Value.ToString())).Rows)
                {
                    DataGridViewRow temp = new DataGridViewRow();
                    DataGridViewCell cell;
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = chiso.ToString();
                    temp.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = row[0].ToString();
                    temp.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = Convert.ToDateTime(row[1].ToString()).Date.ToShortDateString();
                    temp.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = row[2].ToString();
                    temp.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = row[3].ToString();
                    temp.Cells.Add(cell);
                    dgv_thongtin.Rows.Add(temp);
                    chiso++;
                }
                timer1.Start();
                timer1.Enabled = true;
                lbl_thongbao.ForeColor = Color.Red;
                lbl_thongbao.Text = "Tìm thành công";
                timer1_Tick(sender, e);
                txt_ten.Text = "";
            }
            catch (Exception ex)
            { }
        }
        private void rd_timngay_MouseDown(object sender, MouseEventArgs e)
        {
            this.rd_timngay.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_2));
        }
        private void rd_timngay_MouseHover(object sender, EventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_1));
        }
        private void rd_timngay_MouseLeave(object sender, EventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim));
        }
        private void rd_timten_MouseEnter(object sender, EventArgs e)
        {
            this.rd_timten.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_1));
        }
        private void rd_timngay_MouseEnter(object sender, EventArgs e)
        {
            this.rd_timngay.Image = ((System.Drawing.Image)(Properties.Resources.btn_tim_1));
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

        private void dgv_thongtin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
