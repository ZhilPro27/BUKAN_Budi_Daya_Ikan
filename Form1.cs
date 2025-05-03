using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class Form1: Form
    {
        public static WMPLib.WindowsMediaPlayer Backsound = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            this.DoubleBuffered = true;
            this.UpdateStyles();

            InitializeComponent();
            Backsound.URL = @"D:\Kuliah\Semester 4\Pengembangan Aplikasi Basis Data\BUKAN(Budi Daya Ikan)\Resources\Audio\Backsound\Backsound.mp3";
            Backsound.controls.play();
            Backsound.settings.setMode("loop", true);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void btn_highscore_Click(object sender, EventArgs e)
        {
            Highscore highscore = new Highscore();
            highscore.Show();
            this.Hide();
        }

        private void btn_exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
