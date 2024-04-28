using OFFICIAL_Pokemon_Project_FINAL.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
{   
    /// <summary>
    /// This class represents all of the features of a Pokemon that are required for the game.
    /// </summary>
    public class Pokemon
    {
        // properties for various attributes that the Pokemon have
        public string Name {  get; set; } // Pokemon name 
        public Image[] Sprites { get; set; } // Holds both front and back sprite. Front is index 0 and back is index 1
        public int Attack { get; set; } // attack power 
        public int Defense { get; set; } // defense stats
        public int Special { get; set; } // special attack 
        public int Speed { get; set; } // speed attribute 
        public int Health { get; set; } // health attribute
        public int Level { get; set; } // pokemon level 
        public string Type1 { get; set; } // Pokemon type 

#nullable enable
        public string? Type2 { get; set; } // second type for pokemon if they have multiple
#nullable disable

        public string Status { get; set; } = ""; // status of pokemon

        
        // array to hold all possible attack moves 
        public Attack[] moveSet;

        // random number for generating stats 
        private readonly Random rng = new Random();

        // Constructor for creating a new Pokemon object with specified attributes.
        public Pokemon(string name, Image frontSprite, Image backSprite, string type1, string type2, int level)
        {

            this.Name = name;
            Sprites = [frontSprite, backSprite]; // initializing the sprites array
            Attack = Generate_Stat(); // gen random value for stats 
            Defense = Generate_Stat();
            Special = Generate_Stat();
            Speed = Generate_Stat();
            Health = Generate_Stat(100, 280); // health with a range of 100 to 280
            Level = level;
            Type1 = type1;
            Type2 = type2;

            moveSet = new Attack[4]; // initialize moveset array with 4 moves a Pokemon can use
        }

        // generate a random stat value within the range of 5 and 25
        public int Generate_Stat(int low = 5, int high = 25)
        {
            return rng.Next(low, high);
        }

        // check if pokemon is alive based on its current health
        public bool Is_Alive() { return this.Health > 0; }

        // executes the specified attack on the target Pokemon
        public void UseAttack(int attackNumber, Pokemon target, ProgressBar targetHealthBar)
        {
            moveSet[attackNumber].Use(this, target, targetHealthBar);
        }

        // returns the front sprite of the Pokemon
        public Image Get_Front_Sprite()
        {
            return Sprites[0];
        }

        // returns the back sprite of the Pokemon
        public Image Get_Back_Sprite()
        {
            return Sprites[1];
        }
    }

    // subclasses representing specific Pokemon species inherting from the base Pokemon class

    // define Pokemon named Wattrus
    public class Wattrus : Pokemon
    {
        // Electric and Ice type Pokemon at level 50
        public Wattrus() : base("Wattrus", Resources.wattrus_front, Resources.wattrus_back, "Electric", "Ice", 50)
        {
            // implement the specific moveset for Wattrus
            moveSet = [new Thunderbolt(), new Thunder_Wave(), new Ice_Beam(), new Ice_Breath()];

            // adjusting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Wattrus
            Attack = 50 + Generate_Stat(-20, 20);
            Defense = 150 + Generate_Stat(-20, 20);
            Speed = 25 + Generate_Stat(-20, 20);
            Special = 100 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }
    
    // define Pokemon named Nautighoul
    public class Nautighoul : Pokemon
    {
        // Water and Ghost type Pokemon at level 50
        public Nautighoul() : base("Nautighoul", Resources.naughtighoul_front, Resources.naughtighoul_back, "Water", "Ghost", 50)
        {
            // implement the specific moveset for Nautighoul
            moveSet = [new Hydro_Pump(), new Anchor_Slam(), new Shadow_Ball(), new Ectoplasm()];

            // adjusting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Nautighoul
            Attack = 120 + Generate_Stat(-20, 20);
            Defense = 75 + Generate_Stat(-20, 20);
            Speed = 50 + Generate_Stat(-20, 20);
            Special = 100 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    // define Pokemon named Chainsprout
    public class Chainsprout : Pokemon
    {
        // Grass and Steel type Pokemon at level 50
        public Chainsprout() : base("Chainsprout", Resources.chainsprout_front, Resources.chainsprout_back, "Grass", "Steel", 50)
        {
            // implement the specific moveset for Chainsprout
            moveSet = [new Vine_Whip_Attack(), new Razor_Leaf(), new Chainsaw(), new Riposte()];

            // adjusting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Chainsprout
            Attack = 100 + Generate_Stat(-20, 20);
            Defense = 100 + Generate_Stat(-20, 20);
            Speed = 20 + Generate_Stat(-20, 20);
            Special = 75 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    // define Pokemon named Rockmoth
    public class Rockmoth : Pokemon
    {
        // Rock and Bug type Pokemon at level 50
        public Rockmoth() : base("Rockmoth", Resources.rockmoth_front, Resources.rockmoth_back, "Rock", "Bug", 50)
        {
            // implement the specific moveset for Rockmoth
            moveSet = [new Harden(), new Rock_Throw(), new Barbed_Stinger(), new Wing_Attack()];

            // adjusting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Rockmoth
            Attack = 160 + Generate_Stat(-20, 20);
            Defense = 100 + Generate_Stat(-20, 20);
            Speed = 70 + Generate_Stat(-20, 20);
            Special = 50 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    // define Pokemon named Flamindgo
    public class Flamindgo : Pokemon
    {
        // Psychic and Flying type Pokemon at level 50
        public Flamindgo() : base("Flamindgo", Resources.flamindgo_front, Resources.flamindgo_back, "Psychic", "Flying", 50)
        {    
            // implement the specific moveset for Flamindgo
            moveSet = [new Lullaby(), new Dream_Eater(), new Psybeam(), new Arial_Acrobatics()];

            // adjsuting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Flamindgo
            Attack = 100 + Generate_Stat(-20, 20);
            Defense = 60 + Generate_Stat(-20, 20);
            Speed = 120 + Generate_Stat(-20, 20);
            Special = 150 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    // define Pokemon named Infernothorn
    public class Infernothorn : Pokemon
    {
        // Fire and Dragon type Pokemon at level 50
        public Infernothorn() : base("Infernothorn", Resources.infernothorn_front, Resources.infernothorn_back, "Fire", "Dragon", 50)
        {
            // implement the specific moveset for Infernothorn
            moveSet = [new Flamethrower_Attack(), new Fire_Breath(), new Dragon_Pulse(), new Dragon_Roar()];

            // adjusting Attack power, defensive stats, speed, special attack power, and max health within a certain range for Infernothorn
            Attack = 150 + Generate_Stat(-20, 20);
            Defense = 95 + Generate_Stat(-20, 20);
            Speed = 80 + Generate_Stat(-20, 20);
            Special = 150 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }
}
