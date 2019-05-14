using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanlyNhahang.MA
{
    public class Category
    {
        int id;
        string name;

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

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Category(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
        }
    }
}
