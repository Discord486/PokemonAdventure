using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {

        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                //business rule, life should NOT be more than MaxLife
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }

        //CTORS
        //Since we are not going to be able to inherit constructors and we already did a lot of work defining the player FQCTOR, we will not create any 
        //here. We will still get the free default paramaterless CTOR.

        //Methods
        //No need to override the ToString() here because we will never be able to create an object of type Character.

        //Below are methods we want to be inherited by player and monster, so we are creating default versions of each method here. The
        //child classes will use these if they do NOT override it.

        public virtual int CalcBlock()
        {
            //To be able to override this in a child class, make it virtual

            //This basic version just returns block, but this will give us the option to do something different in a child class.

            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
            //Start this with just returning zero, so that we can use the method from an instance of a Character, we will override the method in 
            //Monster and Player.
        }
    }
}
