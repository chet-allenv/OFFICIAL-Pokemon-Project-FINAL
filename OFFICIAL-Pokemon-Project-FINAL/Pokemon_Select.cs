using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    public partial class Pokemon_Select : Form
    {
        public Pokemon_Select()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when a generic Pokemon select component is clicked.
        /// </summary>
        /// <param name="pokemon"> The pokemon object that correlates with the pressed button. </param>
        private void Generic_PokeSelectButton_Click(Pokemon pokemon)
        {
            // Closes the current form
            this.Close();

            // Creates a new instance of the Battle_Screen form
            Battle_Screen myBS = new()
            {
                // Sets the playerPokemon parameter to the desired pokemon
                playerPokemon = pokemon
            };
            
            // Shows the newly created Battle_Screen form.
            myBS.Show();
        }

        /// <summary>
        /// Event handler for when the ChainSprout component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void ChainSproutButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new Chainsprout instance
            Generic_PokeSelectButton_Click(new Chainsprout());
        }

        /// <summary>
        /// Event handler for when the Nautighoul component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void NautighoulButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new Nautighoul instance
            Generic_PokeSelectButton_Click(new Nautighoul());
        }

        /// <summary>
        /// Event handler for when the Wattrus component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void WattrusButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new Wattrus instance
            Generic_PokeSelectButton_Click(new Wattrus());
        }

        /// <summary>
        /// Event handler for when the Rockmoth component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void RockmothButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new Rockmoth instance
            Generic_PokeSelectButton_Click(new Rockmoth());
        }

        /// <summary>
        /// Event handler for when the PsyFly component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void PsyflyButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new PsychicFlying instance
            Generic_PokeSelectButton_Click(new PsychicFlying());
        }

        /// <summary>
        /// Event handler for when the FireDrag component is clicked
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void FiredragButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeSelectButton_Click() method with a new FireDragon instance
            Generic_PokeSelectButton_Click(new FireDragon());
        }
    }
}
