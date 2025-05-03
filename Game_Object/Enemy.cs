using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    public class Enemy : UserControl
    {
        private PictureBox img_Enemy;
        private List<Image> enemyFramesRight;
        private List<Image> enemyFramesLeft;
        private int Speed = 5;
        private int currentFrame = 0;
        private Timer tmr_Update;
        private System.ComponentModel.IContainer components;
        private Timer AnimationTimer;
        private bool MovingRight = true;
        private int hitCount = 0;
        private int maxHits = 5;

        public Enemy()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.UpdateStyles();

            enemyFramesRight = new List<Image>()
            { 
                Properties.Resources.EnemyShark_Right1,
                Properties.Resources.EnemyShark_Right2,
                Properties.Resources.EnemyShark_Right3,
                Properties.Resources.EnemyShark_Right4,
                Properties.Resources.EnemyShark_Right5,
                Properties.Resources.EnemyShark_Right6,
                Properties.Resources.EnemyShark_Right7,
                Properties.Resources.EnemyShark_Right8,
            };

            enemyFramesLeft = new List<Image>() 
            {
                Properties.Resources.EnemyShark_Left1,
                Properties.Resources.EnemyShark_Left2,
                Properties.Resources.EnemyShark_Left3,
                Properties.Resources.EnemyShark_Left4,
                Properties.Resources.EnemyShark_Left5,
                Properties.Resources.EnemyShark_Left6,
                Properties.Resources.EnemyShark_Left7,
                Properties.Resources.EnemyShark_Left8,
            };

            img_Enemy.Click += img_Enemy_Click;
            this.Click += Enemy_Click;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.img_Enemy = new System.Windows.Forms.PictureBox();
            this.tmr_Update = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.img_Enemy)).BeginInit();
            this.SuspendLayout();
            // 
            // img_Enemy
            // 
            this.img_Enemy.BackColor = System.Drawing.Color.Transparent;
            this.img_Enemy.Location = new System.Drawing.Point(0, 0);
            this.img_Enemy.Name = "img_Enemy";
            this.img_Enemy.Size = new System.Drawing.Size(100, 50);
            this.img_Enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Enemy.TabIndex = 0;
            this.img_Enemy.TabStop = false;
            // 
            // tmr_Update
            // 
            this.tmr_Update.Enabled = true;
            this.tmr_Update.Interval = 33;
            this.tmr_Update.Tick += new System.EventHandler(this.Update);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Enabled = true;
            this.AnimationTimer.Interval = 200;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // Enemy
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.img_Enemy);
            this.Name = "Enemy";
            this.Size = new System.Drawing.Size(100, 50);
            ((System.ComponentModel.ISupportInitialize)(this.img_Enemy)).EndInit();
            this.ResumeLayout(false);

        }

        public void MoveEnemy(int x, int y, float speed)
        {
            Point pt = Location;

            float tx = x - pt.X;
            float ty = y - pt.Y;
            float lenght = (float)Math.Sqrt(tx * tx + ty * ty);

            if (tx > 0)
                MovingRight = true;
            else if (tx < 0)
                MovingRight = false;

            if (lenght > Speed)
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

        private Fish getClosest()
        {
            Fish f = null;
            int distClosest = 10000;

            if (core.Fishlist.Count > 0)
            {
                foreach (var item in core.Fishlist)
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

        private void Update(object sender, EventArgs e)
        {
            Fish f = getClosest();

            if (f != null)
            {
                MoveEnemy(f.Location.X, f.Location.Y, Speed);
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= enemyFramesRight.Count)
                currentFrame = 0;

            if (MovingRight)
            {
                img_Enemy.Image = enemyFramesRight[currentFrame];
            }
            else
            {
                img_Enemy.Image = enemyFramesLeft[currentFrame];
            }
        }

        private void Enemy_Click(object sender, EventArgs e) 
        { 
            RegisterHit(); 
        }

        private void img_Enemy_Click(object sender, EventArgs e) 
        { 
            RegisterHit(); 
        }

        private void RegisterHit()
        {
            hitCount++;

            SoundPlayer hitSound = new SoundPlayer();
            hitSound.SoundLocation = @"D:\\Kuliah\\Semester 4\\Pengembangan Aplikasi Basis Data\\BUKAN(Budi Daya Ikan)\\Resources\\Audio\\Hit\\Hit.wav";
            hitSound.Play();

            if (hitCount >= maxHits)
            {
                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                core.Enemylist.Remove(this);
                core.AddMoney();
            }
        }

    }
}
