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
    public partial class Addfood : Form
    {
        public Addfood()
        {
            InitializeComponent();
            loadcategory();

        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            Label Thems = new Label();
            Label label = new Label();
           
                         try
                          { 
                             if (textBox1.Text.Length == 0)
                             {
                        label4.Text = "(*)NameFood không được để trống";
                             }
                          else
                    {
                        label4.Text = "(*)";
                    }
                            if (textBox2.Text.Length == 0)
                                {
                    label5.Text = "(*)Price không được để trống";
                                }
                            else
                            {
                    label5.Text = "(*)";
                            }
                if (label4.Text == "(*)" && label5.Text == "(*)") {
                         int id = (comboBox1.SelectedItem as Category).Id;
                         cls.ThucThiSQLTheoPKN("insert dbo.Food values('"+textBox1.Text+"', "+id+","+textBox2.Text+")");
                         MessageBox.Show("Thêm thành công");
                          this.Close(); }
                          }
                        catch
                        {
                          MessageBox.Show("THêm FALSE");
                            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Addfood_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
   
