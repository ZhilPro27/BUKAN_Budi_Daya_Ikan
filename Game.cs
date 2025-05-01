using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUKAN_Budi_Daya_Ikan_.Game_Object;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class Game: Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";
        public Game()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            timerEnemy.Interval = core.random.Next(30000, 60001);
        }

        private void Food_Generator(object sender, EventArgs e)
        {
            int x = core.random.Next(50, 850);
            int y = core.random.Next(50, 400);
            Food f = new Food(x, y);
            Controls.Add(f);

            core.Foodlist.Add(f);
        }

        private void Enemy_Generator(object sender, EventArgs e)
        {
            int x = core.random.Next(50, 850);
            int y = core.random.Next(50, 400);
            Enemy enemy = new Enemy();
            enemy.Location = new Point(x, y);

            Controls.Add(enemy);
            core.Enemylist.Add(enemy);
        }

        private void Update(object sender, EventArgs e)
        {
            List<Food> foodToRemove = new List<Food>();
            foodToRemove.AddRange(core.Foodlist);
            foreach (Food food in foodToRemove)
            {
                foreach (Fish fish in Controls.OfType<Fish>())
                {
                    if (fish.Bounds.IntersectsWith(food.Bounds))
                    {
                        Controls.Remove(food);
                        core.Foodlist.Remove(food);

                        core.AddScore();
                        lbl_score.Text = "Score = " + core.score;
                    }
                }
            }

            List<Fish> fishToRemove = new List<Fish>(core.Fishlist);
            foreach (Fish fish in fishToRemove)
            {
                foreach (Enemy enemy in Controls.OfType<Enemy>())
                {
                    if (enemy.Bounds.IntersectsWith(fish.Bounds))
                    {
                        Controls.Remove(fish);
                        core.Fishlist.Remove(fish);

                        CheckGameOver();
                    }
                }
            }

            lbl_money.Text = "Money = " + core.money;
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Score (Score, playerName) VALUES (@score, @palyerName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@score", core.score);
                    command.Parameters.AddWithValue("@palyerName", core.playerName);
                    command.ExecuteNonQuery();
                    connection.Close();
                    core.score = 0;
                    this.Close();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_addFish_click(object sender, EventArgs e)
        {
            int hargaIkan = 5;
            if (core.money >= hargaIkan)
            {
                core.money -= hargaIkan;
                lbl_money.Text = "Money = " + core.money;

                int x = core.random.Next(50, 850);
                int y = core.random.Next(50, 400);

                Fish newFish = new Fish();
                newFish.Location = new Point(x, y);

                this.Controls.Add(newFish);
                core.Fishlist.Add(newFish);
            }
            else 
            { 
                MessageBox.Show("Uang tidak cukup untuk membeli ikan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void CheckGameOver()
        {
            if (core.Fishlist.Count == 0)
            {
                MessageBox.Show("Game Over! Semua ikan telah mati.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                Form1 mainMenu = new Form1();
                mainMenu.Show();
            }
        }

    }
}
