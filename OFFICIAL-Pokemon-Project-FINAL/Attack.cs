using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    public class Attack
    {

        public int basePower { get; set; }
        public int accuracy { get; set; }
        public string name { get; set; }
        public string moveType { get; set; }
        public int powerPoints { get; set; }

        
        public readonly PokemonType pt = new();
        public readonly Random rng = new Random();

        public Attack(int basePower, int accuracy, string name, string moveType, int powerPoints)
        {
            this.basePower = basePower;
            this.accuracy = accuracy;
            this.name = name;
            this.moveType = moveType;
            this.powerPoints = powerPoints;

            pt.Initialize_Type_Matchup();
        }

        public virtual string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            return "Attack Used";
        }

        public string Get_Used_Attack_Message(Pokemon pokemon)
        {
            return $"{pokemon.name} used {this.name}";
        }

        public (double effectiveness, string message) Calculate_Type_Effectiveness(Pokemon target)
        {
            string message = "";

            pt.Weakness_Dictionary.TryGetValue(target.type, out List<string> Target_Weaknesses);
            pt.Strength_Dictionary.TryGetValue(target.type, out List<string> Target_Strengths);

            Target_Weaknesses ??= [];
            Target_Strengths ??= [];

            double effectiveness = 1.0;

            if (Target_Strengths.Contains(moveType))
            {
                effectiveness *= 0.5;
            }
            if (Target_Weaknesses.Contains(moveType))
            {
                effectiveness *= 2;
            }

            if (effectiveness < 1)
            {
                message = "It's not very effective";
            }
            else if (effectiveness > 1)
            {
                message = "It's super effective";
            }

            return (effectiveness, message);
        }
    }

    public class Physical_Attack : Attack
    {
        public Physical_Attack(int power, int accuracy, string name, string type, int powerPoints) : base(power, accuracy, name, type, powerPoints) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            string message = "";

            if (powerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            int testAccuracy = rng.Next(0, 101);

            if (testAccuracy <= accuracy)
            {
                double STAB = moveType.Equals(user.type) ? 1.5 : 1.0;

                double typeEffectiveness = Calculate_Type_Effectiveness(target).effectiveness;

                int damage = Calculate_Damage(user, target, STAB, typeEffectiveness);

                if (targetHealthBar.Value - damage < 0)
                {
                    targetHealthBar.Value = 0;
                }

                else
                {
                    targetHealthBar.Value -= damage;
                }
            }

            powerPoints -= 1;

            message = testAccuracy <= accuracy ? $"{user.name} used {this.name}" : $"Attack missed\n{user.name} used {this.name}";

            return message;
        }

        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {

            int randomNumber = rng.Next(217, 256);

            double damage_DOUBLE = ((2 * user.level / 5 + 2) * user.attack * basePower / target.defense / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100;
            int damage = (int)damage_DOUBLE;

            return damage;
        }
    }

    public class Special_Attack : Attack
    {
        public Special_Attack(int power, int accuracy, string name, string type, int powerPoints) : base(power, accuracy, name, type, powerPoints) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            string message = "";

            if (powerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            int testAccuracy = rng.Next(0, 101);

            if (testAccuracy <= accuracy)
            {
                double STAB = moveType.Equals(user.type) ? 1.5 : 1.0;

                double typeEffectiveness = Calculate_Type_Effectiveness(target).effectiveness;

                int damage = Calculate_Damage(user, target, STAB, typeEffectiveness);

               
                if (targetHealthBar.Value - damage < 0)
                {
                    targetHealthBar.Value = 0;
                }

                else
                {
                    targetHealthBar.Value -= damage;
                }
            }

            powerPoints -= 1;

            message = testAccuracy <= accuracy ? $"{user.name} used {this.name}" : $"Attack missed\n{user.name} used {this.name}";

            return message;
        }

        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {
            int randomNumber = rng.Next(217, 256);

            int damage = (int)(((2 * user.level / 5 + 2) * user.attack * basePower / target.defense / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100);

            return damage;
        }
    }

    public class Tackle_Attack : Physical_Attack
    {
        public Tackle_Attack() : base(30, 70, "Tackle", "Normal", 30) { }
    }

    public class Ember_Attack : Special_Attack
    {

        public Ember_Attack() : base(30, 80, "Ember", "Fire", 30) { }
    }

    public class Flamethrower_Attack : Special_Attack
    {
        public Flamethrower_Attack() : base(70, 80, "Flamethrower", "Fire", 10) { }
    }

    public class Bubble_Attack : Special_Attack
    {
        public Bubble_Attack() : base(30, 80, "Bubble", "Water", 30) { }
    }

    public class Vine_Whip_Attack : Special_Attack
    {
        public Vine_Whip_Attack() : base(30, 80, "Vine Whip", "Grass", 30) { }
    }

    public class Sleep_Attack : Special_Attack
    {
        public Sleep_Attack() : base(0, 100, "Sleep Attack", "Normal", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            if (powerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "asleep";
            powerPoints--;

            return $"{user.name} used sleep attack and put {target.name} to sleep!";
        }
    }
}
