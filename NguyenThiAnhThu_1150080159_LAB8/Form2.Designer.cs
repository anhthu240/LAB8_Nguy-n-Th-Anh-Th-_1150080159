using System.Windows.Forms;

namespace NguyenThiAnhThu_1150080159_LAB8
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpList;
        private ListView lsvNXB;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colDiaChi;

        private GroupBox grpEdit;
        private Label lblMa;
        private Label lblTen;
        private Label lblDiaChi;
        private TextBox txtMa;
        private TextBox txtTen;
        private TextBox txtDiaChi;
        private Button btnCapNhat;
        private Button btnReload;
        private Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpList = new GroupBox();
            this.lsvNXB = new ListView();
            this.colMa = new ColumnHeader();
            this.colTen = new ColumnHeader();
            this.colDiaChi = new ColumnHeader();

            this.grpEdit = new GroupBox();
            this.lblMa = new Label();
            this.lblTen = new Label();
            this.lblDiaChi = new Label();
            this.txtMa = new TextBox();
            this.txtTen = new TextBox();
            this.txtDiaChi = new TextBox();
            this.btnCapNhat = new Button();
            this.btnReload = new Button();
            this.btnClear = new Button();

            // ===== Left: List =====
            this.grpList.Text = "Danh sách Nhà Xuất Bản";
            this.grpList.Location = new System.Drawing.Point(12, 12);
            this.grpList.Size = new System.Drawing.Size(600, 420);
            this.grpList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;

            this.lsvNXB.Columns.AddRange(new ColumnHeader[] { this.colMa, this.colTen, this.colDiaChi });
            this.lsvNXB.FullRowSelect = true;
            this.lsvNXB.GridLines = true;
            this.lsvNXB.HideSelection = false;
            this.lsvNXB.Location = new System.Drawing.Point(10, 24);
            this.lsvNXB.MultiSelect = false;
            this.lsvNXB.Name = "lsvNXB";
            this.lsvNXB.Size = new System.Drawing.Size(580, 388);
            this.lsvNXB.View = View.Details;
            this.lsvNXB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            this.lsvNXB.SelectedIndexChanged += new System.EventHandler(this.lsvNXB_SelectedIndexChanged);

            this.colMa.Text = "Mã NXB"; this.colMa.Width = 120;
            this.colTen.Text = "Tên NXB"; this.colTen.Width = 210;
            this.colDiaChi.Text = "Địa chỉ"; this.colDiaChi.Width = 230;

            this.grpList.Controls.Add(this.lsvNXB);

            // ===== Right: Edit =====
            this.grpEdit.Text = "Cập nhật thông tin";
            this.grpEdit.Location = new System.Drawing.Point(620, 12);
            this.grpEdit.Size = new System.Drawing.Size(420, 420);
            this.grpEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            // Labels + Textboxes (đặt thấp xuống tránh header groupbox)
            this.lblMa.AutoSize = true;
            this.lblMa.Text = "Mã NXB:";
            this.lblMa.Location = new System.Drawing.Point(18, 60);

            this.txtMa.Location = new System.Drawing.Point(120, 56);
            this.txtMa.MaxLength = 12;
            this.txtMa.Size = new System.Drawing.Size(270, 23);
            this.txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblTen.AutoSize = true;
            this.lblTen.Text = "Tên NXB:";
            this.lblTen.Location = new System.Drawing.Point(18, 100);

            this.txtTen.Location = new System.Drawing.Point(120, 96);
            this.txtTen.Size = new System.Drawing.Size(270, 23);
            this.txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.Location = new System.Drawing.Point(18, 140);

            this.txtDiaChi.Location = new System.Drawing.Point(120, 136);
            this.txtDiaChi.Size = new System.Drawing.Size(270, 23);
            this.txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Buttons
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Location = new System.Drawing.Point(20, 186);
            this.btnCapNhat.Size = new System.Drawing.Size(370, 36);
            this.btnCapNhat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.btnReload.Text = "Tải lại danh sách";
            this.btnReload.Location = new System.Drawing.Point(20, 232);
            this.btnReload.Size = new System.Drawing.Size(370, 34);
            this.btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);

            this.grpEdit.Controls.Add(this.lblMa);
            this.grpEdit.Controls.Add(this.txtMa);
            this.grpEdit.Controls.Add(this.lblTen);
            this.grpEdit.Controls.Add(this.txtTen);
            this.grpEdit.Controls.Add(this.lblDiaChi);
            this.grpEdit.Controls.Add(this.txtDiaChi);
            this.grpEdit.Controls.Add(this.btnCapNhat);
            this.grpEdit.Controls.Add(this.btnReload);
            this.grpEdit.Controls.Add(this.btnClear);

            // ===== Form =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 444);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpEdit);
            this.Name = "Form2";
            this.Text = "Cập nhật Nhà Xuất Bản";
            this.Load += new System.EventHandler(this.Form2_Load);
        }
    }
}
