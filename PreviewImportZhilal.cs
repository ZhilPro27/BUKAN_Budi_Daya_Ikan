using NPOI.POIFS.Crypt.Dsig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class PreviewImportZhilal : Form
    {
        private string connectionString = "Data source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";
        public PreviewImportZhilal(DataTable data)
        {
            InitializeComponent();
            dgvPreview.DataSource = data;
        }
        

        private void PreviewImportZhilal_Load(object sender, EventArgs e)
        {
            dgvPreview.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ImportDataToDatabase();
            }
        }

        private bool ValidateRow(DataRow row, int rowNumber)
        {
 
            if (string.IsNullOrWhiteSpace(row["playerName"].ToString()))
            {
                MessageBox.Show($"Nama pemain (playerName) di baris {rowNumber} tidak boleh kosong.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(row["FishPurchased"].ToString(), out _) ||
                !int.TryParse(row["EnemiesKilled"].ToString(), out _) ||
                !int.TryParse(row["MoneyEarned"].ToString(), out _) ||
                !int.TryParse(row["FinalScore"].ToString(), out _))
            {
                MessageBox.Show($"Kolom numerik (FishPurchased, EnemiesKilled, dll.) di baris {rowNumber} harus berisi angka.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParse(row["GameStartTime"].ToString(), out DateTime startTime) ||
                !DateTime.TryParse(row["GameEndTime"].ToString(), out DateTime endTime))
            {
                MessageBox.Show($"Format tanggal di baris {rowNumber} tidak valid.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (endTime <= startTime)
            {
                MessageBox.Show($"GameEndTime di baris {rowNumber} harus setelah GameStartTime.", "Kesalahan Logika", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ImportDataToDatabase()
        {
            DataTable dt = (DataTable)dgvPreview.DataSource;
            int rowNumber = 1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!ValidateRow(row, rowNumber))
                        {
                            rowNumber++;
                            continue; 
                        }

                        string query = @"INSERT INTO GameLog 
                               (playerName, GameStartTime, GameEndTime, FishPurchased, EnemiesKilled, MoneyEarned, FinalScore) 
                               VALUES 
                               (@PlayerName, @GameStartTime, @GameEndTime, @FishPurchased, @EnemiesKilled, @MoneyEarned, @FinalScore)";

                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction)) 
                        {
                            cmd.Parameters.AddWithValue("@PlayerName", row["playerName"]);
                            cmd.Parameters.AddWithValue("@GameStartTime", Convert.ToDateTime(row["GameStartTime"]));
                            cmd.Parameters.AddWithValue("@GameEndTime", Convert.ToDateTime(row["GameEndTime"]));
                            cmd.Parameters.AddWithValue("@FishPurchased", Convert.ToInt32(row["FishPurchased"]));
                            cmd.Parameters.AddWithValue("@EnemiesKilled", Convert.ToInt32(row["EnemiesKilled"]));
                            cmd.Parameters.AddWithValue("@MoneyEarned", Convert.ToInt32(row["MoneyEarned"]));
                            cmd.Parameters.AddWithValue("@FinalScore", Convert.ToInt32(row["FinalScore"]));

                            cmd.ExecuteNonQuery();
                        }
                        rowNumber++;
                    }

                    transaction.Commit();
                    MessageBox.Show("Semua data valid berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Terjadi kesalahan, semua impor dibatalkan. Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
