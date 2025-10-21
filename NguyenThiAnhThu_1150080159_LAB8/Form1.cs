using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThiAnhThu_1150080159_LAB8
{
    public partial class Form1 : Form
    {
        // CHUỖI KẾT NỐI — dùng file Quanlysach.mdf trong project
        private readonly string strCon =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=|DataDirectory|\Quanlysach.mdf;
              Integrated Security=True;
              Connect Timeout=30;
              TrustServerCertificate=True";

        private SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();

            // Cố định DataDirectory về thư mục chạy (bin\Debug)
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
        }

        /* ================= KẾT NỐI CSDL ================= */
        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        /* ================= HIỂN THỊ DANH SÁCH ================= */
        private void HienThiDanhSachNXB()
        {
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT MaXB, TenXB, DiaChi FROM NhaXuatBan ORDER BY TenXB", sqlCon))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();

                        while (reader.Read())
                        {
                            string ma = Convert.ToString(reader["MaXB"])?.Trim();
                            string ten = Convert.ToString(reader["TenXB"]);
                            string dc = Convert.ToString(reader["DiaChi"]);

                            ListViewItem lvi = new ListViewItem(ma ?? "");
                            lvi.SubItems.Add(ten ?? "");
                            lvi.SubItems.Add(dc ?? "");
                            lsvDanhSach.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách NXB: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        /* ================= HIỂN THỊ CHI TIẾT ================= */
        private void HienThiThongTinNXBTheoMa(string ma)
        {
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT MaXB, TenXB, DiaChi FROM NhaXuatBan WHERE MaXB = @ma", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            txtNXB.Text = Convert.ToString(r["MaXB"])?.Trim();
                            txtTenNXB.Text = Convert.ToString(r["TenXB"]);
                            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết NXB: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        /* ================= FORM LOAD ================= */
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MoKetNoi(); // test kết nối nhanh
                DongKetNoi();
                HienThiDanhSachNXB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động form: " + ex.Message);
            }
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            string ma = lsvDanhSach.SelectedItems[0].SubItems[0].Text;
            HienThiThongTinNXBTheoMa(ma);
        }

        /* ================= NÚT THÊM ================= */
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = (txtNXB.Text ?? "").Trim();
            string ten = (txtTenNXB.Text ?? "").Trim();
            string diachi = (txtDiaChi.Text ?? "").Trim();

            if (ma.Length == 0 || ten.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tối thiểu Mã NXB và Tên NXB.");
                return;
            }

            try
            {
                MoKetNoi();

                // Kiểm tra khóa trùng
                using (SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM NhaXuatBan WHERE MaXB=@ma", sqlCon))
                {
                    check.Parameters.AddWithValue("@ma", ma);
                    int count = Convert.ToInt32(check.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Mã NXB đã tồn tại.");
                        return;
                    }
                }

                // Thực hiện thêm
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO NhaXuatBan(MaXB, TenXB, DiaChi) VALUES(@ma, @ten, @dc)", sqlCon))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    cmd.Parameters.AddWithValue("@dc", diachi);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Đã thêm nhà xuất bản vào cơ sở dữ liệu!");
                HienThiDanhSachNXB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm NXB: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }
    }
}
