using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFFICIAL_Pokemon_Project_FINAL
{
    // class representing Pokemon types and their strengths/weaknesses 
    public class PokemonType
    {
        // constructor for Pokemon types
        public PokemonType() { }

        // Dictionary to store the strengths of each Pokemon type
        public Dictionary<string, List<string>> Weakness_Dictionary = [];
        
        // Dictionary to store the weaknesses of each Pokemon type
        public Dictionary<string, List<string>> Strength_Dictionary = [];

        // method to initialize type matchup strengths and weaknesses 
        public void Initialize_Type_Matchup()
        {    
            // first check if the dictionary is empty
            if (Strength_Dictionary.Count == 0)
            {
                // add the strengths of each Pokemon type
                Strength_Dictionary.Add("Fire", ["Grass", "Fire", "Ice", "Bug", "Steel"]); // Grass, Fire, Ice, Bug, and Steel type moves are not effective against Fire type Pokemon
                Strength_Dictionary.Add("Water", ["Fire", "Water", "Ice", "Steel"]); // Fire, Water, Ice, and Steel type moves are not effective against Water type Pokemon
                Strength_Dictionary.Add("Grass", ["Water", "Grass", "Electric"]); // Water, Grass, and Electric type moves are not effective against Grass type Pokemon
                Strength_Dictionary.Add("Electric", ["Electric", "Flying", "Steel"]); // Electric, Flying, and Steel type moves are not effective against Electric type Pokemon
                Strength_Dictionary.Add("Steel", ["Grass", "Steel", "Ice", "Normal", "Flying", "Psychic", "Bug", "Dragon", "Rock"]); // Grass, Steel, Ice, Normal, Flying, Psychic, Bug, Dragon, and Rock type moves are not effective against Steel type Pokemon
                Strength_Dictionary.Add("Ice", ["Ice"]); // Ice type moves are not effective against Ice type Pokemon
                Strength_Dictionary.Add("Ghost", ["Bug"]); // Bug type moves are not effective against Ghost type Pokemon
                Strength_Dictionary.Add("Dragon", ["Fire", "Water", "Grass", "Electric"]); // Fire, Water, Grass, and Electric type moves are not effective against Dragon type Pokemon
                Strength_Dictionary.Add("Psychic", ["Psychic"]); // Psychic type moves are not effective against Psychic type Pokemon
                Strength_Dictionary.Add("Flying", ["Grass", "Bug"]); // Grass and Bug type moves are not effective against Flying type Pokemon
                Strength_Dictionary.Add("Bug", ["Grass"]); // Grass type moves are not effective against Bug type Pokemon
                Strength_Dictionary.Add("Rock", ["Normal", "Fire", "Flying"]); // Normal, Fire, and Flying type moves are not effective against Rock type Pokemon
                Strength_Dictionary.Add("Normal", []); // there are no moves that are not effective against Normal type Pokemon in this dictionary
            }

            // check if the weakness dictionary is empty
            if (Weakness_Dictionary.Count == 0)
            {
                Weakness_Dictionary.Add("Fire", ["Water", "Rock"]); // Water and Rock type moves are super effective against Fire type Pokemon
                Weakness_Dictionary.Add("Water", ["Grass", "Electric"]); // Grass and Electric type moves are super effective against Water type Pokemon
                Weakness_Dictionary.Add("Grass", ["Fire", "Ice", "Flying", "Bug"]); // Fire, Ice, Flying, and Bug type moves are super effective against Grass type Pokemon
                Weakness_Dictionary.Add("Electric", []); // no type of moves are super effective against Eelectric type Pokemon in this dictionary
                Weakness_Dictionary.Add("Steel", ["Fire"]); // Fire type moves are super effective against Steel type Pokemon
                Weakness_Dictionary.Add("Ice", ["Fire", "Steel", "Rock"]); // Fire, Steel, and Rock type moves are super effective against Ice type Pokemon
                Weakness_Dictionary.Add("Ghost", ["Ghost"]); // Ghost type moves are super effective against Ghost type Pokemon
                Weakness_Dictionary.Add("Dragon", ["Ice", "Dragon"]); // Ice and Dragon type moves are super effective against Dragon type Pokemon
                Weakness_Dictionary.Add("Psychic", ["Bug", "Ghost"]); // Bug and Ghost type moves are super effective against Psychic type Pokemon
                Weakness_Dictionary.Add("Flying", ["Electric", "Ice", "Rock"]); // Electric, Ice, and Rock type moves are super effective against Flying type Pokemon
                Weakness_Dictionary.Add("Bug", ["Fire", "Flying", "Rock"]); // Fire, Flying, and Rock type moves are super effective against Bug type Pokemon
                Weakness_Dictionary.Add("Rock", ["Water", "Grass", "Steel"]); // Water, Grass, and Steel type moves are super effective against Rock type Pokemon
                Weakness_Dictionary.Add("Normal", []); // no type of moves are super effective against Normal type Pokemon in this dictionary
            }
        }
    }
}
