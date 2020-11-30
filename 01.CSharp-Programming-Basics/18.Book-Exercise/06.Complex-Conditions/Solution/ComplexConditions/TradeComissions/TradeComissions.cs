using System;

namespace TradeComissions
{
    class TradeComissions
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            double ammount = double.Parse(Console.ReadLine());

            double commissions = 0;

            switch (city)
            {
                case "sofia":
                    if (ammount < 0)
                    {
                        Console.WriteLine("error");
                        break;
                    }
                    else if (ammount <= 500)
                    {
                        commissions = ammount * 0.05;
                    }
                    else if (ammount <= 1000)
                    {
                        commissions = ammount * 0.07;
                    }
                    else if (ammount <= 10000)
                    {
                        commissions = ammount * 0.08;
                    }
                    else
                    {
                        commissions = ammount * 0.12;
                    }
                    Console.WriteLine($"{commissions:f2}");
                    break;

                case "varna":
                    if (ammount < 0)
                    {
                        Console.WriteLine("error");
                        break;
                    }
                    else if (ammount <= 500)
                    {
                        commissions = ammount * 0.045;
                    }
                    else if (ammount <= 1000)
                    {
                        commissions = ammount * 0.075;
                    }
                    else if (ammount <= 10000)
                    {
                        commissions = ammount * 0.1;
                    }
                    else
                    {
                        commissions = ammount * 0.13;
                    }
                    Console.WriteLine($"{commissions:f2}");
                    break;

                case "plovdiv":
                    if (ammount < 0)
                    {
                        Console.WriteLine("error");
                        break;
                    }
                    else if (ammount <= 500)
                    {
                        commissions = ammount * 0.055;
                    }
                    else if (ammount <= 1000)
                    {
                        commissions = ammount * 0.08;
                    }
                    else if (ammount <= 10000)
                    {
                        commissions = ammount * 0.12;
                    }
                    else
                    {
                        commissions = ammount * 0.145;
                    }
                    Console.WriteLine($"{commissions:f2}");
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
