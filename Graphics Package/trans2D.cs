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
    public partial class trans2D : Form
    {
        public trans2D()
        {
            InitializeComponent();
        }

        //clear button
        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            panel3.Invalidate();
        }

        //back button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //x,y axis
        public void axis()
        {
            var Graph = panel3.CreateGraphics();
            Pen p = Pens.Black;
            Graph.DrawLine(p, 0, panel3.Height / 2, panel3.Width, panel3.Height / 2);
            Graph.DrawLine(p, panel3.Width / 2, 0, panel3.Width / 2, panel3.Height);
        }

        //draw x,y axis
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            axis();
        }

        private void draw(int x0, int y0, int xEnd, int yEnd)
        {

            var g = panel3.CreateGraphics();
            var aBrush = Brushes.Blue;

            double xinc, yinc, x, y, steps;
            double dx = xEnd- x0;
            double dy = yEnd - y0;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);

            xinc = dx / steps;
            yinc = dy / steps;

            x = x0;
            x = Math.Round(x, 0);
            y = y0;
            y = Math.Round(y, 0);

            g.FillRectangle(aBrush, (int)x ,  (int)y, 2, 2);

            for (int k = 1; k <= steps; k++)
            {
                x += xinc;
                y += yinc;

               
                g.FillRectangle(aBrush, (int)x ,  (int)y, 2, 2);
            }

        }

        private void drawTransformation(int x0, int y0, int xEnd, int yEnd)
        {

            var g = panel3.CreateGraphics();
            var aBrush = Brushes.Black;

            double xinc, yinc, x, y, steps;
            double dx = xEnd - x0;
            double dy = yEnd - y0;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);

            xinc = dx / steps;
            yinc = dy / steps;

            x = x0;
            x = Math.Round(x, 0);
            y = y0;
            y = Math.Round(y, 0);

            g.FillRectangle(aBrush, (int)x, (int)y, 2, 2);

            for (int k = 1; k <= steps; k++)
            {
                x += xinc;
                y += yinc;


                g.FillRectangle(aBrush, (int)x, (int)y, 2, 2);
            }

        }




        //draw button
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            draw(xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0], xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1]);
            draw(xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1], xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2]);
            draw(xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2], xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0]);
        }
       
        //translate button
        private void button4_Click(object sender, EventArgs e)
        {
            var g = panel3.CreateGraphics();

            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);
            int Xt = Convert.ToInt32(textBox7.Text);
            int Yt= Convert.ToInt32(textBox8.Text);

            x1 = x1 + Xt; x2 = x2 + Xt; x3 = x3 + Xt;
            y1 = y1 + Yt; y2 = y2 + Yt; y3 = y3 + Yt;

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0], xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1]);
            drawTransformation(xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1], xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2]);
            drawTransformation(xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2], xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0]);
        }

        //rotation button
        private void button5_Click(object sender, EventArgs e)
        {
            var g = panel3.CreateGraphics();

            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);
            int t = Convert.ToInt32(textBox9.Text);

            double s = Math.Sin(t * Math.PI / 180);
            double c = Math.Cos(t * Math.PI / 180);

            double xf = ((double)x1 * c) - (s * (double)y1);
            double yf = ((double)x1 * s) + (c * (double)y1);

            double xs = ((double)x2 * c) - (s * (double)y2);
            double ys = ((double)x2 * s) + (c * (double)y2);

            double xt = ((double)x3 * c) - (s * (double)y3);
            double yt = ((double)x3 * s) + (c * (double)y3);

            double[] xArray = { xf, xs, xt };
            double[] yArray = { yf, ys, yt };
            drawTransformation((int)xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[0], (int)xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[1]);
            drawTransformation((int)xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[1], (int)xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[2]);
            drawTransformation((int)xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[2], (int)xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[0]);

            /////////// rule /////////
            ///[ costh    -sinth ] [ x1 x2 x3 ]
            ///[ sinth     costh ] [ y1 y2 y3 ]

        }

        //scaling button
        private void button6_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);

            double sx = Convert.ToDouble(textBox11.Text);
            double sy = Convert.ToDouble(textBox10.Text);

            double xf = ((double)x1 * sx);
            double yf = (sy * (double)y1);

            double xs = ((double)x2 * sx);
            double ys =  (sy * (double)y2);

            double xt = ((double)x3 * sx);
            double yt =  (sy * (double)y3);

            double[] xArray = { xf, xs, xt };
            double[] yArray = { yf, ys, yt };
            drawTransformation((int)xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[0], (int)xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[1]);
            drawTransformation((int)xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[1], (int)xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[2]);
            drawTransformation((int)xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[2], (int)xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - (int)yArray[0]);

            /////////// rule /////////
            ///[ sx    0  ] [ x1 x2 x3 ]
            ///[ 0     sy ] [ y1 y2 y3 ]

        }

        //draw x-axis reflection
        private void button8_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(xArray[0] + (panel3.Width / 2), (panel3.Height / 2) + yArray[0], xArray[1] + (panel3.Width / 2), (panel3.Height / 2) + yArray[1]);
            drawTransformation(xArray[1] + (panel3.Width / 2), (panel3.Height / 2) +yArray[1], xArray[2] + (panel3.Width / 2), (panel3.Height / 2) +yArray[2]);
            drawTransformation(xArray[2] + (panel3.Width / 2), (panel3.Height / 2) +yArray[2], xArray[0] + (panel3.Width / 2), (panel3.Height / 2) + yArray[0]);

            /////////// rule /////////
            ///[ 1    0  ] [ x1 x2 x3 ]
            ///[ 0    -1 ] [ y1 y2 y3 ]
        }

        //draw y-axis reflection
        private void button9_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(-xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0],- xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1]);
            drawTransformation(-xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1], -xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2]);
            drawTransformation(-xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2], -xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0]);


            /////////// rule /////////
            ///[ -1    0 ] [ x1 x2 x3 ]
            ///[ 0     1 ] [ y1 y2 y3 ]

        }

        //draw origin reflection
        private void button10_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(-xArray[0] + (panel3.Width / 2), (panel3.Height / 2) + yArray[0], -xArray[1] + (panel3.Width / 2), (panel3.Height / 2) + yArray[1]);
            drawTransformation(-xArray[1] + (panel3.Width / 2), (panel3.Height / 2) +yArray[1], -xArray[2] + (panel3.Width / 2), (panel3.Height / 2) + yArray[2]);
            drawTransformation(-xArray[2] + (panel3.Width / 2), (panel3.Height / 2) + yArray[2], -xArray[0] + (panel3.Width / 2), (panel3.Height / 2) + yArray[0]);

            /////////// rule /////////
            ///[ -1    0  ] [ x1 x2 x3 ]
            ///[ 0     -1 ] [ y1 y2 y3 ]

        }

        //ShearingOverX
        private void button7_Click(object sender, EventArgs e)
        {
             int x1 = Convert.ToInt32(textBox1.Text);
             int y1 = Convert.ToInt32(textBox2.Text);
             int x2 = Convert.ToInt32(textBox3.Text);
             int y2 = Convert.ToInt32(textBox4.Text);
             int x3 = Convert.ToInt32(textBox5.Text);
             int y3 = Convert.ToInt32(textBox6.Text);
             int sh = Convert.ToInt32(textBox12.Text);

             x1 = x1 + (sh * y1);
             x2 = x2 + (sh * y2);
             x3 = x3 + (sh * y3);

            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0], xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1]);
            drawTransformation(xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1], xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2]);
            drawTransformation(xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2], xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0]);

            /////////// rule /////////
            ///[ 1    sh  ] [ x1 x2 x3 ]
            ///[ 0     1  ] [ y1 y2 y3 ]

        }
        //ShearingOverY
        private void button11_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int x3 = Convert.ToInt32(textBox5.Text);
            int y3 = Convert.ToInt32(textBox6.Text);
            int sh = Convert.ToInt32(textBox12.Text);

            y1 = y1 + (sh * x1);
            y2 = y2 + (sh * x2);
            y3 = y3 = (sh * x3);
            int[] xArray = { x1, x2, x3 };
            int[] yArray = { y1, y2, y3 };
            drawTransformation(xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0], xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1]);
            drawTransformation(xArray[1] + (panel3.Width / 2), (panel3.Height / 2) - yArray[1], xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2]);
            drawTransformation(xArray[2] + (panel3.Width / 2), (panel3.Height / 2) - yArray[2], xArray[0] + (panel3.Width / 2), (panel3.Height / 2) - yArray[0]);

            /////////// rule /////////
            ///[ 1    0  ] [ x1 x2 x3 ]
            ///[ sh   1  ] [ y1 y2 y3 ]

        }
    }
}
