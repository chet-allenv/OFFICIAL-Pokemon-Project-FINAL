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

        public string Name {  get; set; }
        
        public Image[] Sprites { get; set; } // Holds both front and back sprite. Front is index 0 and back is index 1
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public string Type1 { get; set; }

#nullable enable
        public string? Type2 { get; set; }
#nullable disable

        public string Status { get; set; } = "";

        

        public Attack[] moveSet;

        private readonly Random rng = new Random();

        public Pokemon(string name, Image frontSprite, Image backSprite, string type1, string type2, int level)
        {

            this.Name = name;
            Sprites = [frontSprite, backSprite];
            Attack = Generate_Stat();
            Defense = Generate_Stat();
            Special = Generate_Stat();
            Speed = Generate_Stat();
            Health = Generate_Stat(100, 280);
            Level = level;
            Type1 = type1;
            Type2 = type2;

            moveSet = new Attack[4];
        }

        public int Generate_Stat(int low = 5, int high = 25)
        {
            return rng.Next(low, high);
        }

        public bool Is_Alive() { return this.Health > 0; }

        public void UseAttack(int attackNumber, Pokemon target, ProgressBar targetHealthBar)
        {
            moveSet[attackNumber].Use(this, target, targetHealthBar);
        }

        public Image Get_Front_Sprite()
        {
            return Sprites[0];
        }

        public Image Get_Back_Sprite()
        {
            return Sprites[1];
        }
    }


    public class Wattrus : Pokemon
    {
        public Wattrus() : base("Wattrus", Resources.wattrus_front, Resources.wattrus_back, "Electric", "Ice", 50)
        {
            // implement later
            moveSet = [new Thunderbolt(), new Thunder_Wave(), new Ice_Beam(), new Ice_Breath()];

            Attack = 50 + Generate_Stat(-20, 20);
            Defense = 150 + Generate_Stat(-20, 20);
            Speed = 25 + Generate_Stat(-20, 20);
            Special = 100 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    public class Nautighoul : Pokemon
    {
        public Nautighoul() : base("Nautighoul", Resources.naughtighoul_front, Resources.naughtighoul_back, "Water", "Ghost", 50)
        {
            // implement later
            moveSet = [new Hydro_Pump(), new Anchor_Slam(), new Shadow_Ball(), new Ectoplasm()];

            Attack = 120 + Generate_Stat(-20, 20);
            Defense = 75 + Generate_Stat(-20, 20);
            Speed = 50 + Generate_Stat(-20, 20);
            Special = 100 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    public class Chainsprout : Pokemon
    {
        public Chainsprout() : base("Chainsprout", Resources.chainsprout_front, Resources.chainsprout_back, "Grass", "Steel", 50)
        {
            // implement later
            moveSet = [new Vine_Whip_Attack(), new Razor_Leaf(), new Chainsaw(), new Riposte()];

            Attack = 100 + Generate_Stat(-20, 20);
            Defense = 100 + Generate_Stat(-20, 20);
            Speed = 20 + Generate_Stat(-20, 20);
            Special = 75 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    public class Rockmoth : Pokemon
    {
        public Rockmoth() : base("Rockmoth", Resources.rockmoth_front, Resources.rockmoth_back, "Rock", "Bug", 50)
        {
            moveSet = [new Harden(), new Rock_Throw(), new Barbed_Stinger(), new Wing_Attack()];

            Attack = 160 + Generate_Stat(-20, 20);
            Defense = 100 + Generate_Stat(-20, 20);
            Speed = 70 + Generate_Stat(-20, 20);
            Special = 50 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    public class Flamindgo : Pokemon
    {

        public Flamindgo() : base("Flamindgo", Resources.flamindgo_front, Resources.flamindgo_back, "Psychic", "Flying", 50)
        {
            moveSet = [new Lullaby(), new Dream_Eater(), new Psybeam(), new Arial_Acrobatics()];

            Attack = 100 + Generate_Stat(-20, 20);
            Defense = 60 + Generate_Stat(-20, 20);
            Speed = 120 + Generate_Stat(-20, 20);
            Special = 150 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }

    public class FireDragon : Pokemon
    {
        public FireDragon() : base("Fire Dragon", Resources.fire_dragon_front, Resources.fire_dragon_back, "Fire", "Dragon", 50)
        {

            moveSet = [new Flamethrower_Attack(), new Fire_Breath(), new Dragon_Pulse(), new Dragon_Roar()];

            Attack = 150 + Generate_Stat(-20, 20);
            Defense = 95 + Generate_Stat(-20, 20);
            Speed = 80 + Generate_Stat(-20, 20);
            Special = 150 + Generate_Stat(-20, 20);
            Health = 500 + Generate_Stat(-100, 100);
        }
    }
}
