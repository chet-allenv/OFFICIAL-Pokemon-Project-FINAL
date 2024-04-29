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
    // Base class for attacks
    public class Attack
    {

        // properties for attack attributes
        public int BasePower { get; set; } // base power for moves
        public int Accuracy { get; set; } // move accuracy
        public string Name { get; set; }
        public string MoveType { get; set; } // elemental type for moves
        public int PowerPoints { get; set; } // PP is number of times an attack can be used

        // Instances of PokemonType and Random used for type matchups and random number generation 
        public readonly PokemonType pt = new();
        public readonly Random rng = new Random();

        // initializing attack attributes 
        public Attack(int basePower, int accuracy, string name, string moveType, int powerPoints)
        {
            this.BasePower = basePower;
            this.Accuracy = accuracy;
            this.Name = name;
            this.MoveType = moveType;
            this.PowerPoints = powerPoints;

            // initialize type matchups
            pt.Initialize_Type_Matchup();
        }

        // method for using attack
        public virtual string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            return "Attack Used";
        }
        
        // getting message indicating that the move has been used
        public string Get_Used_Attack_Message(Pokemon pokemon)
        {
            return $"{pokemon.Name} used {this.Name}";
        }
        
        // Method for calculating the effectiveness of an attack against a target Pokemon based on type matchups
        public (double effectiveness, string message) Calculate_Type_Effectiveness(Pokemon target)
        {
            string message = "";

            // Get the weaknesses and strengths of the target Pokemon's types
            pt.Weakness_Dictionary.TryGetValue(target.Type1, out List<string> Target_Weaknesses_Type1);
            pt.Strength_Dictionary.TryGetValue(target.Type1, out List<string> Target_Strengths_Type1);

            pt.Weakness_Dictionary.TryGetValue(target.Type2, out List<string> Target_Weaknesses_Type2);
            pt.Strength_Dictionary.TryGetValue(target.Type2, out List<string> Target_Strengths_Type2);

            // set default values if dictionaries return null
            Target_Weaknesses_Type1 ??= [];
            Target_Strengths_Type1 ??= [];

            Target_Weaknesses_Type2 ??= [];
            Target_Strengths_Type2 ??= [];

            double effectiveness = 1.0;

            // adjust the effectivenes based on type matchups
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

            // display the effectiveness of the attack
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

    // subclass of attack representing physical attacks
    public class Physical_Attack : Attack
    {
        // Calling base class constructor 
        public Physical_Attack(int power, int accuracy, string name, string type, int powerPoints) : base(power, accuracy, name, type, powerPoints) { }

        // override method for physical attack usage
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            string message = "";

            // check if there is enough PP to use attack
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // generate random number to determine accuracy
            int testAccuracy = rng.Next(0, 101);

            // if the attack lands
            if (testAccuracy <= Accuracy)
            {
                // calculate same type attack bonus (attack is same type as Pokemon) (STAB)
                double STAB = MoveType.Equals(user.Type1) || MoveType.Equals(user.Type2) ? 1.5 : 1.0;

                // calculate type effectiveness 
                double typeEffectiveness = Calculate_Type_Effectiveness(target).effectiveness;

                // calculate damage done to opponent 
                int damage = Calculate_Damage(user, target, STAB, typeEffectiveness);

                // reflect damage done by reducing the health bar
                if (targetHealthBar.Value - damage < 0)
                {
                    targetHealthBar.Value = 0;
                }

                else
                {
                    targetHealthBar.Value -= damage;
                }
            }

            // decrease PP
            PowerPoints -= 1;

            // message to show if attack hit or missed 
            message = testAccuracy <= Accuracy ? $"{user.Name} used {this.Name}" : $"Attack missed\n{user.Name} used {this.Name}";

            return message;
        }

        // method for calculating damage done by physical attack
        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {
            // random number for damage calculation 
            int randomNumber = rng.Next(217, 256);

            // calculate damage
            double damage_DOUBLE = ((2 * user.Level / 5 + 2) * user.Attack * BasePower / target.Defense / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100;
            int damage = (int)damage_DOUBLE;

            return damage;
        }
    }

    public class Special_Attack : Attack
    {
        // subclass from attack for special attacks
        public Special_Attack(int power, int accuracy, string name, string type, int powerPoints) : base(power, accuracy, name, type, powerPoints) { }

        // Override method representing the use of a special attack
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            string message = "";

            // Check if there are remaining PowerPoints for the attack
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // Generate a random number to determine accuracy
            int testAccuracy = rng.Next(0, 101);

            // If the attack hits
            if (testAccuracy <= Accuracy)
            {
                // Calculate same type attack bonus (STAB)
                double STAB = MoveType.Equals(user.Type1) || MoveType.Equals(user.Type2) ? 1.5 : 1.0;

                // Calculate type effectiveness
                double typeEffectiveness = Calculate_Type_Effectiveness(target).effectiveness;

                // Calculate damage
                int damage = Calculate_Damage(user, target, STAB, typeEffectiveness);

                // Reduce target's health
                if (targetHealthBar.Value - damage < 0)
                {
                    targetHealthBar.Value = 0;
                }
                else
                {
                    targetHealthBar.Value -= damage;
                }
            }

            // Decrease PP
            PowerPoints -= 1;

            // Set message based on whether the attack hit or missed
            message = testAccuracy <= Accuracy ? $"{user.Name} used {this.Name}" : $"Attack missed\n{user.Name} used {this.Name}";

            return message;
        }

        public int Calculate_Damage(Pokemon user, Pokemon target, double STAB, double typeEffectiveness)
        {
            // random number for damage calculation 
            int randomNumber = rng.Next(217, 256);

            // calculate damage
            double damage_DOUBLE = ((2 * user.Level / 5 + 2) * user.Special * BasePower / target.Special / 50 + 2) * STAB * typeEffectiveness * randomNumber / 100;
            int damage = (int)damage_DOUBLE;

            return damage;
        }

    }

    // class for attack named tackle which is a normal type physical attack
    public class Tackle_Attack : Physical_Attack
    {
        // constructor for the tackle class, setting its base damage, accuracy, name, type, and PP.
        public Tackle_Attack() : base(30, 70, "Tackle", "Normal", 30) { }
    }

    // class for attack named ember which is a fire type special attack
    public class Ember_Attack : Special_Attack
    {
        // constructor for the Ember class, setting its base damage, accuracy, name, type, and PP.
        public Ember_Attack() : base(30, 80, "Ember", "Fire", 30) { }
    }

    // class for attack named flamethrower which is a fire type special attack
    public class Flamethrower_Attack : Special_Attack
    {
        // constructor for the flame thrower class, setting its base damage, accuracy, name, type, and PP.
        public Flamethrower_Attack() : base(70, 100, "Flamethrower", "Fire", 10) { }
    }

    // class for attack named bubble which is a water type special attack
    public class Bubble_Attack : Special_Attack
    {
        // constructor for the bubble class, setting its base damage, accuracy, name, type, and PP.
        public Bubble_Attack() : base(30, 80, "Bubble", "Water", 30) { }
    }

    // class for attack named vine whip which is a grass type special attack
    public class Vine_Whip_Attack : Special_Attack
    {
        // constructor for the vine whip class, setting its base damage, accuracy, name, type, and PP.
        public Vine_Whip_Attack() : base(30, 80, "Vine Whip", "Grass", 30) { }
    }

    // class for attack named sleep which is a normal type special attack
    public class Sleep_Attack : Special_Attack
    {
        // constructor for the sleep class, setting its base damage, accuracy, name, type, and PP.
        public Sleep_Attack() : base(0, 100, "Sleep Attack", "Normal", 10) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // if you have no PP left you cannot use that attack
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // sleep attack can put user to sleep forcing missed turns
            target.Status = "asleep";
            PowerPoints--;

            // message describing sleep status effect 
            return $"{user.Name} used sleep attack and put {target.Name} to sleep!";
        }
    }

    // class for attack named poison breath which is a poison type special attack
    public class Poison_Breath : Special_Attack
    {
        // constructor for the poison breath class, setting its base damage, accuracy, name, type, and PP.
        public Poison_Breath() : base(0, 100, "Poison Breath", "Normal", 10) { }

        // test for PP and status effets 
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // this move can poison the opponent 
            target.Status = "poisoned";
            PowerPoints--;

            return $"{user.Name} used poison breath and poisoned {target.Name}!";
        }
    }

    // class for attack named fire breath which is a fire type special attack
    public class Fire_Breath : Special_Attack
    {
        // constructor for the fire breath class, setting its base damage, accuracy, name, type, and PP.
        public Fire_Breath() : base(0, 100, "Fire Breath", "Fire", 10) { }

        // override the Use method from the base class to define the behavior of using Fire_Breath attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // check if there are enough PP
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // inflict burn status effect 
            target.Status = "burned";
            // decrease PP after using the attack
            PowerPoints--;

            return $"{user.Name} used fire breath and burned {target.Name}!";
        }
    }

    // class for attack named dragon pulse which is a dragon type special attack
    public class Dragon_Pulse : Special_Attack
    {
        // constructor for the dragon pulse class, setting its base damage, accuracy, name, type, and PP.
        public Dragon_Pulse() : base(90, 100, "Dragon Pulse", "Dragon", 10) { }
    }

    // class for attack named dragon roar which is a dragon type special attack
    public class Dragon_Roar : Special_Attack
    {
        // constructor for the dragon roar class, setting its base damage, accuracy, name, type, and PP.
        public Dragon_Roar() : base(0, 100, "Dragon Roar", "Dragon", 10) { }

        // override the method from the base class to define the behavior of using dragon roar attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            PowerPoints--;

            // decreases the targets Special Attack and Defense stats as a result of the attack
            target.Special -= 25;
            target.Defense -= 25;

            return $"{user.Name} let out a thunderous roar and lowered the special and defence of the target.";
        }
    }

    // class for attack named thunder wave which is a electric type special attack
    public class Thunder_Wave : Special_Attack
    {
        // constructor for the thunder wave class, setting its base damage, accuracy, name, type, and PP.
        public Thunder_Wave() : base(0, 100, "Thunder Wave", "Electric", 10) { }

        // override from base class
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // checks PP
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // paralyzes opponent 
            target.Status = "paralyzed";
            PowerPoints--;

            return $"{user.Name} used thunder wave and paralyzed {target.Name}!";
        }
    }

    // class for attack named ice breath which is a ice type special attack
    public class Ice_Breath : Special_Attack
    {
        // constructor for the ice breath class, setting its base damage, accuracy, name, type, and PP.
        public Ice_Breath() : base(0, 25, "Ice Breath", "Ice", 10) { }

        // override the method from the base class to define the behavior of using ice breath attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // random number to determine if it freezes the target
            int num = rng.Next(0, 4);

            // check PP
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            PowerPoints--;

            // if random num is 0 then the target gets frozen
            if (num == 0)
            {
                target.Status = "frozen";
                return $"{user.Name} used ice breath and froze {target.Name}!";
            }
            else
            {
                // or else attack misses completely 
                return "Attack missed";
            }
        }
    }

    // class for attack named thunderbolt which is a electric type special attack
    public class Thunderbolt : Special_Attack
    {
        // constructor for the thunderbolt class, setting its base damage, accuracy, name, type, and PP.
        public Thunderbolt() : base(90, 100, "Thunderbolt", "Electric", 10) { }

        // override the method from the base class to define the behavior of using thunderbolt attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 10);
            string message = base.Use(user, target, targetHealthBar); ;

            // conditions to check if target gets paralyzed 
            if (num == 0 &&
                !message.Contains("missed", StringComparison.CurrentCultureIgnoreCase) &&
                !message.Contains("unable", StringComparison.CurrentCultureIgnoreCase))
            {
                target.Status = "paralyzed";
                message += $". {target.Name} was paralyzed.";
            }

            return message;
        }
    }

    // class for attack named ice beam which is a ice type special attack
    public class Ice_Beam : Special_Attack
    {
        // constructor for the ice beam class, setting its base damage, accuracy, name, type, and PP.
        public Ice_Beam() : base(90, 100, "Ice Beam", "Ice", 10) { }

        // override the method from the base class to define the behavior of using ice beam attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 10);
            string message = base.Use(user, target, targetHealthBar);

            // conditions to check if target gets frozen 
            if (num == 0 &&
                !message.Contains("missed", StringComparison.CurrentCultureIgnoreCase) &&
                !message.Contains("unable", StringComparison.CurrentCultureIgnoreCase))
            {

                // set status of opponent to frozen
                target.Status = "frozen";
                message += $". {target.Name} was frozen.";
            }

            return message;
        }
    }

    // class for attack named hydro pump which is a water type special attack
    public class Hydro_Pump : Special_Attack
    {
        // constructor for the hydro pump class, setting its base damage, accuracy, name, type, and PP.
        public Hydro_Pump() : base(110, 80, "Hydro Pump", "Water", 5) { }
    }

    // class for attack named anchor slam which is a steel type physical attack
    public class Anchor_Slam : Physical_Attack
    {
        // constructor for the anchor slam class, setting its base damage, accuracy, name, type, and PP.
        public Anchor_Slam() : base(150, 50, "Anchor Slam", "Steel", 5) { }

        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 2);
            string message = base.Use(user, target, targetHealthBar); ;

            // check if opponenet is paralyzed 
            if (num == 0 && 
                !message.Contains("missed", StringComparison.CurrentCultureIgnoreCase) && 
                !message.Contains("unable", StringComparison.CurrentCultureIgnoreCase))
            {
                target.Status = "paralyzed";
                message += $". {target.Name} was paralyzed.";
            }

            return message;
        }
    }

    // class for attack named shadow ball which is a ghost type physical attack
    public class Shadow_Ball : Physical_Attack
    {
        // constructor for the shadow ball class, setting its base damage, accuracy, name, type, and PP.
        public Shadow_Ball() : base(80, 100, "Shadow Ball", "Ghost", 15) { }
    }

    // class for attack named Ectoplasm which is a ghost type physical attack
    public class Ectoplasm : Physical_Attack
    {
        // constructor for the ectoplasm class, setting its base damage, accuracy, name, type, and PP.
        public Ectoplasm() : base(0, 100, "Ectoplasm", "Ghost", 10) { }
        
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            // conitions to determine if target gets poisoned 
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            target.Status = "poisoned";
            PowerPoints--;

            return $"{user.Name} used ectoplasm and poisoned {target.Name}!";
        }

    }

    // class for attack named razor leaf which is a grass type special attack
    public class Razor_Leaf : Special_Attack
    {
        // constructor for the razor leaf class, setting its base damage, accuracy, name, type, and PP.
        public Razor_Leaf() : base(55, 95, "Razor Leaf", "Grass", 25) { }
    }

    // class for attack named chainsaw which is a steel type physical attack
    public class Chainsaw : Physical_Attack
    {
        // constructor for the chainsaw class, setting its base damage, accuracy, name, type, and PP.
        public Chainsaw() : base(100, 100, "Chainsaw", "Steel", 10) { }
    }

    // class for attack named riposte which is a normal type special attack
    public class Riposte : Special_Attack
    {
        // constructor for the riposte class, setting its base damage, accuracy, name, type, and PP.
        public Riposte() : base(0, 100, "Riposte", "Normal", 5) { }

        // override the method from the base class to define the behavior of using riposte attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            PowerPoints--;

            // reduces target attack and defense stats as a result
            user.Attack += 25;
            user.Defense += 25;

            return $"{user.Name} entered a riposte stance and raised their attack and defence";
        }
    }

    // class for attack named harden which is a normal type physical attack
    public class Harden : Physical_Attack
    {
        // constructor for the harden class, setting its base damage, accuracy, name, type, and PP.
        public Harden() : base(0, 100, "Harden", "Rock", 5) { }

        // override the method from the base class to define the behavior of using harden attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // check PP
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            PowerPoints--;

            // increases the users defensvie stats when used 
            user.Defense += 50;

            return $"{user.Name} hardened and raised its defence";
        }
    }

    // class for attack named rock throw which is a normal type physical attack
    public class Rock_Throw : Physical_Attack
    {
        // constructor for the rock throw class, setting its base damage, accuracy, name, type, and PP.
        public Rock_Throw() : base(50, 90, "Rock Throw", "Rock", 15) { }
    }

    // class for attack named barbed stinger which is a bug type physical attack
    public class Barbed_Stinger : Physical_Attack
    {
        // constructor for the barbed stinger class, setting its base damage, accuracy, name, type, and PP.
        public Barbed_Stinger() : base(70, 100, "Barbed Stinger", "Bug", 20) { }

        // override the method from the base class to define the behavior of using barbed stinger attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            int num = rng.Next(0, 5);
            string message = base.Use(user, target, targetHealthBar); ;

            // condition to check if target gets poisoned 
            if (num == 0 &&
                !message.Contains("missed", StringComparison.CurrentCultureIgnoreCase) &&
                !message.Contains("unable", StringComparison.CurrentCultureIgnoreCase))
            {
                // poison the target
                target.Status = "poisoned";
                message += $". {target.Name} was poisoned.";
            }

            return message;
        }
    }

    // class for attack named wing attack which is a flying type physical attack
    public class Wing_Attack : Physical_Attack
    {
        // constructor for the wing attack class, setting its base damage, accuracy, name, type, and PP.
        public Wing_Attack() : base(60, 100, "Wing Attack", "Flying", 35) { }
    }

    // class for attack named lullaby which is a flying type physical attack
    public class Lullaby : Special_Attack
    {
        // constructor for the lullaby class, setting its base damage, accuracy, name, type, and PP.
        public Lullaby() : base(0, 100, "Lullaby", "Psychic", 5) { }

        // override the method from the base class to define the behavior of using lullaby attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {

            // conditons to check if it will put target to sleep
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // put target to sleep
            target.Status = "asleep";
            PowerPoints--;

            return $"{user.Name} used lullaby and made {target.Name} fall asleep!";
        }
    }

    // class for attack named dream eater which is a flying type physical attack
    public class Dream_Eater : Special_Attack
    {
        // constructor for the dream eater class, setting its base damage, accuracy, name, type, and PP.
        public Dream_Eater() : base(100, 100, "Dream Eater", "Psychic", 10) { }

        // override the method from the base class to define the behavior of using dream eater attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            // check PP
            if (PowerPoints <= 0)
            {
                return "Unable to use attack. You are out of PP!";
            }

            // check if tarfet is already asleep
            if (target.Status.ToLower().Equals("asleep"))
            {
                return base.Use(user, target, targetHealthBar);
            }
            else
            {
                // this move only damages pokemon that are alseep
                return "The target must be asleep to deal damage with this move!";
            }
        }
    }

    // class for attack named psybeam which is a flying type physical attack
    public class Psybeam : Special_Attack
    {
        // constructor for the psybeam class, setting its base damage, accuracy, name, type, and PP.
        public Psybeam() : base(80, 100, "Psybeam", "Psychic", 15) { }
    }

    // class for attack named arial acrobatics which is a flying type physical attack
    public class Arial_Acrobatics : Physical_Attack
    {
        // constructor for the arial acrobatics class, setting its base damage, accuracy, name, type, and PP.
        public Arial_Acrobatics() : base(55, 100, "Arial Acrobatics", "Flying", 15) { }

        // override the method from the base class to define the behavior of using arial acrobatics attack.
        public override string Use(Pokemon user, Pokemon target, ProgressBar targetHealthBar)
        {
            string message = base.Use(user, target, targetHealthBar); ;

            // check if attack hits or misses 
            if (!message.Contains("missed", StringComparison.CurrentCultureIgnoreCase) &&
                !message.Contains("unable", StringComparison.CurrentCultureIgnoreCase))
            {
                // user speed increases when used 
                user.Speed += 50;
                message += $". {user.Name} increased their speed.";
            }

            return message;
        }
    }
}
