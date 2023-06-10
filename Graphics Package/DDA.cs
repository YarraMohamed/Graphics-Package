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
    public partial class DDA : Form
    {
        Table t1 = new Table();
       
        public DDA()
        {
            InitializeComponent();
        }

        //back button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            t1.Close();

        }

        //draw button
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);


            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2,y2);

            ddaLineAlgorithm(p1, p2);

        }

        //draw line
        private void ddaLineAlgorithm(Point p1, Point p2)
        {

           
            var g = Panel2.CreateGraphics();
            var aBrush = Brushes.Blue;
            DataTable table = new DataTable();
            table.Columns.Add("k", typeof(int));
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

            double xinc, yinc, x, y, steps;
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;

            if (Math.Abs(dx) > Math.Abs(dy)) steps =Math.Abs(dx);
            else steps =Math.Abs(dy);

            xinc = dx / steps;
            yinc = dy / steps;

            x = p1.X;
            x = Math.Round(x, 0);
            y = p1.Y;
            y = Math.Round(y, 0);

            g.FillRectangle(aBrush, (int)x + (Panel2.Width / 2), (Panel2.Height / 2) - (int)y, 2, 2);

            for (int k = 1; k <= steps; k++)
            {
                x += xinc;
                y += yinc;

                table.Rows.Add(k, x, y);
                g.FillRectangle(aBrush, (int)x + (Panel2.Width / 2), (Panel2.Height / 2) - (int)y, 2, 2);
            }
            t1.dt = table;
            t1.Show();

        }

        //clear button
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Panel2.Invalidate();
            t1.Close();
        }

        //y,x axis
        public void axis()
        {
            var Graph = Panel2.CreateGraphics();
            Pen p = Pens.Black;
            Graph.DrawLine(p, 0, Panel2.Height / 2, Panel2.Width, Panel2.Height / 2);
            Graph.DrawLine(p, Panel2.Width / 2, 0, Panel2.Width / 2, Panel2.Height);
        }

        //darw x,y axis
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            axis();
        }
    }
    }
