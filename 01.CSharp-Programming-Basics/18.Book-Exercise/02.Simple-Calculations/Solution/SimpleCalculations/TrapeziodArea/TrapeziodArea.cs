﻿using System;

namespace TrapeziodArea
{
    class TrapeziodArea
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = (b1 + b2) * h / 2.0;
            Console.WriteLine("Trapezoid area = " + area);
        }
    }
}
