using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace QuanlyNhahang
{
    class Returnclass
    {
        public string scalarReturn(string q)
        {
            string s;
            SqlConnection conn = new SqlConnection(Dangnhap.svconnect);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(q, conn);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                s = (" ");
            }
            conn.Close();
            return s;
        }
    }
}
