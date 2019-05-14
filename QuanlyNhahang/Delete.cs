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
    public partial class Deletetraffet : Form
    {
        public Deletetraffet()
        {
            InitializeComponent();

        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = comboBox1.Text;
                try
                { 
                        string strDelete = "delete from AccountB WHERE UserName = '" + label.Text + "'";
                        cls.ThucThiSQLTheoKetNoi(strDelete);
                        MessageBox.Show("Đã xóa UserName " + label.Text);
                        this.Hide();
                }
                catch
                {
                    MessageBox.Show("Xóa Thất bại ,UserName không tồn tại");
                }
        }

        private void Deletetraffet_Load(object sender, EventArgs e)
        {
            cls.loadcombobox(comboBox1, "select * from AccountB where QUYENHAN!='" + Main.Quyen + "'","UserName");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
