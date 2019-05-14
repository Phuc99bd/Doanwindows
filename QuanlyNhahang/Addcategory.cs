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
    public partial class Addcategory : Form
    {
        public Addcategory()
        {
            InitializeComponent();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    if (textBox2.Text.Length == 0)
                    {
                    label1.Text = "(*)Name Foodcategory không được bỏ trống";

                    }
                     else
                    {
                    label1.Text = "(*)";
                     }
                if (label1.Text == "(*)") { 
                    cls.ThucThiSQLTheoPKN("insert into FoodCategory values (N'" + textBox2.Text + "' )");
                    MessageBox.Show("Thêm thành công");
                    this.Close();}
                }
                catch
                {
                    MessageBox.Show("THêm FALSE");
                }
            }
        

        private void Addcategory_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
