using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.UserActivities;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    // class defining certain Items in the game
    public class Item
    {
        public string Name { get; set; } // name of the items
        public int Amount { get; set; } // amount of each item the player can have

        // gen random number 
        public readonly Random rng = new();

        // constructor for the item class
        public Item(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }

    // Pokeball logic https://bulbapedia.bulbagarden.net/wiki/Catch_rate

    // Define a generic Pokeball class and implement the logic for CatchRate
    public class GenericPokeball : Item
    {
        // getter setter for Pokeball catch rate
        public double CatchRate { get; set; }

        // constructor for the GenericPokeball class defining its name, amount, and catchRate
        public GenericPokeball(string name, int amount, double catchRate) : base(name, amount)
        {
            CatchRate = catchRate;
        }

        // calculate the catchRate of the Pokeball based on the status effect on the target
        private double GetStatusCatchAffect(Pokemon target)
        {
            // Status effect conditions
            string[] minorAffects = ["poisoned", "paralyzed", "burned"];
            string[] majorAffects = ["asleep", "frozen"];

            // check if it is a minor status effect and change the catch rate accordingly 
            if (minorAffects.Contains(target.Status.ToLower()))
            {
                return 1.5; // minor status effect modifier 
            }
            // check if it is a major status effect and change the catch rate accordingly
            if (majorAffects.Contains(target.Status.ToLower()))
            {
                return 2; // major status effect modifier
            }
            else
            {
                return 1; // default modifier with no status effect
            }

        }

        // method to use the Pokeball to catch the target Pokemon
        public virtual double Use(Pokemon target, ProgressBar targetHealthBar)
        {
            // calculate the catch rate result using a formula we created 
            double calculatedResult = (((3 * target.Health) - (2 * targetHealthBar.Value)) * 128 * CatchRate / (3 * target.Health))  * GetStatusCatchAffect(target);
            // output the calculated result
            Debug.WriteLine(calculatedResult);
            // return the result 
            return calculatedResult;
        }
    }

    // define specific types of Pokeballs that all have unique pre-defined catch rates
    public class Pokeball : GenericPokeball
    {
        public Pokeball() : base("Pokeball", 5, 1) { } // default Pokeball
    }
    public class GreatBall : GenericPokeball
    {
        public GreatBall() : base("GreatBall", 3, 1.5) { } // Great Ball with higher catch rate than Pokeball
    }

    public class UltraBall : GenericPokeball
    {
        public UltraBall() : base("UltraBall", 2, 2) { } // Ultra Ball with higher catch rate than Great Ball
    }

    public class MasterBall : GenericPokeball
    {
        public MasterBall() : base("MasterBall", 1, 255) { } // Master Ball with a guaranteed catch rate

    }

    // base class from Item representing Healing Items 
    public class HealingItem : Item
    {
        // get and set the strength of each healing item
        public int HealingStrength { get; set; }

        // constructor for the healing item class
        public HealingItem(string name, int amount, int healingStrength) : base(name, amount)
        {
            HealingStrength = healingStrength;
        }

        // method to use the healing items
        public virtual string UseItem(ProgressBar healthBar)
        {
            // check if the player has any remaining healing items
            if (Amount <= 0)
            {
                throw new Exception();
            }

            // make sure the healing item does not exceed the max health of the user 
            if (healthBar.Value + HealingStrength > healthBar.Maximum)
            {
                healthBar.Value = healthBar.Maximum; // set health to max if the healing power added to the current health exceeds the max health
            }

            else
            {
                healthBar.Value += HealingStrength; // otherwise increase the health based on the healing strength
            }

            Amount -= 1; // decrease amount of a given item after use 

            return $"You used {Name}";
        }

        // method to use a healing item on a Pokemon
        public virtual string UseItem(Pokemon user)
        {
            // check if player has any items left
            if (Amount <= 0)
            {
                throw new Exception(); // exception thrown if no items are available 
            }

            Amount -= 1; // decrease number of items after use 

            return $"You used {Name}";
        }
    }

    // define specific healing items that all have pre defined healing strength 
    public class Potion : HealingItem
    {
        public Potion() : base("Potion", 3, 20) { } // basic healing potion (amount = 3) (healing strength = 20)
    }

    public class SuperPotion : HealingItem
    {
        public SuperPotion() : base("Super Potion", 3, 60) { } // super potion (amount = 3) (healing strength = 60)
    }

    public class HyperPotion : HealingItem
    {
        public HyperPotion() : base("Hyper Potion", 3, 120) { } // hyper potion (amount = 3) (healing strength = 120)
    }

    public class FullHeal : HealingItem
    {
        public FullHeal() : base("Full Heal", 3, 100) {} // full heal (amount = 3) (healing strength = 100)

        // override the UseItem method to remove any status effects on a Pokemon when a Full Heal is used 
        public override string UseItem(Pokemon user)
        {
            user.Status = ""; // remove all status effects 
            Amount--; // decrease item used 
            return $"You used {Name}. Your {user.Name} is no longer suffering from any status effects.";
        }

    }


}
