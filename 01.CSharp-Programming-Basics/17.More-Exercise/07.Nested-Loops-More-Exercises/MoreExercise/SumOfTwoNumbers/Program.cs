namespace SumOfTwoNumbers
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationNumber = 0;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    combinationNumber++;

                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinationNumber} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinationNumber} combinations - neither equals {magicNumber}");
        }
    }
}
