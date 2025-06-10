using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class FormPembelianIkan : Form
    {
        static string connectionString = "Data Source=DESKTOP-P6SA9AD;Initial Catalog=BUKAN_db;Integrated Security=True";

        // Inisialisasi cache dan kebijakan kadaluarsa
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "FishTypeData";

        public FormPembelianIkan()
        {
            InitializeComponent();
        }

        private void FormPembelianIkan_Load(object sender, EventArgs e)
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
        IF OBJECT_ID('dbo.FishType','U') IS NOT NULL
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_FishType_TypeName')
                CREATE NONCLUSTERED INDEX idx_FishType_TypeName ON dbo.FishType(TypeName);
        END";

                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            DataTable dt;
            if (_cache.Contains(CacheKey))
            {
                dt = _cache.Get(CacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT FishTypeID AS [FishTypeID], TypeName, Cost, Speed, AnimationPrefix FROM dbo.FishType;";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }

            dgvFishTypes.AutoGenerateColumns = true; // Sesuaikan nama sesuai UI
            dgvFishTypes.DataSource = dt;
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Harap isi TypeName!", "Peringatan");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    using (var cmd = new SqlCommand("AddFishType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;

                        // Hapus parameter FishTypeID karena ini kolom identity
                        cmd.Parameters.AddWithValue("@TypeName", txtTypeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Cost", txtCost.Text.Trim());
                        cmd.Parameters.AddWithValue("@Speed", txtSpeed.Text.Trim());
                        cmd.Parameters.AddWithValue("@AnimationPrefix", txtAnimationPrefix.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    // Commit transaksi jika berhasil
                    transaction.Commit();
                    _cache.Remove(CacheKey);
                    MessageBox.Show("Data berhasil ditambahkan!", "Sukses");
                    LoadData(); // Reload data setelah insert
                    ClearForm();
                }
                catch (Exception ex)
                {
                    // Rollback transaksi jika terjadi error
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan");
                }
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            if (dgvFishTypes.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var fishTypeID = dgvFishTypes.SelectedRows[0].Cells["FishTypeID"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlTransaction transaction = null;
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        using (var cmd = new SqlCommand("DeleteFishType", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("@FishTypeID", fishTypeID);

                            cmd.ExecuteNonQuery();
                        }

                        // Commit transaksi jika berhasil
                        transaction.Commit();
                        _cache.Remove(CacheKey);
                        MessageBox.Show("Data berhasil dihapus!", "Sukses");
                        ClearForm();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan");
                }
            }
        }

        private void BtnUbah_Click(object sender, EventArgs e)
        {
            if (dgvFishTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    using (var cmd = new SqlCommand("UpdateFishType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;

                        // Menghapus parameter FishTypeID karena ini kolom identity
                        cmd.Parameters.AddWithValue("@FishTypeID", dgvFishTypes.SelectedRows[0].Cells["FishTypeID"].Value);
                        cmd.Parameters.AddWithValue("@TypeName", txtTypeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Cost", txtCost.Text.Trim());
                        cmd.Parameters.AddWithValue("@Speed", txtSpeed.Text.Trim());
                        cmd.Parameters.AddWithValue("@AnimationPrefix", txtAnimationPrefix.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    // Commit transaksi jika berhasil
                    transaction.Commit();
                    _cache.Remove(CacheKey);
                    MessageBox.Show("Data berhasil diperbaharui!", "Sukses");
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PreviewData(openFile.FileName);
                }
            }
        }

        private void PreviewData(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    DataTable dt = new DataTable();

                    // Header kolom
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }

                    // Baris data
                    for (int i = 1; i <= sheet.LastRowNum; i++) // Skip header row
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex++] = cell.ToString();
                        }
                        dt.Rows.Add(newRow);
                    }

                    PreviewPembelianIkan previewForm = new PreviewPembelianIkan(dt);
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT TypeName, Cost, Speed FROM dbo.FishType WHERE TypeName LIKE 'A%'";
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) =>
                {
                    MessageBox.Show(e.Message, "STATISTICS INFO");
                };

                conn.Open();
                var wrappedQuery = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlQuery};
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";

                using (var cmd = new SqlCommand(wrappedQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dgvFishTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvFishTypes.Rows[e.RowIndex];
            txtTypeName.Text = row.Cells[1].Value.ToString() ?? string.Empty;
            txtCost.Text = row.Cells[2].Value.ToString() ?? string.Empty;
            txtSpeed.Text = row.Cells[3].Value.ToString() ?? string.Empty;
            txtAnimationPrefix.Text = row.Cells[4].Value.ToString() ?? string.Empty;
        }

        private void ClearForm()
        {
            txtTypeName.Clear();
            txtCost.Clear();
            txtSpeed.Clear();
            txtAnimationPrefix.Clear();
            dgvFishTypes.ClearSelection();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the data from DataGridView or the DataTable
                DataTable dt = (DataTable)dgvFishTypes.DataSource;

                // Check if data exists
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Create an instance of FormReportFish and pass the data to it
                    FormReportFish reportForm = new FormReportFish(dt);
                    reportForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tidak ada data untuk diekspor.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencoba mengekspor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
