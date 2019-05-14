using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyNhahang.MA;
using QuanlyNhahang.tbl;

namespace QuanlyNhahang
{
    public partial class Hoadon : Form
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Hoadon()
        {
            InitializeComponent();
            cls.LoadData2DataGridView(dataGridView1, "select c.Name as 'Tên món' ,a.Count as 'Số lượng',discount as '% KM ',c.Price*a.Count as 'TT' from BillInfos as a, Bills as b, Food as c where b.Id = (select MAX(Id) from Bills) and b.Id = a.IdBill and a.IdFood = c.ID");
            labelNV.Text = Main.TenNV;
            label6.Text = dateTimePicker1.Value.ToString(); 
            cls.LoadData2Label(label7, "select IdTable from Bills where Id = ( select MAX(Id) from Bills) ");
            cls.LoadData2Label(label11, "select TotalPrice from Bills where Id = (select Max(Id) from Bills)");
        }

        private void Hoadon_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Inhoadon m = new Inhoadon();
            m.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
