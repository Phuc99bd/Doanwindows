using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanlyNhahang.MA;
using QuanlyNhahang.tbl;
namespace QuanlyNhahang
{
    public partial class InfomationCategory : UserControl
    {
        public InfomationCategory()
        {
            InitializeComponent();
           
            Phanquyen();
            
            this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
            this.foodTableAdapter1.Fill(this.test.Food);
           
        }
        private void Phanquyen()
        {
            if(Main.Quyen=="admin")
            {

            }
            else
                if(Main.Quyen=="user")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                
            }
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void label1_Click(object sender, EventArgs e)
        {

        }
   
        private void LoadGrid2()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from FoodCategory", Dangnhap.svconnect);
            adapter.Fill(dt);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Addcategory m = new Addcategory();
            m.ShowDialog();
            this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
            this.foodTableAdapter1.Fill(this.test.Food);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
            this.foodTableAdapter1.Fill(this.test.Food);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepairCategory m = new RepairCategory();
            m.ShowDialog();
            this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
            this.foodTableAdapter1.Fill(this.test.Food);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DeleteCategory m = new DeleteCategory();
            //m.ShowDialog();
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            DialogResult dt = MessageBox.Show("Bạn có chắc chắn muốn xóa loaì: " + row["Name"].ToString(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dt == DialogResult.OK)
            {

                string sql = "delete dbo.FoodCategory where Id=" + row["Id"].ToString() + "";
                cls.ThucThiSQLTheoPKN(sql);
            }
            this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
            this.foodTableAdapter1.Fill(this.test.Food);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
          
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InfomationCategory_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Returnclass rs = new Returnclass();
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (Main.Quyen == "admin")
            {
                DataRow row;

                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    row = gridView1.GetDataRow(i);

                    string query = "update dbo.FoodCategory set Name=N'" + row["Name"].ToString() + "' "
                    + "where Id=" + row["Id"].ToString() + "";
                    cls.ThucThiSQLTheoPKN(query);






                }
                this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
                this.foodTableAdapter1.Fill(this.test.Food);
            }
            else
            {
                this.foodCategoryTableAdapter1.Fill(this.test.FoodCategory);
                this.foodTableAdapter1.Fill(this.test.Food);
            }
        }
    }
}
