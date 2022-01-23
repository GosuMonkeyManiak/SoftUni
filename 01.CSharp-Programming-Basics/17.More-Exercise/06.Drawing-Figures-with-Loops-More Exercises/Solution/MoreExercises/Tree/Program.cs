using System;

namespace ChristmasTree
{
    class ChristmasTree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                {
                    for (int k = 0; k < 1; k++)
                    {
                        Console.Write(new string(' ', n + 1));
                        Console.Write('|');
                        Console.Write(new string(' ', n + 1));
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(new string(' ', n - i));
                    Console.Write(new string('*', i));
                    Console.Write(' ');
                    Console.Write('|');
                    Console.Write(' ');
                    Console.Write(new string('*', i));
                    Console.Write(new string(' ', n - i));
                    Console.WriteLine();
                }
            }
        }
    }
}