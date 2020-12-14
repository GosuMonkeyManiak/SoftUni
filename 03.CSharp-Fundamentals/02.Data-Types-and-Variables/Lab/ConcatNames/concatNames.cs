using System;

namespace ConcatNames
{
    class concatNames
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string deliter = Console.ReadLine();

            Console.WriteLine($"{firstName}{deliter}{lastName}");
        }
    }
}
