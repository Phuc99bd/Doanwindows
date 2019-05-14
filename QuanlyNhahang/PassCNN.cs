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
    public partial class PassCNN : UserControl
    {
        public PassCNN()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    if (textBox1.Text != Main.Password)
                    {
                        label4.Text = "(*)Sai Password";  
                    }
                    else { label4.Text = "(*)"; }
                    if (textBox2.Text.Length - 1 < 5)
                        label5.Text = "(*)Mật khẩu quá ngắn";
                    else { label5.Text = "(*)"; }
                    if (textBox2.Text != textBox3.Text)
                        label6.Text = "(*)Password không trùng nhau";
                    else { label6.Text = "(*)"; }
                    if (label4.Text == "(*)" && label5.Text == "(*)" && label6.Text == "(*)") { 
                    string SQL = "update AccountB set PassWord='" + textBox2.Text + "' where UserName='" + Main.UserName + "' ";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
