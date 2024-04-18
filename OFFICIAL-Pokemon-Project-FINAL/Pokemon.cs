using OFFICIAL_Pokemon_Project_FINAL.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public string name {  get; set; }
        
        public Image[] sprites { get; set; } // Holds both front and back sprite. Front is index 0 and back is index 1
        public int attack { get; set; }
        public int defense { get; set; }
        public int special { get; set; }
        public int speed { get; set; }
        public int health { get; set; }
        public int level { get; set; }
        public string type { get; set; }

        

        public Attack[] moveSet;

        private readonly Random rng = new Random();

        public Pokemon(string name, Image frontSprite, Image backSprite, string type, int level)
        {

            this.name = name;
            sprites = [frontSprite, backSprite];
            attack = Generate_Stat();
            defense = Generate_Stat();
            special = Generate_Stat();
            speed = Generate_Stat();
            health = Generate_Stat(100, 280);
            this.level = level;
            this.type = type;

            moveSet = new Attack[2];
        }

        private int Generate_Stat(int low = 5, int high = 25)
        {
            return rng.Next(low, high) + 2 * (2 * this.level / 5 + 2);
        }

        public bool Is_Alive() { return this.health > 0; }

        public void Attack(int attackNumber, Pokemon target, ProgressBar targetHealthBar)
        {
            moveSet[attackNumber].Use(this, target, targetHealthBar);
        }

        public Image Get_Front_Sprite()
        {
            return sprites[0];
        }

        public Image Get_Back_Sprite()
        {
            return sprites[1];
        }
    }

    public class Charmander : Pokemon
    {

        public Charmander() : base("Charmander", Resources.charmander, Resources.charmander_back, "Fire", 5)
        {
            moveSet = [new Tackle_Attack(), new Ember_Attack()];
        }
    }

    public class Squirtle : Pokemon
    {

        public Squirtle() : base("Squirtle", Resources.squirtle, Resources.squirtle_back, "Water", 5)
        {
            moveSet = [new Tackle_Attack(), new Bubble_Attack()];
        }
    }

    public class Bulbasaur : Pokemon
    {

        public Bulbasaur() : base("Bulbasaur", Resources.bulbasaur, Resources.bulbasaur_back, "Grass", 5)
        {
            moveSet = [new Tackle_Attack(), new Vine_Whip_Attack()];
        }
    }
}
