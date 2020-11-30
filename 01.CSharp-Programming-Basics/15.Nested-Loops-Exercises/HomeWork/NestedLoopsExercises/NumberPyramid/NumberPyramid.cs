using System;
using System.Runtime.InteropServices;

namespace NumberPyramid
{
    class NumberPyramid
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;
            bool isBigger = false;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }

                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
