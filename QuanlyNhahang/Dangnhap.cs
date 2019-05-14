using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;
using QuanlyNhahang.MA;
using QuanlyNhahang.tbl;
using QuanlyNhahang.tb;
using QuanlyNhahang.LM;


namespace QuanlyNhahang
{
    public partial class Dangnhap : Form
    {
        public static string svconnect = string.Empty;
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Dangnhap()
        {
            
            Thread trd = new Thread(new ThreadStart(formrun));
            trd.Start();
            Thread.Sleep(3500);
            trd.Abort();
            InitializeComponent();
           
        }
        private void formrun()
        {
            Application.Run(new GiaodienLoad());
        }
        private void Main_Load(object sender, EventArgs e)
        {
            UserName.Text = Properties.Settings.Default.UserName;
            PassWord.Text = Properties.Settings.Default.PassWord;
            textBox1.Text = Properties.Settings.Default.a;
            checkBox1.Checked = true;
            label4.Hide();
            PassWord.UseSystemPasswordChar= true;
        }
        #region Hình thức change color text buni
        private void textBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.iconfinder_user_285655;
            bunifuSeparator1.LineColor = Color.FromArgb(78, 104, 206);
            UserName.ForeColor = Color.FromArgb(78, 104, 206);

            pictureBox2.BackgroundImage = Properties.Resources.iconfinder_lock_icon_211089;
            bunifuSeparator2.LineColor = Color.WhiteSmoke;
            PassWord.ForeColor = Color.WhiteSmoke;
        }

        private void PassWord_Click_1(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.iconfinder_lock_icon_211089;
            bunifuSeparator2.LineColor = Color.FromArgb(78, 104, 206);
            PassWord.ForeColor = Color.FromArgb(78, 104, 206);

            pictureBox1.BackgroundImage = Properties.Resources.iconfinder_user_285655;
            bunifuSeparator1.LineColor = Color.WhiteSmoke;
            UserName.ForeColor = Color.WhiteSmoke;
        }
        #endregion
       
        #region Xử lý
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                
                string user = UserName.Text;
                string pass = PassWord.Text;
                string userdb, passdb;
                Returnclass rc = new Returnclass();
                svconnect = textBox1.Text;
                userdb = rc.scalarReturn("select UserName from AccountB where UserName='" + user + "'");

                if (!(userdb.Equals(user)))
                {
                    MessageBox.Show("Idvalid User Name!");
                }
                else
                {
                    passdb = rc.scalarReturn("select PassWord from AccountB where PassWord='" + pass + "' and UserName ='"+user+"'");
                    if (passdb.Equals(pass))
                    {
                        cls.LoadData2Label(label4, "select QUYENHAN FROM AccountB where UserName = '" + UserName.Text + "'");
                        Main.Quyen = label4.Text;
                        cls.LoadData2Label(label5, "select Tennhanvien  From AccountB where UserName= '" + UserName.Text + "' ");
                        Main.TenNV = label5.Text;
                        cls.LoadData2Label(label6, "select UserName From AccountB where UserName='" + UserName.Text + "' ");
                        Main.UserName = label6.Text;
                        cls.LoadData2Label(label7, "select PassWord From AccountB where UserName='" + UserName.Text + "'");
                        Main.Password = label7.Text;
                        Main ml = new Main();
                        Label chucvu = new Label();
                        cls.LoadData2Label(chucvu, "select Chucvu from AccountB where UserName = '" + UserName.Text + "'");
                        Main.Chucvu = chucvu.Text;
                        Properties.Settings.Default.a = textBox1.Text;
                        Properties.Settings.Default.Save();
                        if (checkBox1.Checked)
                        {
                            Properties.Settings.Default.UserName = UserName.Text;
                            Properties.Settings.Default.PassWord = PassWord.Text;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.UserName = "";
                            Properties.Settings.Default.PassWord = "";
                            Properties.Settings.Default.Save();
                        }
                        if (chucvu.Text == "Thu ngân" || Main.Quyen=="admin")
                        {
                            cls.ThucThiSQLTheoPKN("delete KiemsoatDN");
                            cls.ThucThiSQLTheoPKN("insert dbo.KiemsoatDN values(N'" + Main.TenNV + "')");
                        }
                        this.Hide();
                        
                         ml.ShowDialog();
                   
                       
                    }
                    else
                    {
                        MessageBox.Show("Idvalid Pass Word!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại chuỗi kết nối");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        private void test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Hàm k xử lý
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void UserName_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserName_Click(object sender, EventArgs e)
        {
            
        }
        private void PassWord_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBoxa_Click(object sender, EventArgs e)
        {

        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
