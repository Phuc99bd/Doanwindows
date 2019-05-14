using QuanlyNhahang.MA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanlyNhahang.tbl
{
    class BillOfTableDetailsDAO
    {
        private static BillOfTableDetailsDAO instance;

        internal static BillOfTableDetailsDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillOfTableDetailsDAO();
                return instance;
            }
        }

        public List<BillDetails> GetListBillDetailsByBillId(int iD)
        {
            List<BillDetails> listBillDetails = new List<BillDetails>();

            string query = "EXEC StoreProc_GetListBillDetailsByBillId @billId";
            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { iD });

            foreach (DataRow row in dataTable.Rows)
            {
                listBillDetails.Add(new BillDetails(row));
            }

            return listBillDetails;
        }
    }
}
