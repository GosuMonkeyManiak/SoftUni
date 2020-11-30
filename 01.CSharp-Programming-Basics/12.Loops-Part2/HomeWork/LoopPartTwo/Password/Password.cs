using System;

namespace Password
{
    class Password
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string currentPass = Console.ReadLine();

            while (currentPass != password)
            {
                currentPass = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {name}!");
        }
    }
}
