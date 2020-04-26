using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu2
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }
        int x = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            x++;
            if (x == 5)
            {
                timer1.Stop();
                pictureBox1.Hide();
                label1.Hide();
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
        }
        private void Form_loading_Load(object sender, EventArgs e)
        {
            label1.Show();

        }
    }
}
