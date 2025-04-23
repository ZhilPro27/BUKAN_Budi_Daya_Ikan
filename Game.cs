using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUKAN_Budi_Daya_Ikan_.Game_Object;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class Game: Form
    {
        public Game()
        {
            InitializeComponent();
        }

        

        private void Food_Generator(object sender, EventArgs e)
        {
            Random r = new Random();

            int x = r.Next(20, 300);
            int y = r.Next(20, 300);
            Food f = new Food(x, y);
            Controls.Add(f);

            core.Foodlist.Add(f);
        }
    }
}
