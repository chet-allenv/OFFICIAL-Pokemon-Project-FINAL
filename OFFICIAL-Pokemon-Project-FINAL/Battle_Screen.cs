using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    public partial class Battle_Screen : Form
    {

        System.Timers.Timer sleepTimer = new System.Timers.Timer(1000);
        volatile int time;

        private Pokemon enemyPokemon;
        private Pokemon playerPokemon;

        private bool is_Player_Turn = false;
        private bool is_Attack_Button_Pressed = false;

        private readonly Random rng = new Random();

        public List<HealingItem> inventory = [new Potion(), new SuperPotion(), new HyperPotion()];

        public int turnNumber = 0;

        public Battle_Screen()
        {
            InitializeComponent();

            enemyPokemon = Pick_Pokemon();
            playerPokemon = Pick_Pokemon();

            Enemy_Health_Bar.Maximum = enemyPokemon.health;
            Enemy_Health_Bar.Value = enemyPokemon.health;

            Player_Health_Bar.Maximum = playerPokemon.health;
            Player_Health_Bar.Value = playerPokemon.health;
        }

        private void Update(object sender, EventArgs e)
        {
            if (!enemyPokemon.Is_Alive())
            {
                Enemy_Sprite.BackgroundImage = null;
                Message_Box.Text = $"Enemy {enemyPokemon.name} has died";
            }

            else if (!playerPokemon.Is_Alive())
            {
                Player_Sprite.BackgroundImage = null;
                Message_Box.Text = $"Your {playerPokemon.name} has died";
            }
        }

        public void Delay(int delay = 1)
        {
            time = 0;

            sleepTimer.Elapsed += new System.Timers.ElapsedEventHandler(SleepTimer_Elapsed);
            sleepTimer.Start();
            while (time < delay) ;
            sleepTimer.Stop();
            Debug.WriteLine("Break Ended!");
        }

        void SleepTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(time);
            time++;
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

            SetStartingTurnNumber();

            // MUST BE LAST
            Updater.Start();

            RunGame();
        }

        public async void Test_Sleep_Method()
        { 
            Message_Box.Text = "Im going to sleep";

            await Task.Run(() => Delay(5));

            Message_Box.Text = "I'm awake!";
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
            if (!is_Player_Turn)
            {
                return;
            }

            is_Attack_Button_Pressed = true;

            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 0);
            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].name}\nPP:{playerPokemon.moveSet[0].powerPoints}";

        }

        private void Attack_Button_2_Click(object sender, EventArgs e)
        {
            if (!is_Player_Turn)
            {
                return;
            }

            is_Attack_Button_Pressed = true;

            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 1);
            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].name}\nPP:{playerPokemon.moveSet[1].powerPoints}";

        }

        private void Update_Message_Box_Text(Pokemon user, Pokemon target, ProgressBar targetHealthBar, int attackNumber)
        {
            string message = $"{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}";

            message += $"\n{user.moveSet[attackNumber].Calculate_Type_Effectiveness(target).message}";

            Message_Box.Text = message;
        }

        private void Sleep_Test_Button_Click(object sender, EventArgs e)
        {
            Test_Sleep_Method();
        }

        public void SetStartingTurnNumber()
        {

            Debug.WriteLine($"Player speed {playerPokemon.speed}");
            Debug.WriteLine($"Enemy speed {enemyPokemon.speed}");

            switch (playerPokemon.speed >= enemyPokemon.speed)
            {
                case true:
                    turnNumber = 0;
                    Message_Box.Text = $"Your {playerPokemon.name} is faster than the enemy {enemyPokemon.name}. You get to go first!";
                    break;
                case false:
                    turnNumber = 1;
                    Message_Box.Text = $"The enemy {enemyPokemon.name} is faster than your {playerPokemon.name}. The enemy will go first!";
                    break;
            }
        }

        private void Potion_Test_Click(object sender, EventArgs e)
        {
            try
            {
                inventory[0].UseItem(Player_Health_Bar);
            }
            catch (Exception)
            {
                Message_Box.Text = "You have run out of potions";
            }
        }


        public async void RunGame()
        {

            await Task.Run(() => Delay(4));

            while (playerPokemon.Is_Alive() && enemyPokemon.Is_Alive())
            {
                if (turnNumber == 0)
                {
                    is_Player_Turn = true;

                    while (!is_Attack_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    await Task.Run(() => Delay(4));

                    is_Player_Turn = false;
                    is_Attack_Button_Pressed = false;
                    turnNumber = 1;
                }
                else
                {
                    int randAttackNum = rng.Next(0, 2);

                    Update_Message_Box_Text(enemyPokemon, playerPokemon, Player_Health_Bar, randAttackNum);

                    await Task.Run(() => Delay(4));

                    turnNumber = 0;
                }
            }

            
        }

        private void Test_Super_Potion_Click(object sender, EventArgs e)
        {
            inventory[1].UseItem(Player_Health_Bar);
        }

        private void Break_Timer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
