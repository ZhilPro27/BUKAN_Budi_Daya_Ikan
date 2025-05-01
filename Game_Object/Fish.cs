using System;
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
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private int speed = 4;
        private Random random = new Random();
        private Timer randomMoveTimer;
        private Point randomTarget;
        private List<Image> fishFramesRight;
        private List<Image> fishFramesLeft;
        private Timer animationTimer;
        private int currentFrame = 0;
        private bool movingRight;

        public Fish()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.UpdateStyles();

            fishFramesRight = new List<Image>()
            {
                Properties.Resources.FishOrange_Right1,
                Properties.Resources.FishOrange_Right2,
                Properties.Resources.FishOrange_Right3,
                Properties.Resources.FishOrange_Right4,
                Properties.Resources.FishOrange_Right5,
                Properties.Resources.FishOrange_Right6,
                Properties.Resources.FishOrange_Right7,
                Properties.Resources.FishOrange_Right8,
            };

            fishFramesLeft = new List<Image>()
            {
                Properties.Resources.FishOrange_Left1,
                Properties.Resources.FishOrange_Left2,
                Properties.Resources.FishOrange_Left3,
                Properties.Resources.FishOrange_Left4,
                Properties.Resources.FishOrange_Left5,
                Properties.Resources.FishOrange_Left6,
                Properties.Resources.FishOrange_Left7,
                Properties.Resources.FishOrange_Left8,
            };
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.randomMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.Update);
            // 
            // randomMoveTimer
            // 
            this.randomMoveTimer.Enabled = true;
            this.randomMoveTimer.Tick += new System.EventHandler(this.RandomMoveTimer_Tick);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 200;
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Fish
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Fish";
            this.Size = new System.Drawing.Size(72, 55);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Update(object sender, EventArgs e)
        {
            Food f = getClosest();

            if (f != null)
            {
                MoveFish(f.Location.X, f.Location.Y, speed);
            }
            else
            {
                MoveFish(randomTarget.X, randomTarget.Y, (speed - 3));
            }
        }

        public void MoveFish(int x, int y, float speed)
        {
            Point pt = Location;

            float tx = x - pt.X;
            float ty = y - pt.Y;
            float lenght = (float)Math.Sqrt(tx * tx + ty * ty);

            if (tx > 0)
                movingRight = true;
            else if (tx < 0)
                movingRight = false;

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


        private Food getClosest()
        {
            Food f = null;
            int distClosest = 300;
            
            if(core.Foodlist.Count > 0)
            {
                foreach(var item in core.Foodlist)
                {
                    float tx = item.Location.X - Location.X;
                    float ty = item.Location.Y - Location.Y;

                    int length = (int)Math.Sqrt(tx * tx + ty * ty);

                    if (length < distClosest)
                    {
                        distClosest = length;
                        f = item;
                    }
                }
            }
            return f;
        }

        private void RandomMoveTimer_Tick(object sender, EventArgs e)
        {
            int randomX = random.Next(0, 500);
            int randomY = random.Next(0, 500);
            randomTarget = new Point(randomX, randomY);

            randomMoveTimer.Interval = random.Next(3000, 5001);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= fishFramesRight.Count)
                currentFrame = 0;

            if (movingRight)
            {
                pictureBox1.Image = fishFramesRight[currentFrame];
            }
            else
            {
                pictureBox1.Image = fishFramesLeft[currentFrame];
            }
        }
    }
}
