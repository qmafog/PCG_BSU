namespace LAB4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.vsbCircle = new System.Windows.Forms.VScrollBar();
            this.vsbNaive = new System.Windows.Forms.VScrollBar();
            this.hsbNaive = new System.Windows.Forms.HScrollBar();
            this.hsbCircle = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.bScale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(506, 92);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 279);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(23, 92);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(436, 283);
            this.panel5.TabIndex = 4;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 12;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(29, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "LINE CLIPPING";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(505, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "POLYGON CLIPPING";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 416);
            this.splitter1.TabIndex = 50;
            this.splitter1.TabStop = false;
            // 
            // vsbCircle
            // 
            this.vsbCircle.Location = new System.Drawing.Point(943, 92);
            this.vsbCircle.Maximum = 50;
            this.vsbCircle.Minimum = -50;
            this.vsbCircle.Name = "vsbCircle";
            this.vsbCircle.Size = new System.Drawing.Size(16, 279);
            this.vsbCircle.TabIndex = 51;
            this.vsbCircle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollCircle_Scroll);
            // 
            // vsbNaive
            // 
            this.vsbNaive.Location = new System.Drawing.Point(461, 92);
            this.vsbNaive.Maximum = 50;
            this.vsbNaive.Minimum = -50;
            this.vsbNaive.Name = "vsbNaive";
            this.vsbNaive.Size = new System.Drawing.Size(16, 283);
            this.vsbNaive.TabIndex = 53;
            this.vsbNaive.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbNaive_Scroll);
            // 
            // hsbNaive
            // 
            this.hsbNaive.Location = new System.Drawing.Point(22, 377);
            this.hsbNaive.Maximum = 50;
            this.hsbNaive.Minimum = -50;
            this.hsbNaive.Name = "hsbNaive";
            this.hsbNaive.Size = new System.Drawing.Size(436, 12);
            this.hsbNaive.TabIndex = 58;
            this.hsbNaive.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbNaive_Scroll);
            // 
            // hsbCircle
            // 
            this.hsbCircle.Location = new System.Drawing.Point(505, 374);
            this.hsbCircle.Maximum = 50;
            this.hsbCircle.Minimum = -50;
            this.hsbCircle.Name = "hsbCircle";
            this.hsbCircle.Size = new System.Drawing.Size(436, 12);
            this.hsbCircle.TabIndex = 60;
            this.hsbCircle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollCircle_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(229, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Scale:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(297, 17);
            this.numericUpDown5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown5.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(109, 22);
            this.numericUpDown5.TabIndex = 22;
            this.numericUpDown5.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // bScale
            // 
            this.bScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bScale.Location = new System.Drawing.Point(447, 11);
            this.bScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bScale.Name = "bScale";
            this.bScale.Size = new System.Drawing.Size(159, 34);
            this.bScale.TabIndex = 30;
            this.bScale.Text = "Change scale";
            this.bScale.UseVisualStyleBackColor = true;
            this.bScale.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(977, 416);
            this.Controls.Add(this.hsbCircle);
            this.Controls.Add(this.hsbNaive);
            this.Controls.Add(this.vsbNaive);
            this.Controls.Add(this.vsbCircle);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.bScale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.VScrollBar vsbCircle;
        private System.Windows.Forms.VScrollBar vsbNaive;
        private System.Windows.Forms.HScrollBar hsbNaive;
        private System.Windows.Forms.HScrollBar hsbCircle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Button bScale;
    }
}

