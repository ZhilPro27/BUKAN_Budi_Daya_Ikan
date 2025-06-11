namespace BUKAN_Budi_Daya_Ikan_
{
    partial class Jaidil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.txtAnimationPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEnemyType = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtRewardMoney = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtHealth = new System.Windows.Forms.TextBox();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemyType)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 37;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 36;
            this.button1.Text = "Analisa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnAnalyze);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(45, 341);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(100, 35);
            this.Import.TabIndex = 35;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.BtnImport);
            // 
            // txtAnimationPrefix
            // 
            this.txtAnimationPrefix.Location = new System.Drawing.Point(175, 206);
            this.txtAnimationPrefix.Name = "txtAnimationPrefix";
            this.txtAnimationPrefix.Size = new System.Drawing.Size(213, 22);
            this.txtAnimationPrefix.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(47, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Animation Prefix";
            // 
            // dgvEnemyType
            // 
            this.dgvEnemyType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnemyType.Location = new System.Drawing.Point(423, 12);
            this.dgvEnemyType.Name = "dgvEnemyType";
            this.dgvEnemyType.RowHeadersWidth = 51;
            this.dgvEnemyType.RowTemplate.Height = 24;
            this.dgvEnemyType.Size = new System.Drawing.Size(738, 486);
            this.dgvEnemyType.TabIndex = 32;
            this.dgvEnemyType.SelectionChanged += new System.EventHandler(this.dgvPreview_SelectionChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(167, 403);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(166, 272);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(100, 35);
            this.btnUbah.TabIndex = 30;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.BtnUbah);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(288, 272);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 35);
            this.btnHapus.TabIndex = 29;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.BtnHapus);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(47, 272);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(100, 35);
            this.btnTambah.TabIndex = 28;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.BtnTambah);
            // 
            // txtRewardMoney
            // 
            this.txtRewardMoney.Location = new System.Drawing.Point(175, 161);
            this.txtRewardMoney.Name = "txtRewardMoney";
            this.txtRewardMoney.Size = new System.Drawing.Size(213, 22);
            this.txtRewardMoney.TabIndex = 27;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(175, 116);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(213, 22);
            this.txtSpeed.TabIndex = 26;
            // 
            // txtHealth
            // 
            this.txtHealth.Location = new System.Drawing.Point(175, 64);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(213, 22);
            this.txtHealth.TabIndex = 25;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(175, 14);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(213, 22);
            this.txtTypeName.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(47, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Reward Money";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(47, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(47, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Health";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(47, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Type Name";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 35);
            this.button3.TabIndex = 38;
            this.button3.Text = "Report";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnReport);
            // 
            // Jaidil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1199, 523);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.txtAnimationPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvEnemyType);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtRewardMoney);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtHealth);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Jaidil";
            this.Text = "EnemyType_Jaidil";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemyType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.TextBox txtAnimationPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvEnemyType;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtRewardMoney;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtHealth;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}