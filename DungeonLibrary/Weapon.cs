using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //Fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }

        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }

        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than the max damage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than the max and more than zero, so we will let it pass.
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }




        //CTORS
        //Create a default and a fully qualified ctor
        public Weapon() { } //end default


        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have any properties that have business based off of OTHER properties..
            //set the OTHER properties first
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//endFQCTOR
        //Methods

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}\t{1} to {2} Damage \nBonus Hit: {3}%\tTwo-Handed? {4}", Name, MinDamage, MaxDamage, BonusHitChance, IsTwoHanded == true ? "Two-Handed" : "One-Handed");
            //Ternary Operator IsTwoHanded == true ? "Two-Handed" : "One-Handed"
        }
    }
}
