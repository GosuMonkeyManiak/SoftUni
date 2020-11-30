using System;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            string numText = Console.ReadLine();

            int sum = 0;

            while (numText != "Stop")
            {
                int num = int.Parse(numText);
                sum += num;
                numText = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}
