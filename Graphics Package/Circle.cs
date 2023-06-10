using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphics_Package
{
    
    public partial class Circle : Form
    {
        Table t1 = new Table();
        public Circle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            t1.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int xc = Convert.ToInt32(textBox1.Text);
            int yc = Convert.ToInt32(textBox2.Text);
            int radius = Convert.ToInt32(textBox3.Text);
            DrawCircle(xc, yc, radius);
        }

        private void DrawCircle(int xc, int yc, int r)
        {
            var g = panel2.CreateGraphics();
            var aBrush = Brushes.Blue;
            DataTable table = new DataTable();
            table.Columns.Add("p", typeof(int));
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

           
            int x = 0;
            int y = r;
            int l=1-r;

            while (x < y)
            {
               x++;
                

                if (l < 0)
                {
                    table.Rows.Add(l, x, y);
                    l += 2 * x + 1;
                }
                   
                else
                {
                    y--;
                    table.Rows.Add(l, x, y);
                    l += 2 * (x - y) + 1;

                }

                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2)-(yc+y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2)-(yc+y), 2, 2);
                g.FillRectangle(aBrush, (xc + x) + (panel2.Width / 2), (panel2.Height / 2)-(yc-y), 2, 2);
                g.FillRectangle(aBrush, (xc - x) + (panel2.Width / 2), (panel2.Height / 2)-(yc-y), 2, 2);

                g.FillRectangle(aBrush, (xc + y) + (panel2.Width / 2), (panel2.Height / 2)-(yc+x), 2, 2);
                g.FillRectangle(aBrush, (xc - y) + (panel2.Width / 2), (panel2.Height / 2)-(yc+x), 2, 2);
                g.FillRectangle(aBrush, (xc + y) + (panel2.Width / 2), (panel2.Height / 2)-(yc-x), 2, 2);
                g.FillRectangle(aBrush, (xc - y) + (panel2.Width / 2), (panel2.Height / 2)-(yc-x), 2, 2);

            }

            t1.dt = table;
            t1.Show();
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