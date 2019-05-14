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
    public partial class DeleteFood : Form
    {
        public DeleteFood()
        {
            InitializeComponent();
            cls.loadcombobox(comboBox1, "select * from Food", "Name");
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            Label label1 = new Label();

            label.Text = comboBox1.Text;
            cls.LoadData2Label(label1, "select ID from Food where Name='" + label.Text + "'");
            try
            {
                string strDelete = "delete from Food WHERE ID = '" + label1.Text + "'";
                cls.ThucThiSQLTheoKetNoi(strDelete);
                MessageBox.Show("Xóa thành công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteFood_Load(object sender, EventArgs e)
        {

        }
    }
}
