using System;
using System.Linq;

namespace MuOnline
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int startHealth = 100;
            int bitCoin = 0;
            string[] rooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int surviveRooms = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i] //first command second number
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentRoom[0])
                {
                    case "potion":

                        if (startHealth == 100)
                        {
                            Console.WriteLine("You healed for 0 hp.");
                            Console.WriteLine($"Current health: {startHealth} hp.");
                        }
                        else
                        {
                            int heal = int.Parse(currentRoom[1]);

                            if (startHealth + heal > 100)
                            {
                                int healed = 100 - startHealth;
                                startHealth = 100;
                                Console.WriteLine($"You healed for {healed} hp.");
                                Console.WriteLine($"Current health: {startHealth} hp.");
                                break;
                            }

                            startHealth += heal;
                            Console.WriteLine($"You healed for {heal} hp.");
                            Console.WriteLine($"Current health: {startHealth} hp.");
                        }

                        break;

                    case "chest":

                        int foundBitCoins = int.Parse(currentRoom[1]);
                        bitCoin += foundBitCoins;

                        Console.WriteLine($"You found {foundBitCoins} bitcoins.");
                        break;

                    default: //monster

                        int monsterAttack = int.Parse(currentRoom[1]);

                        if (startHealth - monsterAttack <= 0)
                        {
                            surviveRooms++;
                            Console.WriteLine($"You died! Killed by {currentRoom[0]}.");
                            Console.WriteLine($"Best room: {surviveRooms}");
                            return;
                        }
                        else
                        {
                            startHealth -= monsterAttack;
                            Console.WriteLine($"You slayed {currentRoom[0]}.");
                        }
                        break;
                }

                surviveRooms++;
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitCoin}");
            Console.WriteLine($"Health: {startHealth}");
        }
    }
}
