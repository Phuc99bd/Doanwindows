using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanlyNhahang
{
    public partial class Thongtinnhanvien : UserControl
    {
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        public Thongtinnhanvien()
        {
            InitializeComponent();
            try
            {
                if (Main.Quyen == "admin")
                {
                    cls.KetNoi();
                    LoadGridcontrol();
                }
                else
                    if(Main.Quyen=="user")
                {
                    cls.KetNoi();
                    DataTable dt = new DataTable("DB");
                    dt.Clear();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select UserName,Tennhanvien,Diachi,Dienthoai,Email,Chucvu,Ngaysinh,Gioitinh from AccountB where QUYENHAN!='admin' ", Dangnhap.svconnect);
                    adapter.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
            PhanQuyen();
        }
        void PhanQuyen()
        {
            if(Main.Quyen=="admin")
            {

            }
            else
               if(Main.Quyen=="user")
            {
                button2.Enabled = false;
            }
        }
        private void LoadGridcontrol()
        {
            DataTable dt = new DataTable("DB");
            dt.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("EXEC CardAccount", Dangnhap.svconnect);
            adapter.Fill(dt);
            gridControl1.DataSource = dt;
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deletetraffet m = new Deletetraffet();
            m.ShowDialog();
            LoadGridcontrol();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void Thongtinnhanvien_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
