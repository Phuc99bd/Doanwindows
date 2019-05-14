using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanlyNhahang.tb;

namespace QuanlyNhahang.tbl
{
    public class MenuDao
    {
        private float price;
        private string foodname;
        private int count;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public string FoodName
        {
            get { return foodname; }
            set { foodname = value; }
        }
        public MenuDao(string foodName, int count, float price, float totalPrice = 0)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public MenuDao(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.Count = (int)row["Count"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
        public float totalprice;
        public float TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
    }
}
