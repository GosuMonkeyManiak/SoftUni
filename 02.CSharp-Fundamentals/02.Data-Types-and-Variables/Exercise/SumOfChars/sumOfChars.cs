﻿using System;

namespace SumOfChars
{
    class sumOfChars
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                sum += letter;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
