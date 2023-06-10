using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Package
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DDA d= new DDA();
            d.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bresenham b = new Bresenham();
            b.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Circle c = new Circle();
            c.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ellipse a = new Ellipse();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trans2D d = new trans2D();
            d.ShowDialog();
        }
    }
}
