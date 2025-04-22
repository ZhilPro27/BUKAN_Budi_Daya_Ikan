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
    public partial class Profile : Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";

        public Profile()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Profile";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgv_Profile.DataSource = dataTable;

                    clearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void clearTextBox()
        {
            txtbox_profile.Clear();
        }

        private void btn_newProfile_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Profile (playerName) VALUES (@playerName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@playerName", txtbox_profile.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_Profile.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this profile?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Profile WHERE playerName = @playerName";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@playerName", dgv_Profile.SelectedRows[0].Cells[0].Value.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}