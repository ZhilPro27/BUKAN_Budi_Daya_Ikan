﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    public class Fish : UserControl
    {
        private PictureBox pictureBox1;

        public Fish()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fish));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Gatherer
            // 
            this.Controls.Add(this.pictureBox1);
            this.Name = "Fish";
            this.Size = new System.Drawing.Size(77, 63);
            this.Load += new System.EventHandler(this.Gatherer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Gatherer_Load(object sender, EventArgs e)
        {

        }

        public void Move(int x, int y, float speed)
        {
            Point pt = Location;

            float tx = x - pt.X;
            float ty = y - pt.Y;
            float lenght = (float)Math.Sqrt(tx * tx + ty * ty);
            if (lenght > speed)
            {
                pt.X = (int)(pt.X + speed * tx / lenght);
                pt.Y = (int)(pt.Y + speed * ty / lenght);

                Location = new Point(pt.X, pt.Y);
            }
            else
            {
                pt.X = x;
                pt.Y = y;
                Location = new Point(pt.X, pt.Y);
            }
        }
    }
}
