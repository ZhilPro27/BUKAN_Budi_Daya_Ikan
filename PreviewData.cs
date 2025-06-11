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
    public partial class PreviewData : Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";

        public PreviewData(DataTable data)
        {
            InitializeComponent();
            dgvPreview.DataSource = data;
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            dgvPreview.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ImportDataToDatabase();
            }
        }



        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPreview.DataSource;

                foreach (DataRow row in dt.Rows)
                /*{
                    if (!ValidateRow(row))
                    {
                        continue;
                    }
                }*/

                {
                    string query = "INSERT INTO Profile (photo) VALUES (@photo)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@photo", row["photo"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data berhasil diimpor ke database", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
