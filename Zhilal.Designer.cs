namespace BUKAN_Budi_Daya_Ikan_
{
    partial class Zhilal
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
            this.dgv_GameLog = new System.Windows.Forms.DataGridView();
            this.lbl_FishPurchased = new System.Windows.Forms.Label();
            this.lbl_EnemiesKilled = new System.Windows.Forms.Label();
            this.lbl_MoneyEarned = new System.Windows.Forms.Label();
            this.lbl_FinalScore = new System.Windows.Forms.Label();
            this.txt_FishPurchased = new System.Windows.Forms.TextBox();
            this.txt_EnemiesKilled = new System.Windows.Forms.TextBox();
            this.txt_MoneyEarned = new System.Windows.Forms.TextBox();
            this.txt_FinalScore = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_analisis = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ErrrorMessage = new System.Windows.Forms.Label();
            this.lbl_Error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GameLog)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_GameLog
            // 
            this.dgv_GameLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GameLog.Location = new System.Drawing.Point(12, 12);
            this.dgv_GameLog.Name = "dgv_GameLog";
            this.dgv_GameLog.Size = new System.Drawing.Size(592, 426);
            this.dgv_GameLog.TabIndex = 0;
            this.dgv_GameLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GameLog_CellClick);
            // 
            // lbl_FishPurchased
            // 
            this.lbl_FishPurchased.AutoSize = true;
            this.lbl_FishPurchased.Location = new System.Drawing.Point(3, 0);
            this.lbl_FishPurchased.Name = "lbl_FishPurchased";
            this.lbl_FishPurchased.Size = new System.Drawing.Size(80, 13);
            this.lbl_FishPurchased.TabIndex = 3;
            this.lbl_FishPurchased.Text = "Fish Purchased";
            // 
            // lbl_EnemiesKilled
            // 
            this.lbl_EnemiesKilled.AutoSize = true;
            this.lbl_EnemiesKilled.Location = new System.Drawing.Point(3, 34);
            this.lbl_EnemiesKilled.Name = "lbl_EnemiesKilled";
            this.lbl_EnemiesKilled.Size = new System.Drawing.Size(75, 13);
            this.lbl_EnemiesKilled.TabIndex = 4;
            this.lbl_EnemiesKilled.Text = "Enemies Killed";
            // 
            // lbl_MoneyEarned
            // 
            this.lbl_MoneyEarned.AutoSize = true;
            this.lbl_MoneyEarned.Location = new System.Drawing.Point(3, 64);
            this.lbl_MoneyEarned.Name = "lbl_MoneyEarned";
            this.lbl_MoneyEarned.Size = new System.Drawing.Size(76, 13);
            this.lbl_MoneyEarned.TabIndex = 5;
            this.lbl_MoneyEarned.Text = "Money Earned";
            // 
            // lbl_FinalScore
            // 
            this.lbl_FinalScore.AutoSize = true;
            this.lbl_FinalScore.Location = new System.Drawing.Point(3, 104);
            this.lbl_FinalScore.Name = "lbl_FinalScore";
            this.lbl_FinalScore.Size = new System.Drawing.Size(60, 13);
            this.lbl_FinalScore.TabIndex = 6;
            this.lbl_FinalScore.Text = "Final Score";
            // 
            // txt_FishPurchased
            // 
            this.txt_FishPurchased.Location = new System.Drawing.Point(111, 3);
            this.txt_FishPurchased.Name = "txt_FishPurchased";
            this.txt_FishPurchased.Size = new System.Drawing.Size(284, 20);
            this.txt_FishPurchased.TabIndex = 9;
            // 
            // txt_EnemiesKilled
            // 
            this.txt_EnemiesKilled.Location = new System.Drawing.Point(111, 37);
            this.txt_EnemiesKilled.Name = "txt_EnemiesKilled";
            this.txt_EnemiesKilled.Size = new System.Drawing.Size(284, 20);
            this.txt_EnemiesKilled.TabIndex = 10;
            // 
            // txt_MoneyEarned
            // 
            this.txt_MoneyEarned.Location = new System.Drawing.Point(111, 67);
            this.txt_MoneyEarned.Name = "txt_MoneyEarned";
            this.txt_MoneyEarned.Size = new System.Drawing.Size(284, 20);
            this.txt_MoneyEarned.TabIndex = 11;
            // 
            // txt_FinalScore
            // 
            this.txt_FinalScore.Location = new System.Drawing.Point(111, 107);
            this.txt_FinalScore.Name = "txt_FinalScore";
            this.txt_FinalScore.Size = new System.Drawing.Size(284, 20);
            this.txt_FinalScore.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel1.Controls.Add(this.txt_FinalScore, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_MoneyEarned, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FishPurchased, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_EnemiesKilled, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_EnemiesKilled, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_FishPurchased, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_MoneyEarned, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FinalScore, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(614, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 136);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(614, 189);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(133, 23);
            this.btn_update.TabIndex = 14;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(894, 189);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(118, 23);
            this.btn_delete.TabIndex = 15;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(753, 189);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(135, 23);
            this.btn_refresh.TabIndex = 16;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_analisis
            // 
            this.btn_analisis.Location = new System.Drawing.Point(614, 218);
            this.btn_analisis.Name = "btn_analisis";
            this.btn_analisis.Size = new System.Drawing.Size(398, 23);
            this.btn_analisis.TabIndex = 17;
            this.btn_analisis.Text = "Analisis";
            this.btn_analisis.UseVisualStyleBackColor = true;
            this.btn_analisis.Click += new System.EventHandler(this.btn_analisis_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(614, 247);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(398, 23);
            this.btn_import.TabIndex = 18;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(614, 276);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(398, 23);
            this.btn_export.TabIndex = 19;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_ErrrorMessage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Error, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(614, 353);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.88235F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.11765F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 85);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // lbl_ErrrorMessage
            // 
            this.lbl_ErrrorMessage.AutoSize = true;
            this.lbl_ErrrorMessage.Location = new System.Drawing.Point(3, 0);
            this.lbl_ErrrorMessage.Name = "lbl_ErrrorMessage";
            this.lbl_ErrrorMessage.Size = new System.Drawing.Size(75, 13);
            this.lbl_ErrrorMessage.TabIndex = 0;
            this.lbl_ErrrorMessage.Text = "Error Message";
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(3, 22);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(0, 13);
            this.lbl_Error.TabIndex = 1;
            // 
            // Zhilal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_analisis);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_GameLog);
            this.Name = "Zhilal";
            this.Text = "Zhilal";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GameLog)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_GameLog;
        private System.Windows.Forms.Label lbl_FishPurchased;
        private System.Windows.Forms.Label lbl_EnemiesKilled;
        private System.Windows.Forms.Label lbl_MoneyEarned;
        private System.Windows.Forms.Label lbl_FinalScore;
        private System.Windows.Forms.TextBox txt_FishPurchased;
        private System.Windows.Forms.TextBox txt_EnemiesKilled;
        private System.Windows.Forms.TextBox txt_MoneyEarned;
        private System.Windows.Forms.TextBox txt_FinalScore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_analisis;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_ErrrorMessage;
        private System.Windows.Forms.Label lbl_Error;
    }
}