using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    public class PokemonType
    {
        public PokemonType() { }

        public Dictionary<string, List<string>> Weakness_Dictionary = [];
        public Dictionary<string, List<string>> Strength_Dictionary = [];

        public void Initialize_Type_Matchup()
        {
            if (Strength_Dictionary.Count == 0)
            {
                Strength_Dictionary.Add("Fire", ["Grass", "Fire"]);
                Strength_Dictionary.Add("Water", ["Fire", "Water"]);
                Strength_Dictionary.Add("Grass", ["Water", "Grass"]);
                Strength_Dictionary.Add("Normal", []);
            }

            if (Weakness_Dictionary.Count == 0)
            {
                Weakness_Dictionary.Add("Fire", ["Water"]);
                Weakness_Dictionary.Add("Water", ["Grass"]);
                Weakness_Dictionary.Add("Grass", ["Fire"]);
                Weakness_Dictionary.Add("Normal", []);
            }
        }
    }
}
