using System;

namespace GamingStore
{
    class Store
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double totalSpend = 0;

            while (true)
            {
                string gameName = Console.ReadLine();
                if (gameName == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${balance:f2}");
                    break;
                }

                switch (gameName)
                {
                    case "OutFall 4": // 39.99
                        if (balance >= 39.99)
                        {
                            Console.WriteLine("Bought OutFall 4");
                            balance -= 39.99;
                            totalSpend += 39.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;

                    case "CS: OG": // 15.99
                        if (balance >= 15.99)
                        {
                            Console.WriteLine("Bought CS: OG");
                            balance -= 15.99;
                            totalSpend += 15.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;

                    case "Zplinter Zell": // 19.99
                        if (balance >= 19.99)
                        {
                            Console.WriteLine("Bought Zplinter Zell");
                            balance -= 19.99;
                            totalSpend += 19.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;

                    case "Honored 2": // 59.99
                        if (balance >= 59.99)
                        {
                            Console.WriteLine("Bought Honored 2");
                            balance -= 59.99;
                            totalSpend += 59.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;

                    case "RoverWatch": // 29.99
                        if (balance >= 29.99)
                        {
                            Console.WriteLine("Bought RoverWatch");
                            balance -= 29.99;
                            totalSpend += 29.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;

                    case "RoverWatch Origins Edition": // 39.99
                        if (balance >= 39.99)
                        {
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                            balance -= 39.99;
                            totalSpend += 39.99;

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");

                            if (balance <= 0)
                            {
                                Console.WriteLine("Out of money!");
                                return;
                            }

                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
            }
        }
    }
}
