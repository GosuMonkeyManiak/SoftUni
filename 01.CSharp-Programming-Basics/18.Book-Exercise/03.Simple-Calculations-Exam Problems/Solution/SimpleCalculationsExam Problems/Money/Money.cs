using System;

namespace Money
{
    class Money
    {
        static void Main(string[] args)
        {
            int bitCoint = int.Parse(Console.ReadLine());
            double chinaCoint = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double levFromBitCoint = bitCoint * 1168;
            double dolarsFromChina = chinaCoint * 0.15;

            double allLev = levFromBitCoint + dolarsFromChina * 1.76;

            double allEuro = allLev / 1.95;

            double tax2 = tax / 100;
            tax2 = tax2 * allEuro;
            allEuro -= tax2;

            Console.WriteLine($"{allEuro}") ;
        }
    }
}
