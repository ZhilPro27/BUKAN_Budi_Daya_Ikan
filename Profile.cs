using BUKAN_Budi_Daya_Ikan_.Game_Object;
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
        private string connectionString = "Data Source=DESKTOP-P6SA9AD;Initial Catalog=BUKAN_db;Integrated Security=True";
        public Profile()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
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
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(txtbox_profile.Text.Count() != 0)
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
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error: Text Box is Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if ((dgv_Profile.SelectedCells.Count > 0) && (txtbox_profile.Text != ""))
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
                            command.Parameters.AddWithValue("@playerName", dgv_Profile.SelectedCells[0].Value.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                            connection.Close();
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
                MessageBox.Show("Please select a profile to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_Profile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Profile.Rows[e.RowIndex];
                txtbox_profile.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if((dgv_Profile.SelectedCells.Count > 0) && (txtbox_profile.Text.Count() != 0))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Profile SET playerName = @playerName WHERE playerName = @oldPlayerName";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@playerName", txtbox_profile.Text);
                        command.Parameters.AddWithValue("@oldPlayerName", dgv_Profile.SelectedCells[0].Value.ToString());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a profile to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if ((dgv_Profile.SelectedCells.Count == 0) || (txtbox_profile.Text == ""))
            {
                MessageBox.Show("Please select a profile to start the game.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                core.playerName = dgv_Profile.SelectedCells[0].Value.ToString();
                this.Close();
                Game game = new Game();
                game.Show();

            }
        }
    }
}