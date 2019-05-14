
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using QuanlyNhahang.MA;

namespace QuanlyNhahang.tbl
{
    public class CategoryDAO
    {
        static private CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return instance;
            }
        }

        public List<Category> GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();

            string query = "SELECT * FROM dbo.FoodCategory";

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query);

            foreach (DataRow row in dataTable.Rows)
            {
                categoryList.Add(new Category(row));
            }

            return categoryList;
        }

        public Category GetCategoryById(int categoryId)
        {
            string query = "EXEC StoreProc_GetCategoryById @categoryId";

            DataTable data = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { categoryId });

            Category category = null;

            if (data.Rows.Count > 0)
                category = new Category(data.Rows[0]);

            return category;
        }

        public bool InsertCategory(string categoryName)
        {
            string query = "EXEC StoreProc_InsertCategory @categoryname ";

            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryName }) > 0;
        }

        public bool UpdateCategory(int categoryId, string categoryName)
        {
            string query = "EXEC StoreProc_UpdateCategory @categoryid , @categoryname ";

            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryId, categoryName }) > 0;
        }

        public bool DeleteCategory(int categoryId)
        {
            string query = "EXEC StoreProc_DeleteCategory @categoryId ";

            return DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryId }) > 0;
        }
    }
}
