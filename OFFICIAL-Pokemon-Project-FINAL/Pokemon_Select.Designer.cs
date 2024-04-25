namespace OFFICIAL_Pokemon_Project_FINAL
{
    partial class Pokemon_Select
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pokemon_Select));
            chainSproutButton = new System.Windows.Forms.Button();
            nautighoulButton = new System.Windows.Forms.Button();
            wattrusButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // chainSproutButton
            // 
            chainSproutButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("chainSproutButton.BackgroundImage");
            chainSproutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            chainSproutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            chainSproutButton.Location = new System.Drawing.Point(59, 51);
            chainSproutButton.Name = "chainSproutButton";
            chainSproutButton.Size = new System.Drawing.Size(128, 128);
            chainSproutButton.TabIndex = 0;
            chainSproutButton.UseVisualStyleBackColor = true;
            chainSproutButton.Click += chainSproutButton_Click;
            // 
            // nautighoulButton
            // 
            nautighoulButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("nautighoulButton.BackgroundImage");
            nautighoulButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            nautighoulButton.Cursor = System.Windows.Forms.Cursors.Hand;
            nautighoulButton.Location = new System.Drawing.Point(288, 51);
            nautighoulButton.Name = "nautighoulButton";
            nautighoulButton.Size = new System.Drawing.Size(128, 128);
            nautighoulButton.TabIndex = 1;
            nautighoulButton.UseVisualStyleBackColor = true;
            nautighoulButton.Click += nautighoulButton_Click;
            // 
            // wattrusButton
            // 
            wattrusButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("wattrusButton.BackgroundImage");
            wattrusButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            wattrusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            wattrusButton.Location = new System.Drawing.Point(508, 51);
            wattrusButton.Name = "wattrusButton";
            wattrusButton.Size = new System.Drawing.Size(128, 128);
            wattrusButton.TabIndex = 2;
            wattrusButton.UseVisualStyleBackColor = true;
            wattrusButton.Click += wattrusButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(86, 182);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 15);
            label1.TabIndex = 3;
            label1.Text = "Chainsprout";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(318, 182);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "Nautighoul";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(549, 182);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 15);
            label3.TabIndex = 5;
            label3.Text = "Wattrus";
            // 
            // Pokemon_Select
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(715, 587);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(wattrusButton);
            Controls.Add(nautighoulButton);
            Controls.Add(chainSproutButton);
            Name = "Pokemon_Select";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button chainSproutButton;
        private System.Windows.Forms.Button nautighoulButton;
        private System.Windows.Forms.Button wattrusButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}