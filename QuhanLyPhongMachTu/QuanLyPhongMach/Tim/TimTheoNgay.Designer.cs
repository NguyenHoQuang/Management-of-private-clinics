namespace QuhanLyPhongMachTu
{
    partial class TimTheoNgay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_ten = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgv_thongtin = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.clmnstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnhoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnngaykham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnloaibenh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmntrieuchung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_timngay = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.rd_timngay = new DevComponents.DotNetBar.RadialMenu();
            this.dt_ngaykham = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lbl_ngay = new DevComponents.DotNetBar.LabelX();
            this.grp_timten = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbl_timten = new DevComponents.DotNetBar.LabelX();
            this.rd_timten = new DevComponents.DotNetBar.RadialMenu();
            this.lbl_ten = new DevComponents.DotNetBar.LabelX();
            this.tt_ten = new System.Windows.Forms.ToolTip(this.components);
            this.tt_ngay = new System.Windows.Forms.ToolTip(this.components);
            this.tt_timten = new System.Windows.Forms.ToolTip(this.components);
            this.tt_timngay = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_thongbao = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtin)).BeginInit();
            this.grp_timngay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_ngaykham)).BeginInit();
            this.grp_timten.SuspendLayout();
            this.SuspendLayout();
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
            this.txt_ten.Location = new System.Drawing.Point(151, 16);
            this.txt_ten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.PreventEnterBeep = true;
            this.txt_ten.Size = new System.Drawing.Size(241, 22);
            this.txt_ten.TabIndex = 1;
            this.tt_ten.SetToolTip(this.txt_ten, "Tên bệnh nhân cần tìm");
            this.txt_ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ten_KeyDown);
            // 
            // dgv_thongtin
            // 
            this.dgv_thongtin.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thongtin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_thongtin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnstt,
            this.clmnhoten,
            this.clmnngaykham,
            this.clmnloaibenh,
            this.clmntrieuchung});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_thongtin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_thongtin.EnableHeadersVisualStyles = false;
            this.dgv_thongtin.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_thongtin.Location = new System.Drawing.Point(11, 213);
            this.dgv_thongtin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_thongtin.Name = "dgv_thongtin";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thongtin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_thongtin.Size = new System.Drawing.Size(1027, 185);
            this.dgv_thongtin.TabIndex = 8;
            this.dgv_thongtin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thongtin_CellContentClick);
            // 
            // clmnstt
            // 
            this.clmnstt.HeaderText = "STT";
            this.clmnstt.Name = "clmnstt";
            this.clmnstt.Width = 40;
            // 
            // clmnhoten
            // 
            this.clmnhoten.HeaderText = "Họ tên";
            this.clmnhoten.Name = "clmnhoten";
            this.clmnhoten.Width = 200;
            // 
            // clmnngaykham
            // 
            this.clmnngaykham.HeaderText = "Ngày khám";
            this.clmnngaykham.Name = "clmnngaykham";
            this.clmnngaykham.Width = 107;
            // 
            // clmnloaibenh
            // 
            this.clmnloaibenh.HeaderText = "Loại bệnh";
            this.clmnloaibenh.Name = "clmnloaibenh";
            this.clmnloaibenh.Width = 150;
            // 
            // clmntrieuchung
            // 
            this.clmntrieuchung.HeaderText = "Triệu chứng";
            this.clmntrieuchung.Name = "clmntrieuchung";
            this.clmntrieuchung.Width = 230;
            // 
            // grp_timngay
            // 
            this.grp_timngay.BackColor = System.Drawing.Color.White;
            this.grp_timngay.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp_timngay.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.grp_timngay.Controls.Add(this.labelX1);
            this.grp_timngay.Controls.Add(this.rd_timngay);
            this.grp_timngay.Controls.Add(this.dt_ngaykham);
            this.grp_timngay.Controls.Add(this.lbl_ngay);
            this.grp_timngay.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp_timngay.Location = new System.Drawing.Point(528, 7);
            this.grp_timngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grp_timngay.Name = "grp_timngay";
            this.grp_timngay.Size = new System.Drawing.Size(509, 181);
            // 
            // 
            // 
            this.grp_timngay.Style.BackColor = System.Drawing.Color.White;
            this.grp_timngay.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp_timngay.Style.BackColorGradientAngle = 90;
            //this.grp_timngay.Style.BackgroundImage = global::QuhanLyPhongMachTu.Properties.Resources.TimNgay2;
            this.grp_timngay.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.BottomRight;
            this.grp_timngay.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timngay.Style.BorderBottomWidth = 1;
            this.grp_timngay.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.grp_timngay.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timngay.Style.BorderLeftWidth = 1;
            this.grp_timngay.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timngay.Style.BorderRightWidth = 1;
            this.grp_timngay.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timngay.Style.BorderTopWidth = 1;
            this.grp_timngay.Style.CornerDiameter = 4;
            this.grp_timngay.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp_timngay.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp_timngay.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp_timngay.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp_timngay.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp_timngay.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp_timngay.TabIndex = 7;
            this.grp_timngay.Text = "Tìm theo ngày:";
            this.grp_timngay.Click += new System.EventHandler(this.grp_timngay_Click_1);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(229, 135);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(24, 17);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Tìm";
            // 
            // rd_timngay
            // 
            this.rd_timngay.BackButtonSymbol = "";
            this.rd_timngay.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.rd_timngay.Colors.RadialMenuButtonBackground = System.Drawing.SystemColors.ActiveCaption;
            this.rd_timngay.Colors.RadialMenuButtonBorder = System.Drawing.Color.DarkCyan;
            this.rd_timngay.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_tim;
            this.rd_timngay.Location = new System.Drawing.Point(200, 52);
            this.rd_timngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rd_timngay.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_timngay.Name = "rd_timngay";
            this.rd_timngay.Size = new System.Drawing.Size(87, 80);
            this.rd_timngay.SymbolSize = 18F;
            this.rd_timngay.TabIndex = 4;
            this.rd_timngay.Text = "radialMenu1";
            this.rd_timngay.Click += new System.EventHandler(this.rd_timngay_Click);
            this.rd_timngay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rd_timngay_MouseDown);
            this.rd_timngay.MouseEnter += new System.EventHandler(this.rd_timngay_MouseEnter);
            this.rd_timngay.MouseLeave += new System.EventHandler(this.rd_timngay_MouseLeave);
            this.rd_timngay.MouseHover += new System.EventHandler(this.rd_timngay_MouseHover);
            // 
            // dt_ngaykham
            // 
            // 
            // 
            // 
            this.dt_ngaykham.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt_ngaykham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_ngaykham.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt_ngaykham.ButtonDropDown.Visible = true;
            this.dt_ngaykham.FieldNavigation = DevComponents.Editors.eInputFieldNavigation.Arrows;
            this.dt_ngaykham.IsPopupCalendarOpen = false;
            this.dt_ngaykham.Location = new System.Drawing.Point(135, 17);
            this.dt_ngaykham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dt_ngaykham.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_ngaykham.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt_ngaykham.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt_ngaykham.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_ngaykham.MonthCalendar.DisplayMonth = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dt_ngaykham.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt_ngaykham.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_ngaykham.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt_ngaykham.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_ngaykham.MonthCalendar.TodayButtonVisible = true;
            this.dt_ngaykham.Name = "dt_ngaykham";
            this.dt_ngaykham.Size = new System.Drawing.Size(185, 22);
            this.dt_ngaykham.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt_ngaykham.TabIndex = 3;
            this.tt_ngay.SetToolTip(this.dt_ngaykham, "Ngày bệnh nhân đến khám bệnh");
            this.dt_ngaykham.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dt_ngaykham_PreviewKeyDown);
            // 
            // lbl_ngay
            // 
            this.lbl_ngay.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ngay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ngay.Location = new System.Drawing.Point(4, 14);
            this.lbl_ngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbl_ngay.Name = "lbl_ngay";
            this.lbl_ngay.Size = new System.Drawing.Size(123, 28);
            this.lbl_ngay.TabIndex = 0;
            this.lbl_ngay.Text = "Nhập ngày khám:";
            // 
            // grp_timten
            // 
            this.grp_timten.BackColor = System.Drawing.Color.White;
            this.grp_timten.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp_timten.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grp_timten.Controls.Add(this.lbl_timten);
            this.grp_timten.Controls.Add(this.rd_timten);
            this.grp_timten.Controls.Add(this.lbl_ten);
            this.grp_timten.Controls.Add(this.txt_ten);
            this.grp_timten.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp_timten.Location = new System.Drawing.Point(11, 7);
            this.grp_timten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grp_timten.Name = "grp_timten";
            this.grp_timten.Size = new System.Drawing.Size(509, 181);
            // 
            // 
            // 
            this.grp_timten.Style.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grp_timten.Style.BackColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.grp_timten.Style.BackColorGradientAngle = 90;
            //this.grp_timten.Style.BackgroundImage = global::QuhanLyPhongMachTu.Properties.Resources.TimTen2;
            this.grp_timten.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.BottomRight;
            this.grp_timten.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timten.Style.BorderBottomWidth = 1;
            this.grp_timten.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.grp_timten.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timten.Style.BorderLeftWidth = 1;
            this.grp_timten.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timten.Style.BorderRightWidth = 1;
            this.grp_timten.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grp_timten.Style.BorderTopWidth = 1;
            this.grp_timten.Style.CornerDiameter = 4;
            this.grp_timten.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp_timten.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grp_timten.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp_timten.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grp_timten.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grp_timten.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grp_timten.TabIndex = 6;
            this.grp_timten.Text = "Tìm theo tên";
            this.grp_timten.Click += new System.EventHandler(this.grp_timten_Click_1);
            // 
            // lbl_timten
            // 
            this.lbl_timten.AutoSize = true;
            // 
            // 
            // 
            this.lbl_timten.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_timten.Location = new System.Drawing.Point(240, 135);
            this.lbl_timten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbl_timten.Name = "lbl_timten";
            this.lbl_timten.Size = new System.Drawing.Size(24, 17);
            this.lbl_timten.TabIndex = 4;
            this.lbl_timten.Text = "Tìm";
            // 
            // rd_timten
            // 
            this.rd_timten.BackButtonSymbol = "";
            this.rd_timten.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rd_timten.Colors.RadialMenuButtonBackground = System.Drawing.SystemColors.ActiveCaption;
            this.rd_timten.Colors.RadialMenuButtonBorder = System.Drawing.Color.DarkCyan;
            this.rd_timten.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_tim;
            this.rd_timten.Location = new System.Drawing.Point(209, 52);
            this.rd_timten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rd_timten.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_timten.Name = "rd_timten";
            this.rd_timten.Size = new System.Drawing.Size(87, 80);
            this.rd_timten.SymbolSize = 18F;
            this.rd_timten.TabIndex = 3;
            this.rd_timten.Text = "radialMenu1";
            this.rd_timten.Click += new System.EventHandler(this.rd_timten_Click);
            this.rd_timten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rd_timten_MouseDown);
            this.rd_timten.MouseEnter += new System.EventHandler(this.rd_timten_MouseEnter);
            this.rd_timten.MouseLeave += new System.EventHandler(this.rd_timten_MouseLeave);
            this.rd_timten.MouseHover += new System.EventHandler(this.rd_timten_MouseHover);
            // 
            // lbl_ten
            // 
            this.lbl_ten.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ten.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ten.Location = new System.Drawing.Point(4, 14);
            this.lbl_ten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbl_ten.Name = "lbl_ten";
            this.lbl_ten.Size = new System.Drawing.Size(145, 28);
            this.lbl_ten.TabIndex = 0;
            this.lbl_ten.Text = "Nhập tên bệnh nhân:";
            // 
            // lbl_thongbao
            // 
            this.lbl_thongbao.AutoSize = true;
            this.lbl_thongbao.BackColor = System.Drawing.Color.Transparent;
            this.lbl_thongbao.ForeColor = System.Drawing.Color.Red;
            this.lbl_thongbao.Location = new System.Drawing.Point(473, 194);
            this.lbl_thongbao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_thongbao.Name = "lbl_thongbao";
            this.lbl_thongbao.Size = new System.Drawing.Size(109, 17);
            this.lbl_thongbao.TabIndex = 9;
            this.lbl_thongbao.Text = "Tìm thành công!";
            this.lbl_thongbao.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_thongbao);
            this.Controls.Add(this.dgv_thongtin);
            this.Controls.Add(this.grp_timngay);
            this.Controls.Add(this.grp_timten);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TimTheoNgay";
            this.Size = new System.Drawing.Size(1052, 501);
            this.Load += new System.EventHandler(this.TimTheoNgay_Load);
            this.EnabledChanged += new System.EventHandler(this.TimTheoNgay_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtin)).EndInit();
            this.grp_timngay.ResumeLayout(false);
            this.grp_timngay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_ngaykham)).EndInit();
            this.grp_timten.ResumeLayout(false);
            this.grp_timten.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_thongtin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnhoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnngaykham;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnloaibenh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmntrieuchung;
        private DevComponents.DotNetBar.Controls.GroupPanel grp_timngay;
        private DevComponents.DotNetBar.LabelX lbl_ngay;
        private DevComponents.DotNetBar.Controls.GroupPanel grp_timten;
        private DevComponents.DotNetBar.LabelX lbl_ten;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ten;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dt_ngaykham;
        private System.Windows.Forms.ToolTip tt_ten;
        private System.Windows.Forms.ToolTip tt_ngay;
        private System.Windows.Forms.ToolTip tt_timngay;
        private System.Windows.Forms.ToolTip tt_timten;
        private DevComponents.DotNetBar.LabelX lbl_timten;
        private DevComponents.DotNetBar.RadialMenu rd_timten;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.RadialMenu rd_timngay;
        private System.Windows.Forms.Label lbl_thongbao;
        private System.Windows.Forms.Timer timer1;
    }
}
