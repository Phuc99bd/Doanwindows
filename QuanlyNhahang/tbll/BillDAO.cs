
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanlyNhahang.MA;

namespace QuanlyNhahang.tbl
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        //Lấy được Bill Id : dataTable.Rows[0]["id"]
        //Không lấy được : -1
        public int GetUnCheckBillIdByTableId(int tableId)
        {
            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable("select * from dbo.Bills where IdTable=" + tableId + " and status =0");

            if (dataTable.Rows.Count > 0)
            {
                Bill bill = new Bill(dataTable.Rows[0]);
                return bill.ID;
                //return (int)dataTable.Rows[0]["id"];
            }

            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("EXEC StorePP_InsertBillByTableId @tableId", new object[] { id });

        }

        public int GetMaxBillId()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(Id) FROM dbo.Bills");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id, int discount, int totalprice)
        {
            string query = "EXEC StoreProc_CheckOutBill @billId , @discount , @totalPrice";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, discount, totalprice });
        }

        public DataTable GetCheckOutBillListByDate(DateTime checkin, DateTime checkout)
        {
            string query = "EXEC StoreProc_GetCheckOutBillListByDate @dateTime1 , @dateTime2";

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { checkin, checkout });

            return dataTable;
        }
        public DataTable GetTotalPrice(DateTime checkin, DateTime checkout)
        {
            string query = "EXEC StoreTotalDT @dateTime1 , @dateTime2 ";
            DataTable data = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { checkin, checkout });
            return data;
        }
        public DataTable GettotalNow(DateTime checkout)
        {
            string query = "EXEC StoreTotalNow @dateTime1 ";
            DataTable data = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { checkout });
            return data;
        }
    }
}

