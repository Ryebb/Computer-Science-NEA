using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NEA_prototype_V1._2
{
    public partial class Form1 : Form
    {
        #region references
        private System.Windows.Forms.Button Render;
        private System.Windows.Forms.TrackBar FOV;
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


            this.Render = new System.Windows.Forms.Button();
            this.Render.Location = new System.Drawing.Point(800, 460);
            this.Render.Size = new System.Drawing.Size(280, 34);
            this.Render.TabIndex = 4;
            this.Render.Text = "Render";
            this.Render.FlatStyle = FlatStyle.Flat;
            this.Render.FlatAppearance.BorderColor = Color.White;
            this.Render.FlatAppearance.BorderSize = 1;
            this.Render.Font = new Font("Bahnschrift SemiBold", 11);
            this.Render.BackColor = System.Drawing.Color.White;
            this.Render.ForeColor = ColorTranslator.FromHtml("#2A3A50");
            this.Render.Click += new System.EventHandler(this.Render_Click);

            this.FOV = new System.Windows.Forms.TrackBar();
            this.FOV.Location= new System.Drawing.Point(800, 460);
            this.FOV.Name = "FOV";
            this.FOV.Size = new System.Drawing.Size(100, 50);

            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(100, 100, g);

            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox1.Location = new System.Drawing.Point(10, 10);
            this.PictureBox1.Size = new System.Drawing.Size(800, 450);
            this.PictureBox1.Image = bmp;

            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.Render,
                    this.PictureBox1,
                    this.FOV});
        }

        private void Render_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
