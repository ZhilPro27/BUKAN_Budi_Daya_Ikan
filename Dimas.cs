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
    public partial class Dimas : Form
    {
        static string connectionString = "Data Source=LAPTOP-7EJJKF9V\\RIST;" + "initial Catalog=BUKAN_db;Integrated Security=True";
        public Dimas()
        {
            InitializeComponent();
        }

        private void Dimas_Load(object sender, EventArgs e)
        {   
            EnsureIndexes();
            LoadData();
        }
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.Score', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Score_PlayerName')
                    CREATE NONCLUSTERED INDEX idx_Score_PlayerName ON dbo.Score(playerName);

                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Score_Score')
                    CREATE NONCLUSTERED INDEX idx_Score_Score ON dbo.Score(Score);
                END";

                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void ClearDimas()
        {
            txtPlayer.Clear();
            txtScore.Clear();

            txtPlayer.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Score";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHighscore.AutoGenerateColumns = true;
                    dgvHighscore.DataSource = dt;

                    ClearDimas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvHighscore.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data profil ini? \nSemua data skor dan riwayat game yang terkait juga akan terhapus.", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlTransaction transaction = null;

                        try
                        {
                            conn.Open();
                            transaction = conn.BeginTransaction(); // Memulai transaksi

                            // Ambil playerName dari dgvHighscore
                            string playerName = dgvHighscore.SelectedRows[0].Cells["playerName"].Value.ToString();

                            // Menjalankan stored procedure untuk menghapus data terkait dari tabel Score
                            using (SqlCommand cmd = new SqlCommand("DeleteScore", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@playerName", playerName);
                                cmd.ExecuteNonQuery(); // Menghapus data skor terkait pemain
                            }

                            // Menjalankan stored procedure untuk menghapus data dari tabel Profile
                            using (SqlCommand cmd = new SqlCommand("DeleteProfile", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@playerName", playerName);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    // Jika berhasil menghapus profil, commit transaksi
                                    transaction.Commit();
                                    MessageBox.Show("Data profil berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(); // Muat ulang data ke DataGridView
                                }
                                else
                                {
                                    // Jika gagal menghapus profil, rollback transaksi
                                    transaction.Rollback();
                                    MessageBox.Show("Data profil tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Jika terjadi error, rollback transaksi
                            if (transaction != null)
                            {
                                transaction.Rollback();
                            }

                            MessageBox.Show("Error: " + ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close(); // Pastikan koneksi selalu ditutup
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data profil yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();

            // Debugging opsional: Cek jumlah kolom dan baris
            MessageBox.Show($"Jumlah Kolom: {dgvHighscore.ColumnCount}\nJumlah Baris: {dgvHighscore.RowCount}",
                "Debugging DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvHighscore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHighscore.Rows[e.RowIndex];

                // Isi nilai ke textbox sesuai urutan kolom: Player, Score
                txtPlayer.Text = row.Cells[0].Value?.ToString();
                txtScore.Text = row.Cells[1].Value?.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                if (dgvHighscore.SelectedRows.Count > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("UpdateHighscore", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Menambahkan parameter untuk stored procedure
                                cmd.Parameters.AddWithValue("@PlayerName", txtPlayer.Text.Trim());
                                cmd.Parameters.AddWithValue("@Score", txtScore.Text.Trim());

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(); // Assume LoadData method to refresh data
                                    ClearDimas(); // Clear form after update
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal diperbarui", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Pilih data yang akan diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Subscribe to InfoMessage event to capture the statistics output
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");

                conn.Open();

                // Wrap the query with STATISTICS commands to track performance
                var wrapped = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlQuery}
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";

                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Definisikan query SQL yang ingin dianalisis berdasarkan tabel Score
            var heavyQuery = "SELECT playerName, Score FROM Score WHERE playerName LIKE 'A%';";

            // Panggil fungsi AnalyzeQuery dengan query yang sudah didefinisikan
            AnalyzeQuery(heavyQuery);
        }
    }
}
