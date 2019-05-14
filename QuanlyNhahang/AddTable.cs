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
    public partial class AddTable : Form
    {
        public AddTable()
        {
            InitializeComponent();
        }
        clsDatabase.clsDatabase cls = new QuanlyNhahang.clsDatabase.clsDatabase();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int count = (int)numericUpDown1.Value;
                while (i != count)
                {
                    cls.ThucThiSQLTheoPKN("EXEC MITA");
                    i++;
                }
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("thêm False");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
