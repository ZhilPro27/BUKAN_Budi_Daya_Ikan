using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    public class Warning : UserControl
    {
        private PictureBox imgWarning;
        private List<Image> warningFrames;
        private Timer WarningAnimation;
        private System.ComponentModel.IContainer components;
        private int currentFrame = 0;

        public Warning()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.UpdateStyles();

            warningFrames = new List<Image>()
            {
                Properties.Resources.WarningSign01,
                Properties.Resources.WarningSign02,
                Properties.Resources.WarningSign03,
                Properties.Resources.WarningSign04,
                Properties.Resources.WarningSign05,
                Properties.Resources.WarningSign06,
                Properties.Resources.WarningSign07,
                Properties.Resources.WarningSign08,
            };
        }

        private void WarningAnimation_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= warningFrames.Count)
            {
                currentFrame = 0;
            }
            imgWarning.Image = warningFrames[currentFrame];
        }

        public void StopAnimation()
        {
            WarningAnimation.Stop();
            WarningAnimation.Dispose();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgWarning = new System.Windows.Forms.PictureBox();
            this.WarningAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // imgWarning
            // 
            this.imgWarning.BackColor = System.Drawing.Color.Transparent;
            this.imgWarning.Image = global::BUKAN_Budi_Daya_Ikan_.Properties.Resources.WarningSign06;
            this.imgWarning.Location = new System.Drawing.Point(0, 0);
            this.imgWarning.Name = "imgWarning";
            this.imgWarning.Size = new System.Drawing.Size(46, 43);
            this.imgWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgWarning.TabIndex = 0;
            this.imgWarning.TabStop = false;
            // 
            // WarningAnimation
            // 
            this.WarningAnimation.Enabled = true;
            this.WarningAnimation.Tick += new System.EventHandler(this.WarningAnimation_Tick);
            // 
            // Warning
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.imgWarning);
            this.Name = "Warning";
            this.Size = new System.Drawing.Size(45, 45);
            ((System.ComponentModel.ISupportInitialize)(this.imgWarning)).EndInit();
            this.ResumeLayout(false);

        }
    
        
    }
}
