using System;
using System.Data;

namespace QuanlyNhahang.MA
{
    public class Bill
    {
        int iD;
        DateTime? dateCheckIn;
        DateTime? dateCheckOut;
        int tableId;
        int status;
        int discount;
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


        public int Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }
        public DateTime? DateCheckIn
        {
            get
            {
                return dateCheckIn;
            }

            set
            {
                dateCheckIn = value;
            }
        }

        public DateTime? DateCheckOut
        {
            get
            {
                return dateCheckOut;
            }

            set
            {
                dateCheckOut = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int TableId
        {
            get
            {
                return tableId;
            }

            set
            {
                tableId = value;
            }
        }


        public Bill(int iD, DateTime? dateCheckIn, DateTime? dateCheckOut, int tableId, int status, int discount)
        {
            this.iD = iD;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.tableId = tableId;
            this.status = status;
            this.discount = discount;
        }

        public Bill(DataRow row)
        {
            this.iD = (int)row["iD"];
            this.dateCheckIn = (DateTime?)row["dateCheckIn"];

            var dateCheckoutTemp = row["dateCheckOut"];
            if (dateCheckoutTemp.ToString() != "")
                this.dateCheckOut = (DateTime?)row["dateCheckOut"];

            this.tableId = (int)row["idtable"];
            this.status = (int)row["status"];
            this.discount = (int)row["discount"];
        }
    }
}
