using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QuhanLyPhongMachTu
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int dem = 1;
        private int baocao;
        private int tab;
        public Form1()
        {
            try
            {

                sqlConectionData.ConnectionString();
                InitializeComponent();
            }
            catch (Exception ex)
            { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                timer1_Tick(sender, e);
                this.Activated -= Form1_Activated;
                tab_phongmachtu.Text = "Hệ thống trang chủ";
                this.DoubleBuffered = true;
                //ẩn hiện các user control
                baocao = 1;
                this.btn_baocao.Image = ((System.Drawing.Image)(Properties.Resources.Date));
                d1.Visible = false;
                phieuKhamBenh1.Visible = false;
                timTheoNgay1.Visible = false;
                baoCaoNgay1.Visible = false;
                baoCaoSuDungThuoc1.Visible = false;
                quyDinh1.Visible = false;
                hoaDon1.Visible = false;
                home1.Visible = true;
                //tắt các user control
                d1.Enabled = false;
                phieuKhamBenh1.Enabled = false;
                timTheoNgay1.Enabled = false;
                baoCaoSuDungThuoc1.Enabled = false;
                baoCaoNgay1.Enabled = false;
                quyDinh1.Enabled = false;
                hoaDon1.Enabled = false;
                taiKhoan1.Enabled = false;
                taiKhoan1.Visible = false;
                //tắt các button
                btn_danhsach.Visible = false;
                btn_baocao.Visible = false;
                btn_hoadon.Visible = false;
                btn_phieukham.Visible = false;
                btn_quanly.Visible = false;
                btn_thaydoi.Visible = false;
                btn_tracuu.Visible = false;

                btn_dangnhap.Visible = false;
                tab = 1;
                this.Activate();
                //
                btn_home.Checked = true;
                btn_danhsach.Checked = false;
                btn_phieukham.Checked = false;
                btn_hoadon.Checked = false;
                btn_tracuu.Checked = false;
                btn_hoadon.Checked = false;
                btn_quanly.Checked = false;
                btn_thaydoi.Checked = false;
                btn_dangnhap.Checked = false;
            }
            catch (Exception ex)
            { }
        }
        private void btn_danhsach_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            tab_phongmachtu.Text = "Danh sách khám bệnh";
            phieuKhamBenh1.Visible = false;
            d1.Visible = true;
            hoaDon1.Visible = false;
            timTheoNgay1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            quyDinh1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = true;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
            tab = 2;
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btn_home = new DevComponents.DotNetBar.ButtonItem();
            this.btn_danhsach = new DevComponents.DotNetBar.ButtonItem();
            this.btn_phieukham = new DevComponents.DotNetBar.ButtonItem();
            this.btn_tracuu = new DevComponents.DotNetBar.ButtonItem();
            this.btn_hoadon = new DevComponents.DotNetBar.ButtonItem();
            this.btn_baocao = new DevComponents.DotNetBar.ButtonItem();
            this.btn_baocaongay = new DevComponents.DotNetBar.ButtonItem();
            this.bt_baocaothuoc = new DevComponents.DotNetBar.ButtonItem();
            this.btn_thaydoi = new DevComponents.DotNetBar.ButtonItem();
            this.btn_quanly = new DevComponents.DotNetBar.ButtonItem();
            this.btn_dangnhap = new DevComponents.DotNetBar.ButtonItem();
            this.tab_phongmachtu = new DevComponents.DotNetBar.TabItem(this.components);
            this.lbl_ad1 = new System.Windows.Forms.Label();
            this.lbl_ad2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.home1 = new QuhanLyPhongMachTu.QuanLyPhongMach.Home();
            this.taiKhoan1 = new QuhanLyPhongMachTu.QuanLyPhongMach.DangNhap.TaiKhoan();
            this.quyDinh1 = new QuhanLyPhongMachTu.QuyDinh();
            this.baoCaoSuDungThuoc1 = new QuhanLyPhongMachTu.BaoCaoSuDungThuoc();
            this.baoCaoNgay1 = new QuhanLyPhongMachTu.BaoCaoNgay();
            this.hoaDon1 = new QuhanLyPhongMachTu.HoaDon();
            this.timTheoNgay1 = new QuhanLyPhongMachTu.TimTheoNgay();
            this.phieuKhamBenh1 = new QuhanLyPhongMachTu.PhieuKhamBenh();
            this.d1 = new QuhanLyPhongMachTu.D();
            this.tt_help = new System.Windows.Forms.ToolTip(this.components);
            this.tt_mail = new System.Windows.Forms.ToolTip(this.components);
            this.tt_info = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.White;
            this.tabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.tabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(144)))), ((int)(((byte)(229))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.tabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(-6, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 121);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tab_phongmachtu);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.bar1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(816, 94);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tab_phongmachtu;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_home,
            this.btn_danhsach,
            this.btn_phieukham,
            this.btn_tracuu,
            this.btn_hoadon,
            this.btn_baocao,
            this.btn_thaydoi,
            this.btn_quanly,
            this.btn_dangnhap});
            this.bar1.Location = new System.Drawing.Point(4, 0);
            this.bar1.Name = "bar1";
            this.bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bar1.Size = new System.Drawing.Size(812, 87);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btn_home
            // 
            this.btn_home.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_home.Image = global::QuhanLyPhongMachTu.Properties.Resources.Home;
            this.btn_home.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_home.Name = "btn_home";
            this.btn_home.Text = "Trang Chủ";
            this.btn_home.Tooltip = "Trang chủ";
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_danhsach
            // 
            this.btn_danhsach.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btn_danhsach.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_danhsach.Image = ((System.Drawing.Image)(resources.GetObject("btn_danhsach.Image")));
            this.btn_danhsach.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_danhsach.Name = "btn_danhsach";
            this.btn_danhsach.Text = "D.sách khám bệnh";
            this.btn_danhsach.Tooltip = "Danh sách khám bệnh";
            this.btn_danhsach.Click += new System.EventHandler(this.btn_danhsach_Click);
            // 
            // btn_phieukham
            // 
            this.btn_phieukham.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btn_phieukham.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_phieukham.Image = global::QuhanLyPhongMachTu.Properties.Resources.Apps_preferences_contact_list_icon__Copy_;
            this.btn_phieukham.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_phieukham.Name = "btn_phieukham";
            this.btn_phieukham.Text = "Khám bệnh ";
            this.btn_phieukham.Tooltip = "Phiếu khám bệnh";
            this.btn_phieukham.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // btn_tracuu
            // 
            this.btn_tracuu.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.btn_tracuu.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_tracuu.Image = global::QuhanLyPhongMachTu.Properties.Resources.search_icon__Copy_;
            this.btn_tracuu.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_tracuu.Name = "btn_tracuu";
            this.btn_tracuu.Text = "Tìm Bệnh Nhân";
            this.btn_tracuu.Tooltip = "Tìm kiếm bệnh nhân";
            this.btn_tracuu.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // btn_hoadon
            // 
            this.btn_hoadon.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_hoadon.Image = global::QuhanLyPhongMachTu.Properties.Resources.Sales_bill__Copy_;
            this.btn_hoadon.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_hoadon.Name = "btn_hoadon";
            this.btn_hoadon.Text = "Hóa đơn";
            this.btn_hoadon.Tooltip = "Hóa đơn";
            this.btn_hoadon.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // btn_baocao
            // 
            this.btn_baocao.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_baocao.Image = global::QuhanLyPhongMachTu.Properties.Resources.Date;
            this.btn_baocao.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_baocao.Name = "btn_baocao";
            this.btn_baocao.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_baocaongay,
            this.bt_baocaothuoc});
            this.btn_baocao.Text = "Báo cáo ngày";
            this.btn_baocao.Tooltip = "Báo cáo";
            this.btn_baocao.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // btn_baocaongay
            // 
            this.btn_baocaongay.Name = "btn_baocaongay";
            this.btn_baocaongay.Symbol = "";
            this.btn_baocaongay.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_baocaongay.Text = "Báo cáo theo ngày";
            this.btn_baocaongay.Click += new System.EventHandler(this.btn_baocaongay_Click);
            // 
            // bt_baocaothuoc
            // 
            this.bt_baocaothuoc.Name = "bt_baocaothuoc";
            this.bt_baocaothuoc.Symbol = "";
            this.bt_baocaothuoc.SymbolColor = System.Drawing.Color.Green;
            this.bt_baocaothuoc.Text = "Báo cáo sử dụng thuốc";
            this.bt_baocaothuoc.Click += new System.EventHandler(this.bt_baocaothuoc_Click);
            // 
            // btn_thaydoi
            // 
            this.btn_thaydoi.Image = global::QuhanLyPhongMachTu.Properties.Resources.settings_3_icon__Copy_;
            this.btn_thaydoi.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_thaydoi.Name = "btn_thaydoi";
            this.btn_thaydoi.Text = "Thay đổi q.định";
            this.btn_thaydoi.Tooltip = "Thay đổi quy định";
            this.btn_thaydoi.Click += new System.EventHandler(this.btn_thaydoi_Click);
            // 
            // btn_quanly
            // 
            this.btn_quanly.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_quanly.Image = global::QuhanLyPhongMachTu.Properties.Resources.TaiKhoan;
            this.btn_quanly.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_quanly.Name = "btn_quanly";
            this.btn_quanly.Text = "Quản lý tài khoản";
            this.btn_quanly.Tooltip = "Quản lý tài khoản";
            this.btn_quanly.Click += new System.EventHandler(this.btn_quanly_Click);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Image = global::QuhanLyPhongMachTu.Properties.Resources.Staff;
            this.btn_dangnhap.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.Tooltip = "Đăng xuất";
            this.btn_dangnhap.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // tab_phongmachtu
            // 
            this.tab_phongmachtu.AttachedControl = this.tabControlPanel1;
            this.tab_phongmachtu.BackColor = System.Drawing.Color.Silver;
            this.tab_phongmachtu.Name = "tab_phongmachtu";
            this.tab_phongmachtu.Text = "Quản lý phòng mạch";
            // 
            // lbl_ad1
            // 
            this.lbl_ad1.Location = new System.Drawing.Point(0, 0);
            this.lbl_ad1.Name = "lbl_ad1";
            this.lbl_ad1.Size = new System.Drawing.Size(100, 23);
            this.lbl_ad1.TabIndex = 19;
            // 
            // lbl_ad2
            // 
            this.lbl_ad2.Location = new System.Drawing.Point(0, 0);
            this.lbl_ad2.Name = "lbl_ad2";
            this.lbl_ad2.Size = new System.Drawing.Size(100, 23);
            this.lbl_ad2.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(724, 633);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 13);
            this.label2.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.Color.Transparent;
            this.home1.BackgroundImage = global::QuhanLyPhongMachTu.Properties.Resources.background_login;
            this.home1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home1.ForeColor = System.Drawing.Color.Black;
            this.home1.Location = new System.Drawing.Point(0, 116);
            this.home1.Margin = new System.Windows.Forms.Padding(4);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(810, 501);
            this.home1.TabIndex = 10;
            this.home1.Load += new System.EventHandler(this.home1_Load);
            // 
            // taiKhoan1
            // 
            this.taiKhoan1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.taiKhoan1.ForeColor = System.Drawing.Color.Black;
            this.taiKhoan1.Location = new System.Drawing.Point(-3, 121);
            this.taiKhoan1.Margin = new System.Windows.Forms.Padding(4);
            this.taiKhoan1.Name = "taiKhoan1";
            this.taiKhoan1.Size = new System.Drawing.Size(813, 357);
            this.taiKhoan1.TabIndex = 9;
            // 
            // quyDinh1
            // 
            this.quyDinh1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quyDinh1.ForeColor = System.Drawing.Color.Black;
            this.quyDinh1.Location = new System.Drawing.Point(-2, 121);
            this.quyDinh1.Margin = new System.Windows.Forms.Padding(4);
            this.quyDinh1.Name = "quyDinh1";
            this.quyDinh1.Size = new System.Drawing.Size(812, 427);
            this.quyDinh1.TabIndex = 8;
            this.quyDinh1.Load += new System.EventHandler(this.quyDinh1_Load);
            // 
            // baoCaoSuDungThuoc1
            // 
            this.baoCaoSuDungThuoc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.baoCaoSuDungThuoc1.ForeColor = System.Drawing.Color.Black;
            this.baoCaoSuDungThuoc1.Location = new System.Drawing.Point(-2, 118);
            this.baoCaoSuDungThuoc1.Margin = new System.Windows.Forms.Padding(4);
            this.baoCaoSuDungThuoc1.Name = "baoCaoSuDungThuoc1";
            this.baoCaoSuDungThuoc1.Size = new System.Drawing.Size(810, 486);
            this.baoCaoSuDungThuoc1.TabIndex = 7;
            // 
            // baoCaoNgay1
            // 
            this.baoCaoNgay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.baoCaoNgay1.ForeColor = System.Drawing.Color.Black;
            this.baoCaoNgay1.Location = new System.Drawing.Point(0, 118);
            this.baoCaoNgay1.Margin = new System.Windows.Forms.Padding(4);
            this.baoCaoNgay1.Name = "baoCaoNgay1";
            this.baoCaoNgay1.Size = new System.Drawing.Size(810, 487);
            this.baoCaoNgay1.TabIndex = 6;
            // 
            // hoaDon1
            // 
            this.hoaDon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hoaDon1.ForeColor = System.Drawing.Color.Black;
            this.hoaDon1.Location = new System.Drawing.Point(-2, 118);
            this.hoaDon1.Margin = new System.Windows.Forms.Padding(4);
            this.hoaDon1.Name = "hoaDon1";
            this.hoaDon1.Size = new System.Drawing.Size(812, 494);
            this.hoaDon1.TabIndex = 5;
            // 
            // timTheoNgay1
            // 
            this.timTheoNgay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.timTheoNgay1.ForeColor = System.Drawing.Color.Black;
            this.timTheoNgay1.Location = new System.Drawing.Point(4, 116);
            this.timTheoNgay1.Margin = new System.Windows.Forms.Padding(4);
            this.timTheoNgay1.Name = "timTheoNgay1";
            this.timTheoNgay1.Size = new System.Drawing.Size(806, 428);
            this.timTheoNgay1.TabIndex = 4;
            // 
            // phieuKhamBenh1
            // 
            this.phieuKhamBenh1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.phieuKhamBenh1.ForeColor = System.Drawing.Color.Black;
            this.phieuKhamBenh1.Location = new System.Drawing.Point(0, 116);
            this.phieuKhamBenh1.Margin = new System.Windows.Forms.Padding(4);
            this.phieuKhamBenh1.Name = "phieuKhamBenh1";
            this.phieuKhamBenh1.Size = new System.Drawing.Size(810, 480);
            this.phieuKhamBenh1.TabIndex = 2;
            this.phieuKhamBenh1.Load += new System.EventHandler(this.phieuKhamBenh1_Load);
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.d1.ForeColor = System.Drawing.Color.Black;
            this.d1.Location = new System.Drawing.Point(1, 117);
            this.d1.Margin = new System.Windows.Forms.Padding(4);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(809, 474);
            this.d1.TabIndex = 1;
            // 
            // tt_info
            // 
            this.tt_info.Popup += new System.Windows.Forms.PopupEventHandler(this.tt_info_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(810, 609);
            this.Controls.Add(this.home1);
            this.Controls.Add(this.taiKhoan1);
            this.Controls.Add(this.quyDinh1);
            this.Controls.Add(this.baoCaoSuDungThuoc1);
            this.Controls.Add(this.baoCaoNgay1);
            this.Controls.Add(this.hoaDon1);
            this.Controls.Add(this.timTheoNgay1);
            this.Controls.Add(this.phieuKhamBenh1);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_ad2);
            this.Controls.Add(this.lbl_ad1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồ án quản lý phòng mạch tư ";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            tab_phongmachtu.Text = "Phiếu khám bệnh";
            phieuKhamBenh1.thuoc = quyDinh1.thuoc;
            phieuKhamBenh1.benh = quyDinh1.benh;
            phieuKhamBenh1.cachdung = quyDinh1.cachdung;
            phieuKhamBenh1.donvi = quyDinh1.donvi;
            phieuKhamBenh1.danhsach = d1.thaydoi;
            phieuKhamBenh1.Visible = true;
            quyDinh1.thuoc = 0;
            quyDinh1.benh = 0;
            quyDinh1.cachdung = 0;
            quyDinh1.donvi = 0;
            d1.thaydoi = 0;
            d1.Visible = false;
            quyDinh1.Visible = false;
            timTheoNgay1.Visible = false;
            hoaDon1.Visible = false;
            taiKhoan1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = true;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
            tab = 3;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            tab_phongmachtu.Text = "Tra cứu bệnh nhân";
            timTheoNgay1.Visible = true;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            quyDinh1.Visible = false;
            hoaDon1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = true;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
            tab = 4;
        }


        private void buttonItem4_Click(object sender, EventArgs e)
        {
            tab_phongmachtu.Text = "Hóa đơn";
            timTheoNgay1.Visible = false;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            quyDinh1.Visible = false;
            hoaDon1.Visible = true;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = true;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
            tab = 5;
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            if (baocao == 1)
            {
                btn_baocao.Text = "Báo cáo ngày";
                btn_baocaongay_Click(sender, e);
            }
            else
            {
                btn_baocao.Text = "Báo cáo thuốc";
                bt_baocaothuoc_Click(sender, e);
            }
        }

        private void btn_baocaongay_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            baocao = 1;
            tab = 6;
            btn_baocao.Text = "Báo cáo ngày";
            this.btn_baocao.Image = ((System.Drawing.Image)(Properties.Resources.Date));
            tab_phongmachtu.Text = "Báo cáo theo ngày";
            timTheoNgay1.Visible = false;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            hoaDon1.Visible = false;
            baoCaoNgay1.Visible = true;
            baoCaoSuDungThuoc1.Visible = false;
            quyDinh1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_baocao.Checked = true;
            btn_tracuu.Checked = false;
            btn_hoadon.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
        }

        private void bt_baocaothuoc_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            baocao = 2;
            tab = 6;
            btn_baocao.Text = "Báo cáo thuốc";
            this.btn_baocao.Image = ((System.Drawing.Image)(Properties.Resources.medicine));
            tab_phongmachtu.Text = "Báo cáo sử dụng thuốc";
            timTheoNgay1.Visible = false;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            hoaDon1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = true;
            quyDinh1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_baocao.Checked = true;
            btn_tracuu.Checked = false;
            btn_hoadon.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("Bạn có muốn đăng xuất không?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                home1.logout();
                home1.DieuChinh();
                this.btn_baocao.Image = ((System.Drawing.Image)(Properties.Resources.Date));
                btn_home_Click(sender, e);
                btn_dangnhap.Visible = false;
                btn_danhsach.Visible = false;
                btn_baocao.Visible = false;
                btn_hoadon.Visible = false;
                btn_phieukham.Visible = false;
                btn_quanly.Visible = false;
                btn_thaydoi.Visible = false;
                btn_tracuu.Visible = false;
                baocao = 1;
                btn_baocao.Text = "Báo cáo ngày";
                home1.login = 0;
                this.Activated += Form1_Activated;
            }
        }
        private void btn_thaydoi_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            home1.Visible = false;
            tab_phongmachtu.Text = "Thay đổi quy định";
            timTheoNgay1.Visible = false;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            hoaDon1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            quyDinh1.Visible = true;
            taiKhoan1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = true;
            btn_dangnhap.Checked = false;
            tab = 1;
        }

        private void quyDinh1_Load(object sender, EventArgs e)
        {
        }

        private void phieuKhamBenh1_Load(object sender, EventArgs e)
        {

        }

        private void btn_quanly_Click(object sender, EventArgs e)
        {
            tab_phongmachtu.Text = "Quản lý tài khoản";
            timTheoNgay1.Visible = false;
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            hoaDon1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            quyDinh1.Visible = false;
            taiKhoan1.Visible = true;
            home1.Visible = false;
            //
            btn_home.Checked = false;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = true;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
            tab = 1;
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            //ẩn hiện các user control
            tab_phongmachtu.Text = "Trang chủ";
            phieuKhamBenh1.Visible = false;
            d1.Visible = false;
            hoaDon1.Visible = false;
            timTheoNgay1.Visible = false;
            baoCaoNgay1.Visible = false;
            baoCaoSuDungThuoc1.Visible = false;
            quyDinh1.Visible = false;
            taiKhoan1.Visible = false;
            home1.Visible = true;
            tab = 1;
            //
            btn_home.Checked = true;
            btn_danhsach.Checked = false;
            btn_phieukham.Checked = false;
            btn_hoadon.Checked = false;
            btn_tracuu.Checked = false;
            btn_baocao.Checked = false;
            btn_quanly.Checked = false;
            btn_thaydoi.Checked = false;
            btn_dangnhap.Checked = false;
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (home1.login == 1)
            {
                btn_dangnhap.Image = ((System.Drawing.Image)(Properties.Resources.Administrator_icon__Copy_));
                btn_dangnhap.Text = "Đăng xuất";
                //cho tất cả cá user control hoạt động
                d1.Enabled = true;
                phieuKhamBenh1.Enabled = true;
                timTheoNgay1.Enabled = true;
                hoaDon1.Enabled = true;
                baoCaoNgay1.Enabled = true;
                baoCaoSuDungThuoc1.Enabled = true;
                quyDinh1.Enabled = true;
                taiKhoan1.Enabled = true;
                btn_danhsach.Visible = true;
                btn_baocao.Visible = true;
                btn_hoadon.Visible = true;
                btn_phieukham.Visible = true;
                btn_quanly.Visible = true;
                btn_thaydoi.Visible = true;
                btn_tracuu.Visible = true;
                btn_dangnhap.Visible = true;
                home1.DieuChinh();
                this.Refresh();
            }
            else
                if (home1.login == 2)
            {
                btn_dangnhap.Image = ((System.Drawing.Image)(Properties.Resources.Doctor1));
                btn_dangnhap.Text = "Đăng xuất";
                //cho tất cả cá user control hoạt động
                d1.Enabled = true;
                phieuKhamBenh1.Enabled = true;
                timTheoNgay1.Enabled = true;
                hoaDon1.Enabled = true;
                baoCaoNgay1.Enabled = true;
                baoCaoSuDungThuoc1.Enabled = true;
                taiKhoan1.Enabled = false;
                btn_thaydoi.Visible = false;
                btn_danhsach.Visible = true;
                btn_baocao.Visible = true;
                btn_hoadon.Visible = true;
                btn_phieukham.Visible = true;
                btn_quanly.Visible = false;
                btn_tracuu.Visible = true;
                btn_dangnhap.Visible = true;
                home1.DieuChinh();
                this.Refresh();
                this.Activated -= Form1_Activated;
            }
            else
                    if (home1.login == 3)
            {
                btn_dangnhap.Image = ((System.Drawing.Image)(Properties.Resources.Staff));
                btn_dangnhap.Text = "Đăng xuất";
                //cho tất cả cá user control hoạt động
                d1.Enabled = true;
                phieuKhamBenh1.Enabled = true;
                timTheoNgay1.Enabled = true;
                hoaDon1.Enabled = true;
                baoCaoNgay1.Enabled = true;
                baoCaoSuDungThuoc1.Enabled = true;
                taiKhoan1.Enabled = false;
                btn_thaydoi.Visible = false;
                btn_danhsach.Visible = true;
                btn_baocao.Visible = true;
                btn_hoadon.Visible = true;
                btn_phieukham.Visible = false;
                btn_quanly.Visible = false;
                btn_tracuu.Visible = true;
                btn_dangnhap.Visible = true;
                this.Refresh();
                this.Activated -= Form1_Activated;
            }
            this.Activated -= Form1_Activated;
        }


        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Activated += Form1_Activated;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_ad1.Left -= 1;
            lbl_ad2.Left -= 1;
            if (lbl_ad1.Left == 0)
            {
                lbl_ad2.Location = new Point(713, 633);
            }
            if (lbl_ad2.Left == 0)
            {
                lbl_ad1.Location = new Point(713, 633);
            }
        }

        private void lbl_ad1_Click(object sender, EventArgs e)
        {

        }

        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void tt_info_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
