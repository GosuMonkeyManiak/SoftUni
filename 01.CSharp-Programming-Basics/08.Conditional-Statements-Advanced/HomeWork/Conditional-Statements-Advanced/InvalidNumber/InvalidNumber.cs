using System;

namespace InvalidNumber
{
    class InvalidNumber
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("invalid");
            }
            else if (num == 0)
            {

            }
            else if (num < 100)
            {
                Console.WriteLine("invalid");
            }
            else if (num > 200)
            {
                Console.WriteLine("invalid");
            }
            else if (num >= 100 || num <= 200)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }

        }
    }
}
