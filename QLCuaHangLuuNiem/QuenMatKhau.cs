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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBanDo
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            label2.Text = "";
        }
        Modify modify = new Modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (email.Trim() == "") { MessageBox.Show("vui long nhap email"); }
            else
            {
                string query = "select *from AccDangNhap where Email = '" + email + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Mật khẩu là: " + modify.TaiKhoans(query)[0].MatKhau;

                }
                else
                {
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Email này chưa được đăng ký!";

                }
            }

        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
