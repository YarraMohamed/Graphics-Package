using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphics_Package
{
    public partial class Ellipse : Form
    {
        Table t1 = new Table();
        public Ellipse()
        {
            InitializeComponent();
        }

  
        private void draw(int xc, int yc, int rx, int ry)
        {
            var g = panel2.CreateGraphics();
            var aBrush = Brushes.Blue;
            DataTable table = new DataTable();
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));
            table.Columns.Add("dx", typeof(int));
            table.Columns.Add("dy", typeof(int));

            int x = 0, y = ry;
            int dy, dx;
            double d1, d2;

            d1 = (ry * ry) - (rx * rx * ry) +
                   (0.25f * rx * rx);


            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            while (dx < dy)
            {

                if (d1 < 0)
                {
                    x++;
                    dx += 2 * ry * ry;
                    d1 += dx + (ry * ry);

                }
                else
                {
                    x++;
                    dx += 2 * ry * ry;
                    y--;
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
                table.Rows.Add(x,y,dx,dy);
                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2) - (yc + y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2) - (yc + y), 2, 2);
                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2) - (yc - y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2) - (yc - y), 2, 2);
            }

            d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f)))
                      + ((rx * rx) * ((y - 1) * (y - 1)))
                      - (rx * rx * ry * ry);

            while (y > 0)
            {
                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
                table.Rows.Add(x, y, dx, dy);
                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2) - (yc + y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2) - (yc + y), 2, 2);
                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2) - (yc - y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2) - (yc - y), 2, 2);

            }
           
            t1.dt = table;
            t1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            panel2.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            t1.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int rx = Convert.ToInt32(textBox3.Text);
            int ry = Convert.ToInt32(textBox4.Text);
            draw(x, y, rx, ry);
        }
        public void axis()
        {
            var Graph = panel2.CreateGraphics();
            Pen p = Pens.Black;
            Graph.DrawLine(p, 0, panel2.Height / 2, panel2.Width, panel2.Height / 2);
            Graph.DrawLine(p, panel2.Width / 2, 0, panel2.Width / 2, panel2.Height);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            axis();
        }
    }
}
