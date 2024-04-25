﻿using OFFICIAL_Pokemon_Project_FINAL.Properties;
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

        public string Name {  get; set; }
        
        public Image[] Sprites { get; set; } // Holds both front and back sprite. Front is index 0 and back is index 1
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public string Type1 { get; set; }

#nullable enable
        public string? Type2 { get; set; }
#nullable disable

        public string Status { get; set; } = "";

        

        public Attack[] moveSet;

        private readonly Random rng = new Random();

        public Pokemon(string name, Image frontSprite, Image backSprite, string type1, string type2, int level)
        {

            this.Name = name;
            Sprites = [frontSprite, backSprite];
            Attack = Generate_Stat();
            Defense = Generate_Stat();
            Special = Generate_Stat();
            Speed = Generate_Stat();
            Health = Generate_Stat(100, 280);
            Level = level;
            Type1 = type1;
            Type2 = type2;

            moveSet = new Attack[4];
        }

        private int Generate_Stat(int low = 5, int high = 25)
        {
            return rng.Next(low, high) + 2 * (2 * this.Level / 5 + 2);
        }

        public bool Is_Alive() { return this.Health > 0; }

        public void UseAttack(int attackNumber, Pokemon target, ProgressBar targetHealthBar)
        {
            moveSet[attackNumber].Use(this, target, targetHealthBar);
        }

        public Image Get_Front_Sprite()
        {
            return Sprites[0];
        }

        public Image Get_Back_Sprite()
        {
            return Sprites[1];
        }
    }


    public class Wattrus : Pokemon
    {
        public Wattrus() : base("Wattrus", Resources.wattrus_front, Resources.wattrus_back, "Electric", "Ice", 50)
        {
            // implement later
            moveSet = [new Thunderbolt(), new Thunder_Wave(), new Ice_Beam(), new Ice_Breath()];
        }
    }

    public class Nautighoul : Pokemon
    {
        public Nautighoul() : base("Nautighoul", Resources.naughtighoul_front, Resources.naughtighoul_back, "Water", "Ghost", 50)
        {
            // implement later
            // moveSet = [Water Attack, Water Attack, Ghost Attack, Ghost Attack]
        }
    }

    public class Chainsprout : Pokemon
    {
        public Chainsprout() : base("Chainsprout", Resources.chainsprout_front, Resources.chainsprout_back, "Grass", "Steel", 50)
        {
            // implement later
            // moveSet = [Grass Attack, Grass Attack, Steel Attack, Steel Attack]
        }
    }
}
