using Microsoft.Reporting.WinForms;
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
    public partial class ReportViewerZhilal : Form
    {
        public ReportViewerZhilal()
        {
            InitializeComponent();
        }

        private void ReportViewerZhilal_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
            this.reportViewer1.RefreshReport();
        }

        private void SetupReportViewer()
        {
            string connectionString = "Data source=DESKTOP-FP1P0A6\\ZHILALKRISNA;Initial Catalog=BUKAN_db;Integrated Security=True";
            string query = @"
                SELECT 
	                playerName, 
	                GameStartTime, 
	                GameEndTime, 
	                FishPurchased, 
	                EnemiesKilled, 
	                MoneyEarned, 
	                FinalScore 
                    FROM GameLog 
                ORDER BY GameStartTime DESC
            ";

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            ReportDataSource rds = new ReportDataSource("DataSetZ", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.ReportPath = "D:\\Kuliah\\Semester 4\\Pengembangan Aplikasi Basis Data\\BUKAN(Budi Daya Ikan)\\ReportZhilal.rdlc";
            this.reportViewer1.RefreshReport();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Zhilal zhilal = new Zhilal();
            zhilal.Show();
            this.Close();
        }
    }
}
