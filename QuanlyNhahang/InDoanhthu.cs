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
    public partial class InDoanhthu : Form
    {
        public InDoanhthu()
        {
            InitializeComponent();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
            DataSet dt = new DataSet();
            dt = cls.Laybang("select Id,DatecheckIn,DatecheckOut,IdTable,discount,TotalPrice from Bills");
            Doanhthu1 m = new Doanhthu1();
            m.SetDataSource(dt);
            crystalReportViewer2.ReportSource = m;
        }
    }
}
