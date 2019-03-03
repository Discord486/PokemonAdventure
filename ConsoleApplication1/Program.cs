using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using DungeonMonster;

namespace DungeonApplication 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokemon Adventure!";
            Console.WriteLine("Welcome to the Pokemon Adventure!");
            string ascii = @"
             _                              
            | |                             
 _ __   ___ | | _____ _ __ ___   ___  _ __  
| '_ \ / _ \| |/ / _ \ '_ ` _ \ / _ \| '_ \ 
| |_) | (_) |   <  __/ | | | | | (_) | | | |
| .__/ \___/|_|\_\___|_| |_| |_|\___/|_| |_|
| |                                         
|_|                           
";
            Console.WriteLine(ascii);

            int score = 0;

            //1. Create a character, we will use a custom class in Class Library
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, false);
            Player player = new Player("Leroy Jenkins", 70, 5, 40, 40, Race.Dale, sword);
            //2. Create a loop for the room

            //3. Build a room

            bool exit = false;

            do
            {
                //Enter a room
                //4. Write a () for entering a room
                Console.WriteLine(GetRoom());
                //5. Create a monster in the room

                Rabbit r1 = new Rabbit(); //Uses our default ctor which sets base values for baby rabbit
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 8, "That's no ordinary rabbit!! Look at the bones.",
                     true); //uses FQ ctor
                Rabbit r3 = new Rabbit("Bugs Bunny", 30, 30, 80, 30, 0, 2, "Very annoying...", true); //uses FQCTOR

                //Randomly select a monster for our room
                Monster[] monsters = { r1, r3, r2, r1, r2, r2, r1, r3 };
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];
                Console.WriteLine("\nIn this room: " + monster.Name);

                //6. Create a loop for menu

                bool reload = false;//COUNTER
                do
                {
                    //7. Menu of decisions on what to do
                    #region MENU

                    Console.WriteLine("\nPlease choose an action.\nA) Attack \nR) Run Away \nC) Character Info \nM) Monster Info\n" +
                        "X) Exit\nEnter your choice:");

                    //8. Catch the user choice

                    string userChoice = Console.ReadLine().ToUpper();
                    if (userChoice.Length > 0)
                    {
                        userChoice = userChoice.Substring(0, 1);
                        //We do this to capture just the first letter of user input
                    }

                    //9. Clear the console AFTER we get the input
                    Console.Clear();

                    //TODO 10. Build a switch to handle user choice
                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("Attack!");
                            //12. Create an attack ()
                            Combat.DoBattle(player, monster);
                            //TODO 13. Handle if player wins
                            //TODO 14. Handle if player loses
                            if (monster.Life <= 0)
                            {
                                //It's dead!
                                //You could put some logic here to have the player get items, get life back, or something
                                //similar due to defeating the monster
                                Console.WriteLine("\nYou defeated {0}!!\n", monster.Name);
                                score++;
                                reload = true; //Now need to get a new room.
                            }
                            break;
                        case "R":
                            Console.WriteLine("Run Away!");
                            //TODO 15. Handle running away and getting a new room
                            Console.WriteLine();
                            reload = true; //loads a new room
                            break;
                        case "C":
                            Console.WriteLine("Character Info");
                            //16. Print character info out to screen
                            Console.WriteLine(player);
                            break;
                        case "M":
                            Console.WriteLine("Monster Info");
                            //17. Print monster info out to screem
                            Console.WriteLine(monster);
                            break;
                        case "X":
                        case "E":
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try Again.");
                            break;
                    }
                    #endregion


                    //TODO 11. We need to handle the player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... you died!");
                        Console.WriteLine("Your score is " + score);
                        exit = true;
                    }
                } while (!reload && !exit); //END Do While for menu

            } while (!exit); //END Do While for room and player

        }//END of Main()
        private static string GetRoom()
        {
            string[] rooms =
            {
                "Room 1",
                "Room 2",
                "Room Final",
                "Elite 4",
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
        }

    }//END Class
}//END Namespace

