
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using QuanlyNhahang.MA;

namespace QuanlyNhahang.tbl
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }
        }

        public List<Food> GetFoodListByCategoryId(int categoryId)
        {
            List<Food> listFood = new List<Food>();

            string query = "EXEC dbo.StoreProc_GetFoodListByCategoryId @categoryId";

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { categoryId });

            foreach (DataRow row in dataTable.Rows)
            {
                listFood.Add(new Food(row));
            }

            return listFood;
        }

        public List<Food> SearchFoodByName(string foodName)
        {
            List<Food> listFood = new List<Food>();

            string query = "EXEC StoreProc_SearchFoodByName @foodname ";

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query, new object[] { foodName });

            foreach (DataRow row in dataTable.Rows)
            {
                listFood.Add(new Food(row));
            }

            return listFood;
        }

        public List<Food> GetFoodList()
        {
            List<Food> listFood = new List<Food>();

            string query = "SELECT * FROM FOOD ORDER BY IdCategory , Name";

            DataTable dataTable = DataProvider.Instance.ExcuteQueryGetDataTable(query);

            foreach (DataRow row in dataTable.Rows)
            {
                listFood.Add(new Food(row));
            }

            return listFood;
        }
      

       
    }
}
