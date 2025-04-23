namespace BUKAN_Budi_Daya_Ikan_
{
    partial class Profile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_profile = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_newProfile = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.dgv_Profile = new System.Windows.Forms.DataGridView();
            this.txtbox_profile = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Profile)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_profile
            // 
            this.lbl_profile.AutoSize = true;
            this.lbl_profile.Font = new System.Drawing.Font("a Alloy Ink", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_profile.Location = new System.Drawing.Point(128, 9);
            this.lbl_profile.Name = "lbl_profile";
            this.lbl_profile.Size = new System.Drawing.Size(122, 27);
            this.lbl_profile.TabIndex = 4;
            this.lbl_profile.Text = "Profile";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_start.Font = new System.Drawing.Font("Indigo Regular", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(148, 358);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(87, 41);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_newProfile
            // 
            this.btn_newProfile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_newProfile.Font = new System.Drawing.Font("Indigo Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newProfile.Location = new System.Drawing.Point(12, 67);
            this.btn_newProfile.Name = "btn_newProfile";
            this.btn_newProfile.Size = new System.Drawing.Size(96, 29);
            this.btn_newProfile.TabIndex = 6;
            this.btn_newProfile.Text = "New Profile";
            this.btn_newProfile.UseVisualStyleBackColor = false;
            this.btn_newProfile.Click += new System.EventHandler(this.btn_newProfile_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_update.Font = new System.Drawing.Font("Indigo Regular", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(144, 67);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(96, 29);
            this.btn_update.TabIndex = 7;
            this.btn_update.Text = "Update Profile";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_delete.Font = new System.Drawing.Font("Indigo Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(276, 67);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(96, 29);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dgv_Profile
            // 
            this.dgv_Profile.AllowUserToAddRows = false;
            this.dgv_Profile.AllowUserToDeleteRows = false;
            this.dgv_Profile.AllowUserToResizeColumns = false;
            this.dgv_Profile.AllowUserToResizeRows = false;
            this.dgv_Profile.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv_Profile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Profile.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Profile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Profile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Profile.ColumnHeadersVisible = false;
            this.dgv_Profile.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Profile.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Profile.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgv_Profile.Location = new System.Drawing.Point(70, 166);
            this.dgv_Profile.MultiSelect = false;
            this.dgv_Profile.Name = "dgv_Profile";
            this.dgv_Profile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Profile.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Profile.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Profile.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Profile.Size = new System.Drawing.Size(240, 186);
            this.dgv_Profile.TabIndex = 9;
            this.dgv_Profile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Profile_CellClick);
            // 
            // txtbox_profile
            // 
            this.txtbox_profile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtbox_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_profile.Location = new System.Drawing.Point(70, 123);
            this.txtbox_profile.Name = "txtbox_profile";
            this.txtbox_profile.Size = new System.Drawing.Size(240, 26);
            this.txtbox_profile.TabIndex = 10;
            this.txtbox_profile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.IndianRed;
            this.btn_back.Font = new System.Drawing.Font("Indigo Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(12, 375);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(63, 24);
            this.btn_back.TabIndex = 11;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.txtbox_profile);
            this.Controls.Add(this.dgv_Profile);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_newProfile);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lbl_profile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_profile;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_newProfile;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridView dgv_Profile;
        private System.Windows.Forms.TextBox txtbox_profile;
        private System.Windows.Forms.Button btn_back;
    }
}