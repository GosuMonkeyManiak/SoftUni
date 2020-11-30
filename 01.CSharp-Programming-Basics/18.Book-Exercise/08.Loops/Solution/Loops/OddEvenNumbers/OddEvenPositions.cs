using System;

namespace OddEvenPositions
{
    class OddEvenPositions
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double EvenSum = 0.0;
            double EvenMax = double.MinValue;
            double EvenMin = double.MaxValue;

            double OddSum = 0.0;
            double OddMax = double.MinValue;
            double OddMin = double.MaxValue;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    EvenSum += number;

                    if (number > EvenMax)
                    {
                        EvenMax = number;
                    }

                    if (number < EvenMin)
                    {
                        EvenMin = number;
                    }
                }
                else
                {
                    OddSum += number;

                    if (number > OddMax)
                    {
                        OddMax = number;
                    }

                    if (number < OddMin)
                    {
                        OddMin = number;
                    }
                }
            }

                //print Odd And Even

                Console.WriteLine($"OddSum={OddSum},");
                if (OddMin == double.MaxValue)
                {
                    Console.WriteLine("OddMin=No,");
                }
                else
                {
                    Console.WriteLine($"OddMin={OddMin},");
                }

                if (OddMax == double.MinValue)
                {
                    Console.WriteLine("OddMax=No,");
                }
                else
                {
                    Console.WriteLine($"OddMax={OddMax},");
                }

                Console.WriteLine($"EvenSum={EvenSum}");

                if (EvenMin == double.MaxValue)
                {
                    Console.WriteLine($"EvenMin=No,");
                }
                else
                {
                    Console.WriteLine($"EvenMin={EvenMin},");
                }

                if (EvenMax == double.MinValue)
                {
                    Console.WriteLine($"EvenMax=No");
                }
                else
                {
                    Console.WriteLine($"EvenMax={EvenMax}");
                }
            
        }
    }
}
