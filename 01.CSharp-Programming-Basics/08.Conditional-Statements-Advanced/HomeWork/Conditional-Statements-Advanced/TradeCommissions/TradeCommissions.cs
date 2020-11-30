using System;

namespace TradeCommissions
{
    class TradeCommissions
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double ammountSells = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":
                    if (ammountSells < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (ammountSells <= 500)
                    {
                        Console.WriteLine($"{ammountSells * 0.05:f2}");
                    }
                    else if (ammountSells <= 1000)
                    {
                        Console.WriteLine($"{ammountSells * 0.07:f2}");
                    }
                    else if (ammountSells <= 10000)
                    {
                        Console.WriteLine($"{ammountSells * 0.08:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{ammountSells * 0.12:f2}");
                    }
                    break;

                case "Varna":
                    if (ammountSells < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (ammountSells <= 500)
                    {
                        Console.WriteLine($"{ammountSells * 0.045:f2}");
                    }
                    else if (ammountSells <= 1000)
                    {
                        Console.WriteLine($"{ammountSells * 0.075:f2}");
                    }
                    else if (ammountSells <= 10000)
                    {
                        Console.WriteLine($"{ammountSells * 0.10:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{ammountSells * 0.13:f2}");
                    }
                    break;

                case "Plovdiv":
                    if (ammountSells < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (ammountSells <= 500)
                    {
                        Console.WriteLine($"{ammountSells * 0.055:f2}");
                    }
                    else if (ammountSells <= 1000)
                    {
                        Console.WriteLine($"{ammountSells * 0.08:f2}");
                    }
                    else if (ammountSells <= 10000)
                    {
                        Console.WriteLine($"{ammountSells * 0.12:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"{ammountSells * 0.145:f2}");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
