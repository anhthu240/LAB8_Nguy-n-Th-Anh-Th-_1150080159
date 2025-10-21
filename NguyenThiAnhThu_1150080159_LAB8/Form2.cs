using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThiAnhThu_1150080159_LAB8
{
    public partial class Form2 : Form
    {
       
        private readonly string strCon =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=|DataDirectory|\Quanlysach.mdf;
              Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";

        private SqlConnection _con;

        public Form2()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
            txtMa.BringToFront();
            txtTen.BringToFront();
            txtDiaChi.BringToFront();
            btnCapNhat.BringToFront();
            btnReload.BringToFront();
            btnClear.BringToFront();
        }

        private void OpenConn()
        {
            if (_con == null) _con = new SqlConnection(strCon);
            if (_con.State == ConnectionState.Closed) _con.Open();
        }
        private void CloseConn()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }

        /* ============ EVENTS ============ */

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtMa.Focus();
        }

        private void lsvNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNXB.SelectedItems.Count == 0) return;
            string ma = lsvNXB.SelectedItems[0].SubItems[0].Text;
            LoadDetail(ma);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = (txtMa.Text ?? "").Trim();
            string ten = (txtTen.Text ?? "").Trim();
            string dc = (txtDiaChi.Text ?? "").Trim();

            if (ma.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập/chọn Mã NXB.");
                txtMa.Focus();
                return;
            }

            try
            {
                OpenConn();

                // Ưu tiên gọi Stored Procedure CapNhatThongTin (nếu có)
                try
                {
                    using (var cmd = new SqlCommand("CapNhatThongTin", _con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@maXB", SqlDbType.Char, 12).Value = ma;
                        cmd.Parameters.Add("@tenXB", SqlDbType.NVarChar, 100).Value = ten;
                        cmd.Parameters.Add("@diaChi", SqlDbType.NVarChar, 500).Value = dc;

                        int kq = cmd.ExecuteNonQuery();
                        MessageBox.Show(kq > 0 ? "Đã cập nhật." : "Không có bản ghi nào được cập nhật.");
                    }
                }
                catch (SqlException ex) when (ex.Number == 2812)
                {
                  
                    using (var cmd = new SqlCommand(
                        "UPDATE NhaXuatBan SET TenXB=@ten, DiaChi=@dc WHERE MaXB=@ma", _con))
                    {
                        cmd.Parameters.Add("@ma", SqlDbType.Char, 12).Value = ma;
                        cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ten;
                        cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 500).Value = dc;

                        int kq = cmd.ExecuteNonQuery();
                        MessageBox.Show(kq > 0 ? "Đã cập nhật." : "Không có bản ghi nào được cập nhật.");
                    }
                }

                LoadList();

                // Focus lại dòng vừa sửa
                foreach (ListViewItem it in lsvNXB.Items)
                    if (string.Equals(it.SubItems[0].Text, ma, StringComparison.OrdinalIgnoreCase))
                    {
                        it.Selected = true;
                        it.Focused = true;
                        it.EnsureVisible();
                        break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
            finally { CloseConn(); }
        }

        /* ============ DATA HELPERS ============ */

        private void LoadList()
        {
            try
            {
                OpenConn();
                using (var cmd = new SqlCommand(
                    "SELECT MaXB, TenXB, DiaChi FROM NhaXuatBan ORDER BY TenXB", _con))
                using (var rd = cmd.ExecuteReader())
                {
                    lsvNXB.Items.Clear();
                    while (rd.Read())
                    {
                        string ma = Convert.ToString(rd["MaXB"])?.Trim();
                        string ten = Convert.ToString(rd["TenXB"]);
                        string dc = Convert.ToString(rd["DiaChi"]);

                        var item = new ListViewItem(ma ?? "");
                        item.SubItems.Add(ten ?? "");
                        item.SubItems.Add(dc ?? "");
                        lsvNXB.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
            finally { CloseConn(); }
        }

        private void LoadDetail(string ma)
        {
            try
            {
                OpenConn();
                using (var cmd = new SqlCommand(
                    "SELECT MaXB, TenXB, DiaChi FROM NhaXuatBan WHERE MaXB=@ma", _con))
                {
                    cmd.Parameters.Add("@ma", SqlDbType.Char, 12).Value = (ma ?? "").Trim();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            txtMa.Text = Convert.ToString(rd["MaXB"])?.Trim() ?? "";
                            txtTen.Text = Convert.ToString(rd["TenXB"]) ?? "";
                            txtDiaChi.Text = Convert.ToString(rd["DiaChi"]) ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem chi tiết: " + ex.Message);
            }
            finally { CloseConn(); }
        }
    }
}
