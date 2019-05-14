using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanlyNhahang.MA
{
    public class BillInfo
    {
        int iD;
        int billId;
        int foodId;
        int count;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public int BillId
        {
            get
            {
                return billId;
            }

            set
            {
                billId = value;
            }
        }

        public int FoodId
        {
            get
            {
                return foodId;
            }

            set
            {
                foodId = value;
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

        public BillInfo(int id, int billid, int foodid, int count)
        {
            iD = id;
            billId = billid;
            foodId = foodid;
            this.count = count;
        }

        public BillInfo(DataRow row)
        {
            iD = (int)row["id"];
            billId = (int)row["idbill"];
            foodId = (int)row["idfood"];
            count = (int)row["count"];
        }
    }
}
