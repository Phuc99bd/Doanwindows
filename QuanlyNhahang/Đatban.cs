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

namespace QuanlyNhahang
{
    public partial class Đatban : UserControl
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Đatban()
        {
            InitializeComponent();
            phanquyen();
            timer1.Start();
            dataGridView1.Hide();
        }
        void phanquyen()
        {
            if(Main.Quyen == "admin")
            {

            }
            else
                if(Main.Chucvu=="Thu ngân")
                {
                flowLayoutPanel4.Enabled = false;
                }
            else
                if(Main.Chucvu=="Nhân viên order")
            {
                button4.Enabled = false;
            }
        }
        private void Đatban_Load(object sender, EventArgs e)
        {
            loadcategory();
            Loadtable();
            loadfood();
            comboBox3.Items.Add("0");
            comboBox3.Items.Add("5");
            comboBox3.Items.Add("10");
            comboBox3.Items.Add("15");
            comboBox3.Items.Add("20");
            comboBox3.Items.Add("25");
            comboBox3.Items.Add("30");
            comboBox3.Items.Add("50");
            comboBox3.SelectedIndex = 0;
            loadbanpv();
           
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void loadbanpv()
        {
            cls.LoadData2Label(txt_SLbanphucvu, "select count(Id) from TableFood where Status=N'Có người'");
            txt_SLbanphucvu.Text=txt_SLbanphucvu.Text + " Bàn";
        }
        #region LoadDulieu
        void Loadtable()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            comboBox1.DataSource = TableDAO.Instance.LoadTableList();
            comboBox1.DisplayMember= "Name";
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Font = new Font("Times New Roman", 12.0f);
                btn.Click += btn_click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }

        }
      
        #endregion
        #region XulyTable
        public static int tblWidth = 60, tblHeight = 60, tblHeight_cate = 30, tblWidth_cate = 120, tblWidth_mon = 170, tblHeight_mon = 30, tblWidth_chitiet = 350, tblHeight_chitiet = 80;
        private void loadlist(int id)
        {

            flowLayoutPanel2.Controls.Clear();
            int tongTien = 0;
            Button btn = flowLayoutPanel2.Tag as Button;
            Table table = (Table)btn.Tag;
            int billId = BillDAO.Instance.GetUnCheckBillIdByTableId(table.ID);
            if (billId == -1)
            {
                txtNameBan.Text = table.Name;
                txttrangthai.Text = "Trống";
                
            }
            else
            {
                txtNameBan.Text = table.Name;
                txttrangthai.Text = "Có người";
                 
            int tableId1 = ((flowLayoutPanel2.Tag as Button).Tag as Table).ID;
            DataTable dt = DataProvider.Instance.ExcuteQueryGetDataTable("select bi.Id,f.Name ,bi.Count,f.Price,f.Price*bi.Count as TotalPrice from dbo.BillInfos as bi, dbo.Bills as b, dbo.Food as f where bi.IdBill = b.Id and bi.IdFood = f.ID and status=0 and b.IdTable=" + tableId1 + "");
            foreach (DataRow row in dt.Rows)
            {
                Button bnt = new Button() { Name = row["Id"].ToString(), Width = tblWidth_chitiet, Height = tblHeight_chitiet, BackColor = Color.Transparent };
                Label lbTM = new Label() { Text = row["Name"].ToString(), Location = new Point(5, 10),Width=165, BackColor = Color.Transparent, Font = new Font("Times New Roman", 12.0f), ForeColor = Color.DarkBlue };
                Label lbDG = new Label() { Text = "Giá: "+ row["Price"].ToString() , Location = new Point(170, 12), Width = 100, BackColor = Color.Transparent, Font = new Font("Times New Roman", 12.0f), ForeColor = Color.Red };
                Label lbSL = new Label() { Text = "Số lượng: ", Width = 90, Location = new Point(5, 45), BackColor = Color.Transparent, Font = new Font("Times New Roman", 12.0f), ForeColor = Color.Green };
                Button lbtru = new Button() { Text = "-", Width = 30, Height = 30, Location = new Point(102, 40 )};
                Label lbSLnow = new Label() { Text=row["Count"].ToString(), Width = 15, Location = new Point(145, 45), BackColor = Color.Transparent, Font = new Font("Times New Roman", 12.0f), ForeColor = Color.Green };
                Button lbcong = new Button() { Text = "+", Width = 30, Height = 30, Location = new Point(175, 40) };
                Button bntX = new Button() { Text = "X", Width = 50,Height=35, Location = new Point(270, 20) };
                bntX.Tag = row;
                lbtru.Tag = row;
                    lbcong.Tag = row;
                lbtru.Click += Lbtru_Click;
                lbcong.Click += Lbcong_Click;
                bntX.Click += bntX_Click;
                bnt.Controls.Add(lbTM);
                bnt.Controls.Add(lbDG);
                bnt.Controls.Add(lbSL);
                bnt.Controls.Add(lbtru);
                bnt.Controls.Add(lbSLnow);
                bnt.Controls.Add(lbcong);
                bnt.Controls.Add(bntX);
                flowLayoutPanel2.Controls.Add(bnt);
                tongTien += Convert.ToInt32(row["Price"].ToString()) * Convert.ToInt32(row["Count"]);
                bnt.Tag = row;
                    
            }
            }
            txtTienmon.Text = tongTien.ToString();
            txtTongthanhtoan.Text = ((tongTien / 100) * (100 - int.Parse(comboBox3.Text))).ToString();
            
        }

        private void Lbcong_Click(object sender, EventArgs e)
        {
            Button btn = flowLayoutPanel2.Tag as Button;
            Table table = (Table)btn.Tag;
            DataRow row = ((sender as Button).Tag as DataRow);
            int a = int.Parse(row["Count"].ToString());
                a = a + 1;
                string sql = "update dbo.BillInfos set Count=" + a + "where Id= " + row["Id"].ToString() + " ";
                cls.ThucThiSQLTheoPKN(sql);
                loadlist(table.ID);

        }

        private void Lbtru_Click(object sender, EventArgs e)
        {
            Button btn = flowLayoutPanel2.Tag as Button;
            Table table = (Table)btn.Tag;
            DataRow row= ((sender as Button).Tag as DataRow);
            int a= int.Parse(row["Count"].ToString());
            if (a != 0)
            {
                a = a - 1;
                string sql = "update dbo.BillInfos set Count=" + a + "where Id= " + row["Id"].ToString() + " ";
                cls.ThucThiSQLTheoPKN(sql);
                loadlist(table.ID);
            }
            else
            {
                MessageBox.Show("Không thể - số lượng vì min số lượng =0");
            }
        }

        void bntX_Click(object sender,EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Button btn = flowLayoutPanel2.Tag as Button;
                Table table = (Table)btn.Tag;
                DataRow row = ((sender as Button).Tag as DataRow);
                string sql = "delete dbo.BillInfos where Id = " + row["Id"].ToString() + " ";
                cls.ThucThiSQLTheoPKN(sql);
                loadlist(table.ID);
                
            }
        }
        private void loadcategory()
        {
            DataTable da = DataProvider.Instance.ExcuteQueryGetDataTable("select ID,Name from FoodCategory");
            foreach(DataRow cate in da.Rows)
            {
                Button bntc = new Button() { Name = cate["ID"].ToString(), Width = 350, Height = 35, BackColor = Color.Transparent, ForeColor = Color.Red };
                Label lbTM = new Label() { Text = cate["Name"].ToString(), Location = new Point(150, 10), Width = 165, BackColor = Color.Transparent, Font = new Font("Times New Roman", 14.0f), ForeColor = Color.DarkBlue };
                bntc.Controls.Add(lbTM);
                bntc.Tag = cate;
                bntc.Click += bntc_click;
                flowLayoutPanel3.Controls.Add(bntc);
            }
        }
        private void bntc_click(object sender,EventArgs e)
        {
            flowLayoutPanel4.Controls.Clear();
            DataRow cate = ((sender as Button).Tag as DataRow);
            DataTable da1 = DataProvider.Instance.ExcuteQueryGetDataTable("select ID,Name,IdCategory,Price from Food where IdCategory=" + cate["ID"].ToString() + "");
            foreach(DataRow ds in da1.Rows)
            {
                Button bntf = new Button() { Name = ds["ID"].ToString(), Width = 350, Height = 50, BackColor = Color.Transparent, ForeColor = Color.Red };
                Label ls = new Label() { Text = ds["Name"].ToString() + "-" + ds["Price"].ToString() +" VNĐ", Width = 330, Location = new Point(15, 15), BackColor = Color.Transparent, Font = new Font("Times New Roman", 14.0f), ForeColor = Color.DarkBlue };

                bntf.Controls.Add(ls);
              
                bntf.Click += Bntf_Click;
                bntf.Tag = ds;
                flowLayoutPanel4.Controls.Add(bntf);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTongthanhtoan.Text = ((int.Parse(txtTienmon.Text) / 100) * (100 - int.Parse(comboBox3.Text))).ToString();
        }

        void loadfood()
        {
            flowLayoutPanel4.Controls.Clear();
            DataTable dp = DataProvider.Instance.ExcuteQueryGetDataTable("select ID,Name,Price from Food ");
            foreach (DataRow ds in dp.Rows)
            {
                Button bntf = new Button() { Name = ds["ID"].ToString(), Width = 350, Height = 50, BackColor = Color.Transparent, ForeColor = Color.Red };
                Label ls = new Label() { Text = ds["Name"].ToString() +"-" + ds["Price"].ToString() + " VNĐ", Width = 330, Location = new Point(15, 15), BackColor = Color.Transparent, Font = new Font("Times New Roman", 14.0f), ForeColor = Color.DarkBlue };
                bntf.Controls.Add(ls);
                bntf.Tag = ds;
                bntf.Click += Bntf_Click;
                flowLayoutPanel4.Controls.Add(bntf);
            }
        }

        private void Bntf_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow ds = ((sender as Button).Tag as DataRow);
                Button btn = flowLayoutPanel2.Tag as Button;
                Table table = (Table)btn.Tag;
                int billId = BillDAO.Instance.GetUnCheckBillIdByTableId(table.ID);
                if (billId == -1)// Bàn trống.
                {
                   
                    txttrangthai.Text = table.Status;
                    BillDAO.Instance.InsertBill(table.ID);
                    cls.ThucThiSQLTheoPKN("update dbo.TableFood set Status =N'Có Người' where ID='" + table.ID + "'");
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetUnCheckBillIdByTableId(table.ID), Convert.ToInt32(ds["ID"].ToString()), 1);
                    
                }
                else
                {
                    
                    BillInfoDAO.Instance.InsertBillInfo(billId, Convert.ToInt32(ds["ID"].ToString()), 1);
                }
                
                Loadtable();
                loadlist(table.ID);
                loadbanpv();
                
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn order");
            }
           

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

       
        private void button8_Click(object sender, EventArgs e)
        {
            
        }

       

        private void contextMenuStrip2_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void chuyểnBànToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void gộpBànToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DialogResult dt = (MessageBox.Show("Mời bạn chọn thao tác?Yes = Chuyển bàn : No = Gộp bàn : Cancel = Hủy thao tác ", "Thông báo", MessageBoxButtons.YesNoCancel));
            if (dt == DialogResult.Yes)
            {
                string query = "EXEC StoreProc_SwapBillForTable  @tableId1 , @tableId2 ";

                int tableId1 = ((flowLayoutPanel2.Tag as Button).Tag as Table).ID;
                int tableId2 = (comboBox1.SelectedItem as Table).ID;
                if (tableId1 == tableId2) return;//tranh lag du lieu.

                Button btn1 = flowLayoutPanel2.Tag as Button;
                Table table1 = btn1.Tag as Table;
                int index = comboBox1.SelectedIndex;
                Button btn2 = (flowLayoutPanel1.Controls[index] as Button);
                Table table2 = btn2.Tag as Table;

                string s = string.Format("Bạn có chắc chuyển {0} sang {1} không ?", table1.Name, table2.Name);
                if (MessageBox.Show(s, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableId1, tableId2 });
                    ////////////////////////////////////////////////////////////////////////////////////////////////
                    if (table2.Status == "Trống")
                    {//Bàn 2:
                        table2.Status = "Có người";
                        btn2.Text = table2.Name + "\n(" + table2.Status + ")";
                        btn2.BackColor = Color.LightGreen;
                        //Bàn 1:
                        table1.Status = "Trống";
                        btn1.Text = table1.Name + "\n(" + table1.Status + ")";
                        btn1.BackColor = Color.Aqua;
                        //btnSwitchTable:
                    }
                }
                loadbanpv();
                loadlist(tableId1);
                Loadtable();
            }
            else
                if (dt == DialogResult.No)
            {
                try
                {

                    SqlConnection sqlCon = new SqlConnection(Dangnhap.svconnect);
                    Button btn = flowLayoutPanel2.Tag as Button;
                    Table table = (Table)btn.Tag;
                    int tableId1 = ((flowLayoutPanel2.Tag as Button).Tag as Table).ID;
                    int tableId2 = (comboBox1.SelectedItem as Table).ID;
                    int billId1 = BillDAO.Instance.GetUnCheckBillIdByTableId(tableId1);
                    int billId = BillDAO.Instance.GetUnCheckBillIdByTableId(tableId2);
                    Label Foodid = new Label();
                    Label count = new Label();
                    Label k = new Label();

                    int index = comboBox1.SelectedIndex;
                    Button btn2 = (flowLayoutPanel1.Controls[index] as Button);
                    Table table2 = btn2.Tag as Table;
                    string s = string.Format("Bạn có chắc Gộp {0} sang {1} không ?", table.Name, table2.Name);
                    if (MessageBox.Show(s, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (billId == -1)// Bàn trống.
                        {
                            BillDAO.Instance.InsertBill(tableId2);
                            cls.LoadData2Label(k, "select Count(ID) from dbo.BillInfos where IdBill='" + billId1 + "' ");
                            int a = Convert.ToInt32(k.Text);
                            cls.LoadData2DataGridView(dataGridView1, "select ID from dbo.BillInfos where IdBill='" + billId1 + "' ");
                            for (int i = 0; i < a; i++)
                            {
                                string IDinfo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                cls.LoadData2Label(Foodid, "select IdFood from BillInfos where ID='" + IDinfo + "'and IdBill = '" + billId1 + "'");
                                int foodId = Convert.ToInt32(Foodid.Text);
                                cls.LoadData2Label(count, "select Count from BillInfos where ID = '" + IDinfo + "' and IdFood='" + foodId + "' and IdBill = '" + billId1 + "'");
                                int Count = Convert.ToInt32(count.Text);
                                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetUnCheckBillIdByTableId(tableId2), foodId, Count);
                            }
                            btn.BackColor = Color.Aqua;
                            cls.ThucThiSQLTheoPKN("delete from BillInfos  where EXISTS (select *from Bills,TableFood where IdBill = Bills.Id AND Bills.IdTable='" + tableId1 + "')");
                            cls.ThucThiSQLTheoPKN("update TableFood set Status =N'Trống' where ID='" + tableId1 + "'");
                            cls.ThucThiSQLTheoPKN("delete from Bills where TotalPrice is NULL and Id ='" + billId1 + "'");
                            loadlist(table.ID);
                            Loadtable();
                        }
                        else
                        {
                            cls.LoadData2Label(k, "select Count(ID) from dbo.BillInfos where IdBill='" + billId1 + "' ");
                            int a = Convert.ToInt32(k.Text);
                            cls.LoadData2DataGridView(dataGridView1, "select ID from dbo.BillInfos where IdBill='" + billId1 + "' ");
                            for (int i = 0; i < a; i++)
                            {
                                string IDinfo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                cls.LoadData2Label(Foodid, "select IdFood from BillInfos where ID='" + IDinfo + "'and IdBill = '" + billId1 + "'");
                                int foodId = Convert.ToInt32(Foodid.Text);
                                cls.LoadData2Label(count, "select Count from BillInfos where ID = '" + IDinfo + "' and IdFood='" + foodId + "' and IdBill = '" + billId1 + "'");
                                int Count = Convert.ToInt32(count.Text);
                                BillInfoDAO.Instance.InsertBillInfo(billId, foodId, Count);
                            }
                            btn.BackColor = Color.Aqua;
                            cls.ThucThiSQLTheoPKN("delete from BillInfos  where EXISTS (select *from Bills,TableFood where IdBill = Bills.Id AND Bills.IdTable='" + tableId1 + "')");
                            cls.ThucThiSQLTheoPKN("delete from Bills where TotalPrice is NULL and Id ='" + billId1 + "'");
                            cls.ThucThiSQLTheoPKN("update TableFood set Status =N'Trống' where ID='" + tableId1 + "'");
                            loadlist(table.ID);
                            Loadtable();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Chỉ gộp bàn khi 2 bàn đã có người");
                }
            }
            else
            {

            }
            loadbanpv();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            datetime.Text = date.ToString();
        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            try {
                button8_Click_1(sender, e);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn");
            }
        }

        void btn_click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            Table table = ((Button)sender).Tag as Table;
            flowLayoutPanel2.Tag = (Button)sender;
            loadlist(table.ID);

        }
        #endregion
        #region Xuly

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = flowLayoutPanel2.Tag as Button;
            Table table = (Table)btn.Tag;
            int discount = int.Parse(comboBox3.Text);
            string str = txtTienmon.Text;
            int totalPrice = (int)Convert.ToDouble(str);
            int newtotalPrice = (totalPrice / 100) * (100 - discount);
            int idBill = BillDAO.Instance.GetUnCheckBillIdByTableId(table.ID);

            if (idBill != -1)
            {
                string s = string.Format("Bạn có chắc thanh toán hóa đơn cho {0}\n{1}đ - {2}% = {3}đ", table.Name, totalPrice, discount, newtotalPrice);

                if (MessageBox.Show(s, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    BillDAO.Instance.CheckOut(idBill, discount, newtotalPrice);
                    table.Status = "Trống";
                    btn.Text = table.Name + "\n(" + table.Status + ")";
                    btn.BackColor = Color.Aqua;
                    loadlist(table.ID);
                    Hoadon m = new Hoadon();
                    m.ShowDialog();
                }
            }
            loadbanpv();
            loadlist(table.ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Chuyển bàn
            string query = "EXEC StoreProc_SwapBillForTable  @tableId1 , @tableId2 ";

            int tableId1 = ((flowLayoutPanel2.Tag as Button).Tag as Table).ID;
            int tableId2 = (comboBox1.SelectedItem as Table).ID;
            if (tableId1 == tableId2) return;//tranh lag du lieu.

            Button btn1 = flowLayoutPanel2.Tag as Button;
            Table table1 = btn1.Tag as Table;
            int index = comboBox1.SelectedIndex;
            Button btn2 = (flowLayoutPanel1.Controls[index] as Button);
            Table table2 = btn2.Tag as Table;

            string s = string.Format("Bạn có chắc chuyển {0} sang {1} không ?", table1.Name, table2.Name);
            if (MessageBox.Show(s, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableId1, tableId2 });
                ////////////////////////////////////////////////////////////////////////////////////////////////
                if (table2.Status == "Trống")
                {//Bàn 2:
                    table2.Status = "Có người";
                    btn2.Text = table2.Name + "\n(" + table2.Status + ")";
                    btn2.BackColor = Color.LightGreen;
                    //Bàn 1:
                    table1.Status = "Trống";
                    btn1.Text = table1.Name + "\n(" + table1.Status + ")";
                    btn1.BackColor = Color.Aqua;
                    //btnSwitchTable:
                }
            }
            Loadtable();
            loadbanpv();
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            //hủy món
            Button btn = flowLayoutPanel2.Tag as Button;
            Table table = (Table)btn.Tag;
            int billId = BillDAO.Instance.GetUnCheckBillIdByTableId(table.ID);
            if (billId != -1)
            {
                cls.ThucThiSQLTheoPKN("delete from BillInfos  where EXISTS (select *from Bills,TableFood where IdBill = Bills.Id AND Bills.IdTable='" + table.ID + "')");
                cls.ThucThiSQLTheoPKN("delete from Bills where Datecheckout is NULL and Id ='"+billId+"'");
                cls.ThucThiSQLTheoPKN("update dbo.TableFood set Status=N'Trống' where ID = '" + table.ID + "'");
                
            }
            
            loadlist(table.ID);
            Loadtable();
            loadbanpv();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                SqlConnection sqlCon = new SqlConnection(Dangnhap.svconnect);
                Button btn = flowLayoutPanel2.Tag as Button;
                Table table = (Table)btn.Tag;
                int tableId1 = ((flowLayoutPanel2.Tag as Button).Tag as Table).ID;
                int tableId2 = (comboBox1.SelectedItem as Table).ID;
                int billId1 = BillDAO.Instance.GetUnCheckBillIdByTableId(tableId1);
                int billId = BillDAO.Instance.GetUnCheckBillIdByTableId(tableId2);
                Label Foodid = new Label();
                Label count = new Label();
                Label k = new Label();

                int index = comboBox1.SelectedIndex;
                Button btn2 = (flowLayoutPanel1.Controls[index] as Button);
                Table table2 = btn2.Tag as Table;
                string s = string.Format("Bạn có chắc Gộp {0} sang {1} không ?", table.Name, table2.Name);
                if (MessageBox.Show(s, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (billId == -1)// Bàn trống.
                    {
                        BillDAO.Instance.InsertBill(tableId2);
                        cls.LoadData2Label(k, "select Count(ID) from dbo.BillInfos where IdBill='" + billId1 + "' ");
                        int a = Convert.ToInt32(k.Text);
                        cls.LoadData2DataGridView(dataGridView1, "select ID from dbo.BillInfos where IdBill='" + billId1 + "' ");
                        for (int i = 0; i < a; i++)
                        {
                            string IDinfo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            cls.LoadData2Label(Foodid, "select IdFood from BillInfos where ID='" + IDinfo + "'and IdBill = '" + billId1 + "'");
                            int foodId = Convert.ToInt32(Foodid.Text);
                            cls.LoadData2Label(count, "select Count from BillInfos where ID = '" + IDinfo + "' and IdFood='" + foodId + "' and IdBill = '" + billId1 + "'");
                            int Count = Convert.ToInt32(count.Text);
                            BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetUnCheckBillIdByTableId(tableId2), foodId, Count);
                        }
                        btn.BackColor = Color.Aqua;
                        cls.ThucThiSQLTheoPKN("delete from BillInfos  where EXISTS (select *from Bills,TableFood where IdBill = Bills.Id AND Bills.IdTable='" + tableId1 + "')");
                        cls.ThucThiSQLTheoPKN("update TableFood set Status =N'Trống' where ID='" + tableId1 + "'");
                        cls.ThucThiSQLTheoPKN("delete from Bills where TotalPrice is NULL and Id ='" + billId1 + "'");
                        loadlist(table.ID);
                        Loadtable();
                    }
                    else
                    {
                        cls.LoadData2Label(k, "select Count(ID) from dbo.BillInfos where IdBill='" + billId1 + "' ");
                        int a = Convert.ToInt32(k.Text);
                        cls.LoadData2DataGridView(dataGridView1, "select ID from dbo.BillInfos where IdBill='" + billId1 + "' ");
                        for (int i = 0; i < a; i++)
                        {
                            string IDinfo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            cls.LoadData2Label(Foodid, "select IdFood from BillInfos where ID='" + IDinfo + "'and IdBill = '" + billId1 + "'");
                            int foodId = Convert.ToInt32(Foodid.Text);
                            cls.LoadData2Label(count, "select Count from BillInfos where ID = '" + IDinfo + "' and IdFood='" + foodId + "' and IdBill = '" + billId1 + "'");
                            int Count = Convert.ToInt32(count.Text);
                            BillInfoDAO.Instance.InsertBillInfo(billId, foodId, Count);
                        }
                        btn.BackColor = Color.Aqua;
                        cls.ThucThiSQLTheoPKN("delete from BillInfos  where EXISTS (select *from Bills,TableFood where IdBill = Bills.Id AND Bills.IdTable='" + tableId1 + "')");
                        cls.ThucThiSQLTheoPKN("delete from Bills where TotalPrice is NULL and Id ='" + billId1 + "'");
                        cls.ThucThiSQLTheoPKN("update TableFood set Status =N'Trống' where ID='" + tableId1 + "'");
                        loadlist(table.ID);
                        Loadtable();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chỉ gộp bàn khi 2 bàn đã có người");
            }
            loadbanpv();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
