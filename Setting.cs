﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_.Resources
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Zhilal zhilal = new Zhilal();
            zhilal.Show();
            this.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormPembelianIkan formPembelianIkan = new FormPembelianIkan();
            formPembelianIkan.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Jaidil j = new Jaidil();
            j.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dimas dimas = new Dimas();
            dimas.Show();
            this.Close();
        }
    }
}
