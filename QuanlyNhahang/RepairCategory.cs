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
    public partial class RepairCategory : Form
    {
        public RepairCategory()
        {
            InitializeComponent();
            loadcategory();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        void loadcategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategoryList();
            CategoryFood.DataSource = listCategory;
            CategoryFood.DisplayMember = "Name";
        }
        private void RepairCategory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (CategoryFood.SelectedItem as Category).Id;
                try
                {
                    if(textBox2.Text.Length==0)
                    {
                    label2.Text = "(*)Name CategoryFood không được bỏ trống";
                    }
                    else
                    {
                    label2.Text = "(*)";
                    }
                    if(label2.Text=="(*)")
                     { 
                    string SQL = "update FoodCategory set Name= N'" + textBox2.Text + "' where ID=" + id + " ";
                    cls.ThucThiSQLTheoPKN(SQL);
                    MessageBox.Show("Sửa thành công!");
                    this.Close();}
                }
                catch
                {
                    MessageBox.Show("Sửa FALSE!");
                }
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
