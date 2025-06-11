using Microsoft.Reporting.WinForms;
using NPOI.SS.Formula.Functions;
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
    public partial class Report_Jaidil : Form
    {
        public Report_Jaidil()
        {
            InitializeComponent();
        }

        private void Report_Jaidil_Load(object sender, EventArgs e)
        {
            // Setup ReportViewer data
            SetupReportViewer();
            // Refresh report to display data
            this.reportViewer1.RefreshReport();
        }

        private void SetupReportViewer()
        {
            // Connection string to your database
            string connectionString = "Data Source=JAIDIL-RACHMAD\\JAIDIL;Initial Catalog=TesSp;Integrated Security=True";

            // SQL query to retrieve the required data from the database
            string query = @"
        SELECT 
            TypeName,
            Health,
            Speed,
            RewardMoney,
            AnimationPrefix
        FROM 
            EnemyType";

            // Create a DataTable to store the data
            DataTable dt = new DataTable();

            // Use SqlDataAdapter to fill the DataTable with data from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Create a ReportDataSource
            ReportDataSource rds = new ReportDataSource("DataSet_Jaidil", dt); // Make sure "DataSet1" matches your RDLC dataset name

            // Clear any existing data sources and add the new data source
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Set the path to the report (.rdlc file)
            // Change this to the actual path of your RDLC file
            reportViewer1.LocalReport.ReportPath = @"D:\KULIAH\SEM 4\Pengembangan Aplikasi Basis Data\Project\Clone\Report_Jaidil.rdlc";

            // Refresh the ReportViewer to show the updated report
            reportViewer1.RefreshReport();
        }

        private void BtnBack(object sender, EventArgs e)
        {
            Jaidil J = new Jaidil();
            J.Show();
            this.Hide();
        }
    }
}
