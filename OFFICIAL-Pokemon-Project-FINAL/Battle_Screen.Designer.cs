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
            Break_Timer = new System.Windows.Forms.Timer(components);
            Sleep_Test_Button = new System.Windows.Forms.Button();
            Player_Health_Bar = new System.Windows.Forms.ProgressBar();
            Potion_Test = new System.Windows.Forms.Button();
            Test_Super_Potion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).BeginInit();
            SuspendLayout();
            // 
            // Enemy_Sprite
            // 
            Enemy_Sprite.BackColor = System.Drawing.Color.Transparent;
            Enemy_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Enemy_Sprite.Location = new System.Drawing.Point(694, 119);
            Enemy_Sprite.Name = "Enemy_Sprite";
            Enemy_Sprite.Size = new System.Drawing.Size(401, 390);
            Enemy_Sprite.TabIndex = 0;
            Enemy_Sprite.TabStop = false;
            // 
            // Player_Sprite
            // 
            Player_Sprite.BackColor = System.Drawing.Color.Transparent;
            Player_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Player_Sprite.Location = new System.Drawing.Point(21, 386);
            Player_Sprite.Name = "Player_Sprite";
            Player_Sprite.Size = new System.Drawing.Size(471, 363);
            Player_Sprite.TabIndex = 1;
            Player_Sprite.TabStop = false;
            // 
            // Enemy_Name
            // 
            Enemy_Name.AutoSize = true;
            Enemy_Name.BackColor = System.Drawing.Color.Transparent;
            Enemy_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Enemy_Name.Location = new System.Drawing.Point(-4, 90);
            Enemy_Name.Name = "Enemy_Name";
            Enemy_Name.Size = new System.Drawing.Size(259, 37);
            Enemy_Name.TabIndex = 2;
            Enemy_Name.Text = "Enemy Pokemon";
            // 
            // Player_Name
            // 
            Player_Name.AutoSize = true;
            Player_Name.BackColor = System.Drawing.Color.Transparent;
            Player_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Player_Name.Location = new System.Drawing.Point(659, 527);
            Player_Name.Name = "Player_Name";
            Player_Name.Size = new System.Drawing.Size(250, 37);
            Player_Name.TabIndex = 3;
            Player_Name.Text = "Player Pokemon";
            // 
            // Exit_Button
            // 
            Exit_Button.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Exit_Button.Location = new System.Drawing.Point(12, 12);
            Exit_Button.Name = "Exit_Button";
            Exit_Button.Size = new System.Drawing.Size(133, 49);
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
            Rerun_Button.Location = new System.Drawing.Point(151, 12);
            Rerun_Button.Name = "Rerun_Button";
            Rerun_Button.Size = new System.Drawing.Size(158, 49);
            Rerun_Button.TabIndex = 5;
            Rerun_Button.Text = "RERUN";
            Rerun_Button.UseVisualStyleBackColor = false;
            Rerun_Button.Click += Rerun_Button_Click;
            // 
            // Enemy_Health_Bar
            // 
            Enemy_Health_Bar.Location = new System.Drawing.Point(-4, 191);
            Enemy_Health_Bar.Name = "Enemy_Health_Bar";
            Enemy_Health_Bar.Size = new System.Drawing.Size(343, 23);
            Enemy_Health_Bar.TabIndex = 6;
            // 
            // Damage_Button
            // 
            Damage_Button.Location = new System.Drawing.Point(12, 263);
            Damage_Button.Name = "Damage_Button";
            Damage_Button.Size = new System.Drawing.Size(110, 64);
            Damage_Button.TabIndex = 7;
            Damage_Button.Text = "DO 10 DAMAGE";
            Damage_Button.UseVisualStyleBackColor = true;
            Damage_Button.Click += Damage_Button_Click;
            // 
            // Heal_Button
            // 
            Heal_Button.Location = new System.Drawing.Point(151, 260);
            Heal_Button.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            Heal_Button.Name = "Heal_Button";
            Heal_Button.Size = new System.Drawing.Size(110, 71);
            Heal_Button.TabIndex = 8;
            Heal_Button.Text = "Heal";
            Heal_Button.UseVisualStyleBackColor = true;
            Heal_Button.Click += Heal_Button_Click;
            // 
            // Attack_Button_1
            // 
            Attack_Button_1.Location = new System.Drawing.Point(627, 777);
            Attack_Button_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Attack_Button_1.Name = "Attack_Button_1";
            Attack_Button_1.Size = new System.Drawing.Size(183, 225);
            Attack_Button_1.TabIndex = 9;
            Attack_Button_1.Text = "Attack 1";
            Attack_Button_1.UseVisualStyleBackColor = true;
            Attack_Button_1.Click += Attack_Button_1_Click;
            // 
            // Attack_Button_2
            // 
            Attack_Button_2.Location = new System.Drawing.Point(867, 777);
            Attack_Button_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Attack_Button_2.Name = "Attack_Button_2";
            Attack_Button_2.Size = new System.Drawing.Size(183, 225);
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
            Message_Box.Location = new System.Drawing.Point(80, 795);
            Message_Box.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Message_Box.Name = "Message_Box";
            Message_Box.Size = new System.Drawing.Size(503, 207);
            Message_Box.TabIndex = 11;
            Message_Box.Text = "Place holder";
            // 
            // Break_Timer
            // 
            Break_Timer.Tick += Break_Timer_Tick;
            // 
            // Sleep_Test_Button
            // 
            Sleep_Test_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Sleep_Test_Button.Location = new System.Drawing.Point(340, 12);
            Sleep_Test_Button.Name = "Sleep_Test_Button";
            Sleep_Test_Button.Size = new System.Drawing.Size(122, 49);
            Sleep_Test_Button.TabIndex = 12;
            Sleep_Test_Button.Text = "Test Sleep Function";
            Sleep_Test_Button.UseVisualStyleBackColor = true;
            Sleep_Test_Button.Click += Sleep_Test_Button_Click;
            // 
            // Player_Health_Bar
            // 
            Player_Health_Bar.Location = new System.Drawing.Point(831, 589);
            Player_Health_Bar.Name = "Player_Health_Bar";
            Player_Health_Bar.Size = new System.Drawing.Size(231, 28);
            Player_Health_Bar.TabIndex = 13;
            // 
            // Potion_Test
            // 
            Potion_Test.Location = new System.Drawing.Point(377, 238);
            Potion_Test.Name = "Potion_Test";
            Potion_Test.Size = new System.Drawing.Size(218, 93);
            Potion_Test.TabIndex = 14;
            Potion_Test.Text = "Use Potion";
            Potion_Test.UseVisualStyleBackColor = true;
            Potion_Test.Click += Potion_Test_Click;
            // 
            // Test_Super_Potion
            // 
            Test_Super_Potion.Location = new System.Drawing.Point(513, 27);
            Test_Super_Potion.Name = "Test_Super_Potion";
            Test_Super_Potion.Size = new System.Drawing.Size(112, 122);
            Test_Super_Potion.TabIndex = 15;
            Test_Super_Potion.Text = "Use Super Potion";
            Test_Super_Potion.UseVisualStyleBackColor = true;
            Test_Super_Potion.Click += Test_Super_Potion_Click;
            // 
            // Battle_Screen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.battle_screen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1146, 1063);
            Controls.Add(Test_Super_Potion);
            Controls.Add(Potion_Test);
            Controls.Add(Player_Health_Bar);
            Controls.Add(Sleep_Test_Button);
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
        private System.Windows.Forms.Timer Break_Timer;
        private System.Windows.Forms.Button Sleep_Test_Button;
        private System.Windows.Forms.ProgressBar Player_Health_Bar;
        private System.Windows.Forms.Button Potion_Test;
        private System.Windows.Forms.Button Test_Super_Potion;
    }
}