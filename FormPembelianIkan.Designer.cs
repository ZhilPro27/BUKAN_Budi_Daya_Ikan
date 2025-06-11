using System.Data.SqlTypes;

namespace BUKAN_Budi_Daya_Ikan_
{
    partial class FormPembelianIkan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtAnimationPrefix = new System.Windows.Forms.TextBox();
            this.dgvFishTypes = new System.Windows.Forms.DataGridView();
            this.BtnTambah = new System.Windows.Forms.Button();
            this.BtnUbah = new System.Windows.Forms.Button();
            this.BtnHapus = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnAnalyze = new System.Windows.Forms.Button();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelAnimationPrefix = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFishTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(144, 60);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(176, 20);
            this.txtTypeName.TabIndex = 1;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(144, 100);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(176, 20);
            this.txtCost.TabIndex = 2;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(144, 140);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(176, 20);
            this.txtSpeed.TabIndex = 3;
            // 
            // txtAnimationPrefix
            // 
            this.txtAnimationPrefix.Location = new System.Drawing.Point(144, 177);
            this.txtAnimationPrefix.Name = "txtAnimationPrefix";
            this.txtAnimationPrefix.Size = new System.Drawing.Size(176, 20);
            this.txtAnimationPrefix.TabIndex = 4;
            // 
            // dgvFishTypes
            // 
            this.dgvFishTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFishTypes.Location = new System.Drawing.Point(337, 63);
            this.dgvFishTypes.Name = "dgvFishTypes";
            this.dgvFishTypes.RowHeadersWidth = 51;
            this.dgvFishTypes.RowTemplate.Height = 24;
            this.dgvFishTypes.Size = new System.Drawing.Size(451, 416);
            this.dgvFishTypes.TabIndex = 5;
            this.dgvFishTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFishTypes_CellClick);
            this.dgvFishTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFishTypes_CellClick);
            // 
            // BtnTambah
            // 
            this.BtnTambah.Location = new System.Drawing.Point(14, 245);
            this.BtnTambah.Name = "BtnTambah";
            this.BtnTambah.Size = new System.Drawing.Size(100, 30);
            this.BtnTambah.TabIndex = 6;
            this.BtnTambah.Text = "Tambah";
            this.BtnTambah.UseVisualStyleBackColor = true;
            this.BtnTambah.Click += new System.EventHandler(this.BtnTambah_Click);
            // 
            // BtnUbah
            // 
            this.BtnUbah.Location = new System.Drawing.Point(144, 245);
            this.BtnUbah.Name = "BtnUbah";
            this.BtnUbah.Size = new System.Drawing.Size(100, 30);
            this.BtnUbah.TabIndex = 7;
            this.BtnUbah.Text = "Ubah";
            this.BtnUbah.UseVisualStyleBackColor = true;
            this.BtnUbah.Click += new System.EventHandler(this.BtnUbah_Click);
            // 
            // BtnHapus
            // 
            this.BtnHapus.Location = new System.Drawing.Point(14, 285);
            this.BtnHapus.Name = "BtnHapus";
            this.BtnHapus.Size = new System.Drawing.Size(100, 30);
            this.BtnHapus.TabIndex = 8;
            this.BtnHapus.Text = "Hapus";
            this.BtnHapus.UseVisualStyleBackColor = true;
            this.BtnHapus.Click += new System.EventHandler(this.BtnHapus_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(144, 285);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(100, 30);
            this.BtnRefresh.TabIndex = 9;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(12, 333);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(313, 36);
            this.BtnImport.TabIndex = 10;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnAnalyze
            // 
            this.BtnAnalyze.Location = new System.Drawing.Point(14, 417);
            this.BtnAnalyze.Name = "BtnAnalyze";
            this.BtnAnalyze.Size = new System.Drawing.Size(311, 39);
            this.BtnAnalyze.TabIndex = 11;
            this.BtnAnalyze.Text = "Analyze";
            this.BtnAnalyze.UseVisualStyleBackColor = true;
            this.BtnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);
            // 
            // labelTypeName
            // 
            this.labelTypeName.AutoSize = true;
            this.labelTypeName.Location = new System.Drawing.Point(20, 63);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(62, 13);
            this.labelTypeName.TabIndex = 13;
            this.labelTypeName.Text = "TypeName:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(20, 103);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(31, 13);
            this.labelCost.TabIndex = 14;
            this.labelCost.Text = "Cost:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(20, 143);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(41, 13);
            this.labelSpeed.TabIndex = 15;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelAnimationPrefix
            // 
            this.labelAnimationPrefix.AutoSize = true;
            this.labelAnimationPrefix.Location = new System.Drawing.Point(20, 183);
            this.labelAnimationPrefix.Name = "labelAnimationPrefix";
            this.labelAnimationPrefix.Size = new System.Drawing.Size(85, 13);
            this.labelAnimationPrefix.TabIndex = 16;
            this.labelAnimationPrefix.Text = "Animation Prefix:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 36);
            this.button1.TabIndex = 17;
            this.button1.Text = "Export & Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(14, 462);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(100, 30);
            this.btn_Back.TabIndex = 18;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // FormPembelianIkan
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelAnimationPrefix);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.BtnAnalyze);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnHapus);
            this.Controls.Add(this.BtnUbah);
            this.Controls.Add(this.BtnTambah);
            this.Controls.Add(this.dgvFishTypes);
            this.Controls.Add(this.txtAnimationPrefix);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtTypeName);
            this.Name = "FormPembelianIkan";
            this.Text = "Form Pembelian Ikan";
            this.Load += new System.EventHandler(this.FormPembelianIkan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFishTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtAnimationPrefix;
        private System.Windows.Forms.DataGridView dgvFishTypes;
        private System.Windows.Forms.Button BtnTambah;
        private System.Windows.Forms.Button BtnUbah;
        private System.Windows.Forms.Button BtnHapus;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.Button BtnAnalyze;
        private System.Windows.Forms.Label labelTypeName;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelAnimationPrefix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Back;
    }
}
