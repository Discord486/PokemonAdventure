using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //Added

namespace DungeonMonster
{
    public class Rabbit : Monster
    {
        //Public and a child of monster

        //Below are the unique properties for Rabbit

        public bool IsFluffy { get; set; }

        //FQCTOR and Default CTOR

        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool isFluffy) :
            base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)

        {
            IsFluffy = isFluffy;
        }

        //default ctor
        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny. Why would you hurt it... bully!";
            IsFluffy = false;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + ((IsFluffy) ? "Fluffy" : "Not so fluffy...");
        }

        //override the block to say if they are fluffy they get a bonus 50% to their block value
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }


    }
}