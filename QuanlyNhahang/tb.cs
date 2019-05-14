using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanlyNhahang.tb
{
    public class Table
    {
        private int iD;
        private string name;
        private string status;

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

        public string Status
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

        public Table(int id, string name, string status)
        {
            iD = id;
            this.name = name;
            this.status = status;
        }

        public Table(DataRow row)
        {
            iD = (int)row["id"];
            name = row["name"].ToString();
            status = row["status"].ToString();
        }

    }
}
