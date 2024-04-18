using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
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

        public virtual int Use(Pokemon target, ProgressBar targetHealthBar)
        {

            return (int)((((targetHealthBar.Value * (1 + CatchRate) / target.health)) / 2) * 100);
        }
    }

    public class Pokeball : GenericPokeball
    {
        public Pokeball() : base("Pokeball", 5, .25) { }
    }
    public class GreatBall : GenericPokeball
    {
        public GreatBall() : base("GreatBall", 3, .5) { }
    }

    public class UltraBall : GenericPokeball
    {
        public UltraBall() : base("UltraBall", 2, .75) { }
    }

    public class MasterBall : GenericPokeball
    {
        public MasterBall() : base("MasterBall", 1, 100.0) { }

        public override int Use(Pokemon target, ProgressBar targetHealthBar)
        {
            return 100;
        }
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
        public FullHeal() : base("Full Heal", 3, 100)
        {
            // IMPLEMENT LATER
        }

    }


}
