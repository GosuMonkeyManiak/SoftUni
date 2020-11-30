using System;

namespace VendingMachine
{
    class Machine
    {
        static void Main(string[] args)
        {
            double allMoney = 0;

            while (true)
            {
                string coin = Console.ReadLine();
                if (coin == "Start")
                {
                    break;
                }

                double currentCoin = double.Parse(coin);

                switch (currentCoin)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        allMoney += currentCoin;
                        break;

                    default:
                        Console.WriteLine($"Cannot accept {currentCoin}");
                        break;
                }
            }

            while (true)
            {
                string product = Console.ReadLine();
                if (product == "End")
                {
                    Console.WriteLine($"Change: {allMoney:f2}");
                    break;
                }

                switch (product)
                {
                    case "Nuts": // 2.0
                        if (allMoney >= 2.0)
                        {
                            Console.WriteLine("Purchased nuts");
                            allMoney -= 2.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Water": // 0.7
                        if (allMoney >= 0.7)
                        {
                            Console.WriteLine("Purchased water");
                            allMoney -= 0.7;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Crisps": // 1.5
                        if (allMoney >= 1.5)
                        {
                            Console.WriteLine("Purchased crisps");
                            allMoney -= 1.5;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Soda": // 0.8
                        if (allMoney >= 0.8)
                        {
                            Console.WriteLine("Purchased soda");
                            allMoney -= 0.8;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    case "Coke": // 1.0
                        if (allMoney >= 1.0)
                        {
                            Console.WriteLine("Purchased coke");
                            allMoney -= 1.0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }
        }
    }
}
