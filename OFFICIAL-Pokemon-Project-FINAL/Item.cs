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
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public readonly Random rng = new();

        public Item(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }

    // Pokeball logic https://bulbapedia.bulbagarden.net/wiki/Catch_rate

    public class GenericPokeball : Item
    {
        public double CatchRate { get; set; }


        public GenericPokeball(string name, int amount, double catchRate) : base(name, amount)
        {
            CatchRate = catchRate;
        }

        private double GetStatusCatchAffect(Pokemon target)
        {
            string[] minorAffects = ["poisoned", "paralyzed", "burned"];
            string[] majorAffects = ["asleep", "frozen"];

            if (minorAffects.Contains(target.Status.ToLower()))
            {
                return 1.5;
            }
            if (majorAffects.Contains(target.Status.ToLower()))
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }

        public virtual double Use(Pokemon target, ProgressBar targetHealthBar)
        {
            double calculatedResult = (((3 * target.health) - (2 * targetHealthBar.Value)) * 128 * CatchRate / (3 * target.health))  * GetStatusCatchAffect(target);
            Debug.WriteLine(calculatedResult);
            return calculatedResult;
        }
    }

    public class Pokeball : GenericPokeball
    {
        public Pokeball() : base("Pokeball", 5, 1) { }
    }
    public class GreatBall : GenericPokeball
    {
        public GreatBall() : base("GreatBall", 3, 1.5) { }
    }

    public class UltraBall : GenericPokeball
    {
        public UltraBall() : base("UltraBall", 2, 2) { }
    }

    public class MasterBall : GenericPokeball
    {
        public MasterBall() : base("MasterBall", 1, 255) { }

    }

    public class HealingItem : Item
    {
        public int HealingStrength { get; set; }


        public HealingItem(string name, int amount, int healingStrength) : base(name, amount)
        {
            HealingStrength = healingStrength;
        }

        public virtual string UseItem(ProgressBar healthBar)
        {
            if (Amount <= 0)
            {
                throw new Exception();
            }

            if (healthBar.Value + HealingStrength > healthBar.Maximum)
            {
                healthBar.Value = healthBar.Maximum;
            }

            else
            {
                healthBar.Value += HealingStrength;
            }

            Amount -= 1;

            return $"You used {Name}";
        }

        public virtual string UseItem(Pokemon user)
        {
            if (Amount <= 0)
            {
                throw new Exception();
            }

            Amount -= 1;

            return $"You used {Name}";
        }
    }

    public class Potion : HealingItem
    {
        public Potion() : base("Potion", 3, 20) { }
    }

    public class SuperPotion : HealingItem
    {
        public SuperPotion() : base("Super Potion", 3, 60) { }
    }

    public class HyperPotion : HealingItem
    {
        public HyperPotion() : base("Hyper Potion", 3, 120) { }
    }

    public class FullHeal : HealingItem
    {
        public FullHeal() : base("Full Heal", 3, 100) {}

        public override string UseItem(Pokemon user)
        {
            user.Status = "";
            return $"You used {Name}. Your {user.name} is no longer suffering from any status effects.";
        }

    }


}
