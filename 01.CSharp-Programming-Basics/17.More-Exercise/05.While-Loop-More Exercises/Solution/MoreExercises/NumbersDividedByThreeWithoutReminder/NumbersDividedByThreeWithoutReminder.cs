﻿using System;

namespace NumbersDividedByThreeWithoutReminder
{
    class NumbersDividedByThreeWithoutReminder
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
