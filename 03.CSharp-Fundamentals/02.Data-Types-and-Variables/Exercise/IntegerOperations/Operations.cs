using System;

namespace IntegerOperations
{
    class Operations
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            int result = first + second;
            result /= third;
            result *= fourth;

            Console.WriteLine(result);
        }
    }
}
