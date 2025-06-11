using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUKAN_Budi_Daya_Ikan_
{
    public partial class FormReportFish : Form
    {
        private DataTable _dataTable;

        // Constructor menerima DataTable
        public FormReportFish(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void FormReportFish_Load(object sender, EventArgs e)
        {
            // Setup ReportViewer data
            SetupReportViewer();
            // Refresh report to display data
            this.reportViewer2.RefreshReport();
        }

        private void SetupReportViewer()
        {
            // Create a ReportDataSource using the passed DataTable
            ReportDataSource rds = new ReportDataSource("DataSet1", _dataTable); // Pastikan "DataSet1" sesuai dengan nama dataset pada file .rdlc

            // Clear any existing data sources and add the new data source
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(rds);

            // Set the path to the report (.rdlc file)
            reportViewer2.LocalReport.ReportPath = @"D:\Kuliah\Semester 4\Pengembangan Aplikasi Basis Data\BUKAN(Budi Daya Ikan)\FishReport.rdlc";  // Ganti dengan path yang sesuai

            // Refresh the ReportViewer to show the updated report
            reportViewer2.RefreshReport();
        }
    }
}
