using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class willnot have fields, properties, or any custom constructors, as it is just a warehouse
        //for different methods
        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 100);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //If the attacker hit than calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                //The attacker missed
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            //Player attacks first
            DoAttack(player, monster);

            //monster attacks second, if still alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }

        }
    }
}
