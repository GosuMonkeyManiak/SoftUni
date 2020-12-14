using System;

namespace ExtractPersonInformation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int indexFirstNameSymbol = text.IndexOf('@') + 1;
                int indexLastNameSymbol = text.IndexOf('|');

                string name = text.Substring(indexFirstNameSymbol, indexLastNameSymbol - indexFirstNameSymbol);

                int indexFirstSymbolAge = text.IndexOf('#') + 1;
                int indexLastSymbolAge = text.IndexOf('*');

                string age = text.Substring(indexFirstSymbolAge, indexLastSymbolAge - indexFirstSymbolAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
