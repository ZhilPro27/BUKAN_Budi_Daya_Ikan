using System;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Caching;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class Zhilal : Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly string _cacheKey = "GameLogData"; 
        private CacheItemPolicy GetCachePolicy()
        {
            return new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
            };
        }

        public Zhilal()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            DataTable dt;
            if (_cache.Contains(_cacheKey))
            {
                dt = _cache.Get(_cacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                try
                {
                    using (var conn = new SqlConnection(connectionString))
                    {
                        var query = "SELECT * FROM GameLog ORDER BY GameStartTime DESC";
                        var da = new SqlDataAdapter(query, conn);
                        da.Fill(dt);
                    }

                    _cache.Add(_cacheKey, dt, GetCachePolicy());
                }
                catch (Exception ex)
                {
                    lbl_Error.Text = "Gagal memuat data dari database: " + ex.Message;
                }
            }
            dgv_GameLog.DataSource = dt;
            clearTextBox();
        }

        private void InvalidateCache()
        {
            if (_cache.Contains(_cacheKey))
            {
                _cache.Remove(_cacheKey);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            loadData();
            EnsureIndexes();
        }

        private void clearTextBox()
        {
            txt_FishPurchased.Clear();
            txt_EnemiesKilled.Clear();
            txt_MoneyEarned.Clear();
            txt_FinalScore.Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dgv_GameLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih data log yang ingin di-update.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedGameLogID = Convert.ToInt32(dgv_GameLog.SelectedRows[0].Cells[0].Value);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (SqlCommand command = new SqlCommand("sp_UpdateGameLog", connection, transaction))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@GameLogID", selectedGameLogID);
                        command.Parameters.AddWithValue("@FishPurchased", Convert.ToInt32(txt_FishPurchased.Text));
                        command.Parameters.AddWithValue("@EnemiesKilled", Convert.ToInt32(txt_EnemiesKilled.Text));
                        command.Parameters.AddWithValue("@MoneyEarned", Convert.ToInt32(txt_MoneyEarned.Text));
                        command.Parameters.AddWithValue("@FinalScore", Convert.ToInt32(txt_FinalScore.Text));
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    lbl_Error.Text="Data log berhasil di-update!";
                    InvalidateCache();
                    loadData();
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception rollbackEx)
                    {
                        lbl_Error.Text = "Error saat melakukan rollback: " + rollbackEx.Message;
                    }
                    lbl_Error.Text = "Terjadi error, perubahan telah dibatalkan. Error: " + ex.Message;
                }
            }
        }

        private void dgv_GameLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_GameLog.Rows[e.RowIndex];
                txt_FishPurchased.Text = row.Cells[4].Value.ToString();
                txt_EnemiesKilled.Text = row.Cells[5].Value.ToString();
                txt_MoneyEarned.Text = row.Cells[6].Value.ToString();
                txt_FinalScore.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            loadData();
            lbl_Error.Text = "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_GameLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih data log yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus log ini secara permanen?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation == DialogResult.No)
            {
                return;
            }

            int selectedGameLogID = Convert.ToInt32(dgv_GameLog.SelectedRows[0].Cells[0].Value);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand("sp_DeleteGameLog", connection, transaction))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@GameLogID", selectedGameLogID);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    lbl_Error.Text = "Data log berhasil dihapus!";
                    InvalidateCache();
                    loadData();
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception rollbackEx)
                    {
                        lbl_Error.Text = "Error saat melakukan rollback: " + rollbackEx.Message;
                    }
                    lbl_Error.Text = "Terjadi error, penghapusan telah dibatalkan. Error: " + ex.Message;
                }
            }
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.BUKAN_db', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_GameLog_Name_Start')
                            CREATE NONCLUSTERED INDEX idx_GameLog_Name_Start ON GameLog (playerName ASC, GameStartTime DESC);
                    END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTIC INFO");
                conn.Open();
                var wrapped = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlQuery};
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;
                ";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_analisis_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT * FROM GameLog WHERE playerName = 'Zhilal' ORDER BY GameStartTime DESC";
            AnalyzeQuery(sqlQuery);
        }

        private void btn_import_Click(object sender, EventArgs e)
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

                    IRow headerRow = sheet.GetRow(0);
                    if (headerRow == null)
                    {
                        lbl_Error.Text = "File Excel tidak valid atau tidak memiliki header.";
                        return;
                    }


                    int columnCount = headerRow.LastCellNum;
                    for (int j = 0; j < columnCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        dt.Columns.Add(cell?.ToString() ?? $"Column{j + 1}");
                    }

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        if (dataRow == null) continue;

                        DataRow newRow = dt.NewRow();
                        for (int cellIndex = 0; cellIndex < columnCount; cellIndex++)
                        {
                            ICell cell = dataRow.GetCell(cellIndex);

                            if (cell != null)
                            {
                                switch (cell.CellType)
                                {
                                    case CellType.Numeric:
                                        if (DateUtil.IsCellDateFormatted(cell))
                                        {
                                            newRow[cellIndex] = cell.DateCellValue;
                                        }
                                        else
                                        {
                                            newRow[cellIndex] = cell.NumericCellValue;
                                        }
                                        break;
                                    case CellType.String:
                                        newRow[cellIndex] = cell.StringCellValue;
                                        break;
                                    case CellType.Boolean:
                                        newRow[cellIndex] = cell.BooleanCellValue;
                                        break;
                                    case CellType.Formula:
                                        try
                                        {
                                            newRow[cellIndex] = cell.NumericCellValue;
                                        }
                                        catch
                                        {
                                            newRow[cellIndex] = cell.StringCellValue;
                                        }
                                        break;
                                    default:
                                        newRow[cellIndex] = DBNull.Value; 
                                        break;
                                }
                            }
                            else
                            {
                                newRow[cellIndex] = DBNull.Value;
                            }
                        }
                        dt.Rows.Add(newRow);
                    }
                    PreviewImportZhilal previewForm = new PreviewImportZhilal(dt);
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                lbl_Error.Text = "Error membaca file Excel: " + ex.Message;
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            ReportViewerZhilal reportViewer = new ReportViewerZhilal();
            reportViewer.Show();
            this.Hide();
        }
    }
}
