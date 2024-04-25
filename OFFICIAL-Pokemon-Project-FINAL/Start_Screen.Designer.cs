namespace OFFICIAL_Pokemon_Project_FINAL
{
    partial class Start_Screen
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
            Quit_Button = new System.Windows.Forms.Button();
            Play_Button = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Quit_Button
            // 
            Quit_Button.BackgroundImage = Properties.Resources.quit_button;
            Quit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Quit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Quit_Button.Location = new System.Drawing.Point(605, 785);
            Quit_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Quit_Button.Name = "Quit_Button";
            Quit_Button.Size = new System.Drawing.Size(363, 145);
            Quit_Button.TabIndex = 1;
            Quit_Button.UseVisualStyleBackColor = true;
            Quit_Button.Click += Quit_Button_Click;
            // 
            // Play_Button
            // 
            Play_Button.BackgroundImage = Properties.Resources.play_button;
            Play_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Play_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            Play_Button.Location = new System.Drawing.Point(94, 785);
            Play_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Play_Button.Name = "Play_Button";
            Play_Button.Size = new System.Drawing.Size(363, 145);
            Play_Button.TabIndex = 0;
            Play_Button.UseVisualStyleBackColor = true;
            Play_Button.Click += Play_Button_Click;
            // 
            // Start_Screen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 64, 0);
            BackgroundImage = Properties.Resources.Title_Screen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1022, 978);
            Controls.Add(Quit_Button);
            Controls.Add(Play_Button);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Start_Screen";
            Text = "Pokemon Project";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Button Quit_Button;
    }
}