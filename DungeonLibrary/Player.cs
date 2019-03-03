using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //New classes default to internal. We must make it public
        //Fields

        //we only need to create fields for the ones with no business rules
        //private int _life; - moved this to Character during Inheritance and Polymorphism lesson

        //Properties

        //Automatic properties are a shortcut syntaxx that allows you to create a shortened version of a public property.
        //They have OPEN getter and setters (the guard is asleep)
        //These automatically create default fields FOR YOU at runtime
        //public string Name { get; set; } - moved this to Character during Inheritance and Polymorphism lesson 
        //public int HitChance { get; set; } - moved this to Character during Inheritance and Polymorphism lesson
        //public int Block { get; set; } - moved this to Character during Inheritance and Polymorphism lesson
        //public int MaxLife { get; set; } - moved this to Character during Inheritance and Polymorphism lesson
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //You can NOT use Automatic Properties when you have a business rule

        //Below moved to Character
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        //business rule, life should NOT be more than MaxLife
        //        if (value <= MaxLife)
        //        {
        //            _life = value;
        //        }
        //        else
        //        {
        //            _life = MaxLife;
        //        }
        //    }
        //}
        //Ctor
        //ONLY going to make a FQ CTOR. We DO NOT want to allow anyone to make a blank player.
        //They must give us all of the info
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

        //Methods
        //money / methods
        public override string ToString()
        {
            string description = "";

            //! Have them follow along...
            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Deow:
                    description = "Dark Elf";
                    break;
                case Race.Gnome:
                    description = "Gnome";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                case Race.Idex:
                    description = "Little square with little legs";
                    break;
                case Race.Dale:
                    description = "Master Left Turner";
                    break;
                case Race.Khajiit:
                    description = "Giant cat person";
                    break;

            }//end switch

            return string.Format("\n-=-= Name: {0} =-=-\n" +
            "Life: {1} of {2}\nHit Chance: {3}%\n" +
            "Weapon:\n{4}\nDescription: {5}",
            Name, Life, MaxLife, HitChance, EquippedWeapon, description);
        }//end to string

        //Methods
        public override int CalcDamage()
        {
            //return base.CalcDamage();
            Random rand = new Random();

            //Determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;
        }

        public override int CalcHitChance()
        {
            //return base.CalcHitChance();
            return HitChance + EquippedWeapon.BonusHitChance;
        }



    }
}
