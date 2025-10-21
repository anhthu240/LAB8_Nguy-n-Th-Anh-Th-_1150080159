namespace NguyenThiAnhThu_1150080159_LAB8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colDiaChi;

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.grpList = new System.Windows.Forms.GroupBox();
            this.lsvDanhSach = new System.Windows.Forms.ListView();
            this.colMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            this.grpInput = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();

            // suspend
            this.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grpList.SuspendLayout();
            this.grpInput.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 50);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "Quản lý Nhà xuất bản - Nguyễn Thị Anh Thư";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // grpList
            this.grpList.Location = new System.Drawing.Point(12, 60);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(540, 300);
            this.grpList.TabStop = true;
            this.grpList.Text = "Danh sách nhà xuất bản";

            // lsvDanhSach
            this.lsvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colMa, this.colTen, this.colDiaChi});
            this.lsvDanhSach.FullRowSelect = true;
            this.lsvDanhSach.GridLines = true;
            this.lsvDanhSach.HideSelection = false;
            this.lsvDanhSach.Location = new System.Drawing.Point(10, 22);
            this.lsvDanhSach.MultiSelect = false;
            this.lsvDanhSach.Name = "lsvDanhSach";
            this.lsvDanhSach.Size = new System.Drawing.Size(520, 270);
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            this.lsvDanhSach.SelectedIndexChanged += new System.EventHandler(this.lsvDanhSach_SelectedIndexChanged);

            this.colMa.Text = "Mã NXB"; this.colMa.Width = 120;
            this.colTen.Text = "Tên NXB"; this.colTen.Width = 200;
            this.colDiaChi.Text = "Địa chỉ"; this.colDiaChi.Width = 180;

            this.grpList.Controls.Add(this.lsvDanhSach);

            // grpInput
            this.grpInput.Location = new System.Drawing.Point(560, 60);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(308, 300);
            this.grpInput.TabStop = true;
            this.grpInput.Text = "Thông tin nhập liệu";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Text = "Mã NXB:";

            // txtNXB
            this.txtNXB.Location = new System.Drawing.Point(95, 37);
            this.txtNXB.MaxLength = 12;
            this.txtNXB.Size = new System.Drawing.Size(190, 23);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Text = "Tên NXB:";

            // txtTenNXB
            this.txtTenNXB.Location = new System.Drawing.Point(95, 77);
            this.txtTenNXB.Size = new System.Drawing.Size(190, 23);

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 120);
            this.label3.Text = "Địa chỉ:";

            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(95, 117);
            this.txtDiaChi.Size = new System.Drawing.Size(190, 23);

            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.Honeydew;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Location = new System.Drawing.Point(18, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(267, 38);
            this.btnThem.Text = "Thêm nhà xuất bản";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Controls.Add(this.txtNXB);
            this.grpInput.Controls.Add(this.label2);
            this.grpInput.Controls.Add(this.txtTenNXB);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.Controls.Add(this.txtDiaChi);
            this.grpInput.Controls.Add(this.btnThem);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 370);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.pnlHeader);
            this.Name = "Form1";
            this.Text = "Quản lý Nhà xuất bản";
            this.Load += new System.EventHandler(this.Form1_Load);

            // resume
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpList.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
