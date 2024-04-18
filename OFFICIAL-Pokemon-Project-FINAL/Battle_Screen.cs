using OFFICIAL_Pokemon_Project_FINAL.Properties;
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
        private bool is_Pokeball_Button_Pressed = false;
        private bool is_Option_Button_Pressed = false;

        private readonly Random rng = new Random();

        public List<HealingItem> inventory = [new Potion(), new SuperPotion(), new HyperPotion()];
        public List<GenericPokeball> pokeballs = [new Pokeball(), new GreatBall(), new UltraBall(), new MasterBall()];

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

            Debug.WriteLine(Enemy_Health_Bar.Value);
            Debug.WriteLine(enemyPokemon.health);
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

            UsePokeballButton.Text = $"Pokeball: {pokeballs[0].Amount}";
            UseGreatBallButton.Text = $"GreatBall: {pokeballs[1].Amount}";
            UseUltraBallButton.Text = $"UltraBall: {pokeballs[2].Amount}";
            UseMasterBallButton.Text = $"MasterBall: {pokeballs[3].Amount}";

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

            AttackPanelLayout.Visible = false;

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

            AttackPanelLayout.Visible = false;
        }

        private void Update_Message_Box_Text(Pokemon user, Pokemon target, ProgressBar targetHealthBar, int attackNumber)
        {
            string message = $"{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}";

            message += $"\n{user.moveSet[attackNumber].Calculate_Type_Effectiveness(target).message}";

            Message_Box.Text = message;
            TestShowAttackBox.Visible = true;
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

            await Task.Run(() => Delay(2));

            while (playerPokemon.Is_Alive() && enemyPokemon.Is_Alive())
            {
                if (turnNumber == 0)
                {
                    Message_Box.Text = "It's your turn, press the button of the option you would like to do!";

                    is_Player_Turn = true;

                    while (!is_Option_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    while (!is_Attack_Button_Pressed && !is_Pokeball_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    await Task.Run(() => Delay(2));


                    is_Player_Turn = false;
                    is_Attack_Button_Pressed = false;
                    is_Option_Button_Pressed = false;
                    is_Pokeball_Button_Pressed = false;

                    turnNumber = 1;
                }
                else
                {
                    
                    bool[] testedNums = [enemyPokemon.moveSet[0].powerPoints > 0, enemyPokemon.moveSet[1].powerPoints > 0];

                    bool outOfMoves = testedNums.All(var => var == false);

                    bool attackUsed = false;

                    
                    if (!outOfMoves)
                    {
                        while (!attackUsed)
                        {
                            int randAttackNum = rng.Next(0, 2);

                            if (testedNums[randAttackNum] == false)
                            {
                                continue;
                            }
                            else { Update_Message_Box_Text(enemyPokemon, playerPokemon, Player_Health_Bar, randAttackNum); attackUsed = true; }
                        }
                    }
                    else
                    {
                        Message_Box.Text = "The Enemy is out of usable moves! It ran around panicking!";
                    }

                     

                    await Task.Run(() => Delay(2));

                    turnNumber = 0;
                }

               
            }


        }

        private static void DoStatusEffect(Pokemon target)
        {
            if (!target.Status.Equals(""))
            {
                if (target.Status.ToLower().Equals("asleep"))
                {
                    // TO IMPLEMENT
                }
                if (target.Status.ToLower().Equals("frozen"))
                {
                    // TO IMPLEMENT
                }
                if (target.Status.ToLower().Equals("poisoned"))
                {
                    // TO IMPLEMENT
                }
                if (target.Status.ToLower().Equals("paralyzed"))
                {
                    // TO IMPLEMENT
                }
                if (target.Status.ToLower().Equals("burned"))
                {
                    // TO IMPLEMENT
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

        private void TestShowAttackBox_Click(object sender, EventArgs e)
        {
            if (!is_Player_Turn)
            {
                return;
            }
            AttackPanelLayout.Visible = true;
            is_Option_Button_Pressed = true;
        }

        private void CatchButton_Click(object sender, EventArgs e)
        {   
            if (!is_Player_Turn)
            {
                return;
            }

            is_Option_Button_Pressed = true;
            PokeballPanelLayout.Visible = true;
        }

        private void HealingItemButton_Click(object sender, EventArgs e)
        {

        }

        private void RunButton_Click(object sender, EventArgs e)
        {

        }

        private void UsePokeballButton_Click(object sender, EventArgs e)
        {
            Generic_PokeballButton_Click(0, Resources.pokeball);
            UsePokeballButton.Text = $"Pokeball: {pokeballs[0].Amount}";
        }

        private void Generic_PokeballButton_Click(int invNumber, Image image)
        {
            is_Pokeball_Button_Pressed = true;

            if (CheckAmountLeft(pokeballs[invNumber]) <= 0)
            {
                Message_Box.Text = $"You cannot use anymore {pokeballs[invNumber].Name}s, you have none remaining";
                return;
            }

            pokeballs[invNumber].Amount--;

            if (CatchPokemon(invNumber))
            {
                Message_Box.Text = $"You caught the {enemyPokemon.name} using a {pokeballs[invNumber].Name}!";
                Enemy_Sprite.Visible = false;
                pokeballPictureBox.Visible = true;
                pokeballPictureBox.BackgroundImage = image;
            }
            else
            {
                Message_Box.Text = $"You failed to catch the {enemyPokemon.name}";
            }

            PokeballPanelLayout.Visible = false;
        }
        private bool CatchPokemon(int inventoryNumber)
        {
            int testNumber = rng.Next(0, 101);

            int catchRate = (int)((pokeballs[inventoryNumber].Use(enemyPokemon, Enemy_Health_Bar) / 255) * 100);

            Debug.WriteLine($"Test Number: {testNumber}\nCatch Rate: {catchRate}\n Pokemon is caught: {catchRate >= testNumber}");

            if (catchRate >= 100) { return true; }

            return catchRate >= testNumber;
        }

        private static int CheckAmountLeft(Item item)
        {
            return item.Amount;
        }

        private void UseGreatBallButton_Click(object sender, EventArgs e)
        {
            Generic_PokeballButton_Click(1, Resources.greatball);
            UseGreatBallButton.Text = $"GreatBall: {pokeballs[1].Amount}";
        }

        private void UseUltraBallButton_Click(object sender, EventArgs e)
        {
            Generic_PokeballButton_Click(2, Resources.ultraball);
            UseUltraBallButton.Text = $"UltraBall: {pokeballs[2].Amount}";
        }

        private void UseMasterBallButton_Click(object sender, EventArgs e)
        {
            Generic_PokeballButton_Click(3, Resources.masterball);
            UseMasterBallButton.Text = $"MasterBall: {pokeballs[3].Amount}";
        }
    }
}
