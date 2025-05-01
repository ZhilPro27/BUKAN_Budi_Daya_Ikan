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

        }

        private void Food_Generator(object sender, EventArgs e)
        {
            Random r = new Random();

            int x = r.Next(20, 850);
            int y = r.Next(50, 400);
            Food f = new Food(x, y);
            Controls.Add(f);

            core.Foodlist.Add(f);
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

                        AddScore();
                    }
                }
            }
        }

        void AddScore()
        {
            core.score += 1;
            lbl_score.Text = "Score = " + core.score.ToString();
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
    }
}
