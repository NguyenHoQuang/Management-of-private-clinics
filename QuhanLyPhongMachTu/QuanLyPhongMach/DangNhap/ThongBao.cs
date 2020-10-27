using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuhanLyPhongMachTu
{
    public partial class ThongBao : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int k = 10;
        private int loai;
        public ThongBao()
        {
            InitializeComponent();
        }
        public ThongBao(int n)
        {
            InitializeComponent();
            loai = n;
        }

        private void ThongBao_Load(object sender, EventArgs e)
        {
            if (loai == 1)
            {
                labelX1.Visible = true;
                labelX2.Visible = false;
                labelX3.Visible = false;
            }
            else
                if (loai == 2)
            {
                labelX1.Visible = false;
                labelX2.Visible = true;
                labelX3.Visible = false;
            }
            else
            {
                labelX1.Visible = false;
                labelX2.Visible = false;
                labelX3.Visible = true;
            }
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k != 0)
                k = k - 1;
            if (k == 0)
                this.Opacity = this.Opacity - 0.1;
            if (this.Opacity == 0)
            {
                timer1.Stop();
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
}
