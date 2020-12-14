using System;

namespace CharsToString
{
    class CharsToString
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            string result = first.ToString();
            result += second;
            result += third;

            Console.WriteLine(result);
        }
    }
}
