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
    public partial class Preview_Jaidil : Form
    {
        private string connectionString = "Data Source=JAIDIL-RACHMAD\\JAIDIL;Initial Catalog=TesSp;Integrated Security=True";
        private DataTable previewData;

        // Konstruktor menerima DataTable dan menampilkan data di DataGridView
        public Preview_Jaidil(DataTable data)
        {
            InitializeComponent();
            previewData = data; // Simpan data untuk digunakan saat impor
            dgvPreview.DataSource = data;
        }

        // Event ketika form dimuat
        private void Preview_Jaidil_Load(object sender, EventArgs e)
        {
            dgvPreview.AutoResizeColumns(); // Menyesuaikan ukuran kolom
        }

        // Event ketika tombol OK ditekan
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ImportDataToDatabase();
            }
        }

        // Fungsi untuk mengimpor data ke database menggunakan stored procedure AddEnemy
        private void ImportDataToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    foreach (DataRow row in previewData.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("AddEnemy", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@TypeName", row["TypeName"].ToString());
                            cmd.Parameters.AddWithValue("@Health", Convert.ToInt32(row["Health"]));
                            cmd.Parameters.AddWithValue("@Speed", Convert.ToInt32(row["Speed"]));
                            cmd.Parameters.AddWithValue("@RewardMoney", Convert.ToInt32(row["Reward Money"]));
                            cmd.Parameters.AddWithValue("@AnimationPrefix", row["Animation Prefix"].ToString());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data berhasil diimpor ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        
    }
}
