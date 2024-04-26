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

        private void chainSproutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new Chainsprout();
            myBS.Show();
        }

        private void nautighoulButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new Nautighoul();
            myBS.Show();
        }

        private void wattrusButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new Wattrus();
            myBS.Show();
        }

        private void rockmothButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new Rockmoth();
            myBS.Show();
        }

        private void psyflyButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new PsychicFlying();
            myBS.Show();
        }

        private void firedragButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Battle_Screen myBS = new();
            myBS.playerPokemon = new FireDragon();
            myBS.Show();
        }
    }
}
