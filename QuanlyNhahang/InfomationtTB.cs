using System;
using System.Windows.Forms;
using System.Data;
namespace QuanlyNhahang
{
    public partial class InfomationtTB : UserControl
    {
        public InfomationtTB()
        {

            InitializeComponent();
            this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
            this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
            
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
            }
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void InfomationtTB_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTable m = new AddTable();
            m.ShowDialog();
            this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
            this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepairTB m = new RepairTB();
            m.ShowDialog();
            this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
            this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteTB m = new DeleteTB();
            m.ShowDialog();
            this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
            this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (Main.Quyen == "admin")
            {
                DataRow row;

                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    row = gridView1.GetDataRow(i);

                    string query = "update dbo.TableFood set Name=N'" + row["Name"].ToString() + "',Status=N'" + row["Status"].ToString() + "' "
                    + "where Id=" + row["Id"].ToString() + "";
                    cls.ThucThiSQLTheoPKN(query);


                }
                this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
                this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
            }
            else
            {
                this.checkoutTableAdapter.Fill(this.qLNHDataSet5.checkout);
                this.tableaTableAdapter.Fill(this.qLNHDataSet5.tablea);
            }
        }
    }
}
