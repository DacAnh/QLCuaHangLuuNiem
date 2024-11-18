using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QLCuaHangLuuNiem
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=LAPTOP-B4J6DCSQ;Initial Catalog=TaiKhoanDangNhap;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}

