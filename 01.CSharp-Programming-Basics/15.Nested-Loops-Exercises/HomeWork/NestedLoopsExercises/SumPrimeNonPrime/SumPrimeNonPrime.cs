using System;

namespace SumPrimeNonPrime
{
    class SumPrimeNonPrime
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int notPriceSum = 0;
            bool isPrime = true;

            while (true)
            {
                string texNum = Console.ReadLine();
                if (texNum == "stop")
                {
                    break;
                }

                int num = int.Parse(texNum);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeSum += num;
                }
                else
                {
                    notPriceSum += num;
                    isPrime = true;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {notPriceSum}");
        }
    }
}
