namespace QuhanLyPhongMachTu.QuanLyPhongMach
{
    partial class Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grp_dangnhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbl_thongbao = new System.Windows.Forms.Label();
            this.btn_dangnhap = new DevComponents.DotNetBar.ButtonX();
            this.txt_matkhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_taikhoan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_matkhau = new System.Windows.Forms.Label();
            this.lbl_ten = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tt_doimk = new System.Windows.Forms.ToolTip(this.components);
            this.tt_taikhoan = new System.Windows.Forms.ToolTip(this.components);
            this.tt_matkhau = new System.Windows.Forms.ToolTip(this.components);
            this.grp_dangnhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_dangnhap
            // 
            this.grp_dangnhap.BackColor = System.Drawing.Color.Transparent;
            this.grp_dangnhap.CanvasColor = System.Drawing.Color.Transparent;
            this.grp_dangnhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.grp_dangnhap.Controls.Add(this.lbl_thongbao);
            this.grp_dangnhap.Controls.Add(this.btn_dangnhap);
            this.grp_dangnhap.Controls.Add(this.txt_matkhau);
            this.grp_dangnhap.Controls.Add(this.txt_taikhoan);
            this.grp_dangnhap.Controls.Add(this.lbl_matkhau);
            this.grp_dangnhap.Controls.Add(this.lbl_ten);
            this.grp_dangnhap.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp_dangnhap.Location = new System.Drawing.Point(308, 18);
            this.grp_dangnhap.Name = "grp_dangnhap";
            this.grp_dangnhap.Size = new System.Drawing.Size(219, 145);
            // 
            // 
            // 
            this.grp_dangnhap.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.grp_dangnhap.Style.BackColor2 = System.Drawing.Color.SkyBlue;
            this.grp_dangnhap.Style.BackColorGradientAngle = 90;
            this.grp_dangnhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_dangnhap.Style.BorderBottomWidth = 1;
            this.grp_dangnhap.Style.BorderColor = System.Drawing.SystemColors.Highlight;
            this.grp_dangnhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_dangnhap.Style.BorderLeftWidth = 1;
            this.grp_dangnhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_dangnhap.Style.BorderRightWidth = 1;
            this.grp_dangnhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_dangnhap.Style.BorderTopWidth = 1;
            this.grp_dangnhap.Style.CornerDiameter = 4;
            this.grp_dangnhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp_dangnhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp_dangnhap.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp_dangnhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp_dangnhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp_dangnhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp_dangnhap.TabIndex = 0;
            this.grp_dangnhap.Text = "Đăng nhập";
            // 
            // lbl_thongbao
            // 
            this.lbl_thongbao.AutoSize = true;
            this.lbl_thongbao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_thongbao.Location = new System.Drawing.Point(23, 79);
            this.lbl_thongbao.Name = "lbl_thongbao";
            this.lbl_thongbao.Size = new System.Drawing.Size(213, 13);
            this.lbl_thongbao.TabIndex = 5;
            this.lbl_thongbao.Text = "Tài khoản hoặc mật khẩu không chính xác";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_dangnhap.BackColor = System.Drawing.Color.White;
            this.btn_dangnhap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_dangnhap.Location = new System.Drawing.Point(70, 96);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(75, 23);
            this.btn_dangnhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btn_dangnhap.TabIndex = 4;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_matkhau.Border.Class = "TextBoxBorder";
            this.txt_matkhau.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_matkhau.DisabledBackColor = System.Drawing.Color.White;
            this.txt_matkhau.ForeColor = System.Drawing.Color.Black;
            this.txt_matkhau.Location = new System.Drawing.Point(61, 54);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.PreventEnterBeep = true;
            this.txt_matkhau.Size = new System.Drawing.Size(149, 20);
            this.txt_matkhau.TabIndex = 3;
            this.tt_taikhoan.SetToolTip(this.txt_matkhau, "Mật khẩu tài khoản");
            this.txt_matkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_matkhau_KeyDown);
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_taikhoan.Border.Class = "TextBoxBorder";
            this.txt_taikhoan.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_taikhoan.DisabledBackColor = System.Drawing.Color.White;
            this.txt_taikhoan.ForeColor = System.Drawing.Color.Black;
            this.txt_taikhoan.Location = new System.Drawing.Point(61, 20);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.PreventEnterBeep = true;
            this.txt_taikhoan.Size = new System.Drawing.Size(149, 20);
            this.txt_taikhoan.TabIndex = 2;
            this.tt_taikhoan.SetToolTip(this.txt_taikhoan, "Tên đăng nhập");
            this.txt_taikhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_taikhoan_KeyDown);
            // 
            // lbl_matkhau
            // 
            this.lbl_matkhau.AutoSize = true;
            this.lbl_matkhau.Location = new System.Drawing.Point(1, 56);
            this.lbl_matkhau.Name = "lbl_matkhau";
            this.lbl_matkhau.Size = new System.Drawing.Size(56, 13);
            this.lbl_matkhau.TabIndex = 1;
            this.lbl_matkhau.Text = "Mật Khẩu:";
            // 
            // lbl_ten
            // 
            this.lbl_ten.AutoSize = true;
            this.lbl_ten.Location = new System.Drawing.Point(1, 23);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(59, 13);
            this.lbl_ten.TabIndex = 0;
            this.lbl_ten.Text = "Tài Khoản:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.grp_dangnhap);
            this.DoubleBuffered = true;
            this.Name = "Home";
            this.Size = new System.Drawing.Size(810, 480);
            this.Load += new System.EventHandler(this.Home_Load);
            this.VisibleChanged += new System.EventHandler(this.Home_VisibleChanged);
            this.grp_dangnhap.ResumeLayout(false);
            this.grp_dangnhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grp_dangnhap;
        private DevComponents.DotNetBar.ButtonX btn_dangnhap;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_matkhau;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_taikhoan;
        private System.Windows.Forms.Label lbl_matkhau;
        private System.Windows.Forms.Label lbl_ten;


        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_thongbao;
        private System.Windows.Forms.ToolTip tt_taikhoan;
        private System.Windows.Forms.ToolTip tt_doimk;
        private System.Windows.Forms.ToolTip tt_matkhau;
    }
}
