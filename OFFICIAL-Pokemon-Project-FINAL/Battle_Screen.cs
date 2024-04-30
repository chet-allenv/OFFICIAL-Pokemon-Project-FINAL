using OFFICIAL_Pokemon_Project_FINAL.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
        public Pokemon playerPokemon;

        public SoundPlayer playerSound = new("C:\\Users\\cheta\\Source\\Repos\\chet-allenv\\OFFICIAL-Pokemon-Project-FINAL\\OFFICIAL-Pokemon-Project-FINAL\\Resources\\BeepBox-Song.wav");

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
        }

        /// <summary>
        /// Delays code for a given time.
        /// </summary>
        /// <param name="delay"> The length of time to delay the code in seconds. DEFAULT IS 1. </param>
        public void Delay(int delay = 1)
        {
            // Resets time to 0
            time = 0;

            // Creates an event handler for the elapsed event of sleepTimer
            sleepTimer.Elapsed += new System.Timers.ElapsedEventHandler(SleepTimer_Elapsed);

            // Starts the sleepTimer
            sleepTimer.Start();

            // Waits until the time reaches the given delay
            while (time < delay) ;

            // Stops the timer
            sleepTimer.Stop();

            // Used for debugging, prints to the debug console to show when the delay is over.
            // Debug.WriteLine("Break Ended!");
        }

        /// <summary>
        /// The created event for the sleepTimer's elapsed event
        /// </summary>
        /// <param name="sender"> Object that raised the event. </param>
        /// <param name="e"> an ElapsedEventArgs object that holds the event data. </param>
        void SleepTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Increments the volatile time variable
            time++;

            // Used for debugging, prints the value of time to the debug comsole.
            // Debug.WriteLine(time);
        }

        private void PlaySong()
        {
            playerSound.PlayLooping();
        }

        /// <summary>
        /// Event handler for the Battle_Screen's load event. Establishes the battle screen with the 
        /// initial values and UI elements.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Battle_Screen_Load(object sender, EventArgs e)
        {
            // Sets the enemyPokemon to a random pokemon using the Pick_Pokemon() method
            enemyPokemon = Pick_Pokemon();

            PlaySong();

            // Sets the maximum and current health of the enemy pokemon's health bar using its health stat
            Enemy_Health_Bar.Maximum = enemyPokemon.Health;
            Enemy_Health_Bar.Value = enemyPokemon.Health;

            // Sets the maximum and current health of the player pokemon's health bar using its health stat
            Player_Health_Bar.Maximum = playerPokemon.Health;
            Player_Health_Bar.Value = playerPokemon.Health;

            // Sets the images for the pokemon using the respective sprites
            Enemy_Sprite.BackgroundImage = enemyPokemon.Get_Front_Sprite();
            Player_Sprite.BackgroundImage = playerPokemon.Get_Back_Sprite();

            // Sets the text of the nameBoxes for both pokemon
            Enemy_Name.Text = enemyPokemon.Name;
            Player_Name.Text = playerPokemon.Name;

            // Set text and background color (using Decide_Type_Color()) for attack buttons based on player Pokémon's move set
            Attack_Button_1.Text = $"{playerPokemon.moveSet[0].Name}\nPP:{playerPokemon.moveSet[0].PowerPoints}";
            Attack_Button_1.BackColor = Decide_Type_Color(playerPokemon.moveSet[0].MoveType);

            Attack_Button_2.Text = $"{playerPokemon.moveSet[1].Name}\nPP:{playerPokemon.moveSet[1].PowerPoints}";
            Attack_Button_2.BackColor = Decide_Type_Color(playerPokemon.moveSet[1].MoveType);

            Attack_Button_3.Text = $"{playerPokemon.moveSet[2].Name}\nPP:{playerPokemon.moveSet[2].PowerPoints}";
            Attack_Button_3.BackColor = Decide_Type_Color(playerPokemon.moveSet[2].MoveType);

            Attack_Button_4.Text = $"{playerPokemon.moveSet[3].Name}\nPP:{playerPokemon.moveSet[3].PowerPoints}";
            Attack_Button_4.BackColor = Decide_Type_Color(playerPokemon.moveSet[3].MoveType);

            // Sets the text of the pokeball buttons based on the user's inventory
            UsePokeballButton.Text = $"Pokeball: {pokeballs[0].Amount}";
            UseGreatBallButton.Text = $"GreatBall: {pokeballs[1].Amount}";
            UseUltraBallButton.Text = $"UltraBall: {pokeballs[2].Amount}";
            UseMasterBallButton.Text = $"MasterBall: {pokeballs[3].Amount}";

            // Sets the text of the potion buttons based on the user's inventory
            potionButton.Text = $"Potion: {inventory[0].Amount}";
            superPotionButton.Text = $"Super Potion: {inventory[1].Amount}";
            hyperPotionButton.Text = $"Hyper Potion: {inventory[2].Amount}";
            fullHealButton.Text = $"Full Heal: {inventory[3].Amount}";

            // Sets the starting turn number using the SetStartingTurnNumber() method
            SetStartingTurnNumber();
            // Updates the status labels using the updateStatusLabels() method
            UpdateStatusLabels();

            // Starts the game loop using the RunGame() method.
            RunGame();
        }

        /// <summary>
        /// Randomly selects one of the six created pokemon and returns it
        /// </summary>
        /// <returns> A pokemon object randomly picked from the six created pokemon. </returns>
        private Pokemon Pick_Pokemon()
        {
            // Uses a switch statement to return a Pokemon object based on a random number from 0-5
            return rng.Next(6) switch
            {
                // Each possible number returns a different pokemon object.
                0 => new Wattrus(),
                1 => new Nautighoul(),
                2 => new Chainsprout(),
                3 => new Rockmoth(),
                4 => new Flamindgo(),
                5 => new Infernothorn(),
                // The default case will return null if the random number doesn't match. (SHOULD NEVER BE REACHED)
                _ => null,
            };
        }

        /// <summary>
        /// Event handler for when the Exit_Button component is clicked. Will close the application when clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event (the Exit_Button). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            // Closes the application.
            Application.Exit();
        }

        /// <summary>
        /// Event handler for when the Rerun_Button component is clicked. Closes the current window and opens a new
        /// select screen, effectively rerunning the battle_screen.
        /// </summary>
        /// <param name="sender"> The object that raised the event (the Rerun_Button). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Rerun_Button_Click(object sender, EventArgs e)
        {
            // Closes the current Battl_Screen form instance
            this.Close();

            // Create a new instance of the Pokemon_Select form
            var newSelectScreen = new Pokemon_Select();

            // Shows the new Pokemon_Select form
            newSelectScreen.Show();
        }

        /// <summary>
        /// Determines the color of an attack button based on its type.
        /// </summary>
        /// <param name="type"> The type of the attack. </param>
        /// <returns> The acolor associated with the given type. Returns Color.White if it does not recognize the given type. </returns>
        private static Color Decide_Type_Color(string type)
        {
            // Uses a switch expression to return the color of the attack type/
            return type switch
            {
                // Returns a color based on a data set of strings
                "Fire" => Color.OrangeRed,
                "Water" => Color.DodgerBlue,
                "Grass" => Color.LimeGreen,
                "Electric" => Color.Gold,
                "Steel" => Color.LightSteelBlue,
                "Ice" => Color.LightBlue,
                "Ghost" => Color.MediumSlateBlue,
                "Dragon" => Color.DarkSlateGray,
                "Psychic" => Color.Orchid,
                "Flying" => Color.SkyBlue,
                "Bug" => Color.YellowGreen,
                "Rock" => Color.Peru,
                "Normal" => Color.Gray,
                // Default case returns Color.White if the given type is not recognized.
                _ => Color.White,
            };
        }

        /// <summary>
        /// A default method that is the basis for when an attack button is clicked.
        /// </summary>
        /// <param name="attackButton"> The button that was clicked. </param>
        /// <param name="moveNumber"> The index of the move in the player pokemon's move set. </param>
        private void Generic_AttackButton_Click(Button attackButton, int moveNumber)
        {
            // Checks if it is the player's turn, if not then it exits the method
            if (!is_Player_Turn)
            {
                return;
            }

            // Turns the is_Attack_Button_Pressed flag on indicating that an attack button was pressed
            is_Attack_Button_Pressed = true;

            // Updates the message box using the Update_Message_Box method.
            Update_Message_Box_Text(playerPokemon, enemyPokemon, Enemy_Health_Bar, moveNumber);

            // Sets the text of the given button to display the updated PP count.
            attackButton.Text = $"{playerPokemon.moveSet[moveNumber].Name}\nPP:{playerPokemon.moveSet[moveNumber].PowerPoints}";

            // Hides the attack panel layout
            AttackPanelLayout.Visible = false;
        }

        /// <summary>
        /// Event handler for when the Attack_Button_1 component is clicked. Calls the Generic_AttackButton_Method
        /// with the correct parameters
        /// </summary>
        /// <param name="sender"> The object that raised the event (Attack_Button_1). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Attack_Button_1_Click(object sender, EventArgs e)
        {
            // Calls the Generic_AttackButton_Click() method using the sender (which will be Attack_Button_1) and move index 0
            Generic_AttackButton_Click(sender as Button, 0);
        }

        /// <summary>
        /// Event handler for when the Attack_Button_2 component is clicked. Calls the Generic_AttackButton_Method
        /// with the correct parameters
        /// </summary>
        /// <param name="sender"> The object that raised the event (Attack_Button_2). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Attack_Button_2_Click(object sender, EventArgs e)
        {
            // Calls the Generic_AttackButton_Click() method using the sender (which will be Attack_Button_2) and move index 1
            Generic_AttackButton_Click(sender as Button, 1);
        }

        /// <summary>
        /// Event handler for when the Attack_Button_3 component is clicked. Calls the Generic_AttackButton_Method
        /// with the correct parameters
        /// </summary>
        /// <param name="sender"> The object that raised the event (Attack_Button_3). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Attack_Button_3_Click(object sender, EventArgs e)
        {
            // Calls the Generic_AttackButton_Click() method using the sender (which will be Attack_Button_3) and move index 2
            Generic_AttackButton_Click(sender as Button, 2);
        }

        /// <summary>
        /// Event handler for when the Attack_Button_4 component is clicked. Calls the Generic_AttackButton_Method
        /// with the correct parameters
        /// </summary>
        /// <param name="sender"> The object that raised the event (Attack_Button_4). </param>
        /// <param name="e"> An EventArgs object containing event data. </param>
        private void Attack_Button_4_Click(object sender, EventArgs e)
        {
            // Calls the Generic_AttackButton_Click() method using the sender (which will be Attack_Button_4) and move index 3
            Generic_AttackButton_Click(sender as Button, 3);
        }
        
        /// <summary>
        /// Updates the Message_Box text box with information based on the result of a move.
        /// </summary>
        /// <param name="user"> the pokemon using the move. </param>
        /// <param name="target"> the pokemon targeted by the move. </param>
        /// <param name="targetHealthBar"> the health bar of the targeted pokeon. </param>
        /// <param name="attackNumber"> the index of the move in the user's move set. </param>
        private void Update_Message_Box_Text(Pokemon user, Pokemon target, ProgressBar targetHealthBar, int attackNumber)
        {
            // Gets the message returned by the Attack.Use() method that correlates with the user's attack at user.moveSet[attackNumber]
            string message = $"{user.moveSet[attackNumber].Use(user, target, targetHealthBar)}";

            // Adds a message based on the move's type effectiveness. (CAN BE EMPTY)
            message += $"\n{user.moveSet[attackNumber].Calculate_Type_Effectiveness(target).message}";

            // Sets the Message_Box text to the message.
            Message_Box.Text = message;

            // Makes the attack box visible.
            ShowAttackBox.Visible = true;
        }
        /// <summary>
        /// Determines the turn number of the first turn based on the speed of both pokemon in play
        /// </summary>
        public void SetStartingTurnNumber()
        {
            // Optional debugging that prints the speed of both pokemon to the console.
            //Debug.WriteLine($"Player speed {playerPokemon.Speed}");
            //Debug.WriteLine($"Enemy speed {enemyPokemon.Speed}");

            // Compares the speed of the two pokemon (Player wins ties)
            switch (playerPokemon.Speed >= enemyPokemon.Speed)
            {
                // IF THE PLAYER IS FASTER OR BOTH ARE SAME SPEED
                case true:

                    // Turn number is set to zero (This indicates that it is the player's turn)
                    turnNumber = 0;

                    // Writes a message to the user letting them know they are going first.
                    Message_Box.Text = $"Your {playerPokemon.Name} is faster than the enemy {enemyPokemon.Name}. You get to go first!";
                    break;
                // IF THE ENEMY IS FASTER
                case false:

                    // Turn number is set to one (This indicates that it is the enemy's turn)
                    turnNumber = 1;

                    // Writes a message to the user letting them know the enemy is going first.
                    Message_Box.Text = $"The enemy {enemyPokemon.Name} is faster than your {playerPokemon.Name}. The enemy will go first!";
                    break;
            }
        }

        /// <summary>
        /// Checks if the player pokemon is alive
        /// </summary>
        /// <returns> True if the player pokemon is alive, false if not. </returns>
        private bool PlayerIsAlive()
        {
            // Returns the Boolean value of if the player's current health is greater than 0
            return Player_Health_Bar.Value > 0;
        }

        /// <summary>
        /// Checks if the enemy pokemon is alive
        /// </summary>
        /// <returns> True if the enemy pokemon is alive, false if not. </returns>
        private bool EnemyIsAlive()
        {
            // Returns the Boolean value of if the enemy's current health is greater than 0
            return Enemy_Health_Bar.Value > 0;
        }

        /// <summary>
        /// This function provides the game loop for the game.
        /// </summary>
        public async void RunGame()
        {
            // Waits for a delay before running the game.
            await Task.Run(() => Delay(4));

            // Initializes the round counter
            int roundCounter = 0;

            // Loops while the player is alive, the enemy is alive, AND the player has not run away
            while (PlayerIsAlive() && EnemyIsAlive() && !ranAway)
            {
                // PLAYER TURN
                if (turnNumber == 0)
                {
                    // Increments the round counter
                    roundCounter++;

                    // Creates a flagger that determines if the player can attack
                    bool canAttack = true;

                    // Checks if the player is affected by statuses that can prevent attacking.
                    if (playerPokemon.Status == "asleep" || playerPokemon.Status == "frozen")
                    { // IF ASLEEP OR FROZEN
                        // Sets the text box's text to let the player know they cant attack
                        Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} and unable to attack!";

                        // Waits for a delay
                        await Task.Run(() => Delay(4));

                        // Sets the canAttack flagger to false indicating that the user can't attack.
                        canAttack = false;
                    }
                    if (playerPokemon.Status == "paralyzed")
                    { // IF PARALYZED
                        // Sets the text box's text to let the player know they may be unable to attack
                        Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} and may be unable to attack!";

                        // Waits for a delay
                        await Task.Run(() => Delay(4));

                        // Creates a test case. There's a 25% chance you can't attack when paralyzed.
                        int testParalysis = rng.Next(0, 3);

                        // FOR DEBUGGING, writes the number of paralysis.
                        //Debug.WriteLine(testParalysis);

                        // Checks if the testParalysis number is equal to zero, if so the user can't attack
                        if (testParalysis == 0)
                        {
                            // Updates the Message_Box to let the user know they can't attack.
                            Message_Box.Text = $"Your {playerPokemon.Name} is {playerPokemon.Status} it can't move!";

                            // Waits for a delay
                            await Task.Run(() => Delay(4));

                            // Sets the canAttack flagger to false indicating that the user can't attack. 
                            canAttack = false;
                        }
                    }

                    // Updates the user that it's their turn and they can press the button of what attack they want to do
                    Message_Box.Text = "It's your turn, press the button of the option you would like to do!";

                    // Sets the is_Player_Turn flagger to true
                    is_Player_Turn = true;

                    // Hides the attack box if the player cannot attack based on the canAttack flagger
                    if (!canAttack)
                    {
                        ShowAttackBox.Visible = false;
                    }

                    // Waits for the user to select one of the four option buttons
                    while (!is_Option_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    // Waits for the user to press one of the sub-menu buttons
                    while (!is_Attack_Button_Pressed && !is_Pokeball_Button_Pressed && !is_Healing_Item_Button_Pressed && !is_Run_Button_Pressed)
                    {
                        await Task.Delay(1);
                    }

                    // Waits for a delay
                    await Task.Run(() => Delay(4));

                    // Resets all flags 
                    is_Player_Turn = false;
                    is_Attack_Button_Pressed = false;
                    is_Option_Button_Pressed = false;
                    is_Pokeball_Button_Pressed = false;
                    is_Healing_Item_Button_Pressed = false;
                    is_Run_Button_Pressed = false;
                    
                    // Hides all sub menu boxes.
                    AttackPanelLayout.Visible = false; 
                    PokeballPanelLayout.Visible = false; 
                    healingItemTableLayout.Visible = false;

                    // Updates the status labels
                    UpdateStatusLabels();

                    // Sets it to the Enemy's turn
                    turnNumber = 1;
                }
                // ENEMY'S TURN
                else
                {
                    // Increments the round counter
                    roundCounter++;

                    // Checks if the enemy is affected by statuses that can prevent attacking.
                    if (enemyPokemon.Status == "asleep" || enemyPokemon.Status == "frozen")
                    { // IF ASLEEP OR FROZEN
                        // Sets the text box's text to let the player know the enemy cant attack
                        Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} and unable to attack!";

                        // Waits for a delay
                        await Task.Run(() => Delay(4));

                        // Sets it to the Player's turn
                        turnNumber = 0;

                        // Reloops the while loop.
                        continue;
                    }
                    if (enemyPokemon.Status == "paralyzed")
                    { // IF PARALYZED
                        // Sets the text box's text to let the player know the enemy may be unable to attack
                        Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} and may be unable to attack!";

                        // Waits for a delay
                        await Task.Run(() => Delay(4));

                        // Creates a test case. There's a 25% chance you can't attack when paralyzed.
                        int testParalysis = rng.Next(0, 3);

                        // FOR DEBUGGING, writes the number of paralysis.
                        //Debug.WriteLine(testParalysis);

                        // Checks if the testParalysis number is equal to zero, if so the enemy can't attack
                        if (testParalysis == 0)
                        {
                            // Updates the Message_Box to let the user know the enemy can't attack.
                            Message_Box.Text = $"Enemy {enemyPokemon.Name} is {enemyPokemon.Status} it can't move!";

                            // Waits for a delay
                            await Task.Run(() => Delay(4));

                            // Sets it to the Player's turn
                            turnNumber = 0;

                            // Reloops the while loop.
                            continue;
                        }
                    }

                    // Checks if the enemy is out of usable moves.
                    bool[] testedNums = [enemyPokemon.moveSet[0].PowerPoints > 0, enemyPokemon.moveSet[1].PowerPoints > 0, enemyPokemon.moveSet[2].PowerPoints > 0, enemyPokemon.moveSet[3].PowerPoints > 0];
                    bool outOfMoves = testedNums.All(var => var == false);

                    // If the enemy is not out of usable moves
                    if (!outOfMoves)
                    {
                        // Creates a boolean flag to check if there was an attack that was used.
                        bool attackUsed = false;

                        // While an attack has not been used
                        while (!attackUsed)
                        {
                            // Generates a random number of the enemy's move set
                            int randAttackNum = rng.Next(0, 4);

                            // Checks if the value at index randAttackNum is false
                            if (testedNums[randAttackNum] == false)
                            { // IF SO
                                continue; // Continues the while loop to check again
                            }
                            else // IF NOT
                            { 
                                // Updates the Message_Box with the used attack
                                Update_Message_Box_Text(enemyPokemon, playerPokemon, Player_Health_Bar, randAttackNum); 

                                // Sets the boolean flag to true that an attack has been used.
                                attackUsed = true; 
                            }
                        }
                    }
                    else // IF THE ENEMY IS OUT OF USABLE MOVES
                    {
                        // Displays a message that the enemy is unable to attack
                        Message_Box.Text = "The Enemy is out of usable moves! It ran around panicking!";
                    }

                    // Waits for a delay
                    await Task.Run(() => Delay(4));

                    // Sets it to the Player's turn 
                    turnNumber = 0;

                    // Updates the satus labels.
                    UpdateStatusLabels();
                }

                // Checks if it is the end of a round to apply the status effects.
                if (roundCounter == 2)
                {
                    // Checks if the DoStatusEffect() method returns true indicating that a message will be outputted.
                    bool playerEffect = DoStatusEffect(playerPokemon, Player_Health_Bar, Message_Box);

                    // If the player Effect is true, it gives the user time to read what happened.
                    if (playerEffect) { await Task.Run(() => Delay(4)); }

                    // Checks if the DoStatusEffect() method returns true indicating that a message will be outputted.
                    bool enemyEffect = DoStatusEffect(enemyPokemon, Enemy_Health_Bar, Message_Box);

                    // If the enemy Effect is true, it gives the user time to read what happened.
                    if (enemyEffect) { await Task.Run(() => Delay(4)); }

                    // Updates status labels
                    UpdateStatusLabels();

                    // Resets the round counter.
                    roundCounter = 0;
                }
            }

            // CHECKS HOW THE GAME ENDED.
            if (!PlayerIsAlive())
            { // IF PLAYER POKEMON FAINTED
                // Removes the player pokemon's image
                Player_Sprite.BackgroundImage = null;

                // Outputs a message for the user letting them know what happened.
                Message_Box.Text = $"Your {playerPokemon.Name} fainted. YOU LOSE.";

                // Waits for a delay
                await Task.Run(() => Delay(4));

                // Closes the current form and opens a new Start_Screen instance
                this.Close();
                new Start_Screen().Show();
            }
            else if (!EnemyIsAlive())
            {// IF ENEMY POKEMON FAINTED
                // Removes the enemy pokemon's image
                Enemy_Sprite.BackgroundImage = null;

                // Outputs a message for the user letting them know what happened.
                Message_Box.Text = $"Enemy {enemyPokemon.Name} fainted. YOU WIN.";

                // Waits for a delay
                await Task.Run(() => Delay(4));

                // Closes the current form and opens a new Start_Screen instance
                this.Close();
                new Start_Screen().Show();
            }
            else if (ranAway)
            { // IF THE USER RAN
                // Waits for a delay
                await Task.Run(() => Delay(4));

                // Closes the current form and opens a new Start_Screen instance
                this.Close();
                new Start_Screen().Show();
            }
        }

        /// <summary>
        /// Applies the correct status effect to the targeted pokemon and updates the UI.
        /// </summary>
        /// <param name="target"> Targeted pokemon. </param>
        /// <param name="targetHealthBar"> Health bar of the targeted pokemon. </param>
        /// <param name="textBox"> the label used to display the message. </param>
        /// <returns> True or False statement if there was a text change. </returns>
        private bool DoStatusEffect(Pokemon target, ProgressBar targetHealthBar, Label textBox)
        {
            // Creates a flagger to test if the text was changed due to a status effect.
            bool textChanged = false;

            // Switch statement that handles all status effects.
            switch (target.Status.ToLower())
            {
                // IF THE TARGET IS ASLEEP
                case "asleep":
                    // Determines randomly if the target wakes up. 33% chance to wake up.
                    int testAwake = rng.Next(0, 3);
                    
                    // Checks if the target wakes up
                    if (testAwake == 0)
                    {
                        // Updates the message and clears the target's status
                        textBox.Text = $"{target.Name} has woken up!";
                        target.Status = "";

                        // Sets the flagger to true indicating a text change
                        textChanged = true;
                    }
                    break;
                // IF THE TARGET IS FROZEN
                case "frozen":
                    // Determines randomly if the target thaws out. 20% chance to thaw out.
                    int testFrozen = rng.Next(0, 6);

                    // Checks if the target thaws out.
                    if (testFrozen == 0)
                    {
                        // Updates the message and clears the target's status
                        textBox.Text = $"{target.Name} has thawed out!";
                        target.Status = "";

                        // Sets the flagger to true indicating a text change
                        textChanged = true;
                    }
                    break;
                // IF THE TARGET IS POISONED
                case "poisoned":
                    // Displays a message showing that the target has taken damage due to poison
                    textBox.Text = $"{target.Name} has taken damage due to poison!";

                    // Calculates poison damage.
                    int poisonDamage = target.Health / 16;

                    // Ensures that the targetHealthBar will not go below zero after applying damage and applies accordingly
                    if (targetHealthBar.Value - poisonDamage < 0)
                    {
                        targetHealthBar.Value = 0;
                    }
                    else
                    {
                        targetHealthBar.Value -= poisonDamage;
                    }

                    // Sets the flagger to true indicating a text change
                    textChanged = true;
                    break;
                // IF THE TARGET IS BURNED
                case "burned":
                    // Displays a message showing that the target has taken damage due to burn
                    textBox.Text = $"{target.Name} has taken damage due to burn!";

                    // Calculates burn damage.
                    int burnDamage = target.Health / 8;

                    // Ensures that the targetHealthBar will not go below zero after applying damage and applies accordingly
                    if (targetHealthBar.Value - burnDamage < 0)
                    {
                        targetHealthBar.Value = 0;
                    }
                    else
                    {
                        targetHealthBar.Value -= burnDamage;
                    }

                    // Sets the flagger to true indicating a text change
                    textChanged = true;
                    break;
            }
            // Returns the textChanged flagger
            return textChanged;
        }

        /// <summary>
        /// Event handler for when the ShowAttackBox component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void ShowAttackBox_Click(object sender, EventArgs e)
        {
            // Checks if it isn't the player's turn
            if (!is_Player_Turn)
            {
                // Exits the method if it isn't the player's turn
                return;
            }

            // Sets it so that the AttackPanel is visible.
            AttackPanelLayout.Visible = true;

            // Sets the is_Option_Button_Pressed flagger to true
            is_Option_Button_Pressed = true;
        }

        /// <summary>
        /// Event handler for when the CatchButton component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void CatchButton_Click(object sender, EventArgs e)
        {
            // Checks if it isn't the player's turn
            if (!is_Player_Turn)
            {
                // Exits the method if it isn't the player's turn
                return;
            }

            // Sets it so that the PokeballPanel is visible.
            PokeballPanelLayout.Visible = true;

            // Sets the is_Option_Button_Pressed flagger to true
            is_Option_Button_Pressed = true;
        }

        /// <summary>
        /// Event handler for when the HealingItemButton component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void HealingItemButton_Click(object sender, EventArgs e)
        {
            // Checks if it isn't the player's turn
            if (!is_Player_Turn)
            {
                // Exits the method if it isn't the player's turn
                return;
            }

            // Sets it so that the HealingItemPanel is visible.
            healingItemTableLayout.Visible = true;

            // Sets the is_Option_Button_Pressed flagger to true
            is_Option_Button_Pressed = true;
            
        }

        /// <summary>
        /// Event handler for when the RunButton component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            // Generates a random number from 0 - 255
            int testNumber = rng.Next(0, 256);

            // Calculates the odds to escape using the CalculateRunAway() method.
            int oddsToEscape = CalculateRunAway();

            // Checks if the odds to escape is greater than 255 OR if the random number is less than the odds to escape
            if (oddsToEscape > 255 || testNumber < oddsToEscape)
            { // IF SO
                // Updates the message box and the ranAway boolean accordingly
                Message_Box.Text = "You successfully ran away ending the battle!";
                ranAway = true;
            }
            else
            { // IF NOT
                // Updates the message box accordingly
                Message_Box.Text = "You have failed to run away.";
            }
            // Sets the run button pressed flagger to true and the is option button pressed flagger to true
            is_Run_Button_Pressed = true;
            is_Option_Button_Pressed = true;
        }

        // RUNNING LOGIC

        /// <summary>
        /// Calculates the odds of running away successfully
        /// </summary>
        /// <returns> The odds of escaping. </returns>
        private int CalculateRunAway()
        {

            // Checks if enemy speed divided by 4 and the mod by 256 is equal to zero to avoid a dividing by zero error and returns 256
            if (enemyPokemon.Speed / 4 % 256 == 0) { return 256; }

            // Calculates the odds to escape using the formula
            int oddsToEscape = (playerPokemon.Speed * 32 / (enemyPokemon.Speed / 4 % 256)) + 30;

            // Returns the oddsToEscape
            return oddsToEscape;
        }

        // CATCHING LOGIC

        /// <summary>
        /// Tries to catch the enemy pokemon using a given pokeball
        /// </summary>
        /// <param name="inventoryNumber"> Index of the given pokeball in the inventory. </param>
        /// <returns> True or False if the pokemon was caught. </returns>
        private bool CatchPokemon(int inventoryNumber)
        {
            // Generates a number from 0 - 100.
            int testNumber = rng.Next(0, 101);

            // Calculates the catch rate of the pokeball using the Pokeball.Use() method
            int catchRate = (int)((pokeballs[inventoryNumber].Use(enemyPokemon, Enemy_Health_Bar) / 255) * 100);

            // Debug information that displays catch rate and test number
            // Debug.WriteLine($"Test Number: {testNumber}\nCatch Rate: {catchRate}\n Pokemon is caught: {catchRate >= testNumber}");

            // If the catch rate is above 100, returns true.
            if (catchRate >= 100) { return true; }

            // returns boolean if catchRate is greater than or equal to testNumber
            return catchRate >= testNumber;
        }

        /// <summary>
        /// Event handler for when a pokeball button is clicked.
        /// </summary>
        /// <param name="invNumber"> index of the pokeball in the inventory. </param>
        /// <param name="image"> The image of the pokeball used to display the capture. </param>
        private void Generic_PokeballButton_Click(int invNumber, Image image)
        {
            // Sets the is_Pokeball_Button_Pressed flagger to true
            is_Pokeball_Button_Pressed = true;

            // Checks if there are any pokeballs of the given type remaining.
            if (CheckAmountLeft(pokeballs[invNumber]) <= 0)
            {
                // Displays a message accordingly
                Message_Box.Text = $"You cannot use anymore {pokeballs[invNumber].Name}s, you have none remaining";
                // Exits the method.
                return;
            }

            // Decrements the amount of pokeballs of the given type in the inventory.
            pokeballs[invNumber].Amount--;

            // Using the CatchPokemon method determines if the pokemon was caught using the given pokeball
            if (CatchPokemon(invNumber))
            {
                // Displays a message showing a successful capture.
                Message_Box.Text = $"You caught the {enemyPokemon.Name} using a {pokeballs[invNumber].Name}!";

                // Hides the enemy sprite
                Enemy_Sprite.Visible = false;

                // Sets the picture to the correct image and then displays it
                pokeballPictureBox.BackgroundImage = image;
                pokeballPictureBox.Visible = true;
                
                // Sets the enemy's health to zero indicating a capture.
                Enemy_Health_Bar.Value = 0;
            }
            else
            {
                // Displays a message saying that the user failed to catch
                Message_Box.Text = $"You failed to catch the {enemyPokemon.Name}";
            }

            // Hides the pokeball panel lay out.
            PokeballPanelLayout.Visible = false;
        }

        /// <summary>
        /// Event handler for when the UsePokeBall component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void UsePokeballButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeballButton_Click method with the correct parameters.
            Generic_PokeballButton_Click(0, Resources.pokeball);

            // Updates the text of the corresponding button.
            UsePokeballButton.Text = $"Pokeball: {pokeballs[0].Amount}";
        }

        /// <summary>
        /// Event handler for when the UseGreatBall component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void UseGreatBallButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeballButton_Click method with the correct parameters.
            Generic_PokeballButton_Click(1, Resources.greatball);

            // Updates the text of the corresponding button.
            UseGreatBallButton.Text = $"GreatBall: {pokeballs[1].Amount}";
        }

        /// <summary>
        /// Event handler for when the UseUltraBall component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void UseUltraBallButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeballButton_Click method with the correct parameters.
            Generic_PokeballButton_Click(2, Resources.ultraball);

            // Updates the text of the corresponding button.
            UseUltraBallButton.Text = $"UltraBall: {pokeballs[2].Amount}";
        }

        /// <summary>
        /// Event handler for when the UseMasterBall component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void UseMasterBallButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_PokeballButton_Click method with the correct parameters.
            Generic_PokeballButton_Click(3, Resources.masterball);

            // Updates the text of the corresponding button.
            UseMasterBallButton.Text = $"MasterBall: {pokeballs[3].Amount}";
        }

        /// <summary>
        /// Checks the Amount property of an Item object.
        /// </summary>
        /// <param name="item"> The Item object that is going to be checked. </param>
        /// <returns> The remaining amount of the item. </returns>
        private static int CheckAmountLeft(Item item)
        {
            // Returns the remaining amount.
            return item.Amount;
        }

        /// <summary>
        /// Event handler for when the generic healing item component is clicked.
        /// </summary>
        /// <param name="invNumber"> The index of the healing item in the inventory. </param>
        private void Generic_UseHealingItem_Click(int invNumber)
        {
            // Sets the is_Healing_item_Button_Pressed flagger to true;
            is_Healing_Item_Button_Pressed = true;

            // Try Catch statement
            try
            {   
                // Checks if the healing item is a full heal
                if (invNumber == 3)
                {   
                    // Uses a full heal item on the player's pokemon and updates the text box accordingly
                    Message_Box.Text = inventory[3].UseItem(playerPokemon);
                }
                else
                {
                    // Uses the corresponding item to heal the player pokemon using the HealingItem.UseItem() and updates the text box accordingly
                    Message_Box.Text = inventory[invNumber].UseItem(Player_Health_Bar);
                }
            }
            catch (Exception) // Catches when an exception is thrown
            {
                // Updates the text box to let the user know they cant use that item.
                Message_Box.Text = "Unable to use this item as you have none left.";
            }

            // Hides the healing item table layout.
            healingItemTableLayout.Visible = false;
        }

        /// <summary>
        /// Event handler for when the Potion component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void PotionButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_UseHealingItem_Click method with the correct parameter for a potion
            Generic_UseHealingItem_Click(0);

            // Update the text of the button to display the remaining amount of potions
            potionButton.Text = $"Potion: {inventory[0].Amount}";
        }

        /// <summary>
        /// Event handler for when the Super Potion component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void SuperPotionButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_UseHealingItem_Click method with the correct parameter for a super potion
            Generic_UseHealingItem_Click(1);

            // Update the text of the button to display the remaining amount of super potions
            superPotionButton.Text = $"Super Potion: {inventory[1].Amount}";
        }

        /// <summary>
        /// Event handler for when the Hyper Potion component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void HyperPotionButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_UseHealingItem_Click method with the correct parameter for a hyper potion
            Generic_UseHealingItem_Click(2);

            // Update the text of the button to display the remaining amount of hyper potions
            hyperPotionButton.Text = $"Hyper Potion: {inventory[2].Amount}";
        }

        /// <summary>
        /// Event handler for when the Full Heal component is clicked.
        /// </summary>
        /// <param name="sender"> The object that raised the event. </param>
        /// <param name="e"> The event arguments. </param>
        private void FullHealButton_Click(object sender, EventArgs e)
        {
            // Calls the Generic_UseHealingItem_Click method with the correct parameter for a full heal
            Generic_UseHealingItem_Click(3);

            // Update the text of the button to display the remaining amount of full heals
            fullHealButton.Text = $"Full Heal: {inventory[3].Amount}";
        }
        
        /// <summary>
        /// Sets the status label for a pokemon based on its current status
        /// </summary>
        /// <param name="pokemon"> The pokemon whose label is to be set. </param>
        /// <param name="statusLabel"> The label that displays the status. </param>
        private static void Generic_StatusLabelSet(Pokemon pokemon, Label statusLabel)
        {
            // Switch statement that takes the current Status of the given pokemon.
            switch (pokemon.Status.ToLower())
            {
                // Sets the status label's text, color, and visibility accordingly
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
                // DEFAULT CASE. Clears the text, changes the color to white, and hides the label.
                default:
                    statusLabel.Text = "";
                    statusLabel.BackColor = Color.White;
                    statusLabel.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Updates the status labels for the player and enemy pokemon using the Generic_StatusLabelSet() method.
        /// </summary>
        private void UpdateStatusLabels()
        {
            // Calls Generic_StatusLabelSet accordingly
            Generic_StatusLabelSet(playerPokemon, Player_StatusLabel);
            Generic_StatusLabelSet(enemyPokemon, Enemy_StatusLabel);
        }
    }
}
