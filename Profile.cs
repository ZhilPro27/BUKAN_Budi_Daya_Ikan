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
    public partial class Profile: Form
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
                connection.Open();
                string query = "SELECT * FROM Profile";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv_Profile.DataSource = dataTable;
            }
        }
    }
}
