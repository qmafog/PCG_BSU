using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace LAB4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown5.Value = 16;

            rastBrush = new Pen(Color.FromArgb(200, 200, 250));
            segments = readRectangleClipper("input.txt");
            polygon = readPolygon("input2.txt");
            start = new Point(0, 0);
            end = new Point(0, 0);
            center = new Point(0, 0);
            radius = 0;
        }
        private List<PointF> polygon;
        private List<KeyValuePair<PointF, PointF>> segments;
        RectangularWindow polygonClipper;
       
        private Point start, end, center;
        private int radius;
        RectClipper clipper;
        int scale = 16;
        int shift = 13;
        Pen rastBrush;

        public List<KeyValuePair<PointF, PointF>> readRectangleClipper(string file)
        {
            List<KeyValuePair<PointF, PointF>> list = new List<KeyValuePair<PointF, PointF>>();
            StreamReader r = new StreamReader(file);
            int num = int.Parse(r.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] str_ = r.ReadLine().Split();
                list.Add(new KeyValuePair<PointF, PointF>(new PointF(float.Parse(str_[0]), float.Parse(str_[1])), new PointF(float.Parse(str_[2]), float.Parse(str_[3]))));
            }
            string[] str = r.ReadLine().Split();
            r.Close();
            clipper = new RectClipper(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]), float.Parse(str[3]));
            return list;
        }

        public List<PointF> readPolygon(string file)
        {
            List<PointF> list = new List<PointF>();
            StreamReader r = new StreamReader(file);
            int num = int.Parse(r.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] str_ = r.ReadLine().Split();
                list.Add(new PointF(float.Parse(str_[0]), float.Parse(str_[1])));
            }
            string[] str = r.ReadLine().Split();
            r.Close();
            polygonClipper = new RectangularWindow(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]), float.Parse(str[3]));
            return list;
        }

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

                    gr.DrawString(counter.ToString(), font, pen.Brush, new PointF(cx, cy - cur_y));
                    gr.DrawString("-" + counter.ToString(), font, pen.Brush, new PointF(cx, cy + cur_y));
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


        public void drawPoligon(List<PointF> points, Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb, System.Drawing.Color color)
        {
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            Pen pen = new Pen(color, 3);
            PointF prev = points[0];
            foreach (PointF point in points)
            {
                gr.DrawLine(pen, new PointF(prev.X * (float)scale + cx, -prev.Y * (float)scale + (float)cy),
                                   new PointF(point.X * (float)scale + cx, -point.Y * (float)scale + (float)cy));
                prev = point;
            }
            gr.DrawLine(pen, new PointF(prev.X * (float)scale + cx, -prev.Y * (float)scale + (float)cy),
                                    new PointF(points[0].X * (float)scale + cx, -points[0].Y * (float)scale + (float)cy));
        }

        public void drawClipping(List<PointF> points, Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb,
                                                 float x0, float y0, float x1, float y1, float xmin, float ymin, float xmax, float ymax)
        {
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            Pen pen = new Pen(Color.Black, 3);
            Pen Pen1 = new Pen(Color.Red, 3);
            Pen Pen2 = new Pen(Color.Blue, 3);
            System.Drawing.Rectangle rect = new Rectangle(new Point((int)Math.Round(xmin * scale + (float)cx), (int)Math.Round(-ymax * scale + (float)cy)),
                                                new Size((int)Math.Round((xmax - xmin) * (float)scale), (int)Math.Round((ymax - ymin) * (float)scale)));
            gr.DrawRectangle(pen, rect);
            if (points.Count > 0)
            {
                gr.DrawLine(Pen1, new PointF(x0 * (float)scale + (float)cx, -y0 * (float)scale + (float)cy),
                                      new PointF(points[0].X * (float)scale + cx, -points[0].Y * (float)scale + (float)cy));
                gr.DrawLine(Pen2, new PointF(points[0].X * (float)scale + cx, -points[0].Y * (float)scale + (float)cy),
                                   new PointF(points[1].X * (float)scale + cx, -points[1].Y * (float)scale + (float)cy));
                gr.DrawLine(Pen1, new PointF(points[1].X * (float)scale + cx, -points[1].Y * (float)scale + (float)cy),
                                   new PointF(x1 * (float)scale + cx, -y1 * (float)scale + (float)cy));

            }
            else
            {
                gr.DrawLine(Pen1, new PointF(x0 * (float)scale + (float)cx, -y0 * (float)scale + (float)cy),
                    new PointF(x1 * (float)scale + cx, -y1 * (float)scale + (float)cy));
            }
        }
        public void drawLine(Graphics gr, Panel panel, VScrollBar vsb, HScrollBar hsb, PointF start, PointF end, Color color)
        {
            int cx = panel.Width / 2 + hsb.Value * shift;
            int cy = panel.Height / 2 - vsb.Value * shift;
            Pen pen = new Pen(color, 2);
            gr.DrawLine(pen, new PointF(start.X * (float)scale + (float)cx, -start.Y * (float)scale + (float)cy),
                               new PointF(end.X * (float)scale + cx, -end.Y * (float)scale + (float)cy));
        }
      
        public class RectClipper
        {
            public PointF min;
            public PointF max;
            public RectClipper(float xmin, float ymin, float xmax, float ymax)
            {
                min = new PointF(xmin, ymin);
                max = new PointF(xmax, ymax);
            }
        }


        public class CohenSutherlandClipping
        {
            public const int INSIDE = 0;
            public const int LEFT = 1;
            public const int RIGHT = 2;
            public const int BOTTOM = 4;
            public const int TOP = 8;

            static int ComputeOutCode(float x, float y, float xmin, float ymin, float xmax, float ymax)
            {
                int code = INSIDE;

                if (x < xmin)
                    code |= LEFT;
                else if (x > xmax)
                    code |= RIGHT;

                if (y < ymin)
                    code |= BOTTOM;
                else if (y > ymax)
                    code |= TOP;

                return code;
            }

            public static List<PointF> CohenSutherland(float x0, float y0, float x1, float y1, float xmin, float ymin, float xmax, float ymax)
            {
                List<PointF> clippedPoints = new List<PointF>();
                int code0 = ComputeOutCode(x0, y0, xmin, ymin, xmax, ymax);
                int code1 = ComputeOutCode(x1, y1, xmin, ymin, xmax, ymax);
                bool accept = false;

                while (true)
                {
                    if ((code0 == 0) && (code1 == 0))
                    {
                        accept = true;
                        break;
                    }
                    else if ((code0 & code1) != 0)
                    {
                        break;
                    }
                    else
                    {
                        int codeOut = (code0 != 0) ? code0 : code1;
                        float x, y;

                        if ((codeOut & TOP) != 0)
                        {
                            if (y1 - y0 != 0)
                            {
                                x = x0 + (x1 - x0) * (ymax - y0) / (y1 - y0);
                            }
                            else
                            {
                                x = x0;
                            }
                            y = ymax;
                        }
                        else if ((codeOut & BOTTOM) != 0)
                        {
                            if (y1 - y0 != 0)
                            {
                                x = x0 + (x1 - x0) * (ymin - y0) / (y1 - y0);
                            }
                            else
                            {
                                x = x0;
                            }
                         
                            y = ymin;
                        }
                        else if ((codeOut & RIGHT) != 0)
                        {
                            if (x1 - x0 != 0)
                            {
                                y = y0 + (y1 - y0) * (xmax - x0) / (x1 - x0);
                            }
                            else
                            {
                                y = y0;
                            }

                            x = xmax;
                        }
                        else
                        { 
                            if (x1 - x0 != 0)
                        {
                                y = y0 + (y1 - y0) * (xmin - x0) / (x1 - x0);
                            }
                        else
                        {
                            y = y0;
                        }

                        
                            x = xmin;
                        }

                        if (codeOut == code0)
                        {
                            x0 = x;
                            y0 = y;
                            code0 = ComputeOutCode(x0, y0, xmin, ymin, xmax, ymax);
                        }
                        else
                        {
                            x1 = x;
                            y1 = y;
                            code1 = ComputeOutCode(x1, y1, xmin, ymin, xmax, ymax);
                        }
                    }
                }

                if (accept)
                {
                    clippedPoints.Add(new PointF(x0, y0));
                    clippedPoints.Add(new PointF(x1, y1));
                }

                return clippedPoints;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            int cx = panel3.Width / 2 + hsbCircle.Value * shift;
            int cy = panel3.Height / 2 - vsbCircle.Value * shift;
            Pen pen = new Pen(Color.Black, 3);
            System.Drawing.Rectangle rect = new Rectangle(new Point((int)Math.Round(polygonClipper.Xmin * scale + (float)cx),
                                                                    (int)Math.Round(-polygonClipper.Ymax * scale + (float)cy)),
                                                new Size((int)Math.Round((polygonClipper.Xmax - polygonClipper.Xmin) * (float)scale),
                                                (int)Math.Round((polygonClipper.Ymax - polygonClipper.Ymin) * (float)scale)));
            gr.DrawRectangle(pen, rect);
            drawPoligon(polygon, gr, panel3, vsbCircle, hsbCircle, Color.Green);
            List<PointF> clippedPolygon = ClipPolygon(polygon, polygonClipper.Xmin, polygonClipper.Ymin, polygonClipper.Xmax, polygonClipper.Ymax);
            drawPoligon(clippedPolygon, gr, panel3, vsbCircle, hsbCircle, Color.Blue);
            drawMarkup(gr, panel3, vsbCircle, hsbCircle);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

            List<PointF> points;
            Graphics gr = e.Graphics;
            foreach (KeyValuePair<PointF, PointF> seg in segments)
            {
                points = CohenSutherlandClipping.CohenSutherland(seg.Key.X, seg.Key.Y, seg.Value.X, seg.Value.Y,
                                                                    clipper.min.X, clipper.min.Y, clipper.max.X, clipper.max.Y);
                drawClipping(points, gr, panel5, vsbNaive, hsbNaive, seg.Key.X, seg.Key.Y, seg.Value.X, seg.Value.Y,
                                                                    clipper.min.X, clipper.min.Y, clipper.max.X, clipper.max.Y);
            }
            drawMarkup(gr, panel5, vsbNaive, hsbNaive);

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
    

        private void clear(Panel panel)
        {
            panel.Invalidate();
        }

        private void clearAll()
        {
           
            clear(panel3);
            clear(panel5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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
            
        }

        private void vsbNaive_Scroll(object sender, ScrollEventArgs e)
        {
            clear(panel5);
        }

        private void vsbDDA_Scroll(object sender, ScrollEventArgs e)
        {
           
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
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //panel1.Size = new Size(Form1.Size, 10);
        }

        private static int ComputeOutCodeAddaptive(float x, float y, float xmin, float ymin, float xmax, float ymax)
        {
            int code = CohenSutherlandClipping.INSIDE;

            if (x <= xmin)
                code |= CohenSutherlandClipping.LEFT;
            else if (x >= xmax)
                code |= CohenSutherlandClipping.RIGHT;

            if (y <= ymin)
                code |= CohenSutherlandClipping.BOTTOM;
            else if (y >= ymax)
                code |= CohenSutherlandClipping.TOP;

            return code;
        }
        private static List<PointF> addAngles(PointF p0, PointF p1, float xmin, float ymin, float xmax, float ymax)
        {
            List<PointF> angles = new List<PointF>();
            int code0 = ComputeOutCodeAddaptive(p0.X, p0.Y, xmin, ymin, xmax, ymax);
            int code1 = ComputeOutCodeAddaptive(p1.X, p1.Y, xmin, ymin, xmax, ymax);
            for (int i = 0; i < 4; i++)
            {
                if (code0 != code1)
                {
                    if (code0 == CohenSutherlandClipping.TOP)
                    {
                        code0 = CohenSutherlandClipping.LEFT;
                        angles.Add(new PointF(xmin, ymax));
                    }
                    else if (code0 == CohenSutherlandClipping.LEFT)
                    {
                        code0 = CohenSutherlandClipping.BOTTOM;
                        angles.Add(new PointF(xmin, ymin));
                    }
                    else if (code0 == CohenSutherlandClipping.BOTTOM)
                    {
                        code0 = CohenSutherlandClipping.RIGHT;
                        angles.Add(new PointF(xmax, ymin));
                    }
                    else if (code0 == CohenSutherlandClipping.RIGHT)
                    {
                        code0 = CohenSutherlandClipping.TOP;
                        angles.Add(new PointF(xmax, ymax));
                    }

                }
                else
                {
                    break;
                }
            }
            return angles;
        }

        public static List<PointF> ClipPolygon(List<PointF> polygon, float xmin, float ymin, float xmax, float ymax)
        {
            List<PointF> clippedPolygon = new List<PointF>();
            List<PointF> clippedLinePoints = new List<PointF>();
            List<PointF> angles = new List<PointF>();
            bool outFlag = false;
            PointF prevPoint = new PointF(0, 0);
            for (int i = 0; i < polygon.Count - 1; i++)
            {
                clippedLinePoints = CohenSutherlandClipping.CohenSutherland(polygon[i].X, polygon[i].Y,
                                                                            polygon[i + 1].X, polygon[i + 1].Y,
                                                                            xmin, ymin, xmax, ymax);
                if (clippedLinePoints.Count != 0)
                {
                    if (outFlag)
                    {
                        angles = addAngles(prevPoint, clippedLinePoints[0], xmin, ymin, xmax, ymax);
                        if (angles.Count != 0)
                            for (int j = 0; j < angles.Count; j++)
                            {
                                clippedPolygon.Add(angles[j]);
                            }
                        outFlag = false;
                    }
                    clippedPolygon.Add(clippedLinePoints[0]);
                    clippedPolygon.Add(clippedLinePoints[1]);
                    prevPoint = clippedLinePoints[1];
                    if (clippedLinePoints[1] != polygon[i + 1])
                    {
                        outFlag = true;

                    }
                }

            }
            angles = addAngles(clippedPolygon[clippedPolygon.Count - 1], clippedPolygon[0], xmin, ymin, xmax, ymax);
            if (angles.Count != 0)
                for (int j = 0; j < angles.Count; j++)
                {
                    clippedPolygon.Add(angles[j]);
                }
            return clippedPolygon;
        }

    }
    class RectangularWindow
    {
        public float Xmin { get; }
        public float Ymin { get; }
        public float Xmax { get; }
        public float Ymax { get; }

        public RectangularWindow(float left, float bottom, float right, float top)
        {
            Xmin = left;
            Ymin = bottom;
            Xmax = right;
            Ymax = top;
        }
    }
}



