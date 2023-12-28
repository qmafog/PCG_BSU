using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Runtime.ConstrainedExecution;

namespace LAB4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown5.Value = 26;
         
            rastBrush = new Pen(Color.FromArgb(200, 200, 250));
            start = new Point(0, 0);
            end = new Point(0, 0);
            center = new Point(0, 0);
            radius = 0;
        }
        private System.Diagnostics.Stopwatch watch;
        private Point start, end, center;
        private int radius;
        int scale = 26;
        int shift = 13;
        Pen rastBrush;
 
        public void drawMarkup(Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb)
        {
            Pen pen = new Pen(Color.Black);
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            int cur_x = 0, cur_y = 0;
            Font font = new Font("Arial", shift - 1);
            int counter = 0;
            gr.DrawString("0", font, pen.Brush, new PointF(cx, cy));
            if (cx <= panel.Width / 2)
            {
                while (cx + cur_x <= panel.Width)
                {
                    pen.Color = Color.Black;
                    counter++;
                    cur_x += scale;
                    gr.DrawString(counter.ToString(), font, pen.Brush, new PointF(cx + cur_x, cy));
                    gr.DrawString("-" + counter.ToString(), font, pen.Brush, new PointF(cx - cur_x, cy));
                    pen.Color = Color.Gray;
                    gr.DrawLine(pen, cx - cur_x, 0, cx - cur_x, panel.Height);
                    gr.DrawLine(pen, cx + cur_x, 0, cx + cur_x, panel.Height);
                }
            }
            else
            {
                while (cx - cur_x >= 0)
                {
                    pen.Color = Color.Black;
                    counter++;
                    cur_x += scale;
                    gr.DrawString(counter.ToString(), font, pen.Brush, new PointF(cx + cur_x, cy));
                    gr.DrawString("-" + counter.ToString(), font, pen.Brush, new PointF(cx - cur_x, cy));
                    pen.Color = Color.Gray;
                    gr.DrawLine(pen, cx - cur_x, 0, cx - cur_x, panel.Height);
                    gr.DrawLine(pen, cx + cur_x, 0, cx + cur_x, panel.Height);
                }
            }
            counter = 0;
            if (cy <= panel.Height / 2)
            {
                while (cy + cur_y <= panel.Height)
                {
                    pen.Color = Color.Black;
                    counter++;
                    cur_y += scale;
       
                    gr.DrawString(counter.ToString(), font, pen.Brush, new PointF(cx, cy + cur_y));
                    gr.DrawString("-" + counter.ToString(), font, pen.Brush, new PointF(cx, cy - cur_y));
                    pen.Color = Color.Gray;
                    gr.DrawLine(pen, 0, cy - cur_y, panel.Width, cy - cur_y);
                    gr.DrawLine(pen, 0, cy + cur_y, panel.Width, cy + cur_y);

                }
            }
            else
            {
                while (cy - cur_y >= 0)
                {
                    pen.Color = Color.Black;
                    counter++;
                    cur_y += scale;
                    gr.DrawString(counter.ToString(), font, pen.Brush, new PointF(cx, cy + cur_y));
                    gr.DrawString("-" + counter.ToString(), font, pen.Brush, new PointF(cx, cy - cur_y));
                    pen.Color = Color.Gray;
                    gr.DrawLine(pen, 0, cy - cur_y, panel.Width, cy - cur_y);
                    gr.DrawLine(pen, 0, cy + cur_y, panel.Width, cy + cur_y);

                }
            }

            cur_x = 0;


            cur_y = 0;

            pen.Color = Color.Black;
            pen.Width = 2;
            gr.DrawLine(pen, cx, 0, cx, panel.Height);
            gr.DrawLine(pen, 0, cy, panel.Width, cy);
            PointF[] x_vec = new PointF[] { new PointF(cx, 0), new PointF(cx - 2, 5), new PointF(cx + 2, 5) };
            PointF[] y_vec = new PointF[] { new PointF(panel.Width - 1, cy), new PointF(panel.Width - 6, cy - 2), new PointF(panel.Width - 6, cy + 2) };
            gr.DrawPolygon(pen, x_vec);
            gr.DrawPolygon(pen, y_vec);
            gr.DrawString("x", new Font("Arial", shift + 1), pen.Brush, new PointF(panel.Width - 20, cy + 10));
            gr.DrawString("y", new Font("Arial", shift + 1), pen.Brush, new PointF(cx - 15, 0));


            

        }

        public void drawRasterization(Point[] points, Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb)
        {
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < points.Length; i++)
            {
                Point p = new Point(points[i].X * scale + cx - shift, -points[i].Y * scale + cy - shift);
                System.Drawing.Rectangle rect = new Rectangle(p, new Size(scale, scale));
                gr.DrawRectangle(pen, rect);
                gr.FillRectangle(rastBrush.Brush, rect);
            }
        }
        public void drawLine(Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb, PointF start, PointF end, Color color)
        {
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            Pen pen = new Pen(color, 2);
            gr.DrawLine(pen, new PointF(start.X * scale + cx, -start.Y * scale + cy),
                               new PointF(end.X * scale + cx, -end.Y * scale + cy));
        }
        public void drawCircle(Graphics gr, Panel panel, Point center, int radius, Color color)
        {
            int cx =panel.Width / 2 + hsbCircle.Value * shift;
            int cy = panel.Height / 2 - vsbCircle.Value * shift;
            gr.DrawEllipse(new Pen(color, 2), (center.X * scale) + cx - radius * scale, -center.Y * scale + cy - radius * scale, 
                                                    2 * radius * scale, 2 * radius * scale);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
 
            Point[] points;
            Graphics gr = e.Graphics;
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            points = Bresenham(start, end);
            watch.Stop();
            textBox1.Text = watch.Elapsed.TotalMilliseconds.ToString();
            if (checkin())
                drawRasterization(points, gr, panel1, vsbBreseham, hsbBresenham);
            drawMarkup(gr, panel1, vsbBreseham, hsbBresenham);
            drawLine(gr, panel1, vsbBreseham, hsbBresenham, start, end, Color.Blue);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Point[] points;
            Graphics gr = e.Graphics;
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            points = DDA(start, end);
            watch.Stop();
            textBox2.Text = watch.Elapsed.TotalMilliseconds.ToString();
            if (checkin())
                drawRasterization(points, gr, panel2, vsbDDA, hsbDDA);
            drawMarkup(gr, panel2, vsbDDA, hsbDDA);
            drawLine(gr, panel2, vsbDDA, hsbDDA, start, end, Color.Blue);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Point[] points;
            Graphics gr = e.Graphics;
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            points = CircleBresenham(center, radius);
            watch.Stop();
            textBox3.Text = watch.Elapsed.TotalMilliseconds.ToString();
            if (radius != 0)
                drawRasterization(points, gr, panel3, vsbCircle, hsbCircle);
            drawMarkup(gr, panel3, vsbCircle, hsbCircle);
            drawCircle(gr, panel3, center, radius, Color.Blue);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Point[] points;
            Graphics gr = e.Graphics;
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            points = Naive(start, end);
            watch.Stop();
            textBox5.Text = watch.Elapsed.TotalMilliseconds.ToString();
            if (checkin())
                drawRasterization(points, gr, panel5, vsbNaive, hsbNaive);
            drawMarkup(gr, panel5, vsbNaive, hsbNaive);
            drawLine(gr, panel5, vsbNaive, hsbNaive, start, end, Color.Blue);
        }

        private bool checkin()
        {
            if (start.X == 0 && end.X == 0 && start.Y == 0 && end.Y == 0)
                return false;
            return true;
        }

        public void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public void Swap(ref float x, ref float y)
        {
            float temp = x;
            x = y;
            y = temp;
        }
        public Point[] Bresenham(PointF start, PointF end)
        {
            List<Point> points = new List<Point>();

            int x1 = (int)start.X;
            int y1 = (int)start.Y;
            int x2 = (int)end.X;
            int y2 = (int)end.Y;
            bool direct = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (direct)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                points.Add(new Point(direct ? y1 : x1,
                                    direct ? x1 : y1));

                if (x1 == x2 && y1 == y2)
                    break;

                int err2 = 2 * err;

                if (err2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (err2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }

            return points.ToArray();
        }

        public Point[] Naive(PointF start, PointF end)
        {
            int x0 = (int)start.X;
            int y0 = (int)start.Y;
            int x1 = (int)end.X;
            int y1 = (int)end.Y;

            List<Point> list = new List<Point>();
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
       
            float deltaX = x1 - x0;
            if (deltaX == 0)
            {
                if (y1 < y0)
                {
                    Swap(ref y1, ref y0);
                }
                for (int y = y0; y <= y1; y++)
                {
                    list.Add(new Point(x1, y));
                }
                return list.ToArray();
            }


            float deltaY = y1 - y0;
            float b = (float)y0 - (float)x0 * deltaY / deltaX;
            bool direct = false;
            if (Math.Abs(deltaY) > Math.Abs(deltaX))
            {
                direct = true;
            }

            list.Add(new Point(x0, y0));
            list.Add(new Point(x1, y1));
            if (!direct)
            {
                if (x1 < x0)
                {
                    Swap(ref x1, ref x0);
                }
                for (float x = x0 + 1; x < x1; x++)
                {
                    list.Add(new Point((int)x, (int)Math.Round(deltaY / deltaX * x + b))); 
                }
            }
            else
            {
                if (y1 < y0)
                {
                    Swap(ref y1, ref y0);
                }
                for (float y = y0 + 1; y < y1; y++)
                {
                    list.Add(new Point((int)Math.Round((y - b) * deltaX / deltaY), (int)y)); 
                
                }
            }
            return list.ToArray();
        }
        public Point[] CircleBresenham(PointF center, int radius)
        {
            int x0 = (int)center.X;
            int y0 = (int)center.Y;
            List<Point> list = new List<Point>();
          
       


            int x = radius;
            int y = 0;


            int radiusError = 1 - x;
            while (x >= y)
            {
                list.Add(new Point(x + x0, y + y0));
                list.Add(new Point(y + x0, x + y0));
                list.Add(new Point(-x + x0, y + y0));
                list.Add(new Point(-y + x0, x + y0));
                list.Add(new Point(-x + x0, -y + y0));
                list.Add(new Point(-y + x0, -x + y0));
                list.Add(new Point(x + x0, -y + y0));
                list.Add(new Point(y + x0, -x + y0));
                y++;
                if (radiusError < 0)
                {
                    radiusError += 2 * y + 1;
                }
                else
                {
                    x--;
                    radiusError += 2 * (y - x + 1);
                }
            }
            

            return list.ToArray();
        }

        public Point[] DDA(PointF start, PointF end)
        {
            List<Point> list = new List<Point>();

            int x1 = (int)start.X;
            int y1 = (int)start.Y;
            int x2 = (int)end.X;
            int y2 = (int)end.Y;

            if (x2 < x1)
                Swap(ref x2, ref x1);
            if (y2 < y1)
                Swap(ref y2, ref y1);
            int dx = x2 - x1;
            int dy = y2 - y1;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            float xIncrement = dx / (float)steps;
            float yIncrement = dy / (float)steps;

            float x = x1;
            float y = y1;

            for (int i = 0; i <= steps; i++)
            {
                list.Add(new Point((int)x, (int)y));

                x += xIncrement;
                y += yIncrement;
            }

            return list.ToArray();
        }




        private void clear(Panel panel)
        {
            panel.Invalidate();
        }

        private void clearAll()
        {
            clear(panel1);
            clear(panel2);
            clear(panel3);
            clear(panel5);
        }

        private void clearLinePanels()
        {
            clear(panel1);
            clear(panel2);
            clear(panel5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            start = new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            end = new Point((int)numericUpDown3.Value, (int)numericUpDown4.Value);
            clearLinePanels();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            scale = (int)numericUpDown5.Value;
            shift = scale / 2;
            clearAll();
        }

        private void vScrollCircle_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void vsbBreseham_Scroll(object sender, ScrollEventArgs e)
        {
            clear(panel1);
        }

        private void vsbNaive_Scroll(object sender, ScrollEventArgs e)
        {
            clear(panel5);
        }

        private void vsbDDA_Scroll(object sender, ScrollEventArgs e)
        {
            clear(panel2);
        }

        private void vsbWu_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            center = new Point((int)numericUpDown6.Value, (int)numericUpDown7.Value);
            radius = (int)numericUpDown8.Value;
            clear(panel3);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           
        }
    }
}
