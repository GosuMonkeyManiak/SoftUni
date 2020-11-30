using System;
using System.Diagnostics.CodeAnalysis;

namespace Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            int widthCake = int.Parse(Console.ReadLine());
            int lengthCake = int.Parse(Console.ReadLine());

            int cakeS = widthCake * lengthCake;
            bool isStop = false;

            while (cakeS > 0)
            {
                string cakeCount = Console.ReadLine();
                if (cakeCount == "STOP")
                {
                    isStop = true;
                    break;
                }

                int num = int.Parse(cakeCount);
                if (cakeS - num < 0)
                {
                    cakeS -= num;
                    break;
                }
                else
                {
                    cakeS -= num;
                }
            }

            if (isStop)
            {
                Console.WriteLine($"{cakeS} pieces are left.");
            }
            else if (cakeS < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeS)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakeS} pieces are left.");
            }

        }
    }
}
