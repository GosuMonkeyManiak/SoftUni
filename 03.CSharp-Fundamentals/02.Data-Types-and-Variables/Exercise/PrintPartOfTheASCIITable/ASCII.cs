using System;

namespace PrintPartOfTheASCIITable
{
    class ASCII
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                char letter = (char)i;
                Console.Write(letter + " ");
            }
        }
    }
}
