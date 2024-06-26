﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    /// <summary>
    /// This is the opening screen that is shown to the users. Gives them the option to play or quit the game.
    /// </summary>
    public partial class Start_Screen : Form
    {
        // Constructor, it initializes all components.
        public Start_Screen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is called when the play button is pressed and it opens the next scene and closes the current.
        /// </summary>
        private void Play_Button_Click(object sender, EventArgs e)
        {
            // Creates a new Battle_Screen instance
            var mySelect = new Pokemon_Select();

            // Shows the newly created Battle_Screen instance
            mySelect.Show();

            // Closes the currently open Start_Screen form
            this.Close();
        }

        /// <summary>
        /// This method is called when the quit button is pressed and it closes the program.
        /// </summary>
        private void Quit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exits the application
        }
    }
}
