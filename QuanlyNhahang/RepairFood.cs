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
    public partial class RepairFood : Form
    {
        public RepairFood()
        {
            InitializeComponent();
            loadcategory();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void RepairFood_Load(object sender, EventArgs e)
        {

        }
        void loadcategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategoryList();
            CategoryFood.DataSource = listCategory;
            CategoryFood.DisplayMember = "Name";
        }
        private void LoadFoodListByCategoryId(int categoryId)
        {
            CdFood.DataSource = FoodDAO.Instance.GetFoodListByCategoryId(categoryId);
            CdFood.DisplayMember = "Name";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int price = (CdFood.SelectedItem as Food).Price;
            textBox1.Text = Convert.ToString(price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            Label m = new Label();

            try
            {
                if (textBox2.Text.Length == 0)
                {
                    label5.Text = "(*)NameFood không được bỏ trống";
                }
                else { 
                    label5.Text = "(*)";}
                if(textBox1.Text.Length == 0)
                {
                    label6.Text = "(*)Price không được bỏ trống";
                }
                else
                {
                    label6.Text = "(*)";
                }
                if(label5.Text=="(*)"&&label6.Text=="(*)")
                { 
                int Id = (CdFood.SelectedItem as Food).Id;
                cls.ThucThiSQLTheoPKN("EXEC Foodupdate '"+textBox2.Text+"','"+textBox1.Text+"','"+Id+"'");
                MessageBox.Show("Sửa thành công!");
                this.Close();}
            }
            catch
            {
                MessageBox.Show("Sửa FALSE");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category categorySelected = CategoryFood.SelectedItem as Category;
            LoadFoodListByCategoryId(categorySelected.Id);
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
