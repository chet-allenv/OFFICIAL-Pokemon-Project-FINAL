namespace OFFICIAL_Pokemon_Project_FINAL
{
    partial class Battle_Screen
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
            this.Enemy_Sprite = new System.Windows.Forms.PictureBox();
            this.Player_Sprite = new System.Windows.Forms.PictureBox();
            this.Enemy_Name = new System.Windows.Forms.Label();
            this.Player_Name = new System.Windows.Forms.Label();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Rerun_Button = new System.Windows.Forms.Button();
            this.Enemy_Health_Bar = new System.Windows.Forms.ProgressBar();
            this.Damage_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy_Sprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Sprite)).BeginInit();
            this.SuspendLayout();
            // 
            // Enemy_Sprite
            // 
            this.Enemy_Sprite.BackColor = System.Drawing.Color.Transparent;
            this.Enemy_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy_Sprite.Location = new System.Drawing.Point(583, 47);
            this.Enemy_Sprite.Name = "Enemy_Sprite";
            this.Enemy_Sprite.Size = new System.Drawing.Size(361, 312);
            this.Enemy_Sprite.TabIndex = 0;
            this.Enemy_Sprite.TabStop = false;
            // 
            // Player_Sprite
            // 
            this.Player_Sprite.BackColor = System.Drawing.Color.Transparent;
            this.Player_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player_Sprite.Location = new System.Drawing.Point(71, 301);
            this.Player_Sprite.Name = "Player_Sprite";
            this.Player_Sprite.Size = new System.Drawing.Size(425, 291);
            this.Player_Sprite.TabIndex = 1;
            this.Player_Sprite.TabStop = false;
            // 
            // Enemy_Name
            // 
            this.Enemy_Name.AutoSize = true;
            this.Enemy_Name.BackColor = System.Drawing.Color.Transparent;
            this.Enemy_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enemy_Name.Location = new System.Drawing.Point(77, 116);
            this.Enemy_Name.Name = "Enemy_Name";
            this.Enemy_Name.Size = new System.Drawing.Size(259, 37);
            this.Enemy_Name.TabIndex = 2;
            this.Enemy_Name.Text = "Enemy Pokemon";
            // 
            // Player_Name
            // 
            this.Player_Name.AutoSize = true;
            this.Player_Name.BackColor = System.Drawing.Color.Transparent;
            this.Player_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player_Name.Location = new System.Drawing.Point(592, 422);
            this.Player_Name.Name = "Player_Name";
            this.Player_Name.Size = new System.Drawing.Size(250, 37);
            this.Player_Name.TabIndex = 3;
            this.Player_Name.Text = "Player Pokemon";
            // 
            // Exit_Button
            // 
            this.Exit_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Button.Location = new System.Drawing.Point(29, 22);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(162, 56);
            this.Exit_Button.TabIndex = 4;
            this.Exit_Button.Text = "EXIT";
            this.Exit_Button.UseVisualStyleBackColor = false;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Rerun_Button
            // 
            this.Rerun_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Rerun_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rerun_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rerun_Button.Location = new System.Drawing.Point(223, 22);
            this.Rerun_Button.Name = "Rerun_Button";
            this.Rerun_Button.Size = new System.Drawing.Size(162, 56);
            this.Rerun_Button.TabIndex = 5;
            this.Rerun_Button.Text = "RERUN";
            this.Rerun_Button.UseVisualStyleBackColor = false;
            this.Rerun_Button.Click += new System.EventHandler(this.Rerun_Button_Click);
            // 
            // Enemy_Health_Bar
            // 
            this.Enemy_Health_Bar.Location = new System.Drawing.Point(223, 172);
            this.Enemy_Health_Bar.Name = "Enemy_Health_Bar";
            this.Enemy_Health_Bar.Size = new System.Drawing.Size(203, 23);
            this.Enemy_Health_Bar.TabIndex = 6;
            // 
            // Damage_Button
            // 
            this.Damage_Button.Location = new System.Drawing.Point(12, 227);
            this.Damage_Button.Name = "Damage_Button";
            this.Damage_Button.Size = new System.Drawing.Size(113, 48);
            this.Damage_Button.TabIndex = 7;
            this.Damage_Button.Text = "DO 10 DAMAGE";
            this.Damage_Button.UseVisualStyleBackColor = true;
            this.Damage_Button.Click += new System.EventHandler(this.Damage_Button_Click);
            // 
            // Battle_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OFFICIAL_Pokemon_Project_FINAL.Properties.Resources.battle_screen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 851);
            this.Controls.Add(this.Damage_Button);
            this.Controls.Add(this.Enemy_Health_Bar);
            this.Controls.Add(this.Rerun_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Player_Name);
            this.Controls.Add(this.Enemy_Name);
            this.Controls.Add(this.Player_Sprite);
            this.Controls.Add(this.Enemy_Sprite);
            this.Name = "Battle_Screen";
            this.Text = "Pokemon Project";
            this.Load += new System.EventHandler(this.Battle_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Enemy_Sprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Sprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Enemy_Sprite;
        private System.Windows.Forms.PictureBox Player_Sprite;
        private System.Windows.Forms.Label Enemy_Name;
        private System.Windows.Forms.Label Player_Name;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Rerun_Button;
        private System.Windows.Forms.ProgressBar Enemy_Health_Bar;
        private System.Windows.Forms.Button Damage_Button;
    }
}