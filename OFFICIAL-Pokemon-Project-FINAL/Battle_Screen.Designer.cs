﻿namespace OFFICIAL_Pokemon_Project_FINAL
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
            Updater = new System.Windows.Forms.Timer(components);
            Message_Box = new System.Windows.Forms.Label();
            Break_Timer = new System.Windows.Forms.Timer(components);
            Sleep_Test_Button = new System.Windows.Forms.Button();
            Player_Health_Bar = new System.Windows.Forms.ProgressBar();
            Potion_Test = new System.Windows.Forms.Button();
            Test_Super_Potion = new System.Windows.Forms.Button();
            TestShowAttackBox = new System.Windows.Forms.Button();
            HealingItemButton = new System.Windows.Forms.Button();
            CatchPokemonButton = new System.Windows.Forms.Button();
            RunButton = new System.Windows.Forms.Button();
            OptionPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            Attack_Button_1 = new System.Windows.Forms.Button();
            Attack_Button_2 = new System.Windows.Forms.Button();
            AttackPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            UsePokeballButton = new System.Windows.Forms.Button();
            UseGreatBallButton = new System.Windows.Forms.Button();
            UseUltraBallButton = new System.Windows.Forms.Button();
            UseMasterBallButton = new System.Windows.Forms.Button();
            PokeballPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            pokeballPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).BeginInit();
            OptionPanelLayout.SuspendLayout();
            AttackPanelLayout.SuspendLayout();
            PokeballPanelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokeballPictureBox).BeginInit();
            SuspendLayout();
            // 
            // Enemy_Sprite
            // 
            Enemy_Sprite.BackColor = System.Drawing.Color.Transparent;
            Enemy_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Enemy_Sprite.Location = new System.Drawing.Point(609, 182);
            Enemy_Sprite.Name = "Enemy_Sprite";
            Enemy_Sprite.Size = new System.Drawing.Size(374, 283);
            Enemy_Sprite.TabIndex = 0;
            Enemy_Sprite.TabStop = false;
            // 
            // Player_Sprite
            // 
            Player_Sprite.BackColor = System.Drawing.Color.Transparent;
            Player_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Player_Sprite.Location = new System.Drawing.Point(21, 387);
            Player_Sprite.Name = "Player_Sprite";
            Player_Sprite.Size = new System.Drawing.Size(440, 295);
            Player_Sprite.TabIndex = 1;
            Player_Sprite.TabStop = false;
            // 
            // Enemy_Name
            // 
            Enemy_Name.AutoSize = true;
            Enemy_Name.BackColor = System.Drawing.Color.Transparent;
            Enemy_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Enemy_Name.ForeColor = System.Drawing.SystemColors.Control;
            Enemy_Name.Location = new System.Drawing.Point(-4, 81);
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
            Player_Name.ForeColor = System.Drawing.SystemColors.Control;
            Player_Name.Location = new System.Drawing.Point(623, 524);
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
            Exit_Button.Location = new System.Drawing.Point(630, 101);
            Exit_Button.Name = "Exit_Button";
            Exit_Button.Size = new System.Drawing.Size(133, 48);
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
            Rerun_Button.Location = new System.Drawing.Point(666, 12);
            Rerun_Button.Name = "Rerun_Button";
            Rerun_Button.Size = new System.Drawing.Size(159, 48);
            Rerun_Button.TabIndex = 5;
            Rerun_Button.Text = "RERUN";
            Rerun_Button.UseVisualStyleBackColor = false;
            Rerun_Button.Click += Rerun_Button_Click;
            // 
            // Enemy_Health_Bar
            // 
            Enemy_Health_Bar.Location = new System.Drawing.Point(-4, 174);
            Enemy_Health_Bar.Name = "Enemy_Health_Bar";
            Enemy_Health_Bar.Size = new System.Drawing.Size(307, 20);
            Enemy_Health_Bar.TabIndex = 6;
            // 
            // Damage_Button
            // 
            Damage_Button.Location = new System.Drawing.Point(11, 263);
            Damage_Button.Name = "Damage_Button";
            Damage_Button.Size = new System.Drawing.Size(110, 63);
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
            Heal_Button.Size = new System.Drawing.Size(110, 72);
            Heal_Button.TabIndex = 8;
            Heal_Button.Text = "Heal";
            Heal_Button.UseVisualStyleBackColor = true;
            Heal_Button.Click += Heal_Button_Click;
            // 
            // Updater
            // 
            Updater.Tick += Update;
            // 
            // Message_Box
            // 
            Message_Box.Location = new System.Drawing.Point(21, 708);
            Message_Box.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            Message_Box.Name = "Message_Box";
            Message_Box.Size = new System.Drawing.Size(493, 76);
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
            Sleep_Test_Button.Size = new System.Drawing.Size(121, 48);
            Sleep_Test_Button.TabIndex = 12;
            Sleep_Test_Button.Text = "Test Sleep Function";
            Sleep_Test_Button.UseVisualStyleBackColor = true;
            Sleep_Test_Button.Click += Sleep_Test_Button_Click;
            // 
            // Player_Health_Bar
            // 
            Player_Health_Bar.Location = new System.Drawing.Point(716, 618);
            Player_Health_Bar.Name = "Player_Health_Bar";
            Player_Health_Bar.Size = new System.Drawing.Size(306, 19);
            Player_Health_Bar.TabIndex = 13;
            // 
            // Potion_Test
            // 
            Potion_Test.Location = new System.Drawing.Point(377, 238);
            Potion_Test.Name = "Potion_Test";
            Potion_Test.Size = new System.Drawing.Size(219, 93);
            Potion_Test.TabIndex = 14;
            Potion_Test.Text = "Use Potion";
            Potion_Test.UseVisualStyleBackColor = true;
            Potion_Test.Click += Potion_Test_Click;
            // 
            // Test_Super_Potion
            // 
            Test_Super_Potion.Location = new System.Drawing.Point(513, 27);
            Test_Super_Potion.Name = "Test_Super_Potion";
            Test_Super_Potion.Size = new System.Drawing.Size(111, 122);
            Test_Super_Potion.TabIndex = 15;
            Test_Super_Potion.Text = "Use Super Potion";
            Test_Super_Potion.UseVisualStyleBackColor = true;
            Test_Super_Potion.Click += Test_Super_Potion_Click;
            // 
            // TestShowAttackBox
            // 
            TestShowAttackBox.Location = new System.Drawing.Point(4, 5);
            TestShowAttackBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            TestShowAttackBox.Name = "TestShowAttackBox";
            TestShowAttackBox.Size = new System.Drawing.Size(238, 72);
            TestShowAttackBox.TabIndex = 17;
            TestShowAttackBox.Text = "Attack";
            TestShowAttackBox.UseVisualStyleBackColor = true;
            TestShowAttackBox.Click += TestShowAttackBox_Click;
            // 
            // HealingItemButton
            // 
            HealingItemButton.Location = new System.Drawing.Point(250, 5);
            HealingItemButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            HealingItemButton.Name = "HealingItemButton";
            HealingItemButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            HealingItemButton.Size = new System.Drawing.Size(239, 72);
            HealingItemButton.TabIndex = 18;
            HealingItemButton.Text = "Healing Items";
            HealingItemButton.UseVisualStyleBackColor = true;
            HealingItemButton.Click += HealingItemButton_Click;
            // 
            // CatchPokemonButton
            // 
            CatchPokemonButton.Location = new System.Drawing.Point(4, 87);
            CatchPokemonButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            CatchPokemonButton.Name = "CatchPokemonButton";
            CatchPokemonButton.Size = new System.Drawing.Size(238, 73);
            CatchPokemonButton.TabIndex = 19;
            CatchPokemonButton.Text = "Catch Pokemon";
            CatchPokemonButton.UseVisualStyleBackColor = true;
            CatchPokemonButton.Click += CatchButton_Click;
            // 
            // RunButton
            // 
            RunButton.Location = new System.Drawing.Point(250, 87);
            RunButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            RunButton.Name = "RunButton";
            RunButton.Size = new System.Drawing.Size(239, 73);
            RunButton.TabIndex = 20;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // OptionPanelLayout
            // 
            OptionPanelLayout.BackColor = System.Drawing.Color.Transparent;
            OptionPanelLayout.ColumnCount = 2;
            OptionPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.Controls.Add(TestShowAttackBox, 0, 0);
            OptionPanelLayout.Controls.Add(HealingItemButton, 1, 0);
            OptionPanelLayout.Controls.Add(CatchPokemonButton, 0, 1);
            OptionPanelLayout.Controls.Add(RunButton, 1, 1);
            OptionPanelLayout.Location = new System.Drawing.Point(21, 789);
            OptionPanelLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            OptionPanelLayout.Name = "OptionPanelLayout";
            OptionPanelLayout.RowCount = 2;
            OptionPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.Size = new System.Drawing.Size(493, 165);
            OptionPanelLayout.TabIndex = 11;
            // 
            // Attack_Button_1
            // 
            Attack_Button_1.Location = new System.Drawing.Point(6, 8);
            Attack_Button_1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            Attack_Button_1.Name = "Attack_Button_1";
            Attack_Button_1.Size = new System.Drawing.Size(224, 104);
            Attack_Button_1.TabIndex = 9;
            Attack_Button_1.Text = "Attack 1";
            Attack_Button_1.UseVisualStyleBackColor = true;
            Attack_Button_1.Click += Attack_Button_1_Click;
            // 
            // Attack_Button_2
            // 
            Attack_Button_2.Location = new System.Drawing.Point(242, 8);
            Attack_Button_2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            Attack_Button_2.Name = "Attack_Button_2";
            Attack_Button_2.Size = new System.Drawing.Size(224, 104);
            Attack_Button_2.TabIndex = 10;
            Attack_Button_2.Text = "Attack 2";
            Attack_Button_2.UseVisualStyleBackColor = true;
            Attack_Button_2.Click += Attack_Button_2_Click;
            // 
            // AttackPanelLayout
            // 
            AttackPanelLayout.BackColor = System.Drawing.Color.Transparent;
            AttackPanelLayout.ColumnCount = 2;
            AttackPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.Controls.Add(Attack_Button_1, 0, 0);
            AttackPanelLayout.Controls.Add(Attack_Button_2, 1, 0);
            AttackPanelLayout.Location = new System.Drawing.Point(533, 713);
            AttackPanelLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            AttackPanelLayout.Name = "AttackPanelLayout";
            AttackPanelLayout.RowCount = 2;
            AttackPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.Size = new System.Drawing.Size(472, 241);
            AttackPanelLayout.TabIndex = 16;
            AttackPanelLayout.Visible = false;
            // 
            // UsePokeballButton
            // 
            UsePokeballButton.Location = new System.Drawing.Point(4, 5);
            UsePokeballButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            UsePokeballButton.Name = "UsePokeballButton";
            UsePokeballButton.Size = new System.Drawing.Size(230, 113);
            UsePokeballButton.TabIndex = 17;
            UsePokeballButton.Text = "Pokeball";
            UsePokeballButton.UseVisualStyleBackColor = true;
            UsePokeballButton.Click += UsePokeballButton_Click;
            // 
            // UseGreatBallButton
            // 
            UseGreatBallButton.Location = new System.Drawing.Point(242, 5);
            UseGreatBallButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            UseGreatBallButton.Name = "UseGreatBallButton";
            UseGreatBallButton.Size = new System.Drawing.Size(230, 113);
            UseGreatBallButton.TabIndex = 18;
            UseGreatBallButton.Text = "Greatball";
            UseGreatBallButton.UseVisualStyleBackColor = true;
            UseGreatBallButton.Click += UseGreatBallButton_Click;
            // 
            // UseUltraBallButton
            // 
            UseUltraBallButton.Location = new System.Drawing.Point(4, 128);
            UseUltraBallButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            UseUltraBallButton.Name = "UseUltraBallButton";
            UseUltraBallButton.Size = new System.Drawing.Size(230, 113);
            UseUltraBallButton.TabIndex = 19;
            UseUltraBallButton.Text = "Ultraball";
            UseUltraBallButton.UseVisualStyleBackColor = true;
            UseUltraBallButton.Click += UseUltraBallButton_Click;
            // 
            // UseMasterBallButton
            // 
            UseMasterBallButton.Location = new System.Drawing.Point(242, 128);
            UseMasterBallButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            UseMasterBallButton.Name = "UseMasterBallButton";
            UseMasterBallButton.Size = new System.Drawing.Size(230, 113);
            UseMasterBallButton.TabIndex = 20;
            UseMasterBallButton.Text = "Masterball";
            UseMasterBallButton.UseVisualStyleBackColor = true;
            UseMasterBallButton.Click += UseMasterBallButton_Click;
            // 
            // PokeballPanelLayout
            // 
            PokeballPanelLayout.BackColor = System.Drawing.Color.Transparent;
            PokeballPanelLayout.ColumnCount = 2;
            PokeballPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.Controls.Add(UsePokeballButton, 0, 0);
            PokeballPanelLayout.Controls.Add(UseMasterBallButton, 1, 1);
            PokeballPanelLayout.Controls.Add(UseGreatBallButton, 1, 0);
            PokeballPanelLayout.Controls.Add(UseUltraBallButton, 0, 1);
            PokeballPanelLayout.Location = new System.Drawing.Point(533, 708);
            PokeballPanelLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            PokeballPanelLayout.Name = "PokeballPanelLayout";
            PokeballPanelLayout.RowCount = 2;
            PokeballPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.Size = new System.Drawing.Size(476, 246);
            PokeballPanelLayout.TabIndex = 21;
            PokeballPanelLayout.Visible = false;
            // 
            // pokeballPictureBox
            // 
            pokeballPictureBox.BackColor = System.Drawing.Color.Transparent;
            pokeballPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pokeballPictureBox.Location = new System.Drawing.Point(687, 249);
            pokeballPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pokeballPictureBox.Name = "pokeballPictureBox";
            pokeballPictureBox.Size = new System.Drawing.Size(226, 216);
            pokeballPictureBox.TabIndex = 22;
            pokeballPictureBox.TabStop = false;
            pokeballPictureBox.Visible = false;
            // 
            // Battle_Screen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.battle_screen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1022, 978);
            Controls.Add(pokeballPictureBox);
            Controls.Add(PokeballPanelLayout);
            Controls.Add(AttackPanelLayout);
            Controls.Add(OptionPanelLayout);
            Controls.Add(Test_Super_Potion);
            Controls.Add(Potion_Test);
            Controls.Add(Player_Health_Bar);
            Controls.Add(Sleep_Test_Button);
            Controls.Add(Message_Box);
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
            OptionPanelLayout.ResumeLayout(false);
            AttackPanelLayout.ResumeLayout(false);
            PokeballPanelLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pokeballPictureBox).EndInit();
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
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Label Message_Box;
        private System.Windows.Forms.Timer Break_Timer;
        private System.Windows.Forms.Button Sleep_Test_Button;
        private System.Windows.Forms.ProgressBar Player_Health_Bar;
        private System.Windows.Forms.Button Potion_Test;
        private System.Windows.Forms.Button Test_Super_Potion;
        private System.Windows.Forms.Button TestShowAttackBox;
        private System.Windows.Forms.Button HealingItemButton;
        private System.Windows.Forms.Button CatchPokemonButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TableLayoutPanel OptionPanelLayout;
        private System.Windows.Forms.Button Attack_Button_1;
        private System.Windows.Forms.Button Attack_Button_2;
        private System.Windows.Forms.TableLayoutPanel AttackPanelLayout;
        private System.Windows.Forms.Button UsePokeballButton;
        private System.Windows.Forms.Button UseGreatBallButton;
        private System.Windows.Forms.Button UseUltraBallButton;
        private System.Windows.Forms.Button UseMasterBallButton;
        private System.Windows.Forms.TableLayoutPanel PokeballPanelLayout;
        private System.Windows.Forms.PictureBox pokeballPictureBox;
    }
}