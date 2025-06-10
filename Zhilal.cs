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
    public partial class Zhilal : Form
    {
        private string connectionString = "Data Source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";

        public Zhilal()
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
                    string query = "SELECT * FROM GameLog";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgv_GameLog.DataSource = dataTable;

                    clearTextBox();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    lbl_Error.Text = ex.Message;
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void clearTextBox()
        {
            txt_GameStartTime.Clear();
            txt_GameEndTime.Clear();
            txt_FishPurchased.Clear();
            txt_EnemiesKilled.Clear();
            txt_MoneyEarned.Clear();
            txt_FinalScore.Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }
    }
}
