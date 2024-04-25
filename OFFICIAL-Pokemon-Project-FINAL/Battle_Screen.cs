using OFFICIAL_Pokemon_Project_FINAL.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{

    /// <summary>
    /// This method contains all of the game logic and actively runs the game. It also implements buttons that the user can press. It implements
    /// the Windows Form class as it is a Windows Form object.
    /// </summary>
    public partial class Battle_Screen : Form
    {

        /// Creates the sleepTimer timer that is used to put the program to sleep to allow the user to read
        System.Timers.Timer sleepTimer = new System.Timers.Timer(1000);
        volatile int time; // This is time in seconds that the program is currently asleep for

        // Creates two Pokemon instances for the player and the enemy
        private Pokemon enemyPokemon;
        private Pokemon playerPokemon;

        // Creates a lot of boolean variables that establish states that the program is in
        private bool is_Player_Turn = false; // Determines if it is the player's turn
        private bool is_Attack_Button_Pressed = false; // Determines if the buttons that represent the ACTUAL attacks are pressed
        private bool is_Pokeball_Button_Pressed = false; // Checks if one of the ACTUAL pokeball buttons are pressed
        private bool is_Option_Button_Pressed = false; // Checks if one of the four option buttons are pressed
        private bool is_Healing_Item_Button_Pressed = false; // Checks if one of the ACTUAL healing item buttons are pressed
        private bool is_Run_Button_Pressed = false; // Checks if the run button has been pressed.
        private bool ranAway = false; // Checks if the player has run away.

        // A Random instance that is used throughout the program to generate numebrs.
        private readonly Random rng = new();
           
        // Lists that hold the healing items the player has and the pokeballs they have respectively
        public List<HealingItem> inventory = [new Potion(), new SuperPotion(), new HyperPotion(), new FullHeal()];
        public List<GenericPokeball> pokeballs = [new Pokeball(), new GreatBall(), new UltraBall(), new MasterBall()];

        // The number of turn that it is.
        public int turnNumber = 0;

        // Constructor
        public Battle_Screen()
        {
            // Initializes the Visual Studio components like buttons and textboxes
            InitializeComponent();

            enemyPokemon = new Wattrus();
            playerPokemon = new Wattrus();

            Enemy_Health_Bar.Maximum = enemyPokemon.Health;
            Enemy_Health_Bar.Value = enemyPokemon.Health;

            Player_Health_Bar.Maximum = playerPokemon.health;
            Player_Health_Bar.Value = playerPokemon.health;

            // Updates the statusLabels using the updateStatusLabels() method
            updateStatusLabels();

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
            // Resets time to 0
            time = 0;

            // Sets the elapsed property of Elapsed 
            sleepTimer.Elapsed += new System.Timers.ElapsedEventHandler(SleepTimer_Elapsed);
            sleepTimer.Start();
            while (time < delay) ;
            sleepTimer.Stop();
            // Debug.WriteLine("Break Ended!");
        }

        void SleepTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Debug.WriteLine(time);
            time++;
        }

        private void Battle_Screen_Load(object sender, EventArgs e)
        {

            Enemy_Sprite.BackgroundImage = enemyPokemon.Get_Front_Sprite();
            Player_Sprite.BackgroundImage = playerPokemon.Get_Back_Sprite();

            Enemy_Name.Text = enemyPokemon.Name;
            Player_Name.Text = playerPokemon.Name;

            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].Name}\nPP:{playerPokemon.moveSet[0].PowerPoints}";
            Attack_Button_1.BackColor = Decide_Type_Color(playerPokemon.moveSet[0].MoveType);

            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].Name}\nPP:{playerPokemon.moveSet[1].PowerPoints}";
            Attack_Button_2.BackColor = Decide_Type_Color(playerPokemon.moveSet[1].MoveType);

            Attack_Button_3.Text = $"{playerPokemon.moveSet[2].Name}\nPP:{playerPokemon.moveSet[2].PowerPoints}";
            Attack_Button_3.BackColor = Decide_Type_Color(playerPokemon.moveSet[2].MoveType);

            Attack_Button_4.Text = $"{playerPokemon.moveSet[3].Name}\nPP:{playerPokemon.moveSet[3].PowerPoints}";
            Attack_Button_4.BackColor = Decide_Type_Color(playerPokemon.moveSet[3].MoveType);

            UsePokeballButton.Text = $"Pokeball: {pokeballs[0].Amount}";
            UseGreatBallButton.Text = $"GreatBall: {pokeballs[1].Amount}";
            UseUltraBallButton.Text = $"UltraBall: {pokeballs[2].Amount}";
            UseMasterBallButton.Text = $"MasterBall: {pokeballs[3].Amount}";

            potionButton.Text = $"Potion: {inventory[0].Amount}";
            superPotionButton.Text = $"Super Potion: {inventory[1].Amount}";
            hyperPotionButton.Text = $"Hyper Potion: {inventory[2].Amount}";
            fullHealButton.Text = $"Full Heal: {inventory[3].Amount}";

            SetStartingTurnNumber();

            RunGame();
        }

        private Pokemon Pick_Pokemon()
        {

            switch (rng.Next(3))
            {
                case 0:
                    return new Wattrus();
                case 1:
                    return new Nautighoul();
                case 2:
                    return new Chainsprout();
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

        private Color Decide_Type_Color(string type)
        {

            if (type.Equals("Fire"))
            {
                return Color.OrangeRed;
            }

            else if (type.Equals("Water"))
            {
                return Color.DodgerBlue;
            }

            else if (type.Equals("Grass"))
            {
                return Color.LimeGreen;
            }
            else if (type.Equals("Electric"))
            {
                return Color.Gold;
            }
            else if (type.Equals("Steel"))
            {
                return Color.LightSteelBlue;
            }
            else if (type.Equals("Ice"))
            {
                return Color.LightBlue;
            }
            else if (type.Equals("Ghost"))
            {
                return Color.MediumSlateBlue;
            }
            else if (type.Equals("Dragon"))
            {
                return Color.DarkSlateGray;
            }
            else if (type.Equals("Psychic"))
            {
                return Color.Orchid;
            }
            else if (type.Equals("Flying"))
            {
                return Color.SkyBlue;
            }
            else if (type.Equals("Bug"))
            {
                return Color.YellowGreen;
            }
            else if (type.Equals("Rock"))
            {
                return Color.Peru;
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
            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].Name}\nPP:{playerPokemon.moveSet[0].PowerPoints}";

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
            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].Name}\nPP:{playerPokemon.moveSet[1].PowerPoints}";

            AttackPanelLayout.Visible = false;
        }

        private void Attack_Button_3_Click(object sender, EventArgs e)
        {
            if (!is_Player_Turn)
            {
                return;
            }

            is_Attack_Button_Pressed = true;

            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 2);
            Attack_Button_3.Text = $"{playerPokemon.moveSet[2].Name}\nPP:{playerPokemon.moveSet[2].PowerPoints}";

            AttackPanelLayout.Visible = false;
        }

        private void Attack_Button_4_Click(object sender, EventArgs e)
        {
            if (!is_Player_Turn)
            {
                return;
            }

            is_Attack_Button_Pressed = true;

            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, 3);
            Attack_Button_4.Text = $"{playerPokemon.moveSet[3].Name}\nPP:{playerPokemon.moveSet[3].PowerPoints}";

            AttackPanelLayout.Visible = false;
        }

        

        private void Update_Message_Box_Text(Pokemon user, Pokemon target, ProgressBar targetHealthBar, int attackNumber)
        {
            string message = $"{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}";

            message += $"\n{user.moveSet[attackNumber].Calculate_Type_Effectiveness(target).message}";

            Message_Box.Text = message;
            ShowAttackBox.Visible = true;
        }

        public void SetStartingTurnNumber()
        {

            Debug.WriteLine($"Player speed {playerPokemon.Speed}");
            Debug.WriteLine($"Enemy speed {enemyPokemon.Speed}");

            switch (playerPokemon.Speed >= enemyPokemon.Speed)
            {
                case true:
                    turnNumber = 0;
                    Message_Box.Text = $"Your {playerPokemon.Name} is faster than the enemy {enemyPokemon.Name}. You get to go first!";
                    break;
                case false:
                    turnNumber = 1;
                    Message_Box.Text = $"The enemy {enemyPokemon.Name} is faster than your {playerPokemon.Name}. The enemy will go first!";
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

        private bool PlayerIsAlive()
        {
            return Player_Health_Bar.Value > 0;
        }
        private bool EnemyIsAlive()
        {
            return Enemy_Health_Bar.Value > 0;
        }

        public async void RunGame()
        {

            await Task.Run(() => Delay(4));

            int roundCounter = 0;

            while (PlayerIsAlive() && EnemyIsAlive() && !ranAway)
            {
                if (turnNumber == 0)
                {
                    roundCounter++;

                    bool canAttack = true;

                    if (playerPokemon.Status == "asleep" || playerPokemon.Status == "frozen")
                    {
                        Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} and unable to attack!";

                        await Task.Run(() => Delay(4));

                        canAttack = false;
                    }
                    if (playerPokemon.Status == "paralyzed")
                    {
                        Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} and may be unable to attack!";

                        await Task.Run(() => Delay(4));

                        int testParalysis = rng.Next(0, 3);

                        Debug.WriteLine(testParalysis);

                        if (testParalysis == 0)
                        {
                            Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} it can't move!";

                            await Task.Run(() => Delay(4));

                            canAttack = false;
                        }
                    }

                    Message_Box.Text = "It's your turn, press the button of the option you would like to do!";

                    is_Player_Turn = true;

                    if (!canAttack)
                    {
                        ShowAttackBox.Visible = false;
                    }

                    while (!is_Option_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    while (!is_Attack_Button_Pressed && !is_Pokeball_Button_Pressed && !is_Healing_Item_Button_Pressed && !is_Run_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    await Task.Run(() => Delay(4));


                    is_Player_Turn = false;
                    is_Attack_Button_Pressed = false;
                    is_Option_Button_Pressed = false;
                    is_Pokeball_Button_Pressed = false;
                    is_Healing_Item_Button_Pressed = false;
                    is_Run_Button_Pressed = false;

                    AttackPanelLayout.Visible = false; PokeballPanelLayout.Visible = false; healingItemTableLayout.Visible = false;


                    updateStatusLabels();

                    turnNumber = 1;
                }

                else
                {
                    roundCounter++;

                    if (enemyPokemon.Status == "asleep" || enemyPokemon.Status == "frozen")
                    {
                        Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} and unable to attack!";

                        await Task.Run(() => Delay(4));

                        turnNumber = 0;
                        continue;
                    }
                    if (enemyPokemon.Status == "paralyzed")
                    {
                        Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} and may be unable to attack!";

                        await Task.Run(() => Delay(4));

                        int testParalysis = rng.Next(0, 3);

                        Debug.WriteLine(testParalysis);

                        if (testParalysis == 0)
                        {
                            Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} it can't move!";

                            await Task.Run(() => Delay(4));

                            turnNumber = 0;
                            continue;
                        }
                    }

                    bool[] testedNums = [enemyPokemon.moveSet[0].PowerPoints > 0, enemyPokemon.moveSet[1].PowerPoints > 0];

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


                    await Task.Run(() => Delay(4));

                    turnNumber = 0;

                    updateStatusLabels();
                }



                if (roundCounter == 2)
                {
                    bool playerEffect = DoStatusEffect(playerPokemon, Player_Health_Bar, Message_Box);

                    if (playerEffect) { await Task.Run(() => Delay(4)); }

                    bool enemyEffect = DoStatusEffect(enemyPokemon, Enemy_Health_Bar, Message_Box);

                    if (enemyEffect) { await Task.Run(() => Delay(4)); }

                    updateStatusLabels();

                    roundCounter = 0;
                }
            }

            if (!PlayerIsAlive())
            {
                Player_Sprite.BackgroundImage = null;

                Message_Box.Text = $"Your {playerPokemon.Name} fainted. YOU LOSE.";

                await Task.Run(() => Delay(4));

                this.Close();
                new Start_Screen().Show();
            }
            else if (!EnemyIsAlive())
            {
                Enemy_Sprite.BackgroundImage = null;

                Message_Box.Text = $"Enemy {enemyPokemon.Name} fainted. YOU WIN.";

                await Task.Run(() => Delay(4));

                this.Close();
                new Start_Screen().Show();
            }
            else if (ranAway)
            {
                await Task.Run(() => Delay(4));

                this.Close();
                new Start_Screen().Show();
            }
        }

        private bool DoStatusEffect(Pokemon target, ProgressBar targetHealthBar, Label textBox)
        {
            bool textChanged = false;

            if (!target.Status.Equals(""))
            {
                if (target.Status.ToLower().Equals("asleep"))
                {
                    int testAwake = rng.Next(0, 3);

                    if (testAwake == 0)
                    {
                        textBox.Text = $"{target.Name} has woken up!";
                        target.Status = "";
                    }
                }
                if (target.Status.ToLower().Equals("frozen"))
                {
                    int testFrozen = rng.Next(0, 6);

                    if (testFrozen == 0)
                    {
                        textBox.Text = $"{target.Name} has thawed out!";
                        target.Status = "";
                    }
                }
                if (target.Status.ToLower().Equals("poisoned"))
                {
                    textBox.Text = $"{target.Name} has taken damage due to poison!";

                    int poisonDamage = target.Health / 16;

                    if (targetHealthBar.Value - poisonDamage < 0)
                    {
                        targetHealthBar.Value = 0;
                    }
                    else
                    {
                        targetHealthBar.Value -= poisonDamage;
                    }
                }
                if (target.Status.ToLower().Equals("burned"))
                {
                    textBox.Text = $"{target.Name} has taken damage due to burn!";

                    int burnDamage = target.Health / 8;

                    if (targetHealthBar.Value - burnDamage < 0)
                    {
                        targetHealthBar.Value = 0;
                    }
                    else
                    {
                        targetHealthBar.Value -= burnDamage;
                    }
                }

                textChanged = true;
            }

            return textChanged;
        }


        private void ShowAttackBox_Click(object sender, EventArgs e)
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
            if (!is_Player_Turn)
            {
                return;
            }

            is_Option_Button_Pressed = true;
            healingItemTableLayout.Visible = true;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            int testNumber = rng.Next(0, 256);

            int oddsToEscape = CalculateRunAway();

            if (oddsToEscape > 255 || testNumber < oddsToEscape)
            {
                Message_Box.Text = "You successfully ran away ending the battle!";
                ranAway = true;
            }
            else
            {
                Message_Box.Text = "You have failed to run away.";
            }

            is_Option_Button_Pressed = true;
            is_Run_Button_Pressed = true;
        }

        private int CalculateRunAway()
        {

            // Checks if enemy speed divided by 4 and the mod by 256 is equal to zero to avoid a dividing by zero error and returns 256
            if (enemyPokemon.Speed / 4 % 256 == 0) { return 256; }

            // Calculates the odds to escape using the formula
            int oddsToEscape = (playerPokemon.Speed * 32 / (enemyPokemon.Speed / 4 % 256)) + 30;

            // Returns the oddsToEscape
            return oddsToEscape;
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
                Message_Box.Text = $"You caught the {enemyPokemon.Name} using a {pokeballs[invNumber].Name}!";
                Enemy_Sprite.Visible = false;
                pokeballPictureBox.Visible = true;
                pokeballPictureBox.BackgroundImage = image;
                Enemy_Health_Bar.Value = 0;
            }
            else
            {
                Message_Box.Text = $"You failed to catch the {enemyPokemon.Name}";
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

        private void Generic_UseHealingItem_Click(int invNumber)
        {
            is_Healing_Item_Button_Pressed = true;

            try
            {
                if (invNumber == 3)
                {
                    Message_Box.Text = inventory[3].UseItem(playerPokemon);
                }
                else
                {
                    Message_Box.Text = inventory[invNumber].UseItem(Player_Health_Bar);
                }
            }
            catch (Exception)
            {
                Message_Box.Text = "Unable to use this item as you have none left.";
            }

            healingItemTableLayout.Visible = false;
        }
        private void potionButton_Click(object sender, EventArgs e)
        {
            Generic_UseHealingItem_Click(0);
            potionButton.Text = $"Potion: {inventory[0].Amount}";
        }

        private void superPotionButton_Click(object sender, EventArgs e)
        {
            Generic_UseHealingItem_Click(1);
            superPotionButton.Text = $"Super Potion: {inventory[1].Amount}";
        }

        private void hyperPotionButton_Click(object sender, EventArgs e)
        {
            Generic_UseHealingItem_Click(2);
            hyperPotionButton.Text = $"Hyper Potion: {inventory[2].Amount}";
        }

        private void fullHealButton_Click(object sender, EventArgs e)
        {
            Generic_UseHealingItem_Click(3);
            fullHealButton.Text = $"Full Heal: {inventory[3].Amount}";
        }


        private void updateStatusLabels()
        {
            Generic_StatusLabelSet(playerPokemon, Player_StatusLabel);
            Generic_StatusLabelSet(enemyPokemon, Enemy_StatusLabel);
        }
        private static void Generic_StatusLabelSet(Pokemon pokemon, Label statusLabel)
        {
            switch (pokemon.Status.ToLower())
            {
                case "":
                    statusLabel.Text = "";
                    statusLabel.BackColor = Color.White;
                    statusLabel.Visible = false;
                    break;
                case "asleep":
                    statusLabel.Text = "SLP";
                    statusLabel.BackColor = Color.LightGray;
                    statusLabel.Visible = true;
                    break;
                case "paralyzed":
                    statusLabel.Text = "PAR";
                    statusLabel.BackColor = Color.Gold;
                    statusLabel.Visible = true;
                    break;
                case "frozen":
                    statusLabel.Text = "FRZ";
                    statusLabel.BackColor = Color.LightBlue;
                    statusLabel.Visible = true;
                    break;
                case "poisoned":
                    statusLabel.Text = "PSN";
                    statusLabel.BackColor = Color.Purple;
                    statusLabel.Visible = true;
                    break;
                case "burned":
                    statusLabel.Text = "BRN";
                    statusLabel.BackColor = Color.OrangeRed;
                    statusLabel.Visible = true;
                    break;
            }
        }

    }
}
