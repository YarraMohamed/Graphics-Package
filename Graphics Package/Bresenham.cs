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
    public partial class Bresenham : Form
    {
        Table t1 = new Table();
        public Bresenham()
        {
            InitializeComponent();
        }

        //back button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //t1.Close();
            
        }

        //draw button
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);

            bresenhamLineAlgorithm( x1,y1,x2,y2);

        }
        //draw line
        private void bresenhamLineAlgorithm(int x1,int y1,int x2,int y2)
        {
            
            var g = panel2.CreateGraphics();
            var aBrush = Brushes.Blue;
            DataTable table = new DataTable();
            table.Columns.Add("p", typeof(int));
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

            int m = (y2 - y1) / (x2 - x1);
            int x=x1, y=y1;
            int dx=0, dy=0, twoDy=-0, twoDyMinusDx=0,p=0;

            g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);

            // first octant
            if (m<1 && x1 < x2)
            {
                dx = x2 - x1;
                dy = y2 - y1;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;
                while (x < x2)
                {
                    x++;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        y++;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);
                }
            }

             //second octant
             if(m>1 && y1 < y2)
            {
                dx = y2 - y1;
                dy = x2 - x1;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;
                while (y < y2)
                {
                    y++;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        x++;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);

                }
                t1.dt = table;
                t1.Show();
            }

            //third octant
             if (m < -1&& y1<y2)
            {
                    dx = y2 - y1;
                    dy = x1 - x2;
                    twoDy = 2 * dy;
                    twoDyMinusDx = 2 * (dy - dx);
                    p = (2 * dy) - dx;
                    while (y < y2)
                    {
                        y++;
                        if (p < 0)
                        {
                            table.Rows.Add(p, x, y);
                            p += twoDy;
                        }
                        else
                        {
                            x--;
                            table.Rows.Add(p, x, y);
                            p += twoDyMinusDx;
                        }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);

                }
                t1.dt = table;
                t1.Show();
            }

            //fourth octant
             if (m > -1 && x1 > x2)
            {
                dx = x1 - x2;
                dy = y2 - y1;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;

                while (x > x2)
                {
                    x--;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        y++;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);
                }
                t1.dt = table;
                t1.Show();
            }

            //fifth octant
             if (m<1 && x1 > x2)
            {
                dx = x1 - x2;
                dy = y1 - y2;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;

                while (x>x2)
                {
                    x--;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        y--;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x - (panel2.Width / 2), (panel2.Height / 2) + y, 2, 2);
                }
                t1.dt = table;
                t1.Show();
            }

            //sixth octant 
             if (m > 1 && y1 > y2)
            {
                dx = y1 - y2;
                dy = x1 - x2;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;

                while (y > y2)
                {
                    y--;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        x--;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);
                }
             t1.dt = table;
            t1.Show();
            }

             //seventh octant 
             if(m<-1 && y1 > y2)
              {
                 dx = y1 - y2;
                    dy = x2 - x1;
                    twoDy = 2 * dy;
                    twoDyMinusDx = 2 * (dy - dx);
                    p = (2 * dy) - dx;

                    while (y > y2)
                    {
                        y--;
                        if (p < 0)
                        {
                            table.Rows.Add(p, x, y);
                            p += twoDy;
                        }
                        else
                        {
                            x++;
                            table.Rows.Add(p, x, y);
                            p += twoDyMinusDx;
                        }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);
                }
                t1.dt = table;
                t1.Show();
            }
           
           //eighth octant
             if (m>-1 && x1 < x2)
            {
                dx = x2 - x1;
                dy = y1 - y2;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                p = (2 * dy) - dx;

                while (x < x2)
                {
                    x++;
                    if (p < 0)
                    {
                        table.Rows.Add(p, x, y);
                        p += twoDy;
                    }
                    else
                    {
                        y--;
                        table.Rows.Add(p, x, y);
                        p += twoDyMinusDx;
                    }
                    g.FillRectangle(aBrush, x + (panel2.Width / 2), (panel2.Height / 2) - y, 2, 2);
                }
                t1.dt = table;
                t1.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            panel2.Invalidate();
            t1.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            axis();
        }
        public void axis()
        {
            var Graph = panel2.CreateGraphics();
            Pen p = Pens.Black;
            Graph.DrawLine(p, 0, panel2.Height / 2, panel2.Width, panel2.Height / 2);
            Graph.DrawLine(p, panel2.Width / 2, 0, panel2.Width / 2, panel2.Height);
        }
    }
}
