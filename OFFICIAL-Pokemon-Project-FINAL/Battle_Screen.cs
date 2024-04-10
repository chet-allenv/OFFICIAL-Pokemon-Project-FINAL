using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    public partial class Battle_Screen : Form
    {

        private Pokemon enemyPokemon;
        private Pokemon playerPokemon;

        private readonly Random rng = new Random();

        public Battle_Screen()
        {
            InitializeComponent();

            enemyPokemon = Pick_Pokemon();
            playerPokemon = Pick_Pokemon();

            Enemy_Health_Bar.Maximum = enemyPokemon.health;
            Enemy_Health_Bar.Value = enemyPokemon.health;
        }

        private void Update(object sender, EventArgs e)
        {
            if (!Check_Enemy_Alive())
            {
                Enemy_Sprite.BackgroundImage = null;
                Message_Box.Text = $"Enemy {Enemy_Name.Text} has died";
            }
        }

        private bool Check_Enemy_Alive()
        {
            if (Enemy_Health_Bar.Value <= 0)
            {
                return false;
            }

            return true;
        }

        private void Battle_Screen_Load(object sender, EventArgs e)
        {

            Enemy_Sprite.BackgroundImage = enemyPokemon.Get_Front_Sprite();
            Player_Sprite.BackgroundImage = playerPokemon.Get_Back_Sprite();

            Enemy_Name.Text = enemyPokemon.name;
            Player_Name.Text = playerPokemon.name;

            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].name}\nPP:{playerPokemon.moveSet[0].powerPoints}";
            Attack_Button_1.BackColor = Decide_Type_Color(playerPokemon.moveSet[0].moveType);

            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].name}\nPP:{playerPokemon.moveSet[1].powerPoints}";
            Attack_Button_2.BackColor = Decide_Type_Color(playerPokemon.moveSet[1].moveType);

            // MUST BE LAST
            Updater.Start();
        }

        private Pokemon Pick_Pokemon()
        {

            switch (rng.Next(3))
            {
                case 0:
                    return new Bulbasaur();
                case 1:
                    return new Charmander();
                case 2:
                    return new Squirtle();
            }

            return null;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Rerun_Button_Click(object sender, EventArgs e)
        {
            this.Close();

            var newBattleScreen = new Battle_Screen();

            newBattleScreen.Show();
        }

        private void Damage_Button_Click(object sender, EventArgs e)
        {
            if (Enemy_Health_Bar.Value > 10)
            {
                Enemy_Health_Bar.Value -= 10;
            }

            else
            {
                Enemy_Health_Bar.Value = 0;
            }
        }

        private void Heal_Button_Click(object sender, EventArgs e)
        {
            if (Enemy_Health_Bar.Value + 10 > Enemy_Health_Bar.Maximum)
            {
                Enemy_Health_Bar.Value = Enemy_Health_Bar.Maximum;
            }

            else
            {
                Enemy_Health_Bar.Value += 10;
            }
        }

        private Color Decide_Type_Color(string type)
        {

            if (type.Equals("Fire"))
            {
                return Color.Red;
            }

            else if (type.Equals("Water"))
            {
                return Color.Blue;
            }

            else if (type.Equals("Grass"))
            {
                return Color.Green;
            }

            else if (type.Equals("Normal"))
            {
                return Color.Gray;
            }

            return Color.White;
        }

        private void Attack_Button_1_Click(object sender, EventArgs e)
        {
            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 0);
            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].name}\nPP:{playerPokemon.moveSet[0].powerPoints}";
        }

        private void Attack_Button_2_Click(object sender, EventArgs e)
        {
            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 1);
            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].name}\nPP:{playerPokemon.moveSet[1].powerPoints}";
        }

        private void Update_Message_Box_Text(Pokemon user, Pokemon target, ProgressBar targetHealthBar, int attackNumber)
        {
            string message = $"{user.moveSet[attackNumber].Calculate_Type_Effectiveness(target).message}";

            message = !message.Equals("") ? message + $"\n{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}" : $"{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}";

            Message_Box.Text = message;
        }
    }
}
