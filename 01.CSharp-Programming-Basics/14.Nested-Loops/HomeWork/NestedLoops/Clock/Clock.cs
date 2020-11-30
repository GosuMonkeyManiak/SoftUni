using System;

namespace Clock
{
    class Clock
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int k = 0; k < 60; k++)
                {
                    Console.WriteLine($"{i}:{k}");
                }
            }
        }
    }
}
