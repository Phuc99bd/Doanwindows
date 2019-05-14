using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Data;
using DevExpress.DataAccess;


namespace QuanlyNhahang.clsDatabase
{
    class clsDatabase
    {
        //Khai báo các chuỗi kết nối và các đối tượng
        private SqlConnection sqlCon;
        private SqlCommand sqlCom;
        private SqlDataReader sqlRea;
        private SqlDataAdapter sqlAdap;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable("DB");

        //Phương thức kết nối tới CSDL SQL Server

        #region Ketnoi
        public void KetNoi()
        {
            sqlCon = new SqlConnection(Dangnhap.svconnect);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        //Phương thức đóng kết nối tới CSDL
        private void NgatKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        #endregion
        
        #region Xyly
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>
        /// 
        public DataSet Laybang(string sql)
        {
                KetNoi();
                sqlAdap = new SqlDataAdapter(sql, sqlCon);
                sqlAdap.Fill(ds,"DB");
                NgatKetNoi();
                return ds;
 
        }
        public void ThucThiSQLTheoKetNoi(string strSql)
        {
            KetNoi();
            //

            sqlCom = new SqlCommand(strSql, sqlCon);
            sqlCom.ExecuteNonQuery();
            //
            NgatKetNoi();
        }
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>
        public void ThucThiSQLTheoPKN(string strSql)
        {
            ds.Clear();
            //Thực thi
            sqlAdap = new SqlDataAdapter(strSql, Dangnhap.svconnect);
            sqlAdap.Fill(ds, "DB");
        }
        public void Execute(string LenhSQL)
        {
            using (SqlConnection sqlConn = new SqlConnection(Dangnhap.svconnect))
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand(LenhSQL, sqlConn);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }

        /// Phương thức Load dữ liệu lên Combobox
        /// <param name="cb">Tên của  Combobox</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho Combobox</param>
        public void LoadData2Combobox(ComboBox cb, string strSelect)
        {
            //Kết nối
            cb.Items.Clear();
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Combobox
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            //Đóng kết nối
            NgatKetNoi();
        }
        public void LoadData2Label(Label lb, string strSelect)
        {
            lb.Text = "";
            KetNoi();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                lb.Text = sqlRea[0].ToString();
            }
            NgatKetNoi();
        }
        public void LoadDateTextbox(TextBox tx,string strSelect)
        {
            tx.Text = "";
            KetNoi();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while ( sqlRea.Read())
            {
                tx.Text = sqlRea[0].ToString();
            }
            NgatKetNoi();
        }
        /// Phương thức Load dữ liệu lên DataGridView
        /// <param name="dg">Tên của DataGridView</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho DataGridView</param>
        public void LoadData2DataGridView(DataGridView dg, string strSelect)
        {
            dt.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect, Dangnhap.svconnect);
            sqlAdap.Fill(dt);
            dg.DataSource = dt;
        }
        #endregion

        #region Dev
        public void loadcombobox(ComboBox cb,string sql,string member)
        {
            dt.Clear();
            cb.Items.Clear();
            sqlAdap = new SqlDataAdapter(sql, Dangnhap.svconnect);
            sqlAdap.Fill(dt);
            cb.DataSource = dt;
            cb.DisplayMember = member;

        }
        public void loadcombobox2(ComboBox cb, string sql, string member)
        {
            DataTable table2 = new DataTable("DB");
            table2.Clear();
            cb.Items.Clear();
            sqlAdap = new SqlDataAdapter(sql, Dangnhap.svconnect);
            sqlAdap.Fill(table2);
            cb.DataSource = table2;
            cb.DisplayMember = member;

        }
        #endregion

        

    }
}

