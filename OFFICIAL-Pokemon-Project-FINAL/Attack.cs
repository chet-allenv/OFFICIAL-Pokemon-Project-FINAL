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

        public int BasePower { get; set; }
        public int Accuracy { get; set; }
        public string Name { get; set; }
        public string MoveType { get; set; }
        public int PowerPoints { get; set; }

        
        public readonly PokemonType pt = new();
        public readonly Random rng = new Random();

        public Attack(int basePower, int accuracy, string name, string moveType, int powerPoints)
        {
            this.BasePower = basePower;
            this.Accuracy = accuracy;
            this.Name = name;
            this.MoveType = moveType;
            this.PowerPoints = powerPoints;

            pt.Initialize_Type_Matchup();
        }

        public virtual string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            return "Attack Used";
        }

        public string Get_Used_Attack_Message(Pokemon pokemon)
        {
            return $"{pokemon.Name} used {this.Name}";
        }

        public (double effectiveness, string message) Calculate_Type_Effectiveness(Pokemon target)
        {
            string message = "";

            pt.Weakness_Dictionary.TryGetValue(target.Type1, out List<string> Target_Weaknesses_Type1);
            pt.Strength_Dictionary.TryGetValue(target.Type1, out List<string> Target_Strengths_Type1);

            pt.Weakness_Dictionary.TryGetValue(target.Type2, out List<string> Target_Weaknesses_Type2);
            pt.Strength_Dictionary.TryGetValue(target.Type2, out List<string> Target_Strengths_Type2);

            Target_Weaknesses_Type1 ??= [];
            Target_Strengths_Type1 ??= [];

            Target_Weaknesses_Type2 ??= [];
            Target_Strengths_Type2 ??= [];

            double effectiveness = 1.0;

            if (Target_Strengths_Type1.Contains(MoveType))
            {
                effectiveness *= 0.5;
            }
            if (Target_Weaknesses_Type1.Contains(MoveType))
            {
                effectiveness *= 2;
            }
            if (Target_Strengths_Type2.Contains(MoveType))
            {
                effectiveness *= 0.5;
            }
            if (Target_Weaknesses_Type2.Contains(MoveType))
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

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            int testAccuracy = rng.Next(0, 101);

            if (testAccuracy <= Accuracy)
            {
                double STAB = MoveType.Equals(user.Type1) || MoveType.Equals(user.Type2) ? 1.5 : 1.0;

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

            PowerPoints -= 1;

            message = testAccuracy <= Accuracy ? $"{user.Name} used {this.Name}" : $"Attack missed\n{user.Name} used {this.Name}";

            return message;
        }

        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {

            int randomNumber = rng.Next(217, 256);

            double damage_DOUBLE = ((2 * user.Level / 5 + 2) * user.Attack * BasePower / target.Defense / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100;
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

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            int testAccuracy = rng.Next(0, 101);

            if (testAccuracy <= Accuracy)
            {
                double STAB = MoveType.Equals(user.Type1) || MoveType.Equals(user.Type2) ? 1.5 : 1.0;

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

            PowerPoints -= 1;

            message = testAccuracy <= Accuracy ? $"{user.Name} used {this.Name}" : $"Attack missed\n{user.Name} used {this.Name}";

            return message;
        }

        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {
            int randomNumber = rng.Next(217, 256);

            int damage = (int)(((2 * user.Level / 5 + 2) * user.Attack * BasePower / target.Defense / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100);

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

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "asleep";
            PowerPoints--;

            return $"{user.Name} used sleep attack and put {target.Name} to sleep!";
        }
    }

    public class Poison_Breath : Special_Attack
    {
        public Poison_Breath() : base(0, 100, "Poison Breath", "Normal", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "poisoned";
            PowerPoints--;

            return $"{user.Name} used poison breath and poisoned {target.Name}!";
        }
    }

    public class Fire_Breath : Special_Attack
    {
        public Fire_Breath() : base(0, 100, "Fire Breath", "Fire", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "burned";
            PowerPoints--;

            return $"{user.Name} used fire breath and burned {target.Name}!";
        }
    }

    public class Thunder_Wave : Special_Attack
    {
        public Thunder_Wave() : base(0, 100, "Thunder Wave", "Normal", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "paralyzed";
            PowerPoints--;

            return $"{user.Name} used thunder wave and paralyzed {target.Name}!";
        }
    }

    public class Ice_Breath : Special_Attack
    {
        public Ice_Breath() : base(0, 25, "Ice Breath", "Ice", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 4);


            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            PowerPoints--;

            if (num == 0)
            {
                target.Status = "frozen";
                return $"{user.Name} used ice breath and froze {target.Name}!";
            }
            else
            {
                return "Attack missed";
            }
        }
    }

    public class Thunderbolt : Special_Attack
    {
        public Thunderbolt() : base(90, 100, "Thunderbolt", "Electric", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 10);
            string message = "";


            if (num == 0)
            {
                target.Status = "Paralyzed";
                message = $"{target.Name} was paralyzed";
            }

            return message + base.Use(user, target, targetHealthBar);
        }
    }
    public class Ice_Beam : Special_Attack
    {
        public Ice_Beam() : base(90, 100, "Ice Beam", "Ice", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 10);
            string message = "";


            if (num == 0)
            {
                target.Status = "Frozen";
                message = $"{target.Name} was Frozen";
            }

            return message + base.Use(user, target, targetHealthBar);
        }
    }

}
