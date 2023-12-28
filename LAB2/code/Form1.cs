using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;


namespace LAB2
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private TableLayoutPanel tablePanel;
        private Button openButton;
        private Button clearButton;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(738, 251);
            this.MinimumSize = new Size(738, 251);
            this.MaximumSize = new Size(738, 251);

            dataGridView1.Text = "Info";
            dataGridView1.RowCount = 1;

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "File name";
            dataGridView1.Columns[1].Name = "Size (px)";
            dataGridView1.Columns[2].Name = "Resolution (dpi)";
            dataGridView1.Columns[3].Name = "Color Depth";
            dataGridView1.Columns[4].Name = "Compression";
            int cellheight = dataGridView1.Right / 5 - 12;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {

                col.Width = cellheight;
            }



        }
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeComponents()
        {


        }

        private void ClearTable(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
        }

        private void OpenFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                ProcessImages(folderDialog.SelectedPath);
            }
        }

        private void ProcessImages(string folderPath)
        {
            string[] allowedExtensions = { ".jpg", ".gif", ".tif", ".bmp", ".png", ".pcx" };
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*").Where(file => allowedExtensions.Any(file.ToLower().EndsWith)).ToArray();
            string[] parameters = new string[5];
            foreach (string filePath in imageFiles)
            {
                Image newImage = Image.FromFile(filePath);
                parameters[0] = Path.GetFileName(filePath);
                parameters[1] = Convert.ToString(newImage.Width) + "x" + Convert.ToString(newImage.Height);
                float res = newImage.VerticalResolution;
                parameters[2] = Convert.ToString(res);
                int pixels = Image.GetPixelFormatSize(newImage.PixelFormat);
                parameters[3] = Convert.ToString(pixels);
                parameters[4] = GetImageCompression(filePath);
                dataGridView1.Rows.Add(parameters);


            }
        }

        private void ProcessImage(string imagePath)
        {
            string[] files = { imagePath };
            string[] allowedExtensions = { ".jpg", ".gif", ".tif", ".bmp", ".png", ".pcx" };
            string[] imageFiles = files.Where(file => allowedExtensions.Any(file.ToLower().EndsWith)).ToArray();
            string[] parameters = new string[5];
            foreach (string filePath in imageFiles)
            {
                Image newImage = Image.FromFile(filePath);
                parameters[0] = Path.GetFileName(filePath);
                parameters[1] = Convert.ToString(newImage.Width) + "x" + Convert.ToString(newImage.Height);
                float res = newImage.VerticalResolution;
                parameters[2] = Convert.ToString(res);
                int pixels = Image.GetPixelFormatSize(newImage.PixelFormat);
                parameters[3] = Convert.ToString(pixels);
                parameters[4] = GetImageCompression(filePath);
                dataGridView1.Rows.Add(parameters);


            }
        }
        private string GetImageCompression(string filePath)
        {
            try
            {
                using (Image image = Image.FromFile(filePath))
                {
                    foreach (PropertyItem prop in image.PropertyItems)
                    {
                        if (prop.Id == 0x0103) // Compression tag
                        {
                            ushort compressionValue = BitConverter.ToUInt16(prop.Value, 0);
                            return Convert.ToString(compressionValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла {filePath}: {ex.Message}");
            }

            return "N/A";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            string path;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderDialog.SelectedPath;
                ProcessImages(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files|*.jpg;*.gif;*.tif;*.bmp;*.png;*.pcx";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string imageName = openFileDialog1.FileName;
            ProcessImage(imageName);
        }

    }
}

        /*
        
    }
}
        */