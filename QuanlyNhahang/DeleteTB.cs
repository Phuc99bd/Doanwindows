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
    public partial class DeleteTB : Form
    {
        public DeleteTB()
        {
            InitializeComponent();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int ct = (int)numericUpDown1.Value;
            try
            {
                while (i != ct)
                {
                    cls.ThucThiSQLTheoKetNoi("EXEC KALI");
                    i++;
                }
                MessageBox.Show("Xóa Thành Công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Xóa False");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteTB_Load(object sender, EventArgs e)
        {

        }
    }
}
