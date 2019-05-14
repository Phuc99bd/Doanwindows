using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanlyNhahang
{
    public partial class Addaccount : UserControl
    {
        public Addaccount()
        {
            InitializeComponent();
            cls.loadcombobox(comboBox1, "select * from CV", "Name");
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Addaccount_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    if (textBox1.Text.Length - 1 < 5)
                    {
                        label6.Text = "(*)Tên tài khoản quá ngắn!Trên 5 kí tự";
                    }
                    else
                    {
                        label6.Text = "(*)";
                    }

                    if (textBox2.Text.Length - 1 < 5)
                    {
                        label7.Text = "(*)Mật khẩu quá ngắn!Trên 5 kí tự";
                    }
                    else
                    {
                        label7.Text = "(*)";
                    }
                    if (textBox3.Text != textBox2.Text)
                    {
                        label8.Text = "(*)Password không trùng nhau";
                    }
                    else
                    {
                        label8.Text = "(*)";
                    }
                    if(label6.Text=="(*)"&& label7.Text =="(*)" && label8.Text=="(*)") { 
                        Label m = new Label();
                    
                    m.Text = comboBox1.Text;
                    cls.ThucThiSQLTheoPKN("insert into AccountB values('" + textBox1.Text + "','" + textBox2.Text + "','user','','','','',N'"+m.Text+"','','')");
                    MessageBox.Show("Tạo tài khoản thành công hãy cập nhật thông tin cho tài khoản");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";}
                }
                catch { MessageBox.Show("Lỗi.Có thể bạn chưa chọn chức vụ hoặc đã có người sử dụng UserName này"); }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {

                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
     
    }
}
