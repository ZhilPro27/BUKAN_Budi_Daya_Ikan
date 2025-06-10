namespace BUKAN_Budi_Daya_Ikan_
{
    partial class PreviewPembelianIkan
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
                this.dgvPreview = new System.Windows.Forms.DataGridView();
                this.btnImport = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
                this.SuspendLayout();
                // 
                // dgvPreview
                // 
                this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgvPreview.Location = new System.Drawing.Point(30, 32);
                this.dgvPreview.Name = "dgvPreview";
                this.dgvPreview.RowHeadersWidth = 62;
                this.dgvPreview.RowTemplate.Height = 28;
                this.dgvPreview.Size = new System.Drawing.Size(654, 385);
                this.dgvPreview.TabIndex = 0;
                this.dgvPreview.Click += new System.EventHandler(this.BtnImport_Click);
                // 
                // btnImport
                // 
                this.btnImport.Location = new System.Drawing.Point(707, 32);
                this.btnImport.Name = "btnImport";
                this.btnImport.Size = new System.Drawing.Size(81, 54);
                this.btnImport.TabIndex = 1;
                this.btnImport.Text = "Import";
                this.btnImport.UseVisualStyleBackColor = true;
                this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
                // 
                // PreviewForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.btnImport);
                this.Controls.Add(this.dgvPreview);
                this.Name = "PreviewPembelianIkan";
                this.Text = "PreviewPembelianIkan";
                this.Click += new System.EventHandler(this.PreviewPembelianIkan_Load);
                ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.DataGridView dgvPreview;
            private System.Windows.Forms.Button btnImport;
        }
    }