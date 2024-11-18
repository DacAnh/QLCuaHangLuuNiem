using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBanDo;


namespace QLBanDo
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dangkys = new Dangky();
            dangkys.ShowDialog();
        }
        Modify modify = new Modify();
        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk = textBox_TenTaiKhoan.Text;
            string matkhau = textBox_MatKhau.Text;
            if (tentk.Trim() == "") { MessageBox.Show("Vui lòng nhập tài khoản!"); return; }
            else if (matkhau.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu!"); return; }
            else
            {
                string query = "select *from AccDangNhap where TaiKhoan = '" + tentk + "'and MatKhau ='" + matkhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
