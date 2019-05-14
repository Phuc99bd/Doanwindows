using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanlyNhahang.tbl;

namespace QuanlyNhahang.MA
{
    public class Menus
    {
        private static Menus instance;

        public static Menus Instance
        {
            get
            {
                if (instance == null) instance = new Menus(); return Menus.instance;
            }
            private set
            {
                Menus.instance = value;
            }
        }

        private Menus()
        {

        }
        public List<MenuDao> GetListMenuByTable(int id)
        {
            List<MenuDao> listmenu = new List<MenuDao>();
            DataTable data = DataProvider.Instance.ExcuteQueryGetDataTable("select f.Name ,bi.Count,f.Price,f.Price*bi.Count as TotalPrice from dbo.BillInfos as bi, dbo.Bills as b, dbo.Food as f where bi.IdBill = b.Id and bi.IdFood = f.ID and status=0 and b.IdTable=" + id + "");

            foreach (DataRow item in data.Rows)
            {
                MenuDao menu = new MenuDao(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }

    }
}
