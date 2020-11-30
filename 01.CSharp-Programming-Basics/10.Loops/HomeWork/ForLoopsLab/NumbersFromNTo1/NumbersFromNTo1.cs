using System;

namespace NumbersFromNTo1
{
    class NumbersFromNTo1
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = num; i >= 1; i--) 
            {
                Console.WriteLine(i);
            }
        }
    }
}
