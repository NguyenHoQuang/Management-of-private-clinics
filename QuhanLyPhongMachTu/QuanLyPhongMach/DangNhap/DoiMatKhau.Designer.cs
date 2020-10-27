namespace QuhanLyPhongMachTu.QuanLyPhongMach
{
    partial class DoiMatKhau
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
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.lbl_cu = new System.Windows.Forms.Label();
            this.txt_cu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_moi = new System.Windows.Forms.Label();
            this.lbl_remoi = new System.Windows.Forms.Label();
            this.txt_moi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_remoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rd_capnhat = new DevComponents.DotNetBar.RadialMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.tt_capnhat = new System.Windows.Forms.ToolTip(this.components);
            this.tt_cu = new System.Windows.Forms.ToolTip(this.components);
            this.tt_moi = new System.Windows.Forms.ToolTip(this.components);
            this.tt_remoi = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(71)))), ((int)(((byte)(42))))));
            // 
            // lbl_cu
            // 
            this.lbl_cu.AutoSize = true;
            this.lbl_cu.BackColor = System.Drawing.Color.White;
            this.lbl_cu.ForeColor = System.Drawing.Color.Black;
            this.lbl_cu.Location = new System.Drawing.Point(12, 25);
            this.lbl_cu.Name = "lbl_cu";
            this.lbl_cu.Size = new System.Drawing.Size(92, 13);
            this.lbl_cu.TabIndex = 0;
            this.lbl_cu.Text = "Mật khẩu hiện tại:";
            // 
            // txt_cu
            // 
            // 
            // 
            // 
            this.txt_cu.Border.Class = "TextBoxBorder";
            this.txt_cu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cu.DisabledBackColor = System.Drawing.Color.White;
            this.txt_cu.Location = new System.Drawing.Point(102, 20);
            this.txt_cu.Name = "txt_cu";
            this.txt_cu.PreventEnterBeep = true;
            this.txt_cu.Size = new System.Drawing.Size(255, 20);
            this.txt_cu.TabIndex = 1;
            this.tt_cu.SetToolTip(this.txt_cu, "Mật khẩu hiện tại của tài khoản");
            // 
            // lbl_moi
            // 
            this.lbl_moi.AutoSize = true;
            this.lbl_moi.BackColor = System.Drawing.Color.White;
            this.lbl_moi.ForeColor = System.Drawing.Color.Black;
            this.lbl_moi.Location = new System.Drawing.Point(12, 65);
            this.lbl_moi.Name = "lbl_moi";
            this.lbl_moi.Size = new System.Drawing.Size(74, 13);
            this.lbl_moi.TabIndex = 2;
            this.lbl_moi.Text = "Mật khẩu mới:";
            // 
            // lbl_remoi
            // 
            this.lbl_remoi.AutoSize = true;
            this.lbl_remoi.BackColor = System.Drawing.Color.White;
            this.lbl_remoi.ForeColor = System.Drawing.Color.Black;
            this.lbl_remoi.Location = new System.Drawing.Point(12, 96);
            this.lbl_remoi.Name = "lbl_remoi";
            this.lbl_remoi.Size = new System.Drawing.Size(115, 13);
            this.lbl_remoi.TabIndex = 3;
            this.lbl_remoi.Text = "Nhập lại mật khẩu mới:";
            // 
            // txt_moi
            // 
            // 
            // 
            // 
            this.txt_moi.Border.Class = "TextBoxBorder";
            this.txt_moi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_moi.DisabledBackColor = System.Drawing.Color.White;
            this.txt_moi.Location = new System.Drawing.Point(89, 58);
            this.txt_moi.Name = "txt_moi";
            this.txt_moi.PreventEnterBeep = true;
            this.txt_moi.Size = new System.Drawing.Size(268, 20);
            this.txt_moi.TabIndex = 4;
            this.tt_moi.SetToolTip(this.txt_moi, "Mật khẩu mới định tạo");
            // 
            // txt_remoi
            // 
            // 
            // 
            // 
            this.txt_remoi.Border.Class = "TextBoxBorder";
            this.txt_remoi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_remoi.DisabledBackColor = System.Drawing.Color.White;
            this.txt_remoi.Location = new System.Drawing.Point(133, 94);
            this.txt_remoi.Name = "txt_remoi";
            this.txt_remoi.PreventEnterBeep = true;
            this.txt_remoi.Size = new System.Drawing.Size(224, 20);
            this.txt_remoi.TabIndex = 5;
            this.tt_remoi.SetToolTip(this.txt_remoi, "Nhập lại mật khẩu mới lần nữa");
            // 
            // rd_capnhat
            // 
            this.rd_capnhat.BackColor = System.Drawing.Color.White;
            this.rd_capnhat.ForeColor = System.Drawing.Color.Black;
            this.rd_capnhat.Image = global::QuhanLyPhongMachTu.Properties.Resources.btn_capnhat_2;
            this.rd_capnhat.Location = new System.Drawing.Point(143, 130);
            this.rd_capnhat.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.rd_capnhat.Name = "rd_capnhat";
            this.rd_capnhat.Size = new System.Drawing.Size(65, 65);
            this.rd_capnhat.SymbolSize = 13F;
            this.rd_capnhat.TabIndex = 6;
            this.rd_capnhat.Text = "radialMenu1";
            this.tt_capnhat.SetToolTip(this.rd_capnhat, "Cập nhật mật khẩu mới");
            this.rd_capnhat.Click += new System.EventHandler(this.rd_capnhat_Click);
            this.rd_capnhat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rd_capnhat_MouseDown);
            this.rd_capnhat.MouseEnter += new System.EventHandler(this.rd_capnhat_MouseEnter);
            this.rd_capnhat.MouseLeave += new System.EventHandler(this.rd_capnhat_MouseLeave);
            this.rd_capnhat.MouseHover += new System.EventHandler(this.rd_capnhat_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(150, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cập nhật";
            // 
            // tt_capnhat
            // 
            this.tt_capnhat.AutoPopDelay = 5000;
            this.tt_capnhat.InitialDelay = 500;
            this.tt_capnhat.ReshowDelay = 100;
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 216);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rd_capnhat);
            this.Controls.Add(this.txt_remoi);
            this.Controls.Add(this.txt_moi);
            this.Controls.Add(this.lbl_remoi);
            this.Controls.Add(this.lbl_moi);
            this.Controls.Add(this.txt_cu);
            this.Controls.Add(this.lbl_cu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.DoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Label lbl_cu;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cu;
        private System.Windows.Forms.Label lbl_moi;
        private System.Windows.Forms.Label lbl_remoi;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_moi;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_remoi;
        private DevComponents.DotNetBar.RadialMenu rd_capnhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tt_capnhat;
        private System.Windows.Forms.ToolTip tt_cu;
        private System.Windows.Forms.ToolTip tt_moi;
        private System.Windows.Forms.ToolTip tt_remoi;
    }
}