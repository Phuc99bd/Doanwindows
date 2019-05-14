
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanlyNhahang.MA;

namespace QuanlyNhahang.tbl
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
        }

        public List<BillInfo> GetListBillInfo(int iD)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            string query = "SELECT * FROM dbo.BillInfos WHERE IdBill = " + iD;
            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query);

            foreach (DataRow row in dataTable.Rows)
            {
                BillInfo billInfo = new BillInfo(row);
                listBillInfo.Add(billInfo);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int billId, int foodId, int count)
        {
            int i = (int)DataProvider.Instance.ExcuteNonQuery("EXEC Store_InsertBillInfo @billId , @foodId , @count ", new object[] { billId, foodId, count });

        }

    }
}