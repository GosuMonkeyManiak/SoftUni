namespace PrimePairs
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int startValueFirstPair = int.Parse(Console.ReadLine());
            int startValueSecondPair = int.Parse(Console.ReadLine());

            int subtractionBetweenFirst = int.Parse(Console.ReadLine());
            int subtractionBetweenSecond = int.Parse(Console.ReadLine());

            int endValueFirstPair = startValueFirstPair + subtractionBetweenFirst;
            int endValueSecondPair = startValueSecondPair + subtractionBetweenSecond;

            for (int i = startValueFirstPair; i <= endValueFirstPair; i++)
            {
                for (int j = startValueSecondPair; j <= endValueSecondPair; j++)
                {
                    if (IsPrime(i) && IsPrime(j))
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }

        public static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n % x == 0)
                    .SequenceEqual(new[] { 1, n });
            }

            return false;
        }
    }
}
