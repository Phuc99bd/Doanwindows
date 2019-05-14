using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanlyNhahang
{
    public partial class Main : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        //Khai báo dữ liệu 
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public static string Quyen = string.Empty;
        public static string TenNV = string.Empty;
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string Chucvu = string.Empty;
        public Main()
        {
            InitializeComponent();
            timer1.Start();
            label4.Text = Quyen;
            label2.Text = TenNV; 
            Home2 m = new Home2();
            Addcontrolstopnal(m);
            this.KeyPreview = true;
            Phanquyen();
            


        }
        private void Phanquyen()
        {
          if(Main.Quyen=="admin")
            {
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                TTNV.Enabled = true;
                Addac.Enabled = true;
                Pass.Enabled = true;
                Support.Enabled = true;
                Updates.Enabled = true;
            }
          else
                if(Main.Quyen=="user")
            {
                Addac.Enabled = false;
                button12.Enabled = false;
                Updates.Text= "Update TT "+
"(Ctrl + F3)";
            }
        }
            #region Xử lý dữ liệu
            private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Width = btn.Width;
        }
        private void Addcontrolstopnal(Control c)
        {
            c.Dock = DockStyle.Fill;
            panellive.Controls.Clear();
            panellive.Controls.Add(c);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Restraurant_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveSidePanel(Addac);
            Addaccount m = new Addaccount();
            Addcontrolstopnal(m);
        }

        private void TTNV_Click(object sender, EventArgs e)
        {
            moveSidePanel(TTNV);
            Thongtinnhanvien uc = new Thongtinnhanvien();
            Addcontrolstopnal(uc);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if(Main.Quyen=="admin")
            { 
            moveSidePanel(Updates);
            Update y = new Update();
            Addcontrolstopnal(y);}
            else
                if(Main.Quyen=="user")
            {
                moveSidePanel(Updates);
                UpdateCNN m = new UpdateCNN();
                Addcontrolstopnal(m);
            }
        }

        private void Pass_Click(object sender, EventArgs e)
        {
            if(Main.Quyen=="admin")
            { 
            moveSidePanel(Pass);
            ChangePass j = new ChangePass();
            Addcontrolstopnal(j);}
            else
                if(Main.Quyen=="user")
            {
                moveSidePanel(Pass);
                PassCNN m = new PassCNN();
                Addcontrolstopnal(m);
            }
        }

        private void Support_Click(object sender, EventArgs e)
        {
            moveSidePanel(Support);
            Hotro m = new Hotro();
            Addcontrolstopnal(m);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            moveSidePanel(Logout);
            this.Hide();
            Dangnhap i = new Dangnhap();
            i.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if(Main.Quyen == "admin" || Main.Quyen =="user") { 
            Đatban m = new Đatban();
            Addcontrolstopnal(m);}
        }
        private void button9_Click(object sender, EventArgs e)
        {
            InfomationFood m = new InfomationFood();
            Addcontrolstopnal(m);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            InfomationCategory m = new InfomationCategory();
            Addcontrolstopnal(m);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InfomationtTB m = new InfomationtTB();
            Addcontrolstopnal(m);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Doanhthu m = new Doanhthu();
            Addcontrolstopnal(m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labeltime.Text = dt.ToString("HH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home m = new Home();
            Addcontrolstopnal(m);
            
        }

        private void panellive_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home2 lm = new Home2();
            Addcontrolstopnal(lm);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labeltime_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true && e.KeyCode == Keys.F)
            {
                button9.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                button10.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.T)
            {
                button11.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.B)
            {
                button12.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.O)
            {
                button8.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F1)
            {
                Support.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F2)
            {
                TTNV.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F3)
            {
                Updates.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F4)
            {
                Addac.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F5)
            {
                Pass.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.X)
            {
                Logout.PerformClick();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            label8.Text = Chucvu;
        }
    }
}
