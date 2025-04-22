using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    public class Food  : UserControl
    {
        private PictureBox pic_food;

        public Food(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Food));
            this.pic_food = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_food)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_food
            // 
            this.pic_food.Image = ((System.Drawing.Image)(resources.GetObject("pic_food.Image")));
            this.pic_food.Location = new System.Drawing.Point(0, 0);
            this.pic_food.Name = "pic_food";
            this.pic_food.Size = new System.Drawing.Size(30, 30);
            this.pic_food.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_food.TabIndex = 0;
            this.pic_food.TabStop = false;
            // 
            // Food
            // 
            this.Controls.Add(this.pic_food);
            this.Name = "Food";
            this.Size = new System.Drawing.Size(32, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pic_food)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
