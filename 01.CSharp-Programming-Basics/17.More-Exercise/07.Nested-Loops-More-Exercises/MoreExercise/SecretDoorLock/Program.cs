namespace SecretDoorLock
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int hundredNumber = int.Parse(Console.ReadLine());
            int tenNumber = int.Parse(Console.ReadLine());
            int entityNumber = int.Parse(Console.ReadLine());


            for (int i = 1; i <= hundredNumber; i++)
            {
                for (int j = 1; j <= tenNumber; j++)
                {
                    for (int k = 1; k <= entityNumber; k++)
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
