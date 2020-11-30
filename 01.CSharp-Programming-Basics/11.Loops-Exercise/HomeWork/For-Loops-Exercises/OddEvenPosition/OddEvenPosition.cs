using System;

namespace OddEvenPosition
{
    class OddEvenPosition
    {
        static void Main(string[] args)
        {
            //Изходът да се форматира в следния вид:
            //"OddSum=" + { сума на числата на нечетни позиции},
            //"OddMin=" + { минимална стойност на числата на нечетни позиции } / {“No”},
            //"OddMax=" + { максимална стойност на числата на нечетни позиции } / {“No”},
            //"EvenSum=" + { сума на числата на четни позиции },
            //"EvenMin=" + { минимална стойност на числата на четни позиции } / {“No”},
            //"EvenMax=" + { максимална стойност на числата на четни позиции } / {“No”}
            //Всяко число трябва да е форматирано до втория знак след десетичната запетая.

            int n = int.Parse(Console.ReadLine());

            double OddSum = 0.0;
            double OddMin = double.MaxValue;
            double OddMax = double.MinValue;

            double EvenSum = 0.0;
            double EvenMin = double.MaxValue;
            double EvenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    EvenSum += num;

                    if (num < EvenMin)
                    {
                        EvenMin = num;
                    }
                    if (num > EvenMax)
                    {
                        EvenMax = num;
                    }

                }
                else
                {
                    OddSum += num;

                    if (num < OddMin)
                    {
                        OddMin = num;
                    }
                    if (num > OddMax)
                    {
                        OddMax = num;
                    }
                }
            }

            Console.WriteLine($"OddSum={OddSum:f2},");

            if (OddMax == double.MinValue && OddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={OddMin:f2},");
                Console.WriteLine($"OddMax={OddMax:f2},");
            }

            Console.WriteLine($"EvenSum={EvenSum:f2},");

            if (EvenMin == double.MaxValue && EvenMax == double.MinValue)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={EvenMin:f2},");
                Console.WriteLine($"EvenMax={EvenMax:f2}");
            }
        }
    }
}
