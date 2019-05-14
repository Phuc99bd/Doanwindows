
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QuanlyNhahang.MA;

namespace QuanlyNhahang.tbl
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public static int TableWidth = 100;
        public static int TableHeight = 70;
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable("EXEC StoreProc_GetTableList");

            foreach (DataRow row in dataTable.Rows)
            {
                Table table = new Table(row);
                tableList.Add(table);
            }

            return tableList;
        }

        public bool InsertTable()
        {
            string query = "EXEC StoreProc_InsertTable";
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public bool DeleteTable(int tableId)
        {
            string query = "EXEC StoreProc_DeleteTable @tableId ";
            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableId }) > 0;
        }

        public bool ResetTableName()
        {
            string query = "EXEC StoreProc_ResetAllTableNames";
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

    }
}

