﻿using System;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            PrintInWords(grade);
        }

        public static void PrintInWords(double grade) 
        {
            if (grade >= 2.00 & grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
