namespace SafePasswordGenerator
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPassCount = int.Parse(Console.ReadLine());

            int currentPassCount = 0;

            int symbolA = 35;
            int symbolB = 64;

            for (int k = 1; k <= a; k++)
            {
                for (int l = 1; l <= b; l++)
                {
                    if (symbolA == 56)
                    {
                        symbolA = 35;
                    }

                    if (symbolB == 97)
                    {
                        symbolB = 64;
                    }

                    Console.Write($"{(char)symbolA}{(char)symbolB}{k}{l}{(char)symbolB}{(char)symbolA}|");
                    currentPassCount++;

                    if (currentPassCount == maxPassCount)
                    {
                        return;
                    }

                    symbolA++;
                    symbolB++;
                }
            }
        }
    }
}
