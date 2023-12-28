using System;
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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.trackBar1.Minimum = 0;
            this.trackBar1.Maximum = 255;
            this.trackBar2.Minimum = 0;
            this.trackBar2.Maximum = 255;
            this.trackBar3.Minimum = 0;
            this.trackBar3.Maximum = 255;
            this.trackBar4.Minimum = 0;
            this.trackBar4.Maximum = 95047;
            this.trackBar5.Minimum = 0;
            this.trackBar5.Maximum = 100000;
            this.trackBar6.Minimum = 0;
            this.trackBar6.Maximum = 108883;
            this.trackBar7.Minimum = 0;
            this.trackBar7.Maximum = 1000;
            this.trackBar8.Minimum = 0;
            this.trackBar8.Maximum = 1000;
            this.trackBar9.Minimum = 0;
            this.trackBar9.Maximum = 1000;
            this.trackBar10.Minimum = 0;
            this.trackBar10.Maximum = 1000;
            this.textBox10.Text = "1";

            colorDialog1.FullOpen = true;
            colorDialog1.Color = this.panel1.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            this.panel1.BackColor = colorDialog1.Color;
            textBox1.Text = Convert.ToString(colorDialog1.Color.R);
            textBox2.Text = Convert.ToString(colorDialog1.Color.G);
            textBox3.Text = Convert.ToString(colorDialog1.Color.B);
            FromRGB(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox1.Text);
            }
            catch (System.FormatException exp) { value = 0; }
            if (value < 0)
                value = 0;
            if (value > trackBar1.Maximum)
                value = trackBar1.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar1.Value = int_value;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.textBox1.Text = this.trackBar1.Value.ToString();
            FromRGB(0);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private double fToXYZ(double x)
        {
            if (x >= 0.04045)
            {
                return Math.Pow((x + 0.055) / 1.055, 2.4);
            }
            else
            {
                return x / 12.92;
            }
        }

        private double fToRGB(double x)
        {
            if (x >= 0.0031308)
            {
                return 1.055 * Math.Pow(x, 1.0 / 2.4) - 0.055;
            }
            else
            {
                return 12.92 * x;
            }
        }
        private void FromRGB(int ind)
        {
            String text;
            if (textBox1.Text.Length == 0)
                text = "0";
            else
                text = textBox1.Text;
            double R = Convert.ToDouble(text);
            if (textBox2.Text.Length == 0)
                text = "0";
            else
                text = textBox2.Text;
            double G = Convert.ToDouble(text);
            if (textBox3.Text.Length == 0)
                text = "0";
            else
                text = textBox3.Text;
            double B = Convert.ToDouble(text);
            if (ind <= 0)
            {

                double K = Math.Min(1.0 - (G / 255.0), 1.0 - (R / 255.0));
                double valueC, valueM, valueY;
                K = Math.Min(K, 1 - (B / 255.0));
                if (K == 1)
                {
                    valueC = 0;
                    valueM = 0;
                    valueY = 0;
                }
                else
                {
                    valueC = (1.0 - (R / 255.0) - K) / (1.0 - K);
                    valueM = (1.0 - (G / 255.0) - K) / (1.0 - K);
                    valueY = (1.0 - (B / 255.0) - K) / (1.0 - K);
                }
                textBox7.Text = Convert.ToString(valueC);
                textBox8.Text = Convert.ToString(valueM);
                textBox9.Text = Convert.ToString(valueY);
                textBox10.Text = Convert.ToString(K);

            }

            if (ind >= 0)
            {

                double valueX = (0.412453 * fToXYZ(R / 255) * 100) +
                    (0.357580 * fToXYZ(G / 255) * 100) +
                    (0.180423 * fToXYZ(B / 255) * 100);

                double valueYY = (0.212671 * fToXYZ(R / 255) * 100) +
                    (0.715160 * fToXYZ(G / 255) * 100) +
                    (0.072169 * fToXYZ(B / 255) * 100);
                double valueZ = (0.019334 * fToXYZ(R / 255) * 100) +
                    (0.119193 * fToXYZ(G / 255) * 100) +
                    (0.950227 * fToXYZ(B / 255) * 100);




                textBox4.Text = Convert.ToString(valueX);
                textBox5.Text = Convert.ToString(valueYY);
                textBox6.Text = Convert.ToString(valueZ);
            }

            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            colorDialog1.Color = this.panel1.BackColor;
        }

        private void FromCMYK()
        {
            String text;
            if (textBox7.Text.Length == 0)
                text = "0";
            else
                text = textBox7.Text;
            double C = Convert.ToDouble(text);
            if (textBox8.Text.Length == 0)
                text = "0";
            else
                text = textBox8.Text;
            double M = Convert.ToDouble(text);
            if (textBox9.Text.Length == 0)
                text = "0";
            else
                text = textBox9.Text;
            double Y = Convert.ToDouble(text);
            if (textBox10.Text.Length == 0)
                text = "0";
            else
                text = textBox10.Text;
            double K = Convert.ToDouble(text);
            double R = (1 - C) * (1 - K) * 255;
            double G = (1 - M) * (1 - K) * 255;
            double B = (1 - Y) * (1 - K) * 255;
            textBox1.Text = Convert.ToString(Convert.ToInt32(R));
            textBox2.Text = Convert.ToString(Convert.ToInt32(G));
            textBox3.Text = Convert.ToString(Convert.ToInt32(B));
            FromRGB(1);
        }

        private void FromXYZ()
        {
            String text;
            if (textBox4.Text.Length == 0)
                text = "0";
            else
                text = textBox4.Text;
            double X = Convert.ToDouble(text);
            if (textBox5.Text.Length == 0)
                text = "0";
            else
                text = textBox5.Text;
            double Y = Convert.ToDouble(text);
            if (textBox6.Text.Length == 0)
                text = "0";
            else
                text = textBox6.Text;
            double Z = Convert.ToDouble(text);
            double Rn = (3.2406 * (X / 100.0)) + (-1.5372 * (Y / 100.0)) + (-0.4986 * (Z / 100.0));
            double Gn = (-0.9689 * (X / 100.0)) + (1.8758 * (Y / 100.0)) + (0.0415 * (Z / 100.0));
            double Bn = (0.0557 * (X / 100.0)) + (-0.2040 * (Y / 100.0)) + (1.0570 * (Z / 100.0));
            double R = fToRGB(Rn) * 255;
            double G = fToRGB(Gn) * 255;
            double B = fToRGB(Bn) * 255;
            textBox1.Text = Convert.ToString(Convert.ToInt32(R));
            textBox2.Text = Convert.ToString(Convert.ToInt32(G));
            textBox3.Text = Convert.ToString(Convert.ToInt32(B));
            FromRGB(-1);
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.textBox2.Text = this.trackBar2.Value.ToString();
            FromRGB(0);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.textBox3.Text = this.trackBar3.Value.ToString();
            FromRGB(0);
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox2.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            if (value < 0)
                value = 0;
            if (value > trackBar2.Maximum)
                value = trackBar2.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar2.Value = int_value;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox3.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            if (value < 0)
                value = 0;
            if (value > trackBar3.Maximum)
                value = trackBar3.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar3.Value = int_value;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox4.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar4.Maximum)
                value = trackBar4.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar4.Value = int_value;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox5.Text);
            }
            catch (System.FormatException exp) { value = 0; }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar5.Maximum)
                value = trackBar5.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar5.Value = int_value;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox6.Text);
            }
            catch (System.FormatException exp) { value = 0; }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar6.Maximum)
                value = trackBar6.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar6.Value = int_value;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox7.Text);
            }
            catch (System.FormatException exp) { value = 0; }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar7.Maximum)
                value = trackBar7.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar7.Value = int_value;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox8.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar8.Maximum)
                value = trackBar8.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar8.Value = int_value;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox9.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar9.Maximum)
                value = trackBar9.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar9.Value = int_value;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Convert.ToDouble(textBox10.Text);
            }
            catch (System.FormatException exp)
            {
                value = 0;
            }
            value *= 1000.0;
            if (value < 0)
                value = 0;
            if (value > trackBar10.Maximum)
                value = trackBar10.Maximum;
            int int_value = Convert.ToInt32(value);
            trackBar10.Value = int_value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar4.Value;
            value /= 1000.0;
            this.textBox4.Text = value.ToString();
            FromXYZ();
     
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar5.Value;
            value /= 1000.0;
            this.textBox5.Text = value.ToString();
            FromXYZ();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar6.Value;
            value /= 1000.0;
            this.textBox6.Text = value.ToString();
            FromXYZ();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar7.Value;
            value /= 1000.0;
            this.textBox7.Text = value.ToString();
            FromCMYK();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar8.Value;
            value /= 1000.0;
            this.textBox8.Text = value.ToString();
            FromCMYK(); 
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar9.Value;
            value /= 1000.0;
            this.textBox9.Text = value.ToString();
            FromCMYK();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            double value = (double)this.trackBar10.Value;
            value /= 1000.0;
            this.textBox10.Text = value.ToString();
            FromCMYK();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox1, trackBar1, 0.0, 255.0, 1);
            FromRGB(0);     //changes CMYK and XYZ from RGB
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox1, trackBar1, 0.0, 255.0, 1);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox2, trackBar2, 0.0, 255.0, 1);
            FromRGB(0);     //changes CMYK and XYZ from RGB
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox3, trackBar3, 0.0, 255.0, 1);
            FromRGB(0);     //changes CMYK and XYZ from RGB
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox10, trackBar10, 0.0, 1000.0, 1000);
            FromCMYK();
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox4, trackBar4, 0.0, 95047.0, 1000);
            FromXYZ();
        }
        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox5, trackBar5, 0.0, 100000.0, 1000);
            FromXYZ();
        }
        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox6, trackBar6, 0.0, 108883.0, 1000);
            FromXYZ();
        }
        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox7, trackBar7, 0.0, 1000.0, 1000);
            FromCMYK();
        }
        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox8, trackBar8, 0.0, 1000.0, 1000);
            FromCMYK();
        }
        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox9, trackBar9, 0.0, 1000.0, 1000);
            FromCMYK();
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox10, trackBar10, 0.0, 1000.0, 1000);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox2, trackBar2, 0.0, 255.0, 1);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox3, trackBar3, 0.0, 255.0, 1);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox9, trackBar9, 0.0, 1000.0, 1000);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox8, trackBar8, 0.0, 1000.0, 1000);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox7, trackBar7, 0.0, 1000.0, 1000);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox4, trackBar4, 0.0, 95047.0, 1000);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox5, trackBar5, 0.0, 100000.0, 1000);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            ValueTranformer.Transform(textBox6, trackBar6, 0.0, 108883.0, 1000);
        }
    }

    public class ValueTranformer
    {
        public ValueTranformer() { }

        public static void Transform(System.Windows.Forms.TextBox textBox, 
                              System.Windows.Forms.TrackBar trackBar, double min, double max, int coef)
        {
            string text = textBox.Text;
            if (text.Length == 0)
            {
                trackBar.Value = 0;
                textBox.Text = "0";
                return;
            }
            else if (text[0] == '-')
            {
                text = text.Remove(0, 1);
            }
            else
            {
                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
                if (text[0] == ',')
                    text = text.Remove(0, 1);
            }
            double value;
           // try
            //{
                value = Convert.ToDouble(text) * coef;
            /*  }
              catch(System.FormatException e)
              {
                  textBox.Text = "0";
                  text = "0";
                  value = Convert.ToDouble(text) * coef;

              }*/
            if (value < 0)
                value = -value;

            while (value > max)
            {
                text = text.Remove(text.Length - 1, 1);

                value /= 10;
            }
            textBox.Text = text;
            
        }
    }
}
