namespace UniquePinCode
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumberLimit = int.Parse(Console.ReadLine());
            int secondNumberLimit = int.Parse(Console.ReadLine());
            int thirdNumberLimit = int.Parse(Console.ReadLine());

            for (int i = 1; i <= firstNumberLimit; i++)
            {
                for (int j = 1; j <= secondNumberLimit; j++)
                {
                    for (int k = 1; k <= thirdNumberLimit; k++)
                    {
                        if ((i % 2 == 0 && k % 2 == 0) && IsPrime(j))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
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
