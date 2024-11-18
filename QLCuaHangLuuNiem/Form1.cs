using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QLCuaHangLuuNiem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

       
        string str = "Data Source=TENSANG;Initial Catalog=Db;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
       
        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddataNV();
            loaddataKH();
           
        }
        //Qli Nhân Viên
        void loaddataNV()
            {
                DataTable dtNhanVien = new DataTable();
                command = connection.CreateCommand();
                command.CommandText = "SELECT maNhanVien AS [Mã nhân viên], hoTen AS [Tên nhân viên], soDienThoai AS [Số Điện Thoại], chucVu AS [Chức vụ] FROM NhanVien";
                adapter.SelectCommand = command;
                dtNhanVien.Clear();
                adapter.Fill(dtNhanVien);
                dgvNhanVien.DataSource = dtNhanVien;
            }

            private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                txtNVMNV.ReadOnly = true;
                int i;
                i = dgvNhanVien.CurrentRow.Index;
                txtNVMNV.Text = dgvNhanVien.Rows[i].Cells["Mã nhân viên"].Value.ToString();
                txtNVTNV.Text = dgvNhanVien.Rows[i].Cells["Tên nhân viên"].Value.ToString();
                txtNVCV.Text = dgvNhanVien.Rows[i].Cells["Chức vụ"].Value.ToString();
                mskNVDT.Text = dgvNhanVien.Rows[i].Cells["Số điện thoại"].Value.ToString();
            }

            private void btnNVThemm_Click(object sender, EventArgs e)
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into NhanVien(hoTen,chucVu,soDienThoai) values (N'" + txtNVTNV.Text + @"',N'" + txtNVCV.Text + @"',N'" + mskNVDT.Text + @"')";
                command.ExecuteNonQuery();
                loaddataNV();
            }

            private void btnNVSua_Click(object sender, EventArgs e)
            {
                command = connection.CreateCommand();
                command.CommandText = "update NhanVien set hoTen =N'" + txtNVTNV.Text + "', chucVu = N'" + txtNVCV.Text + "', soDienThoai ='" + mskNVDT.Text + "' where maNhanVien = '" + txtNVMNV.Text + "' ";
                command.ExecuteNonQuery();
                loaddataNV();
            }

           private void btnNVXoa_Click(object sender, EventArgs e)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from NhanVien where  maNhanVien = '" + txtNVMNV.Text + @"'";
                command.ExecuteNonQuery();
                loaddataNV();
            }
        //Qli Khách hàng
        void loaddataKH()
        {
            DataTable dtKhachHang = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "SELECT maKhachHang AS [Mã Khách Hàng], hoTen AS [Tên Khách Hàng], soDienThoai AS [Số Điện Thoại], diaChi AS [Địa Chỉ] FROM KhachHang";
            adapter.SelectCommand = command;
            dtKhachHang.Clear();
            adapter.Fill(dtKhachHang);
            dgvKhachHang.DataSource = dtKhachHang;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtKHMKH.ReadOnly = true;
            int i;
            i = dgvKhachHang.CurrentRow.Index;
            txtKHMKH.Text = dgvKhachHang.Rows[i].Cells["Mã khách hàng"].Value.ToString();
            txtKHTKH.Text = dgvKhachHang.Rows[i].Cells["Tên khách hàng"].Value.ToString();
            txtKHDC.Text = dgvKhachHang.Rows[i].Cells["Địa chỉ"].Value.ToString();
            msbKHDT.Text = dgvKhachHang.Rows[i].Cells["Số điện thoại"].Value.ToString();

        }

        private void btnKHThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into KhachHang(hoTen,soDienThoai,diaChi) values (N'" + txtKHTKH.Text + @"','" + msbKHDT.Text + @"',N'" + txtKHDC.Text + @"')";
            command.ExecuteNonQuery();
            loaddataKH();
        }

        private void btnKHSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update KhachHang set hoTen =N'" + txtKHTKH.Text + "', soDienThoai ='" + msbKHDT.Text + "', diaChi = N'" + txtKHDC.Text + "'  where maKhachHang = '" + txtKHMKH.Text + "' ";
            command.ExecuteNonQuery();
            loaddataKH();
        }

        private void btnKHXoa_Click(object sender, EventArgs e)
        {

            command = connection.CreateCommand();
            command.CommandText = "delete from KhachHang where  maKhachHang = '" + txtKHMKH.Text + @"'";
            command.ExecuteNonQuery();
            loaddataKH();
        }
        //Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            Application.Exit();
        }

        
    }

}
