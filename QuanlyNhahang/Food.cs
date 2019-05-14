using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace QuanlyNhahang.tbl
{
    public class Food
    {
        int id;
        string name;
        int idCategory;
        int price;
        string nameAndPrice;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int IdCategory
        {
            get
            {
                return idCategory;
            }

            set
            {
                idCategory = value;
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

        public string NameAndPrice
        {
            get
            {
                return nameAndPrice;
            }

            set
            {
                nameAndPrice = value;
            }
        }

        public Food(int id, string name, int idCategory, int price)
        {
            this.id = id;
            this.name = name;
            this.idCategory = idCategory;
            this.price = price;
            this.nameAndPrice = name + " - " + price + " VNĐ";
        }

        public Food(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.idCategory = (int)row["idCategory"];
            this.price = Convert.ToInt32(row["price"].ToString());
            this.nameAndPrice = name + " - " + price + " VNĐ";
        }
    }
}

