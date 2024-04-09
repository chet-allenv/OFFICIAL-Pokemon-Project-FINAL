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
            this.Quit_Button = new System.Windows.Forms.Button();
            this.Play_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Quit_Button
            // 
            this.Quit_Button.BackgroundImage = global::OFFICIAL_Pokemon_Project_FINAL.Properties.Resources.quit_button;
            this.Quit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Quit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Quit_Button.Location = new System.Drawing.Point(302, 576);
            this.Quit_Button.Name = "Quit_Button";
            this.Quit_Button.Size = new System.Drawing.Size(327, 116);
            this.Quit_Button.TabIndex = 1;
            this.Quit_Button.UseVisualStyleBackColor = true;
            this.Quit_Button.Click += new System.EventHandler(this.Quit_Button_Click);
            // 
            // Play_Button
            // 
            this.Play_Button.BackgroundImage = global::OFFICIAL_Pokemon_Project_FINAL.Properties.Resources.play_button;
            this.Play_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Play_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play_Button.Location = new System.Drawing.Point(302, 400);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(327, 116);
            this.Play_Button.TabIndex = 0;
            this.Play_Button.UseVisualStyleBackColor = true;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // Start_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(920, 782);
            this.Controls.Add(this.Quit_Button);
            this.Controls.Add(this.Play_Button);
            this.Name = "Start_Screen";
            this.Text = "Pokemon Project";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Button Quit_Button;
    }
}