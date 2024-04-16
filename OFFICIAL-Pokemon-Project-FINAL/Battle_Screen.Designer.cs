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
            components = new System.ComponentModel.Container();
            Enemy_Sprite = new System.Windows.Forms.PictureBox();
            Player_Sprite = new System.Windows.Forms.PictureBox();
            Enemy_Name = new System.Windows.Forms.Label();
            Player_Name = new System.Windows.Forms.Label();
            Exit_Button = new System.Windows.Forms.Button();
            Rerun_Button = new System.Windows.Forms.Button();
            Enemy_Health_Bar = new System.Windows.Forms.ProgressBar();
            Damage_Button = new System.Windows.Forms.Button();
            Heal_Button = new System.Windows.Forms.Button();
            Attack_Button_1 = new System.Windows.Forms.Button();
            Attack_Button_2 = new System.Windows.Forms.Button();
            Updater = new System.Windows.Forms.Timer(components);
            Message_Box = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).BeginInit();
            SuspendLayout();
            // 
            // Enemy_Sprite
            // 
            Enemy_Sprite.BackColor = System.Drawing.Color.Transparent;
            Enemy_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Enemy_Sprite.Location = new System.Drawing.Point(454, 36);
            Enemy_Sprite.Margin = new System.Windows.Forms.Padding(2);
            Enemy_Sprite.Name = "Enemy_Sprite";
            Enemy_Sprite.Size = new System.Drawing.Size(281, 234);
            Enemy_Sprite.TabIndex = 0;
            Enemy_Sprite.TabStop = false;
            // 
            // Player_Sprite
            // 
            Player_Sprite.BackColor = System.Drawing.Color.Transparent;
            Player_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Player_Sprite.Location = new System.Drawing.Point(55, 226);
            Player_Sprite.Margin = new System.Windows.Forms.Padding(2);
            Player_Sprite.Name = "Player_Sprite";
            Player_Sprite.Size = new System.Drawing.Size(330, 218);
            Player_Sprite.TabIndex = 1;
            Player_Sprite.TabStop = false;
            // 
            // Enemy_Name
            // 
            Enemy_Name.AutoSize = true;
            Enemy_Name.BackColor = System.Drawing.Color.Transparent;
            Enemy_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Enemy_Name.Location = new System.Drawing.Point(59, 87);
            Enemy_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Enemy_Name.Name = "Enemy_Name";
            Enemy_Name.Size = new System.Drawing.Size(180, 26);
            Enemy_Name.TabIndex = 2;
            Enemy_Name.Text = "Enemy Pokemon";
            // 
            // Player_Name
            // 
            Player_Name.AutoSize = true;
            Player_Name.BackColor = System.Drawing.Color.Transparent;
            Player_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Player_Name.Location = new System.Drawing.Point(461, 316);
            Player_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Player_Name.Name = "Player_Name";
            Player_Name.Size = new System.Drawing.Size(173, 26);
            Player_Name.TabIndex = 3;
            Player_Name.Text = "Player Pokemon";
            // 
            // Exit_Button
            // 
            Exit_Button.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Exit_Button.Location = new System.Drawing.Point(22, 16);
            Exit_Button.Margin = new System.Windows.Forms.Padding(2);
            Exit_Button.Name = "Exit_Button";
            Exit_Button.Size = new System.Drawing.Size(126, 42);
            Exit_Button.TabIndex = 4;
            Exit_Button.Text = "EXIT";
            Exit_Button.UseVisualStyleBackColor = false;
            Exit_Button.Click += Exit_Button_Click;
            // 
            // Rerun_Button
            // 
            Rerun_Button.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            Rerun_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Rerun_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Rerun_Button.Location = new System.Drawing.Point(174, 16);
            Rerun_Button.Margin = new System.Windows.Forms.Padding(2);
            Rerun_Button.Name = "Rerun_Button";
            Rerun_Button.Size = new System.Drawing.Size(126, 42);
            Rerun_Button.TabIndex = 5;
            Rerun_Button.Text = "RERUN";
            Rerun_Button.UseVisualStyleBackColor = false;
            Rerun_Button.Click += Rerun_Button_Click;
            // 
            // Enemy_Health_Bar
            // 
            Enemy_Health_Bar.Location = new System.Drawing.Point(174, 129);
            Enemy_Health_Bar.Margin = new System.Windows.Forms.Padding(2);
            Enemy_Health_Bar.Name = "Enemy_Health_Bar";
            Enemy_Health_Bar.Size = new System.Drawing.Size(158, 17);
            Enemy_Health_Bar.TabIndex = 6;
            // 
            // Damage_Button
            // 
            Damage_Button.Location = new System.Drawing.Point(44, 158);
            Damage_Button.Margin = new System.Windows.Forms.Padding(2);
            Damage_Button.Name = "Damage_Button";
            Damage_Button.Size = new System.Drawing.Size(88, 51);
            Damage_Button.TabIndex = 7;
            Damage_Button.Text = "DO 10 DAMAGE";
            Damage_Button.UseVisualStyleBackColor = true;
            Damage_Button.Click += Damage_Button_Click;
            // 
            // Heal_Button
            // 
            Heal_Button.Location = new System.Drawing.Point(138, 158);
            Heal_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Heal_Button.Name = "Heal_Button";
            Heal_Button.Size = new System.Drawing.Size(88, 51);
            Heal_Button.TabIndex = 8;
            Heal_Button.Text = "Heal";
            Heal_Button.UseVisualStyleBackColor = true;
            Heal_Button.Click += Heal_Button_Click;
            // 
            // Attack_Button_1
            // 
            Attack_Button_1.Location = new System.Drawing.Point(439, 466);
            Attack_Button_1.Name = "Attack_Button_1";
            Attack_Button_1.Size = new System.Drawing.Size(128, 135);
            Attack_Button_1.TabIndex = 9;
            Attack_Button_1.Text = "Attack 1";
            Attack_Button_1.UseVisualStyleBackColor = true;
            Attack_Button_1.Click += Attack_Button_1_Click;
            // 
            // Attack_Button_2
            // 
            Attack_Button_2.Location = new System.Drawing.Point(607, 466);
            Attack_Button_2.Name = "Attack_Button_2";
            Attack_Button_2.Size = new System.Drawing.Size(128, 135);
            Attack_Button_2.TabIndex = 10;
            Attack_Button_2.Text = "Attack 2";
            Attack_Button_2.UseVisualStyleBackColor = true;
            Attack_Button_2.Click += Attack_Button_2_Click ;
            // 
            // Updater
            // 
            Updater.Tick += Update;
            // 
            // Message_Box
            // 
            Message_Box.Location = new System.Drawing.Point(56, 477);
            Message_Box.Name = "Message_Box";
            Message_Box.Size = new System.Drawing.Size(352, 124);
            Message_Box.TabIndex = 11;
            Message_Box.Text = "Place holder";
            // 
            // Battle_Screen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.battle_screen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(802, 638);
            Controls.Add(Message_Box);
            Controls.Add(Attack_Button_2);
            Controls.Add(Attack_Button_1);
            Controls.Add(Heal_Button);
            Controls.Add(Damage_Button);
            Controls.Add(Enemy_Health_Bar);
            Controls.Add(Rerun_Button);
            Controls.Add(Exit_Button);
            Controls.Add(Player_Name);
            Controls.Add(Enemy_Name);
            Controls.Add(Player_Sprite);
            Controls.Add(Enemy_Sprite);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Battle_Screen";
            Text = " ";
            Load += Battle_Screen_Load;
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button Heal_Button;
        private System.Windows.Forms.Button Attack_Button_1;
        private System.Windows.Forms.Button Attack_Button_2;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Label Message_Box;
    }
}