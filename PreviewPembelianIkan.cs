using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class PreviewPembelianIkan : Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";

        public PreviewPembelianIkan(DataTable data)
        {
            InitializeComponent();
            dgvPreview.DataSource = data;
        }

        private void PreviewPembelianIkan_Load(object sender, EventArgs e)
        {
            dgvPreview.AutoResizeColumns();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mengimpor data dari DataGridView ke database
                ImportDataToDatabase();
            }
        }

        private bool ValidateRow(DataRow row)
        {
            // Validasi tidak diperlukan untuk FishTypeID karena kolom ini otomatis di-generate oleh MySQL

            // Validasi TypeName
            string typeName = row["TypeName"].ToString();
            if (string.IsNullOrEmpty(typeName))
            {
                MessageBox.Show("TypeName tidak boleh kosong.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validasi Cost
            if (!decimal.TryParse(row["Cost"].ToString(), out decimal cost) || cost <= 0)
            {
                MessageBox.Show("Cost harus berupa angka yang valid dan lebih besar dari 0.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validasi Speed
            if (!int.TryParse(row["Speed"].ToString(), out int speed) || speed <= 0)
            {
                MessageBox.Show("Speed harus berupa angka yang valid dan lebih besar dari 0.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validasi AnimationPrefix
            string animationPrefix = row["AnimationPrefix"].ToString();
            if (string.IsNullOrEmpty(animationPrefix))
            {
                MessageBox.Show("AnimationPrefix tidak boleh kosong.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPreview.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    // Validasi setiap baris sebelum diimpor
                    if (!ValidateRow(row))
                    {
                        // Jika validasi gagal, lanjutkan ke baris berikutnya
                        continue; // Lewati baris ini jika tidak valid
                    }

                    string query = "INSERT INTO FishType (TypeName, Cost, Speed, AnimationPrefix) " +
                                   "VALUES (@TypeName, @Cost, @Speed, @AnimationPrefix)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TypeName", row["TypeName"]);
                            cmd.Parameters.AddWithValue("@Cost", row["Cost"]);
                            cmd.Parameters.AddWithValue("@Speed", row["Speed"]);
                            cmd.Parameters.AddWithValue("@AnimationPrefix", row["AnimationPrefix"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Data berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Tutup PreviewForm setelah data diimpor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
