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
    public partial class RepairTB : Form
    {
        public RepairTB()
        {
            InitializeComponent();
            loadtable();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        void loadtable()
        {
            List<Table> listCategory = TableDAO.Instance.LoadTableList();
            Tble.DataSource = listCategory;
            Tble.DisplayMember = "Name";
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RepairTB_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text.Length==0)
                {
                    label2.Text = "(*)Name Table không được bỏ trống ";
                }
                else
                { 
                int id = (Tble.SelectedItem as Table).ID;
                cls.ThucThiSQLTheoPKN("update dbo.TableFood set Name ='" + textBox2.Text + "' where ID='" + id + "' ");
                MessageBox.Show("Sửa thành công");
                this.Close();}
            }
            catch
            {
                MessageBox.Show("Sửa False");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
