using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyNhahang.MA;
using QuanlyNhahang.tbl;
using System.Data.SqlClient;
using System.Xml.XmlConfiguration;

namespace QuanlyNhahang
{
    public partial class InfomationFood : UserControl
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public InfomationFood()
        {
            InitializeComponent();
            loadGridcontrol();
            
            Phanquyen();
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
                button3.Enabled = false;
                bunifuThinButton21.Enabled = false;
            }
        }
        private void loadGridcontrol()
        {
            
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select a.Id,a.Name,a.IdCategory,b.Name as N'Tên loại',a.Price from Food a,FoodCategory b where a.IdCategory = b.ID ", Dangnhap.svconnect);
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadGridcontrol();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addfood m = new Addfood();
            m.ShowDialog();
            loadGridcontrol();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //RepairFood m = new RepairFood();
            //m.ShowDialog();
            //loadGridcontrol();

            DataRow row;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                row = gridView1.GetDataRow(i);
                string query = "update dbo.Food set Name=N'" + row["Name"].ToString() + "',IdCategory=" +
                    row["IdCategory"].ToString()+ ",Price="+row["Price"].ToString()+" where Id="+ row["Id"].ToString() +"";

                cls.ThucThiSQLTheoPKN(query);
   

            }
            loadGridcontrol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DeleteFood m = new DeleteFood();
            //m.ShowDialog();
            //loadGridcontrol();
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            DialogResult dt = MessageBox.Show("Bạn có chắc chắn muốn xóa món: " + row["Name"].ToString(), "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dt == DialogResult.OK)
            {

                string sql = "delete dbo.Food where Id=" + row["Id"].ToString() + "";
                cls.ThucThiSQLTheoPKN(sql);
            }
            loadGridcontrol();
        }

        private void InfomationFood_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select a.ID,a.Name,f.Name as NameCategory,a.Price from Food as a,FoodCategory as f where a.Name like '" + searchControl1.Text + "%' and a.IdCategory = f.ID OrDER BY ID", Dangnhap.svconnect);
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Inthucdon m = new Inthucdon();
            m.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        Returnclass rs = new Returnclass();
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (Main.Quyen == "admin")
            {
                DataRow row;
                int m = gridView1.RowCount;
                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    row = gridView1.GetDataRow(i);
                    string a = rs.scalarReturn("select Id from dbo.Food where Id=" + row["Id"].ToString() + "");
                    string query = "update dbo.Food set Name=N'" + row["Name"].ToString() + "',IdCategory=" +
                    row["IdCategory"].ToString() + ",Price=" + row["Price"].ToString() + " where Id=" + row["Id"].ToString() + "";
                    cls.ThucThiSQLTheoPKN(query);
                    if (gridView1.RowCount > m)
                    {
                        string sql = "insert dbo.Food values('" + row["Name"].ToString() + "'," + row["IdCategory"].ToString() + "," + row["Price"].ToString() + ")";
                        cls.ThucThiSQLTheoPKN(sql);
                    }
                }
            }
            else
            {

            }

            
            loadGridcontrol();


        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {

        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if(e.KeyCode == Keys.Delete)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                DialogResult dt = MessageBox.Show("Bạn có chắc chắn muốn xóa món: " + row["Name"].ToString(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dt == DialogResult.OK)
                {

                    string sql = "delete dbo.Food where Id=" + row["Id"].ToString() + "";
                    cls.ThucThiSQLTheoPKN(sql);
                }
                loadGridcontrol();
            }
        }
    }
}
