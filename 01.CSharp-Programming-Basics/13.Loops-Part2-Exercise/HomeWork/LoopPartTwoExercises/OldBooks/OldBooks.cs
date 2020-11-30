using System;

namespace OldBooks
{
    class OldBooks
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());

            int count = 0;

            bool flag = false;

            while (count < libraryCapacity)
            {
                string newBook = Console.ReadLine();
                if (newBook == book)
                {
                    flag = true;
                    break;
                }

                count++;
            }

            if (flag == true)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {libraryCapacity} books.");
            }

        }
    }
}
