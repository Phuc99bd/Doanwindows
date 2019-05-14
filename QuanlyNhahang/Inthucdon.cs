using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyNhahang
{
    public partial class Inthucdon : Form
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Inthucdon()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
            DataSet ds = new DataSet();
            ds = cls.Laybang("SELECT Food.Name, Food.Price, FoodCategory.Name FROM  QLNH.dbo.Food Food INNER JOIN QLNH.dbo.FoodCategory FoodCategory ON Food.IdCategory = FoodCategory.ID");
            FoodDataset m = new FoodDataset();
            m.SetDataSource(ds);
            crystalReportViewer2.ReportSource = m;
        }
    }
}
