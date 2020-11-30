using System;

namespace NumberInRange
{
    class NumberInRange
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > 0 && num < 100)
            {
                Console.WriteLine("Yes");
            }
            else if (num == 100)
            {
                Console.WriteLine("Yes");
            }
            else if(num < -1 && num > -100)
            {
                Console.WriteLine("Yes");
            }
            else if (num == -100)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
