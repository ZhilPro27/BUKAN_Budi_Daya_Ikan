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
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class Jaidil : Form
    {
        private string connectionString = "Data Source=JAIDIL-RACHMAD\\JAIDIL;Initial Catalog=TesSp;Integrated Security=True";

        public Jaidil()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadData();
            EnsureIndexes();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TypeName, Health, Speed, RewardMoney, AnimationPrefix FROM EnemyType";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEnemyType.AutoGenerateColumns = true;
                    dgvEnemyType.DataSource = dt;

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.TesSp','U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='Idx_EnemyType_RewardMoney')
                            CREATE CLUSTERED INDEX Idx_EnemyType_RewardMoney ON dbo.TesSp(RewardMoney);
                    END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ClearForm()
        {
            txtTypeName.Clear();
            txtHealth.Clear();
            txtSpeed.Clear();
            txtRewardMoney.Clear();
            txtAnimationPrefix.Clear();

            txtTypeName.Focus();
        }

        private void BtnTambah(object sender, EventArgs e)
        {
            string typeName = (txtTypeName.Text);
            int health = int.Parse(txtHealth.Text);
            int speed = int.Parse(txtSpeed.Text);
            int rewardMoney = int.Parse(txtRewardMoney.Text);
            string animationPrefix = (txtAnimationPrefix.Text);

            // Validasi
            if (health <= 0 || speed <= 0 || rewardMoney <= 0)
            {
                MessageBox.Show("Health, Speed, dan Reward Money harus lebih dari 0.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek koneksi dan duplikasi TypeName
            string connectionString = "Data Source=JAIDIL-RACHMAD\\JAIDIL;Initial Catalog=TesSp;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cek apakah TypeName sudah ada
                string cekQuery = "SELECT COUNT(*) FROM EnemyType WHERE TypeName = @TypeName";
                using (SqlCommand cekCmd = new SqlCommand(cekQuery, conn))
                {
                    cekCmd.Parameters.AddWithValue("@TypeName", typeName);
                    int count = (int)cekCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("TypeName sudah digunakan. Masukkan nama lain.", "Duplikasi TypeName", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Panggil stored procedure AddEnemy
                using (SqlCommand cmd = new SqlCommand("AddEnemy", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeName", typeName);
                    cmd.Parameters.AddWithValue("@Health", health);
                    cmd.Parameters.AddWithValue("@Speed", speed);
                    cmd.Parameters.AddWithValue("@RewardMoney", rewardMoney);
                    cmd.Parameters.AddWithValue("@AnimationPrefix", animationPrefix);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data musuh berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Fungsi untuk mengubah data (UPDATE)
        private void BtnUbah(object sender, EventArgs e)
        {
            if (dgvEnemyType.SelectedRows.Count > 0)
            {
                try
                {
                    // Validasi input kosong
                    if (string.IsNullOrWhiteSpace(txtTypeName.Text) ||
                        string.IsNullOrWhiteSpace(txtHealth.Text) ||
                        string.IsNullOrWhiteSpace(txtSpeed.Text) ||
                        string.IsNullOrWhiteSpace(txtRewardMoney.Text) ||
                        string.IsNullOrWhiteSpace(txtAnimationPrefix.Text))
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Konversi dan validasi nilai numerik
                    int health = Convert.ToInt32(txtHealth.Text.Trim());
                    int speed = Convert.ToInt32(txtSpeed.Text.Trim());
                    int rewardMoney = Convert.ToInt32(txtRewardMoney.Text.Trim());

                    if (health <= 0 || speed <= 0 || rewardMoney <= 0)
                    {
                        MessageBox.Show("Health, Speed, dan Reward Money harus lebih dari 0!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateEnemyType", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Menambahkan parameter untuk stored procedure
                            cmd.Parameters.AddWithValue("@TypeName", txtTypeName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Health", health);
                            cmd.Parameters.AddWithValue("@Speed", speed);
                            cmd.Parameters.AddWithValue("@RewardMoney", rewardMoney);
                            cmd.Parameters.AddWithValue("@AnimationPrefix", txtAnimationPrefix.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();   // Memuat ulang data dari database
                                ClearForm();  // Membersihkan input form
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan atau gagal diperbarui!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Health, Speed, dan Reward Money harus berupa angka yang valid!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        // Fungsi untuk menghapus data (DELETE)
        private void BtnHapus(object sender, EventArgs e)
        {
            if (dgvEnemyType.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string id = dgvEnemyType.SelectedRows[0].Cells["EnemyTypeID"].Value.ToString();
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("DeleteEnemyType", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@EnemyTypeID", int.Parse(id));

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();     // Refresh data grid
                                    ClearForm();    // Kosongkan form input
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRefresh(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM EnemyType"; // Ambil semua data musuh

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvEnemyType.DataSource = dt;
                    }

                    dgvEnemyType.AutoResizeColumns(); // Menyesuaikan ukuran kolom
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal me-refresh data: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event untuk memilih file dan mempreview data
        private void BtnImport(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewData(filePath); // Tampilkan preview sebelum diimport
            }
        }

        private void AnalyzeQuery(string sqlquery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTIC INFO");
                conn.Open();
                var wrapped = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlquery}  
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method untuk menampilkan preview data di DataGridView
        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs); // Membuka workbook Excel
                    ISheet sheet = workbook.GetSheetAt(0);     // Mendapatkan worksheet pertama
                    DataTable dt = new DataTable();

                    // Membaca header kolom
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }

                    // Membaca sisa data
                    for (int i = 1; i <= sheet.LastRowNum; i++) // Lewati baris header
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex] = cell.ToString();
                            cellIndex++;
                        }
                        dt.Rows.Add(newRow);
                    }

                    // Membuka PreviewForm dan mengirimkan DataTable ke form tersebut
                    Preview_Jaidil P = new Preview_Jaidil(dt);
                    P.ShowDialog(); // Tampilkan PreviewForm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPreview_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEnemyType.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEnemyType.SelectedRows[0];

                // Pastikan kolom tersedia di DataGridView
                txtTypeName.Text = selectedRow.Cells["TypeName"].Value?.ToString();
                txtHealth.Text = selectedRow.Cells["Health"].Value?.ToString();
                txtSpeed.Text = selectedRow.Cells["Speed"].Value?.ToString();
                txtRewardMoney.Text = selectedRow.Cells["RewardMoney"].Value?.ToString();
                txtAnimationPrefix.Text = selectedRow.Cells["AnimationPrefix"].Value?.ToString();
            }
        }

        private void BtnAnalyze(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT * FROM EnemyType WHERE RewardMoney > 100 ORDER BY RewardMoney DESC";
            AnalyzeQuery(heavyQuery);
        }

        private void BtnReport(object sender, EventArgs e)
        {
            Report_Jaidil R = new Report_Jaidil();
            R.Show();
            this.Hide();
        }
    }
}
