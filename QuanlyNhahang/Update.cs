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
using QuanlyNhahang.MA;

namespace QuanlyNhahang
{
    public partial class Update : UserControl
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Update()
        {

            InitializeComponent();
            radioButton1.Checked = true;
            
            
        }

        private void Update_Load(object sender, EventArgs e)
        {
                cls.loadcombobox(comboBox1, "select * from AccountB where QUYENHAN!= '" + Main.Quyen + "'","UserName");
            cls.loadcombobox2(comboBox2, "select * from CV", "Name");
        }
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
        private void button1_Click(object sender, EventArgs e)
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

            Label label = new Label();
            label.Text = comboBox1.Text;
                try
                {
                    if (textBox1.Text.Length == 0)
                        label6.Text = "(*)Tên nhân viên không được đê trống";
                    else { label6.Text = "(*)"; }
                    if (textBox2.Text.Length == 0)
                        label9.Text = "(*)Địa chỉ không được để trống";
                    else { label9.Text = "(*)"; }
                    if (check == false)
                        label11.Text = "(*)Email Không hợp lệ";
                    else { label11.Text = "(*)"; }
                    if (check1 == false)
                        label10.Text = "(*)SDT Không hợp lệ";
                    else { label10.Text = "(*)"; }
                    if (label6.Text == "(*)" && label10.Text == "(*)" && label9.Text == "(*)" && label11.Text == "(*)"){
                        Label m = new Label();
                        m.Text = comboBox2.Text;
                        string SQL = "update AccountB set Tennhanvien =N'" + textBox1.Text + "' ,Diachi=N'" + textBox2.Text + "',Dienthoai='" + textBox4.Text + "' ,Email='" + textBox3.Text + "' , Chucvu=N'" + m.Text + "',Ngaysinh='" + maskedTextBox1.Text + "',Gioitinh=N'" + labels.Text + "' where UserName=N'" + label.Text + "' ";
                        cls.ThucThiSQLTheoPKN(SQL);
                        MessageBox.Show("Sửa thành công!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Sửa FALSE!");
                }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string un = comboBox1.Text;
            Label tennhanvien = new Label();
            Label Diachi = new Label();
            Label Email = new Label();
            Label Dienthoai = new Label();
            Label Combobox = new Label();
            Label Gioitinh = new Label();
            Label Ngaysinh = new Label();
            cls.LoadData2Label(tennhanvien, "select Tennhanvien from AccountB where UserName='" + un + "'");
            cls.LoadData2Label(Diachi, "select Diachi from AccountB where UserName='" + un + "'");
            cls.LoadData2Label(Email, "select Email from AccountB where UserName='" + un + "'");
            cls.LoadData2Label(Dienthoai, "select Dienthoai from AccountB where UserName='" + un + "'");
            cls.LoadData2Label(Combobox, "select Chucvu from AccountB where UserName = '" + un + "'");
            cls.LoadData2Label(Gioitinh, "select Gioitinh from AccountB where UserName ='" + un + "'");
            cls.LoadData2Label(Ngaysinh, "select Ngaysinh from AccountB where UserName = '" + un + "'");
            textBox1.Text = tennhanvien.Text;
            textBox2.Text = Diachi.Text;
            textBox3.Text = Email.Text;
            textBox4.Text = Dienthoai.Text;
            comboBox2.Text = Combobox.Text;
            maskedTextBox1.Text = Ngaysinh.Text;
            if(Gioitinh.Text == "Nam")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

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
    }
}
