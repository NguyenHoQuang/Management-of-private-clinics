namespace QuhanLyPhongMachTu.QuanLyPhongMach.QuyDinh
{
    partial class Benh
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.grp_benh = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbl_thongbao = new System.Windows.Forms.Label();
            this.lbl_xoa = new System.Windows.Forms.Label();
            this.lbl_capnhat = new System.Windows.Forms.Label();
            this.lbl_them = new System.Windows.Forms.Label();
            this.rd_xoa = new DevComponents.DotNetBar.RadialMenu();
            this.rd_capnhat = new DevComponents.DotNetBar.RadialMenu();
            this.rd_them = new DevComponents.DotNetBar.RadialMenu();
            this.txt_ten = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_ten = new DevComponents.DotNetBar.LabelX();
            this.txt_ma = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_ma = new DevComponents.DotNetBar.LabelX();
            this.dgv_benh = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmnstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmntenbenh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tt_ten = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tt_them = new System.Windows.Forms.ToolTip(this.components);
            this.tt_capnhat = new System.Windows.Forms.ToolTip(this.components);
            this.tt_xoa = new System.Windows.Forms.ToolTip(this.components);
            this.grp_benh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_benh)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42))))));
            // 
            // grp_benh
            // 
            this.grp_benh.BackColor = System.Drawing.Color.White;
            this.grp_benh.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grp_benh.Controls.Add(this.lbl_thongbao);
            this.grp_benh.Controls.Add(this.lbl_xoa);
            this.grp_benh.Controls.Add(this.lbl_capnhat);
            this.grp_benh.Controls.Add(this.lbl_them);
            this.grp_benh.Controls.Add(this.rd_xoa);
            this.grp_benh.Controls.Add(this.rd_capnhat);
            this.grp_benh.Controls.Add(this.rd_them);
            this.grp_benh.Controls.Add(this.txt_ten);
            this.grp_benh.Controls.Add(this.lbl_ten);
            this.grp_benh.Controls.Add(this.txt_ma);
            this.grp_benh.Controls.Add(this.lbl_ma);
            this.grp_benh.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp_benh.Location = new System.Drawing.Point(0, 7);
            this.grp_benh.Name = "grp_benh";
            this.grp_benh.Size = new System.Drawing.Size(391, 160);
            // 
            // 
            // 
            this.grp_benh.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grp_benh.Style.BackColorGradientAngle = 90;
            this.grp_benh.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grp_benh.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_benh.Style.BorderBottomWidth = 1;
            this.grp_benh.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.grp_benh.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_benh.Style.BorderLeftWidth = 1;
            this.grp_benh.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_benh.Style.BorderRightWidth = 1;
            this.grp_benh.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_benh.Style.BorderTopWidth = 1;
            this.grp_benh.Style.CornerDiameter = 4;
            this.grp_benh.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp_benh.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp_benh.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp_benh.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp_benh.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp_benh.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp_benh.TabIndex = 5;
            this.grp_benh.Text = "Bệnh";
            this.grp_benh.Click += new System.EventHandler(this.grp_benh_Click);
            // 
            // lbl_thongbao
            // 
            this.lbl_thongbao.AutoSize = true;
            this.lbl_thongbao.BackColor = System.Drawing.Color.White;
            this.lbl_thongbao.ForeColor = System.Drawing.Color.Black;
            this.lbl_thongbao.Location = new System.Drawing.Point(147, 37);
            this.lbl_thongbao.Name = "lbl_thongbao";
            this.lbl_thongbao.Size = new System.Drawing.Size(88, 13);
            this.lbl_thongbao.TabIndex = 15;
            this.lbl_thongbao.Text = "Thêm thông báo!";
            this.lbl_thongbao.Visible = false;
            // 
            // lbl_xoa
            // 
            this.lbl_xoa.AutoSize = true;
            this.lbl_xoa.BackColor = System.Drawing.Color.White;
            this.lbl_xoa.ForeColor = System.Drawing.Color.Black;
            this.lbl_xoa.Location = new System.Drawing.Point(311, 121);
            this.lbl_xoa.Name = "lbl_xoa";
            this.lbl_xoa.Size = new System.Drawing.Size(26, 13);
            this.lbl_xoa.TabIndex = 14;
            this.lbl_xoa.Text = "Xóa";
            // 
            // lbl_capnhat
            // 
            this.lbl_capnhat.AutoSize = true;
            this.lbl_capnhat.BackColor = System.Drawing.Color.White;
            this.lbl_capnhat.ForeColor = System.Drawing.Color.Black;
            this.lbl_capnhat.Location = new System.Drawing.Point(172, 122);
            this.lbl_capnhat.Name = "lbl_capnhat";
            this.lbl_capnhat.Size = new System.Drawing.Size(50, 13);
            this.lbl_capnhat.TabIndex = 13;
            this.lbl_capnhat.Text = "Cập nhật";
            // 
            // lbl_them
            // 
            this.lbl_them.AutoSize = true;
            this.lbl_them.BackColor = System.Drawing.Color.White;
            this.lbl_them.ForeColor = System.Drawing.Color.Black;
            this.lbl_them.Location = new System.Drawing.Point(41, 122);
            this.lbl_them.Name = "lbl_them";
            this.lbl_them.Size = new System.Drawing.Size(34, 13);
            this.lbl_them.TabIndex = 12;
            this.lbl_them.Text = "Thêm";
            // 
            // rd_xoa
            // 
            this.rd_xoa.BackColor = System.Drawing.Color.Transparent;
            this.rd_xoa.ForeColor = System.Drawing.Color.Black;
            this.rd_xoa.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_xoa;
            this.rd_xoa.Location = new System.Drawing.Point(291, 53);
            this.rd_xoa.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_xoa.Name = "rd_xoa";
            this.rd_xoa.Size = new System.Drawing.Size(65, 65);
            this.rd_xoa.SymbolSize = 13F;
            this.rd_xoa.TabIndex = 11;
            this.rd_xoa.Text = "radialMenu3";
            this.tt_xoa.SetToolTip(this.rd_xoa, "Xóa bệnh đã chọn ra khỏi danh sách");
            this.rd_xoa.Click += new System.EventHandler(this.ra_xoa_Click);
            this.rd_xoa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ra_xoa_MouseDown);
            this.rd_xoa.MouseEnter += new System.EventHandler(this.ra_xoa_MouseEnter);
            this.rd_xoa.MouseLeave += new System.EventHandler(this.ra_xoa_MouseLeave);
            this.rd_xoa.MouseHover += new System.EventHandler(this.ra_xoa_MouseHover);
            this.rd_xoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ra_xoa_MouseMove);
            // 
            // rd_capnhat
            // 
            this.rd_capnhat.BackColor = System.Drawing.Color.Transparent;
            this.rd_capnhat.ForeColor = System.Drawing.Color.Black;
            this.rd_capnhat.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_capnhat_2;
            this.rd_capnhat.Location = new System.Drawing.Point(163, 55);
            this.rd_capnhat.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_capnhat.Name = "rd_capnhat";
            this.rd_capnhat.Size = new System.Drawing.Size(65, 65);
            this.rd_capnhat.SymbolSize = 13F;
            this.rd_capnhat.TabIndex = 10;
            this.rd_capnhat.Text = "radialMenu2";
            this.tt_capnhat.SetToolTip(this.rd_capnhat, "Cập nhật lại tên loại bệnh");
            this.rd_capnhat.Click += new System.EventHandler(this.rd_capnhat_Click);
            this.rd_capnhat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rd_capnhat_MouseDown);
            this.rd_capnhat.MouseEnter += new System.EventHandler(this.rd_capnhat_MouseEnter);
            this.rd_capnhat.MouseLeave += new System.EventHandler(this.rd_capnhat_MouseLeave);
            this.rd_capnhat.MouseHover += new System.EventHandler(this.rd_capnhat_MouseHover);
            // 
            // rd_them
            // 
            this.rd_them.BackColor = System.Drawing.Color.Transparent;
            this.rd_them.ForeColor = System.Drawing.Color.Black;
            this.rd_them.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_them_2;
            this.rd_them.Location = new System.Drawing.Point(26, 55);
            this.rd_them.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_them.Name = "rd_them";
            this.rd_them.Size = new System.Drawing.Size(65, 65);
            this.rd_them.SymbolSize = 13F;
            this.rd_them.TabIndex = 9;
            this.rd_them.Text = "radialMenu1";
            this.tt_them.SetToolTip(this.rd_them, "Thêm một loại bệnh vào danh sách");
            this.rd_them.Click += new System.EventHandler(this.rd_them_Click);
            this.rd_them.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rd_them_MouseDown);
            this.rd_them.MouseEnter += new System.EventHandler(this.rd_them_MouseEnter);
            this.rd_them.MouseLeave += new System.EventHandler(this.rd_them_MouseLeave);
            this.rd_them.MouseHover += new System.EventHandler(this.rd_them_MouseHover);
            // 
            // txt_ten
            // 
            this.txt_ten.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_ten.Border.Class = "TextBoxBorder";
            this.txt_ten.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ten.DisabledBackColor = System.Drawing.Color.White;
            this.txt_ten.ForeColor = System.Drawing.Color.Black;
            this.txt_ten.Location = new System.Drawing.Point(226, 8);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.PreventEnterBeep = true;
            this.txt_ten.Size = new System.Drawing.Size(146, 20);
            this.txt_ten.TabIndex = 8;
            this.tt_ten.SetToolTip(this.txt_ten, "Tên của loại bệnh");
            // 
            // lbl_ten
            // 
            this.lbl_ten.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ten.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ten.ForeColor = System.Drawing.Color.Black;
            this.lbl_ten.Location = new System.Drawing.Point(168, 6);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(52, 23);
            this.lbl_ten.TabIndex = 7;
            this.lbl_ten.Text = "Tên bệnh:";
            // 
            // txt_ma
            // 
            this.txt_ma.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_ma.Border.Class = "TextBoxBorder";
            this.txt_ma.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ma.DisabledBackColor = System.Drawing.Color.White;
            this.txt_ma.Enabled = false;
            this.txt_ma.ForeColor = System.Drawing.Color.Black;
            this.txt_ma.Location = new System.Drawing.Point(62, 8);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.PreventEnterBeep = true;
            this.txt_ma.Size = new System.Drawing.Size(76, 20);
            this.txt_ma.TabIndex = 6;
            // 
            // lbl_ma
            // 
            this.lbl_ma.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ma.ForeColor = System.Drawing.Color.Black;
            this.lbl_ma.Location = new System.Drawing.Point(11, 6);
            this.lbl_ma.Name = "lbl_ma";
            this.lbl_ma.Size = new System.Drawing.Size(52, 23);
            this.lbl_ma.TabIndex = 5;
            this.lbl_ma.Text = "Mã bệnh:";
            // 
            // dgv_benh
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_benh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_benh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_benh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnstt,
            this.clmntenbenh});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_benh.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_benh.EnableHeadersVisualStyles = false;
            this.dgv_benh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgv_benh.Location = new System.Drawing.Point(0, 175);
            this.dgv_benh.Name = "dgv_benh";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_benh.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_benh.Size = new System.Drawing.Size(391, 158);
            this.dgv_benh.TabIndex = 6;
            this.dgv_benh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_benh_CellContentClick);
            this.dgv_benh.SelectionChanged += new System.EventHandler(this.dgv_benh_SelectionChanged);
            // 
            // clmnstt
            // 
            this.clmnstt.HeaderText = "STT";
            this.clmnstt.Name = "clmnstt";
            this.clmnstt.Width = 50;
            // 
            // clmntenbenh
            // 
            this.clmntenbenh.HeaderText = "Tên Bệnh";
            this.clmntenbenh.Name = "clmntenbenh";
            this.clmntenbenh.Width = 297;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Benh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 334);
            this.Controls.Add(this.dgv_benh);
            this.Controls.Add(this.grp_benh);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Benh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh";
            this.Load += new System.EventHandler(this.BENH_Load);
            this.grp_benh.ResumeLayout(false);
            this.grp_benh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_benh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.GroupPanel grp_benh;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ten;
        private System.Windows.Forms.ToolTip tt_ten;
        private DevComponents.DotNetBar.LabelX lbl_ten;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ma;
        private DevComponents.DotNetBar.LabelX lbl_ma;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_benh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmntenbenh;
        private System.Windows.Forms.Label lbl_xoa;
        private System.Windows.Forms.Label lbl_capnhat;
        private System.Windows.Forms.Label lbl_them;
        private DevComponents.DotNetBar.RadialMenu rd_xoa;
        private DevComponents.DotNetBar.RadialMenu rd_capnhat;
        private DevComponents.DotNetBar.RadialMenu rd_them;
        private System.Windows.Forms.Label lbl_thongbao;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip tt_xoa;
        private System.Windows.Forms.ToolTip tt_capnhat;
        private System.Windows.Forms.ToolTip tt_them;
    }
}