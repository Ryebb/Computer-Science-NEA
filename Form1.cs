using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NEA_prototype_V1._2
{
    public partial class Form1 : Form
    {
        #region references
        private System.Windows.Forms.Button Render;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TrackBar FOVSlider;
        private System.Windows.Forms.TrackBar depthSlider;
        private System.Windows.Forms.PictureBox PictureBox1;
        #endregion

        public Form1()
        {
            this.InitializeComponent();
            this.InitializeComponent2();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "NEA Prototype UI";
            this.Load += new EventHandler(Form1_Load);
        }

        private void InitializeComponent2()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;

            #region Render Scene Button
            this.Render = new System.Windows.Forms.Button();
            this.Render.Location = new System.Drawing.Point(850, 460);
            this.Render.Size = new System.Drawing.Size(280, 34);
            this.Render.TabIndex = 4;
            this.Render.Text = "Render Scene";
            this.Render.FlatStyle = FlatStyle.Flat;
            this.Render.FlatAppearance.BorderColor = Color.White;
            this.Render.FlatAppearance.BorderSize = 1;
            this.Render.Font = new Font("Bahnschrift SemiBold", 11);
            this.Render.BackColor = System.Drawing.Color.White;
            this.Render.ForeColor = ColorTranslator.FromHtml("#2A3A50");
            this.Render.Click += new System.EventHandler(this.Render_Click);
            #endregion

            #region Render Test Image Button
            this.testButton = new System.Windows.Forms.Button();
            this.testButton.Location = new System.Drawing.Point(850, 494);
            this.testButton.Size = new System.Drawing.Size(280, 34);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Render Test Image";
            this.testButton.FlatStyle = FlatStyle.Flat;
            this.testButton.FlatAppearance.BorderColor = Color.White;
            this.testButton.FlatAppearance.BorderSize = 1;
            this.testButton.Font = new Font("Bahnschrift SemiBold", 11);
            this.testButton.BackColor = System.Drawing.Color.White;
            this.testButton.ForeColor = ColorTranslator.FromHtml("#2A3A50");
            this.testButton.Click += new System.EventHandler(this.RenderTestImage);
            #endregion

            #region FOV Controls
            this.FOVSlider = new System.Windows.Forms.TrackBar();
            this.FOVSlider.Location = new System.Drawing.Point(850, 400);
            this.FOVSlider.Name = "FOV";
            this.FOVSlider.Size = new System.Drawing.Size(250, 50);
            this.FOVSlider.Minimum = 10;
            this.FOVSlider.Maximum = 150;
            this.FOVSlider.Value = 70;
            #endregion

            #region Image Depth Controls
            this.depthSlider = new System.Windows.Forms.TrackBar();
            this.depthSlider.Location = new System.Drawing.Point(850, 350);
            this.depthSlider.Name = "Depth";
            this.depthSlider.Size = new System.Drawing.Size(250, 50);
            this.depthSlider.Minimum = 1;
            this.depthSlider.Maximum = 10;
            this.depthSlider.Value = 3;
            #endregion

            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(100, 100, g);

            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox1.Location = new System.Drawing.Point(10, 10);
            this.PictureBox1.Size = new System.Drawing.Size(800, 450);
            this.PictureBox1.Image = bmp;

            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.Render,
                this.testButton,
                this.PictureBox1,
                this.depthSlider,
                this.FOVSlider});
        }

        private void Render_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RenderTestImage(object sender,  EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(800, 450, g);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(j / 2), Convert.ToInt32(i / 4), 255 - Convert.ToInt32(j / 2)));
                }
            }
            this.PictureBox1.Image = bmp;
        }

    }
}
