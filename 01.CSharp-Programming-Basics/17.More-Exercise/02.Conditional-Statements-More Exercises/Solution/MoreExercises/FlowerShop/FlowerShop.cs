using System;

namespace FlowerShop
{
    class FlowerShop
    {
        static void Main(string[] args)
        {
            //intPut
            int magnoli = int.Parse(Console.ReadLine());
            int zombuli = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());

            double moneyForPresent = double.Parse(Console.ReadLine());
            //•	Магнолии – 3.25 лева
            //•	Зюмбюли – 4 лева
            //•	Рози – 3.50 лева
            //•	Кактуси – 8 лева

            double inCome = 0.0;
            inCome += magnoli * 3.25;
            inCome += zombuli * 4;
            inCome += rose * 3.5;
            inCome += cactus * 8;

            // 5% for tax
            double tax = inCome * 0.05;
            inCome -= tax;

            if (inCome >= moneyForPresent)
            {
                Console.WriteLine($"She is left with {Math.Floor(inCome - moneyForPresent)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(moneyForPresent - inCome)} leva.");
            }
        }
    }
}
