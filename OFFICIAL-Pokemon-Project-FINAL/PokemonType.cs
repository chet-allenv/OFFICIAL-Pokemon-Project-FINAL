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
                Strength_Dictionary.Add("Fire", ["Grass", "Fire", "Ice", "Bug", "Steel"]);
                Strength_Dictionary.Add("Water", ["Fire", "Water", "Ice", "Steel"]);
                Strength_Dictionary.Add("Grass", ["Water", "Grass", "Electric"]);
                Strength_Dictionary.Add("Electric", ["Electric", "Flying", "Steel"]);
                Strength_Dictionary.Add("Steel", ["Grass", "Steel", "Ice", "Normal", "Flying", "Psychic", "Bug", "Dragon", "Rock"]);
                Strength_Dictionary.Add("Ice", ["Ice"]);
                Strength_Dictionary.Add("Ghost", ["Bug"]);
                Strength_Dictionary.Add("Dragon", ["Fire", "Water", "Grass", "Electric"]);
                Strength_Dictionary.Add("Psychic", ["Psychic"]);
                Strength_Dictionary.Add("Flying", ["Grass", "Bug"]);
                Strength_Dictionary.Add("Bug", ["Grass"]);
                Strength_Dictionary.Add("Rock", ["Normal", "Fire", "Flying"]);
                Strength_Dictionary.Add("Normal", []);
            }

            if (Weakness_Dictionary.Count == 0)
            {
                Weakness_Dictionary.Add("Fire", ["Water", "Rock"]);
                Weakness_Dictionary.Add("Water", ["Grass", "Electric"]);
                Weakness_Dictionary.Add("Grass", ["Fire", "Ice", "Flying", "Bug"]);
                Weakness_Dictionary.Add("Electric", []);
                Weakness_Dictionary.Add("Steel", ["Fire"]);
                Weakness_Dictionary.Add("Ice", ["Fire", "Steel", "Rock"]);
                Weakness_Dictionary.Add("Ghost", ["Ghost"]);
                Weakness_Dictionary.Add("Dragon", ["Ice", "Dragon"]);
                Weakness_Dictionary.Add("Psychic", ["Bug", "Ghost"]);
                Weakness_Dictionary.Add("Flying", ["Electric", "Ice", "Rock"]);
                Weakness_Dictionary.Add("Bug", ["Fire", "Flying", "Rock"]);
                Weakness_Dictionary.Add("Rock", ["Water", "Grass", "Steel"]);
                Weakness_Dictionary.Add("Normal", []);
            }
        }
    }
}
