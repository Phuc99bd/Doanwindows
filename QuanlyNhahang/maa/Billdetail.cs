using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanlyNhahang.MA
{
    public class BillDetails
    {
        string foodName;
        int count;
        int price;
        int totalPrice;

        public string FoodName
        {
            get
            {
                return foodName;
            }

            set
            {
                foodName = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public BillDetails(string foodName, int count, int price, int totalPrice = 0)
        {
            this.foodName = foodName;
            this.count = count;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public BillDetails(DataRow row)
        {
            foodName = row["name"].ToString();
            count = (int)row["count"];
            price = Convert.ToInt32(row["price"].ToString());
            totalPrice = Convert.ToInt32(row["totalprice"].ToString());
        }
    }
}
