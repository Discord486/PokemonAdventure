using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields
        private int _minDamage;

        //Properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //CTORS
        public Monster() { }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //methods
        public override string ToString()
        {
            return string.Format("\n******Monster******\n{0}\nLife: {1} of {2} \nDamage: {3}" +
                " to {4}\nBlock: {5}\nDescription:\n{6}\n", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

        //We are overriding the CalcDamage() to use the properties of MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //return base.CalcDamage();
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //If we had a monster that had a Min of two and a Max of 8, if we pass MinDamage, MaxDamage to the Next() it 
            //would actually return a random number between 2-7 because the MaxValue (2nd Paramater) is Exclusive
        }



    }
}
