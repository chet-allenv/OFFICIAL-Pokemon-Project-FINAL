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
            Updater = new System.Windows.Forms.Timer(components);
            Message_Box = new System.Windows.Forms.Label();
            Sleep_Test_Button = new System.Windows.Forms.Button();
            Player_Health_Bar = new System.Windows.Forms.ProgressBar();
            ShowAttackBox = new System.Windows.Forms.Button();
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
            healingItemTableLayout = new System.Windows.Forms.TableLayoutPanel();
            potionButton = new System.Windows.Forms.Button();
            fullHealButton = new System.Windows.Forms.Button();
            superPotionButton = new System.Windows.Forms.Button();
            hyperPotionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).BeginInit();
            OptionPanelLayout.SuspendLayout();
            AttackPanelLayout.SuspendLayout();
            PokeballPanelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokeballPictureBox).BeginInit();
            healingItemTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // Enemy_Sprite
            // 
            Enemy_Sprite.BackColor = System.Drawing.Color.Transparent;
            Enemy_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Enemy_Sprite.Location = new System.Drawing.Point(426, 42);
            Enemy_Sprite.Margin = new System.Windows.Forms.Padding(2);
            Enemy_Sprite.Name = "Enemy_Sprite";
            Enemy_Sprite.Size = new System.Drawing.Size(262, 237);
            Enemy_Sprite.TabIndex = 0;
            Enemy_Sprite.TabStop = false;
            // 
            // Player_Sprite
            // 
            Player_Sprite.BackColor = System.Drawing.Color.Transparent;
            Player_Sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Player_Sprite.Location = new System.Drawing.Point(71, 237);
            Player_Sprite.Margin = new System.Windows.Forms.Padding(2);
            Player_Sprite.Name = "Player_Sprite";
            Player_Sprite.Size = new System.Drawing.Size(217, 177);
            Player_Sprite.TabIndex = 1;
            Player_Sprite.TabStop = false;
            // 
            // Enemy_Name
            // 
            Enemy_Name.AutoSize = true;
            Enemy_Name.BackColor = System.Drawing.Color.Transparent;
            Enemy_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Enemy_Name.ForeColor = System.Drawing.SystemColors.Control;
            Enemy_Name.Location = new System.Drawing.Point(-3, 49);
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
            Player_Name.ForeColor = System.Drawing.SystemColors.Control;
            Player_Name.Location = new System.Drawing.Point(436, 314);
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
            Exit_Button.Location = new System.Drawing.Point(8, 4);
            Exit_Button.Margin = new System.Windows.Forms.Padding(2);
            Exit_Button.Name = "Exit_Button";
            Exit_Button.Size = new System.Drawing.Size(93, 29);
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
            Rerun_Button.Location = new System.Drawing.Point(106, 4);
            Rerun_Button.Margin = new System.Windows.Forms.Padding(2);
            Rerun_Button.Name = "Rerun_Button";
            Rerun_Button.Size = new System.Drawing.Size(111, 29);
            Rerun_Button.TabIndex = 5;
            Rerun_Button.Text = "RERUN";
            Rerun_Button.UseVisualStyleBackColor = false;
            Rerun_Button.Click += Rerun_Button_Click;
            // 
            // Enemy_Health_Bar
            // 
            Enemy_Health_Bar.Location = new System.Drawing.Point(-3, 104);
            Enemy_Health_Bar.Margin = new System.Windows.Forms.Padding(2);
            Enemy_Health_Bar.Name = "Enemy_Health_Bar";
            Enemy_Health_Bar.Size = new System.Drawing.Size(215, 12);
            Enemy_Health_Bar.TabIndex = 6;
            // 
            // Damage_Button
            // 
            Damage_Button.Location = new System.Drawing.Point(8, 158);
            Damage_Button.Margin = new System.Windows.Forms.Padding(2);
            Damage_Button.Name = "Damage_Button";
            Damage_Button.Size = new System.Drawing.Size(77, 38);
            Damage_Button.TabIndex = 7;
            Damage_Button.Text = "DO 10 DAMAGE";
            Damage_Button.UseVisualStyleBackColor = true;
            Damage_Button.Click += Damage_Button_Click;
            // 
            // Heal_Button
            // 
            Heal_Button.Location = new System.Drawing.Point(106, 156);
            Heal_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Heal_Button.Name = "Heal_Button";
            Heal_Button.Size = new System.Drawing.Size(77, 43);
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
            Message_Box.Location = new System.Drawing.Point(15, 425);
            Message_Box.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Message_Box.Name = "Message_Box";
            Message_Box.Size = new System.Drawing.Size(345, 46);
            Message_Box.TabIndex = 11;
            Message_Box.Text = "Place holder";
            // 
            // Sleep_Test_Button
            // 
            Sleep_Test_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Sleep_Test_Button.Location = new System.Drawing.Point(238, 7);
            Sleep_Test_Button.Margin = new System.Windows.Forms.Padding(2);
            Sleep_Test_Button.Name = "Sleep_Test_Button";
            Sleep_Test_Button.Size = new System.Drawing.Size(85, 29);
            Sleep_Test_Button.TabIndex = 12;
            Sleep_Test_Button.Text = "Test Sleep Function";
            Sleep_Test_Button.UseVisualStyleBackColor = true;
            Sleep_Test_Button.Click += Sleep_Test_Button_Click;
            // 
            // Player_Health_Bar
            // 
            Player_Health_Bar.Location = new System.Drawing.Point(501, 371);
            Player_Health_Bar.Margin = new System.Windows.Forms.Padding(2);
            Player_Health_Bar.Name = "Player_Health_Bar";
            Player_Health_Bar.Size = new System.Drawing.Size(214, 11);
            Player_Health_Bar.TabIndex = 13;
            // 
            // ShowAttackBox
            // 
            ShowAttackBox.Location = new System.Drawing.Point(3, 3);
            ShowAttackBox.Name = "ShowAttackBox";
            ShowAttackBox.Size = new System.Drawing.Size(166, 43);
            ShowAttackBox.TabIndex = 17;
            ShowAttackBox.Text = "Attack";
            ShowAttackBox.UseVisualStyleBackColor = true;
            ShowAttackBox.Click += ShowAttackBox_Click;
            // 
            // HealingItemButton
            // 
            HealingItemButton.Location = new System.Drawing.Point(175, 3);
            HealingItemButton.Name = "HealingItemButton";
            HealingItemButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            HealingItemButton.Size = new System.Drawing.Size(167, 43);
            HealingItemButton.TabIndex = 18;
            HealingItemButton.Text = "Healing Items";
            HealingItemButton.UseVisualStyleBackColor = true;
            HealingItemButton.Click += HealingItemButton_Click;
            // 
            // CatchPokemonButton
            // 
            CatchPokemonButton.Location = new System.Drawing.Point(3, 52);
            CatchPokemonButton.Name = "CatchPokemonButton";
            CatchPokemonButton.Size = new System.Drawing.Size(166, 44);
            CatchPokemonButton.TabIndex = 19;
            CatchPokemonButton.Text = "Catch Pokemon";
            CatchPokemonButton.UseVisualStyleBackColor = true;
            CatchPokemonButton.Click += CatchButton_Click;
            // 
            // RunButton
            // 
            RunButton.Location = new System.Drawing.Point(175, 52);
            RunButton.Name = "RunButton";
            RunButton.Size = new System.Drawing.Size(167, 44);
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
            OptionPanelLayout.Controls.Add(ShowAttackBox, 0, 0);
            OptionPanelLayout.Controls.Add(HealingItemButton, 1, 0);
            OptionPanelLayout.Controls.Add(CatchPokemonButton, 0, 1);
            OptionPanelLayout.Controls.Add(RunButton, 1, 1);
            OptionPanelLayout.Location = new System.Drawing.Point(15, 473);
            OptionPanelLayout.Name = "OptionPanelLayout";
            OptionPanelLayout.RowCount = 2;
            OptionPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            OptionPanelLayout.Size = new System.Drawing.Size(345, 99);
            OptionPanelLayout.TabIndex = 11;
            // 
            // Attack_Button_1
            // 
            Attack_Button_1.Location = new System.Drawing.Point(4, 5);
            Attack_Button_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Attack_Button_1.Name = "Attack_Button_1";
            Attack_Button_1.Size = new System.Drawing.Size(157, 62);
            Attack_Button_1.TabIndex = 9;
            Attack_Button_1.Text = "Attack 1";
            Attack_Button_1.UseVisualStyleBackColor = true;
            Attack_Button_1.Click += Attack_Button_1_Click;
            // 
            // Attack_Button_2
            // 
            Attack_Button_2.Location = new System.Drawing.Point(169, 5);
            Attack_Button_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Attack_Button_2.Name = "Attack_Button_2";
            Attack_Button_2.Size = new System.Drawing.Size(157, 62);
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
            AttackPanelLayout.Location = new System.Drawing.Point(373, 428);
            AttackPanelLayout.Name = "AttackPanelLayout";
            AttackPanelLayout.RowCount = 2;
            AttackPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            AttackPanelLayout.Size = new System.Drawing.Size(330, 145);
            AttackPanelLayout.TabIndex = 16;
            AttackPanelLayout.Visible = false;
            // 
            // UsePokeballButton
            // 
            UsePokeballButton.Location = new System.Drawing.Point(3, 3);
            UsePokeballButton.Name = "UsePokeballButton";
            UsePokeballButton.Size = new System.Drawing.Size(160, 68);
            UsePokeballButton.TabIndex = 17;
            UsePokeballButton.Text = "Pokeball";
            UsePokeballButton.UseVisualStyleBackColor = true;
            UsePokeballButton.Click += UsePokeballButton_Click;
            // 
            // UseGreatBallButton
            // 
            UseGreatBallButton.Location = new System.Drawing.Point(169, 3);
            UseGreatBallButton.Name = "UseGreatBallButton";
            UseGreatBallButton.Size = new System.Drawing.Size(161, 68);
            UseGreatBallButton.TabIndex = 18;
            UseGreatBallButton.Text = "Greatball";
            UseGreatBallButton.UseVisualStyleBackColor = true;
            UseGreatBallButton.Click += UseGreatBallButton_Click;
            // 
            // UseUltraBallButton
            // 
            UseUltraBallButton.Location = new System.Drawing.Point(3, 77);
            UseUltraBallButton.Name = "UseUltraBallButton";
            UseUltraBallButton.Size = new System.Drawing.Size(160, 68);
            UseUltraBallButton.TabIndex = 19;
            UseUltraBallButton.Text = "Ultraball";
            UseUltraBallButton.UseVisualStyleBackColor = true;
            UseUltraBallButton.Click += UseUltraBallButton_Click;
            // 
            // UseMasterBallButton
            // 
            UseMasterBallButton.Location = new System.Drawing.Point(169, 77);
            UseMasterBallButton.Name = "UseMasterBallButton";
            UseMasterBallButton.Size = new System.Drawing.Size(161, 68);
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
            PokeballPanelLayout.Location = new System.Drawing.Point(373, 425);
            PokeballPanelLayout.Name = "PokeballPanelLayout";
            PokeballPanelLayout.RowCount = 2;
            PokeballPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            PokeballPanelLayout.Size = new System.Drawing.Size(333, 148);
            PokeballPanelLayout.TabIndex = 21;
            PokeballPanelLayout.Visible = false;
            // 
            // pokeballPictureBox
            // 
            pokeballPictureBox.BackColor = System.Drawing.Color.Transparent;
            pokeballPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pokeballPictureBox.Location = new System.Drawing.Point(515, 213);
            pokeballPictureBox.Name = "pokeballPictureBox";
            pokeballPictureBox.Size = new System.Drawing.Size(72, 66);
            pokeballPictureBox.TabIndex = 22;
            pokeballPictureBox.TabStop = false;
            pokeballPictureBox.Visible = false;
            // 
            // healingItemTableLayout
            // 
            healingItemTableLayout.BackColor = System.Drawing.Color.Transparent;
            healingItemTableLayout.ColumnCount = 2;
            healingItemTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            healingItemTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            healingItemTableLayout.Controls.Add(potionButton, 0, 0);
            healingItemTableLayout.Controls.Add(fullHealButton, 1, 1);
            healingItemTableLayout.Controls.Add(superPotionButton, 1, 0);
            healingItemTableLayout.Controls.Add(hyperPotionButton, 0, 1);
            healingItemTableLayout.Location = new System.Drawing.Point(370, 424);
            healingItemTableLayout.Name = "healingItemTableLayout";
            healingItemTableLayout.RowCount = 2;
            healingItemTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            healingItemTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            healingItemTableLayout.Size = new System.Drawing.Size(333, 148);
            healingItemTableLayout.TabIndex = 23;
            healingItemTableLayout.Visible = false;
            // 
            // potionButton
            // 
            potionButton.Location = new System.Drawing.Point(3, 3);
            potionButton.Name = "potionButton";
            potionButton.Size = new System.Drawing.Size(160, 68);
            potionButton.TabIndex = 17;
            potionButton.Text = "Use Potion";
            potionButton.UseVisualStyleBackColor = true;
            potionButton.Click += potionButton_Click;
            // 
            // fullHealButton
            // 
            fullHealButton.Location = new System.Drawing.Point(169, 77);
            fullHealButton.Name = "fullHealButton";
            fullHealButton.Size = new System.Drawing.Size(161, 68);
            fullHealButton.TabIndex = 20;
            fullHealButton.Text = "Use Full Heal";
            fullHealButton.UseVisualStyleBackColor = true;
            fullHealButton.Click += fullHealButton_Click;
            // 
            // superPotionButton
            // 
            superPotionButton.Location = new System.Drawing.Point(169, 3);
            superPotionButton.Name = "superPotionButton";
            superPotionButton.Size = new System.Drawing.Size(161, 68);
            superPotionButton.TabIndex = 18;
            superPotionButton.Text = "Use Super Potion";
            superPotionButton.UseVisualStyleBackColor = true;
            superPotionButton.Click += superPotionButton_Click;
            // 
            // hyperPotionButton
            // 
            hyperPotionButton.Location = new System.Drawing.Point(3, 77);
            hyperPotionButton.Name = "hyperPotionButton";
            hyperPotionButton.Size = new System.Drawing.Size(160, 68);
            hyperPotionButton.TabIndex = 19;
            hyperPotionButton.Text = "Use Hyper Potion";
            hyperPotionButton.UseVisualStyleBackColor = true;
            hyperPotionButton.Click += hyperPotionButton_Click;
            // 
            // Battle_Screen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.battle_screen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(715, 587);
            Controls.Add(healingItemTableLayout);
            Controls.Add(pokeballPictureBox);
            Controls.Add(PokeballPanelLayout);
            Controls.Add(AttackPanelLayout);
            Controls.Add(OptionPanelLayout);
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
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Battle_Screen";
            Text = " ";
            Load += Battle_Screen_Load;
            ((System.ComponentModel.ISupportInitialize)Enemy_Sprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)Player_Sprite).EndInit();
            OptionPanelLayout.ResumeLayout(false);
            AttackPanelLayout.ResumeLayout(false);
            PokeballPanelLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pokeballPictureBox).EndInit();
            healingItemTableLayout.ResumeLayout(false);
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
        private System.Windows.Forms.Button Sleep_Test_Button;
        private System.Windows.Forms.ProgressBar Player_Health_Bar;
        private System.Windows.Forms.Button ShowAttackBox;
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
        private System.Windows.Forms.TableLayoutPanel healingItemTableLayout;
        private System.Windows.Forms.Button potionButton;
        private System.Windows.Forms.Button fullHealButton;
        private System.Windows.Forms.Button superPotionButton;
        private System.Windows.Forms.Button hyperPotionButton;
    }
}