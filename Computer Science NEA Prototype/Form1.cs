using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Point3 = Vec3;

//NOTES:

//WHEN MAKING A POINT IN SPACE, USE AN ALIAS I.E. using Point3 = Vec3;
//THIS IS SO WE DON'T GET VECTORS AND POINTS CONFUSED

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
        private System.Windows.Forms.Label FOVLabel;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.ProgressBar RenderProgress;
        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
            BackColor = ColorTranslator.FromHtml("#181f1a");
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NEA Prototype UI";
            Load += new EventHandler(Form1_Load);
        }

        private void InitializeComponent2()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;

            #region Render Scene Button
            Render = new System.Windows.Forms.Button();
            Render.Location = new System.Drawing.Point(850, 460);
            Render.Size = new System.Drawing.Size(280, 34);
            Render.TabIndex = 4;
            Render.Text = "Render Scene";
            Render.FlatStyle = FlatStyle.Flat;
            Render.FlatAppearance.BorderColor = Color.White;
            Render.FlatAppearance.BorderSize = 1;
            Render.Font = new Font("Bahnschrift SemiBold", 11);
            Render.BackColor = System.Drawing.Color.White;
            Render.ForeColor = ColorTranslator.FromHtml("#2A3A50");
            Render.Click += new System.EventHandler(this.Render_Click);
            #endregion

            #region Render Test Image Button
            testButton = new System.Windows.Forms.Button();
            testButton.Location = new System.Drawing.Point(850, 494);
            testButton.Size = new System.Drawing.Size(280, 34);
            testButton.TabIndex = 4;
            testButton.Text = "Render Test Image";
            testButton.FlatStyle = FlatStyle.Flat;
            testButton.FlatAppearance.BorderColor = Color.White;
            testButton.FlatAppearance.BorderSize = 1;
            testButton.Font = new Font("Bahnschrift SemiBold", 11);
            testButton.BackColor = System.Drawing.Color.White;
            testButton.ForeColor = ColorTranslator.FromHtml("#2A3A50");
            testButton.Click += new System.EventHandler(this.RenderTestImage);
            #endregion

            #region FOV Controls
            FOVSlider = new System.Windows.Forms.TrackBar();
            FOVSlider.Location = new System.Drawing.Point(850, 400);
            FOVSlider.Name = "FOVSlider";
            FOVSlider.Size = new System.Drawing.Size(250, 50);
            FOVSlider.Minimum = 10;
            FOVSlider.Maximum = 150;
            FOVSlider.Value = 70;
            FOVSlider.Scroll += new System.EventHandler(FOVSlider_Changed);

            FOVLabel = new System.Windows.Forms.Label();
            FOVLabel.Location = new System.Drawing.Point(850, 380);
            FOVLabel.Font = new Font("Bahnschrift SemiBold", 7);
            FOVLabel.ForeColor = Color.White;
            FOVLabel.Text = $"Current FOV: {FOVSlider.Value}";
            #endregion

            #region Image Depth Controls
            depthSlider = new System.Windows.Forms.TrackBar();
            depthSlider.Location = new System.Drawing.Point(850, 320);
            depthSlider.Name = "depthSlider";
            depthSlider.Size = new System.Drawing.Size(250, 50);
            depthSlider.Minimum = 1;
            depthSlider.Maximum = 10;
            depthSlider.Value = 3;
            depthSlider.Scroll += new System.EventHandler(depthSlider_Changed);

            depthLabel = new System.Windows.Forms.Label();
            depthLabel.Location = new System.Drawing.Point(850, 300);
            depthSlider.AutoSize = true;
            depthLabel.Font = new Font("Bahnschrift SemiBold", 7);
            depthLabel.ForeColor = Color.White;
            depthLabel.Text = $"Image Depth: {depthSlider.Value}";
            #endregion

            Graphics g = CreateGraphics();
            Bitmap bmp = new Bitmap(100, 100, g);

            PictureBox1 = new System.Windows.Forms.PictureBox();
            PictureBox1.Location = new System.Drawing.Point(10, 10);
            PictureBox1.Size = new System.Drawing.Size(800, 450);
            PictureBox1.Image = bmp;

            Controls.AddRange(new System.Windows.Forms.Control[] { Render,
                testButton,
                PictureBox1,
                RenderProgress,
                depthLabel,
                depthSlider,
                FOVLabel,
                FOVSlider});
        }

        private void Render_Click(object sender, EventArgs e)
        {
            double aspect_ratio = 16 / 9;
            int image_width = 400;
            int image_height = Convert.ToInt32(image_width / aspect_ratio); //Add a check in case height is ever less than 1

            #region Progress Bar
            RenderProgress = new System.Windows.Forms.ProgressBar();
            RenderProgress.Visible = true;
            RenderProgress.Minimum = 1;
            RenderProgress.Maximum = image_height;
            RenderProgress.Value = 1;
            RenderProgress.Step = 1;
            RenderProgress.Location = new System.Drawing.Point(850, 494);
            RenderProgress.Size = new System.Drawing.Size(280, 34);

            testButton.Visible = false;
            Controls.Add(RenderProgress);
            #endregion

            #region Camera Setup
            double focal_length = 1;
            Point3 camera_centre = new Point3(0, 0, 0);
            double viewport_height = 2.0;
            double viewport_width = viewport_width = viewport_height * (Convert.ToDouble(image_width) / image_height);
            #endregion

            //horizontal and vertical vectors for viewport
            Vec3 viewport_a = new Vec3(viewport_width, 0, 0);
            Vec3 viewport_b = new Vec3(0, -viewport_height, 0);

            //calculate the vectors that represent the change between each pixel of the viewport
            Vec3 pixel_d_a = viewport_a.Scalar_Divide(image_width);
            Vec3 pixel_d_b = viewport_b.Scalar_Divide(image_width);

            // Calculate the location of the upper left pixel.
            Point3 viewport_upper_left = camera_centre.Subtract(new Vec3(0, 0, focal_length).Subtract(viewport_a.Scalar_Divide(2).Subtract(viewport_b.Scalar_Divide(2))));
            Point3 pixel0_loc = viewport_upper_left.Add((pixel_d_a.Add(pixel_d_b).Scalar_Multiply(0.5)));

            //RENDER!!!!!!
            for (int j = 0; j < image_height; j++)
            {
                for (int i = 0; i < image_width; i++)
                {
                    Point3 pixel_center = pixel0_loc.Add(pixel_d_a.Scalar_Multiply(i)).Add(pixel_d_b.Scalar_Multiply(j));
                    Vec3 ray_direction = pixel_center.Subtract(camera_centre);
                    Ray ray = new Ray(camera_centre, ray_direction);

                    //color pixel_color = ray_color(r);
                    //write_color(std::cout, pixel_color);
                }
                RenderProgress.PerformStep();
            }




            //Progress Bar End
            //PictureBox1.Image = bmp;
            RenderProgress.Visible = false;
            testButton.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RenderTestImage(object sender,  EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(800, 450, g);

            #region Progress Bar
            RenderProgress = new System.Windows.Forms.ProgressBar();
            RenderProgress.Visible = true;
            RenderProgress.Minimum = 1;
            RenderProgress.Maximum = bmp.Height;
            RenderProgress.Value = 1;
            RenderProgress.Step = 1;
            RenderProgress.Location = new System.Drawing.Point(850, 494);
            RenderProgress.Size = new System.Drawing.Size(280, 34);

            testButton.Visible = false;
            Controls.Add(RenderProgress);
            #endregion

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(255 - Convert.ToInt32(j / 4), Convert.ToInt32(i / 2), Convert.ToInt32(j / 4)));
                }
                RenderProgress.PerformStep();
            }
            PictureBox1.Image = bmp;
            RenderProgress.Visible = false;
            testButton.Visible = true;
        }

        private void FOVSlider_Changed(object sender, EventArgs e)
        {
            FOVLabel.Text = $"Current FOV: {FOVSlider.Value}";
        }

        private void depthSlider_Changed(object sender, EventArgs e)
        {
            depthLabel.Text = $"Image Depth: {depthSlider.Value}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("You pressed " + e.KeyCode);
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                Close();
            }
            //"Trace rays" - Fran Irving Garey, June 20 2025
        }
    }
}