using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanlyNhahang.tbl;
using QuanlyNhahang.MA;

namespace QuanlyNhahang
{
    public partial class Doanhthu : UserControl
    {
        public Doanhthu()
        {
            InitializeComponent();
            
            Loadtimetick();       
        }
        void LoadListBillBydate(DateTime checkin, DateTime checkout)
        {
            gridControl1.DataSource = BillDAO.Instance.GetCheckOutBillListByDate(checkin, checkout);
            gridView1.Columns[0].Width = 25;
            gridView1.Columns[4].AppearanceCell.ForeColor = Color.Red;
            
           
        }
        void Loadtimetick()
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
            dateTimePicker3.Value = new DateTime(today.Year, today.Month, today.Day);
            dateTimePicker4.Value = dateTimePicker3.Value.AddDays(-1);
            dateTimePicker3.Hide();
            dateTimePicker4.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
        }
        private void Doanhthu_Load(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            LoadListBillBydate(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadTotalP(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadTotalNow(dateTimePicker3.Value);
            LoadTotalHq(dateTimePicker4.Value);


            int index = dataGridView2.CurrentRow.Index;
            TT.Text = dataGridView2.Rows[index].Cells[0].Value.ToString() + "đ";

            label4.Text = dataGridView3.Rows[index].Cells[0].Value.ToString() + "đ";
            label5.Text = dataGridView4.Rows[index].Cells[0].Value.ToString() + "đ";
            if (label4.Text == "đ")
            {
                label4.Text = "0đ";
            }
            if(label5.Text =="đ")
            {
                label5.Text = "0đ";
            }
        }
        private void LoadTotalP(DateTime checkin, DateTime checkout)
        {
            dataGridView2.DataSource = BillDAO.Instance.GetTotalPrice(checkin, checkout);
        }
        private void LoadTotalNow(DateTime checkout)
        {
            dataGridView3.DataSource = BillDAO.Instance.GettotalNow(checkout);
        }
        private void LoadTotalHq(DateTime checkout)
        {
            dataGridView4.DataSource = BillDAO.Instance.GettotalNow(checkout);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            LoadListBillBydate(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadTotalP(dateTimePicker1.Value,dateTimePicker2.Value);

            int index = dataGridView2.CurrentRow.Index;
            TT.Text = dataGridView2.Rows[index].Cells[0].Value.ToString() + "đ";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            InDoanhthu m = new InDoanhthu();
            m.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
