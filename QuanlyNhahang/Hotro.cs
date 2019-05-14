using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace QuanlyNhahang
{
    public partial class Hotro : UserControl
    {
        public Hotro()
        {
            InitializeComponent();
        }

        private void Hotro_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/Tricker.Phuc");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/profile.php?id=100007990025742");
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process pro = new Process())
            {
                pro.StartInfo.FileName = "mailto:" + linkLabel1.Text;
                pro.Start();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process pro = new Process())
            {
                pro.StartInfo.FileName = "mailto:" + linkLabel3.Text;
                pro.Start();
            }
        }
    }
}
