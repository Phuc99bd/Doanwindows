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
    public partial class DeleteCategory : Form
    {
        public DeleteCategory()
        {
            InitializeComponent();
            loadcategory();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void DeleteCategory_Load(object sender, EventArgs e)
        {

        }
        void loadcategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategoryList();
            comboBox1.DataSource = listCategory;
            comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (comboBox1.SelectedItem as Category).Id;
            try
            {
                string strDelete = "delete from FoodCategory WHERE ID = " + id + " ";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                MessageBox.Show("Xóa thành công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("xÓA Thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
