namespace BUKAN_Budi_Daya_Ikan_
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.lbl_menu = new System.Windows.Forms.Label();
            this.lbl_money = new System.Windows.Forms.Label();
            this.btn_add__fish = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.timerFoods = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_menu
            // 
            this.lbl_menu.AutoSize = true;
            this.lbl_menu.Font = new System.Drawing.Font("Aladin", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_menu.Location = new System.Drawing.Point(12, 9);
            this.lbl_menu.Name = "lbl_menu";
            this.lbl_menu.Size = new System.Drawing.Size(76, 24);
            this.lbl_menu.TabIndex = 1;
            this.lbl_menu.Text = "Score = ";
            // 
            // lbl_money
            // 
            this.lbl_money.AutoSize = true;
            this.lbl_money.Font = new System.Drawing.Font("Aladin", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_money.Location = new System.Drawing.Point(12, 46);
            this.lbl_money.Name = "lbl_money";
            this.lbl_money.Size = new System.Drawing.Size(81, 24);
            this.lbl_money.TabIndex = 2;
            this.lbl_money.Text = "Money = ";
            // 
            // btn_add__fish
            // 
            this.btn_add__fish.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_add__fish.Font = new System.Drawing.Font("Indigo Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add__fish.Location = new System.Drawing.Point(12, 82);
            this.btn_add__fish.Name = "btn_add__fish";
            this.btn_add__fish.Size = new System.Drawing.Size(56, 44);
            this.btn_add__fish.TabIndex = 6;
            this.btn_add__fish.Text = "Add Fish";
            this.btn_add__fish.UseVisualStyleBackColor = false;
            // 
            // btn_end
            // 
            this.btn_end.BackColor = System.Drawing.Color.LightCoral;
            this.btn_end.Font = new System.Drawing.Font("Indigo Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_end.Location = new System.Drawing.Point(822, 12);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(56, 28);
            this.btn_end.TabIndex = 7;
            this.btn_end.Text = "END";
            this.btn_end.UseVisualStyleBackColor = false;
            // 
            // timerFoods
            // 
            this.timerFoods.Enabled = true;
            this.timerFoods.Interval = 1000;
            this.timerFoods.Tick += new System.EventHandler(this.Food_Generator);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(890, 519);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.btn_add__fish);
            this.Controls.Add(this.lbl_money);
            this.Controls.Add(this.lbl_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_menu;
        private System.Windows.Forms.Label lbl_money;
        private System.Windows.Forms.Button btn_add__fish;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Timer timerFoods;
    }
}