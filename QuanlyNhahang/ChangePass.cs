using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyNhahang
{
    public partial class ChangePass : UserControl
    {
        public ChangePass()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            cls.loadcombobox(comboBox1, "select * from AccountB where QUYENHAN!='admin'","UserName");
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void ChangePass_Load(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label l = new Label();
            cls.LoadData2Label(l, "select PassWord from AccountB where UserName='" + comboBox1.Text + "'");
                try
                {
                    if (textBox2.Text.Length - 1 < 5)
                        label7.Text = "(*)Mật khẩu quá ngắn";
                    else { label7.Text = "(*)"; }
                    if (textBox2.Text != textBox3.Text)
                        label8.Text = "(*)Password không trùng nhau";
                    else { label8.Text = "(*)"; }
                    if (label7.Text == "(*)" && label8.Text == "(*)") { 
                    string SQL = "update AccountB set PassWord='" + textBox2.Text + "' where UserName='" + comboBox1.Text + "' ";
                    cls.ThucThiSQLTheoPKN(SQL);
                    MessageBox.Show("Thành công!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";}
                }
                catch
                {
                    MessageBox.Show("Sửa FALSE!");
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.LoadDateTextbox(textBox1, "select PassWord from AccountB where UserName='" + comboBox1.Text + "'");
        }
    }
}
