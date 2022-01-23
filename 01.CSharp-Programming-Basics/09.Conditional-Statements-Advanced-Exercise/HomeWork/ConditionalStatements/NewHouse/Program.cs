namespace NewHouse
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string typeOfFlowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double moneyToPayForFlowers = 0;

            switch (typeOfFlowers.ToLower())
            {
                case "roses":
                    moneyToPayForFlowers = numberOfFlowers * 5;

                    if (numberOfFlowers > 80)
                    {
                        moneyToPayForFlowers = moneyToPayForFlowers * (1 - 0.1);
                    }
                    break;

                case "dahlias":
                    moneyToPayForFlowers = numberOfFlowers * 3.80;

                    if (numberOfFlowers > 90)
                    {
                        moneyToPayForFlowers = moneyToPayForFlowers * (1 - 0.15);
                    }
                    break;

                case "tulips":
                    moneyToPayForFlowers = numberOfFlowers * 2.80;

                    if (numberOfFlowers > 80)
                    {
                        moneyToPayForFlowers = moneyToPayForFlowers * (1 - 0.15);
                    }
                    break;

                case "narcissus":
                    moneyToPayForFlowers = numberOfFlowers * 3;

                    if (numberOfFlowers < 120)
                    {
                        moneyToPayForFlowers = moneyToPayForFlowers * 1.15;
                    }
                    break;

                case "gladiolus":
                    moneyToPayForFlowers = numberOfFlowers * 2.50;

                    if (numberOfFlowers < 80)
                    {
                        moneyToPayForFlowers = moneyToPayForFlowers * 1.20;
                    }
                    break;
            }

            if (budget >= moneyToPayForFlowers)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {budget - moneyToPayForFlowers:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyToPayForFlowers - budget:f2} leva more.");
            }
        }
    }
}
