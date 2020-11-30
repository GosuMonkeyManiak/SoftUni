using System;

namespace LowerOrUpper
{
    class LowerOrUpper
    {
        static void Main(string[] args)
        {
            char someChar = char.Parse(Console.ReadLine());

            char temp = Char.ToUpper(someChar);

            if (someChar == temp)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
