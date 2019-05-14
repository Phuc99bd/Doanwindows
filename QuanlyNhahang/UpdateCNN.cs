using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace QuanlyNhahang
{
    public partial class UpdateCNN : UserControl
    {
        public UpdateCNN()
        {
            InitializeComponent();
            Loadtt();
            radioButton1.Checked = true;
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static bool IsValidPhone(string value)
        {
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }
        public static bool IsValidOld(string value)
        {
            string pattern = @"^-*[0-2,\.?\-?\(?\)?\ ]+$";
            return Regex.IsMatch(value, pattern);
        }
      
        private void Loadtt()
        {
            Label tennhanvien = new Label();
            Label Diachi = new Label();
            Label Email = new Label();
            Label Dienthoai = new Label();
            Label Tuoi = new Label();
            cls.LoadData2Label(tennhanvien, "select Tennhanvien from AccountB where UserName='" + Main.UserName + "'");
            cls.LoadData2Label(Diachi, "select Diachi from AccountB where UserName='" + Main.UserName + "'");
            cls.LoadData2Label(Email, "select Email from AccountB where UserName='" + Main.UserName + "'");
            cls.LoadData2Label(Dienthoai, "select Dienthoai from AccountB where UserName='" + Main.UserName + "'");
            cls.LoadData2Label(Tuoi, "select Ngaysinh from AccountB where UserName='" + Main.UserName + "'");
            textBox1.Text = tennhanvien.Text;
            textBox2.Text = Diachi.Text;
            textBox3.Text = Email.Text;
            textBox4.Text = Dienthoai.Text;
            maskedTextBox1.Text = Tuoi.Text;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool check = isValidEmail(textBox3.Text);
            bool check1 = IsValidPhone(textBox4.Text);
            Label labels = new Label();
            if (radioButton1.Checked == true)
            {
                labels.Text = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                labels.Text = radioButton2.Text;
            }
                try
                {
                    if (textBox1.Text.Length == 0)
                        label1.Text = "(*)Tên nhân viên không được để trống ";
                    else { label1.Text = "(*)"; }
                    if (textBox2.Text.Length == 0)
                        label10.Text="(*)Địa chỉ không được để trống" ;
                    else { label10.Text = "(*)"; }
                    if (check == false)
                    {
                        label4.Text = "(*)Email Không hợp lệ";
                    }
                    else { label4.Text = "(*)"; }
                    if (check1 == false)
                    {
                        label9.Text = "(*)Số điện thoại không hợp lệ";
                    }
                    else { label9.Text = "(*)"; }
                    
                    if (label1.Text == "(*)" && label10.Text == "(*)" && label4.Text == "(*)" && label9.Text == "(*)") { 
                    Label m = new Label();
                    string SQL = "update AccountB set Tennhanvien =N'" + textBox1.Text + "' ,Diachi=N'" + textBox2.Text + "',Dienthoai='" + textBox4.Text + "' ,Email='" + textBox3.Text + "',Ngaysinh='" + maskedTextBox1.Text + "',Gioitinh=N'" + labels.Text + "' where UserName=N'" + Main.UserName + "' ";
                    cls.ThucThiSQLTheoPKN(SQL);
                    MessageBox.Show("Đã Cập nhật!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";}
                    
                }
                catch
                {
                    MessageBox.Show("Sửa FALSE!");
                }
            }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
